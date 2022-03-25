using Student.Repository;
using Student.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentViewModel> CreateStudent(StudentViewModel studentViewModel)
        {
            Model.Student student = new Model.Student
            {
                FirstName = studentViewModel.FirstName,
                LastName = studentViewModel.LastName
            };

            student = await _studentRepository.AddStudentAsync(student);
            studentViewModel.Id = student.Id;

            return studentViewModel;
        }

        public async Task<StudentViewModel> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Id = student.Id;
            studentViewModel.FirstName = student.FirstName;
            studentViewModel.LastName = student.LastName;

            return studentViewModel;
        }

        public async Task<IList<StudentViewModel>> GetStudentList()
        {
            var studentList = await _studentRepository.GetStudentListAsync();

            List<StudentViewModel> list = new List<StudentViewModel>();

            foreach (var student in studentList)
            {
                StudentViewModel studentViewModel = new StudentViewModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                };

                list.Add(studentViewModel);
            }

            return list;
        }
    }
}
