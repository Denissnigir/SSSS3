using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabelAppS2.Model
{
    public partial class Client
    {
        public string GetName
        {
            get
            {
                string name = $"{SecondName} {FirstName} {MiddleName}";
                return name;
            }
        }

        public string GetBill
        {
            get
            {
                string bill = Contract.FirstOrDefault().Bill;
                return bill;
            }
        }

        public string GetServices
        {
            get
            {
                string services = string.Empty;
                foreach(var service in Contract.FirstOrDefault().ContractService.Where(p => p.ContractId == Contract.FirstOrDefault().Id).ToList())
                {
                    if (!string.IsNullOrWhiteSpace(services))
                    {
                        services += ", ";
                    }

                    services += service.Service.Name;
                }

                return services;
            }
        }

        public string GetAddress
        {
            get
            {
                var x = AddressInPassport.Split(',');
                string address = $"{x[2]} {x[3]}";
                return address;
            }
        }

        public string GetPassport
        {
            get
            {
                var passport = $"{PassportSerial} {PassportNumber}";
                return passport;
            }
        }

        public string GetPassportInfo
        {
            get
            {
                var passport = $"{PassportDate.Day}.{PassportDate.Month}.{PassportDate.Year} {PassportOrgName}";
                return passport;
            }
        }

        public string GetContract
        {
            get
            {
                var number = Contract.FirstOrDefault().Number;
                return number;
            }
        }

        public string GetContractDateType
        {
            get
            {
                string contract = $"{Contract.FirstOrDefault().StartDate} {Contract.FirstOrDefault().ContractType.Name}";
                return contract;
            }
        }

        public string GetContactEnd
        {
            get
            {
                string huita = "Не расторгнут!";

                if (Contract.FirstOrDefault().DateOfEnd != null)
                {
                    huita = $"{Contract.FirstOrDefault().DateOfEnd} {Contract.FirstOrDefault().ReasonOfEnd}";
                }

                return huita;
            }
        }

        public string GetEquipment
        {
            get
            {
                string equip = Contract.FirstOrDefault().Equipment.Name;
                return equip;
            }
        }

        public string GetRent
        {
            get
            {
                string huita = "Нет аренды";
                var rent = Context._con.Rent.ToList().Where(p => p.ContractId == Contract.FirstOrDefault().Id).FirstOrDefault();
                if(rent != null)
                {
                    huita = $"{rent.Contract.Number} {rent.ExpireDate}";
                }
                return huita;
            }
        }

        public string GetSupport
        {
            get
            {
                string supp = "Нет обращений";
                return supp;
            }
        }

        public string GetRequestNumber
        {
            get
            {
                string number = $"{Contract.FirstOrDefault().Bill}/{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
                return number;
            }
        }

        public string Getinfo
        {
            get
            {
                string info = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year} {Number} {Contract.FirstOrDefault().Bill}";
                return info;
            }
        }

        public string GetSerial
        {
            get
            {
                string serial = Contract.FirstOrDefault().Equipment.SerialNumber;
                return serial;
            }
        }

    }
}
