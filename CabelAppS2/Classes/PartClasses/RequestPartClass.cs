using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabelAppS2.Model
{
    public partial class Request
    {
        public string GetColor
        {
            get
            {
                string color = "White";
                if(ServiceId == 1)
                {
                    color = "#00D5FF";
                }
                else if(ServiceId == 2)
                {
                    color = "#00FF80 ";
                } 
                else if(ServiceId == 3)
                {
                    color = "#FFF700 ";
                }
                else if(ServiceId == 4)
                {
                    color = "#C400FF";
                }

                if(ServiceStatusId == 3)
                {
                    color = "#D7D3D8 ";
                }

                return color;
            }
        }

        public string GetClientNumber
        {
            get
            {
                string number = Contract.Client.Number;
                return number;
            }
        }
    }
}
