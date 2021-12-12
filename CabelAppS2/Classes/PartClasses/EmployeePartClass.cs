using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabelAppS2.Model
{
    public partial class Employee
    {
        public string GetEmployee
        {
            get
            {
                string name = $"{SecondName} {FirstName} - {Role.Name}";
                return name;
            }
        }

        public string GetName
        {
            get
            {
                string name = $"{SecondName} {FirstName} {MiddleName}";
                return name;
            }
        }

        public string GetColor
        {
            get
            {
                string color = "#20D9EE";
                var x = Context._con.Timesheet.ToList().Where(p => p.EmployeeId == Id && p.StartDate == DateTime.Now.Date).FirstOrDefault();

                var y = Context._con.EmployeeRequest.ToList().Where(p => p.EmployeeId == Id).ToList().Count();
                if(y >= 1)
                {
                    color = "#20EE49";
                }

                if(x != null)
                {
                    color = "#D7D3D8";
                }
                return color;
            }
        }
    }
}
