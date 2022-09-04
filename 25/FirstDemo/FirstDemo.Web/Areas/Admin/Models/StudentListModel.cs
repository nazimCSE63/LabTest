using FirstDemo.Training.Services;
using FirstDemo.Web.Models;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class StudentListModel
    {
        private readonly IStudentService _studentService;

        public StudentListModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public object GetPagedStudents(DataTablesAjaxRequestModel model)
        {
            var data = _studentService.GetStudents(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "Name", "Fee" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string?[]
                        {
                                record.Name,
                                record.CGPA.ToString(),
                                record.Address,
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }
    }
}
