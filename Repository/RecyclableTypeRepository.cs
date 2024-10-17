using Domain;
using SDS_Technical_Exam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;

namespace SDS_Technical_Exam.Repository
{
    public class RecyclableTypeRepository: IRecyclableTypeRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public RecyclableTypeRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RecyclableType>> GetAll()
        {
            var allRecyclableType = await _dbContext.RecyclableType.AsNoTracking()
                .ToListAsync();

            return allRecyclableType;
        }

        public async Task<RecyclableType> GetById(int Id)
        {
            var recyclableType = await _dbContext.RecyclableType.AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == Id);

            return recyclableType;
        }

        public async Task<RecyclableType> GetByType(string type)
        {
            var recyclableType = await _dbContext.RecyclableType.AsNoTracking()
                .FirstOrDefaultAsync(a => a.Type.ToLower() == type.ToLower());

            return recyclableType;
        }

        public async Task CreateUpdate(int? Id, RecyclableType recyclableType)
        {
            if(Id == null)
            {
                _dbContext.RecyclableType.Add(recyclableType);
                 await _dbContext.SaveChangesAsync();
            }
            else
            {
                var originalrecyclableType = await _dbContext.RecyclableType
                    .FirstOrDefaultAsync(a => a.Id == Id);

                originalrecyclableType.Type = recyclableType.Type;
                originalrecyclableType.Rate = recyclableType.Rate;
                originalrecyclableType.MaxKg = recyclableType.MaxKg;
                originalrecyclableType.MinKg = recyclableType.MinKg;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(int Id)
        {
            var recyclableType = await _dbContext.RecyclableType
                .FirstOrDefaultAsync(a => a.Id == Id);

            _dbContext.RecyclableType.Remove(recyclableType);
            await _dbContext.SaveChangesAsync();
        }
    }
}