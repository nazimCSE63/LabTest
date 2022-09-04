using FirstDemo.Web.AdoNetCodes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FirstDemo.Web.Models
{
    public class TestModel
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public IList<IDictionary<string, object>> Courses { get; set; }
        public DataSet Data { get; set; }

        public TestModel()
        {

        }
        internal void DoSomething()
        {
            throw new NotImplementedException();
        }

        internal void InsertData(string connectionString)
        {
            var title = "Advance TypeScript";
            var fees = 4000;
            var isActive = true;
            var registrationEnd = new DateTime(2023, 3, 3);

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("@title", title);
            data.Add("@fees", fees);
            data.Add("@isActive", isActive);
            data.Add("@registrationEnd", registrationEnd);

            var command = "insert into Courses (Title, Fees, IsActive, RegistrationEndDate) values(@title, @fees, @isActive, @registrationEnd)";
            //var command = "update Courses set Fees=50000 where Fees =8000";
            //var command = "delete from Courses where Fees =28";
            var dataUtility = new DataUtility(connectionString);
            dataUtility.ExecuteCommand(command, data);
        }

        internal void GetData(string connectionString)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("@isActive", true);

            //var command = @"select Title, Fees from courses where isActive = @isActive";
            var command = @"select * from courses where isActive = @isActive";
            var dataUtility = new DataUtility(connectionString);
            Courses = dataUtility.GetData(command, data);
        }

        internal void GetDataUsingDataSet(string connectionString)
        {
            var dataUtility = new DataUtility(connectionString);
            Data = dataUtility.UseDataSet();
        }
    }
}
