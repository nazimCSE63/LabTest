using FirstDemo.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Training.Services
{
    public interface IStudentService
    {
        void CreateStudent(Student student);
        void DeleteStudent(int id);
        void EditStudent(Student student);
        Student GetStudent(int id);
        (int total, int totalDisplay, IList<Student> records) GetStudents(int pageIndex,
            int pageSize, string searchText, string orderBy);
        IList<Student> GetStudents();
    }
}
