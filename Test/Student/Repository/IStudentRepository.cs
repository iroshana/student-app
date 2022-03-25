using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Repository
{
    public interface IStudentRepository
    {
        Task<Model.Student> GetStudentByIdAsync(int id);
        Task<Model.Student> AddStudentAsync(Model.Student student);
        Task<IList<Model.Student>> GetStudentListAsync();
    }
}
