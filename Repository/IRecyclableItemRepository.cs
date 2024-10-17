using SDS_Technical_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS_Technical_Exam.Repository
{
    public interface IRecyclableItemRepository
    {
        Task<List<RecyclableItem>> GetAll();
        Task<RecyclableItem> GetById(int Id);
        Task CreateUpdate(int? Id, RecyclableItem recyclableType);
        Task Delete(int Id);
    }
}
