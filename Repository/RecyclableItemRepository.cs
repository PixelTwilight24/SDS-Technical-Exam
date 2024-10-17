using Domain;
using SDS_Technical_Exam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SDS_Technical_Exam.Repository
{
    public class RecyclableItemRepository: IRecyclableItemRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public RecyclableItemRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RecyclableItem>> GetAll()
        {
            var allRecyclableItem = await _dbContext.RecyclableItem.AsNoTracking()
                .ToListAsync();

            return allRecyclableItem;
        }

        public async Task<RecyclableItem> GetById(int Id)
        {
            var recyclableItem = await _dbContext.RecyclableItem.AsNoTracking()
                .Include(x => x.RecyclableType)
                .FirstOrDefaultAsync(a => a.Id == Id);

            return recyclableItem;
        }

        public async Task CreateUpdate(int? Id, RecyclableItem recyclableItem)
        {
            if (Id == null)
            {
                _dbContext.RecyclableItem.Add(recyclableItem);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                var originalRecyclableItem = await _dbContext.RecyclableItem
                    .FirstOrDefaultAsync(a => a.Id == Id);

                originalRecyclableItem.ItemDescription = recyclableItem.ItemDescription;
                originalRecyclableItem.Weight = recyclableItem.Weight;
                originalRecyclableItem.ComputedRate = recyclableItem.ComputedRate;
                originalRecyclableItem.RecyclableTypeId = recyclableItem.RecyclableTypeId;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(int Id)
        {
            var recyclableItem = await _dbContext.RecyclableItem
                .FirstOrDefaultAsync(a => a.Id == Id);

            _dbContext.RecyclableItem.Remove(recyclableItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}