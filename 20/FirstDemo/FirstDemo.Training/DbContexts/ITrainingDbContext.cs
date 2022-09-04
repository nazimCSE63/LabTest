using FirstDemo.Training.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstDemo.Training.DbContexts
{
    public interface ITrainingDbContext
    {
        DbSet<Course> Courses { get; set; }
    }
}