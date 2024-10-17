using SDS_Technical_Exam.Models;
using SDS_Technical_Exam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SDS_Technical_Exam.Controllers
{
    public class RecyclableTypeController : Controller
    {
        private IRecyclableTypeRepository _recyclableTypeRepository;

        public RecyclableTypeController(
            IRecyclableTypeRepository recyclableTypeRepository)
        {
            _recyclableTypeRepository = recyclableTypeRepository;
        }

        public async Task<ActionResult> List()
        {
            var list = await _recyclableTypeRepository.GetAll();
            return View(list);
        }

        public ActionResult Add()
        {
            return View(new RecyclableType());
        }
        public async Task<ActionResult> Edit(int Id)
        {
            var recyclableType = await _recyclableTypeRepository.GetById(Id);
            return View(recyclableType);
        }

        public async Task<ActionResult> CreateEditForm(int? Id, RecyclableType recyclableType)
        {

            var existingType = await _recyclableTypeRepository.GetByType(recyclableType.Type);

            // Check if type already exist
            if ( existingType != null && existingType.Id != recyclableType.Id)
            {
                ModelState.AddModelError("Type", "A recyclable type with the same name already exists.");
                return View("Add", recyclableType);
            }

            await _recyclableTypeRepository.CreateUpdate(Id, recyclableType);
            
            return RedirectToAction("List");
        }

        public async Task<ActionResult> Delete(int Id)
        {
            var recyclableType = await _recyclableTypeRepository.GetById(Id);
            return View(recyclableType);
        }
        public async Task<ActionResult> DeletePost(int Id)
        {
            await _recyclableTypeRepository.Delete(Id);
            return RedirectToAction("List");
        }
    }
}