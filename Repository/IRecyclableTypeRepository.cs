using SDS_Technical_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS_Technical_Exam.Repository
{
    public interface IRecyclableTypeRepository
    {
        Task<List<RecyclableType>> GetAll();
        Task<RecyclableType> GetById(int Id);
        Task<RecyclableType> GetByType(string type);
        Task CreateUpdate(int? Id, RecyclableType recyclableType);
        Task Delete(int Id);
    }
}
