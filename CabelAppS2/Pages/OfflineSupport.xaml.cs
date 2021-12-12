using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CabelAppS2.Model;
using Microsoft.Win32;

namespace CabelAppS2.Pages
{
    /// <summary>
    /// Логика взаимодействия для OfflineSupport.xaml
    /// </summary>
    public partial class OfflineSupport : Page
    {
        private Request curRequest { get; set; }
        public OfflineSupport(Request request)
        {
            InitializeComponent();
            UserGrid.DataContext = request;
            Timesheet.ItemsSource = Context._con.EmployeeRequest.Where(p => p.RequestId == request.Id)
                                                                .ToList();
            EmployeeList.ItemsSource = Context._con.Employee.ToList();
            curRequest = request;
        }

        private void EmployeeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(EmployeeList.SelectedItem is Employee employee)
            {
                var order = new EmployeeRequest();
                order.EmployeeId = employee.Id;
                order.RequestId = curRequest.Id;
                var x = Context._con.EmployeeRequest.Where(p => p.RequestId == order.RequestId)
                                                    .OrderByDescending(p => p.Id)
                                                    .FirstOrDefault();
                if(x == null)
                {
                    order.StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0);
                    order.EndDate = order.StartDate.AddMinutes(30);
                }
                else
                {
                    order.StartDate = x.StartDate.AddHours(1);
                    order.EndDate = x.EndDate.AddHours(1);
                }

                Context._con.EmployeeRequest.Add(order);
                Context._con.SaveChanges();
                Timesheet.ItemsSource = Context._con.EmployeeRequest.Where(p => p.RequestId == curRequest.Id)
                                                                    .ToList();
            }
        }

        private void PrintToCsv(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Requests.csv";
            saveFileDialog.Filter = ".csv | *.csv";
            var x = Context._con.EmployeeRequest.Where(p => p.RequestId == curRequest.Id)
                                                .ToList()
                                                .Select(p => $"{p.Request.Number} {p.Employee.GetName} {p.StartDate} - {p.EndDate} | Клиент: {p.Request.Contract.Client.GetName}")
                                                .ToList();
            if ((bool)saveFileDialog.ShowDialog())
            {
                File.WriteAllLines(saveFileDialog.FileName, x, Encoding.Default);
            }
        }
    }
}
