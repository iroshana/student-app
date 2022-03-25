using Student.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Services
{
    public interface IStudentService
    {
        Task<StudentViewModel> GetStudentById(int id);
        Task<StudentViewModel> CreateStudent(StudentViewModel studentViewModel);
        Task<IList<StudentViewModel>> GetStudentList();
    }
}
