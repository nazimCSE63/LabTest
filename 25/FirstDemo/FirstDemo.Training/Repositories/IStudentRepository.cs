using FirstDemo.Data;
using FirstDemo.Training.Entities;

namespace FirstDemo.Training.Repositories
{
    public interface IStudentRepository : IRepository<Student, int>
    {
    }
}