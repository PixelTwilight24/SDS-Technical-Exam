using SDS_Technical_Exam.Models;
using SDS_Technical_Exam.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SDS_Technical_Exam.Controllers
{
    public class RecyclableItemController : Controller
    {
        private IRecyclableItemRepository _recyclableItemRepository;
        private IRecyclableTypeRepository _recyclableTypeRepository;

        public RecyclableItemController(
            IRecyclableItemRepository recyclableItemRepository, 
            IRecyclableTypeRepository recyclableTypeRepository)
        {
            _recyclableItemRepository = recyclableItemRepository;
            _recyclableTypeRepository = recyclableTypeRepository;
        }

        public async Task<ActionResult> List()
        {
            var typeList = await _recyclableTypeRepository.GetAll();
            var list = await _recyclableItemRepository.GetAll();

            ViewBag.RecyclableTypes = typeList;
            return View(list);
        }

        public async Task<ActionResult> Add()
        {
            var typeList = await _recyclableTypeRepository.GetAll();

            ViewBag.RecyclableTypes = typeList;
            return View(new RecyclableItem());
        }
        public async Task<ActionResult> Edit(int Id)
        {
            var recyclableItem = await _recyclableItemRepository.GetById(Id);
            var typeList = await _recyclableTypeRepository.GetAll();

            ViewBag.RecyclableTypes = typeList;
            return View(recyclableItem);
        }

        public async Task<ActionResult> CreateEditForm(int? Id, RecyclableItem recyclableItem)
        {

            // Get the type
            var type = await _recyclableTypeRepository.GetById(recyclableItem.RecyclableTypeId);

            // Check if weight match the requirement per type
            if (recyclableItem.Weight < type.MinKg || recyclableItem.Weight > type.MaxKg)
            {
                ModelState.AddModelError("Weight", $"The weight should be between {type.MinKg} and {type.MaxKg}");
                var typeList = await _recyclableTypeRepository.GetAll();

                ViewBag.RecyclableTypes = typeList;
                return View("Add", recyclableItem);
            }

            await _recyclableItemRepository.CreateUpdate(Id, recyclableItem);
            
            return RedirectToAction("List");
        }

        public async Task<ActionResult> Delete(int Id)
        {
            var recyclableType = await _recyclableItemRepository.GetById(Id);
            return View(recyclableType);
        }
        public async Task<ActionResult> DeletePost(int Id)
        {

            await _recyclableItemRepository.Delete(Id);
            return RedirectToAction("List");
        }
    }
}