using CabelAppS2.Model;
using CabelAppS2.Pages;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CabelAppS2.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public static Employee curEmployee { get; set; }

        public UserWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ClientsPage());
            RoleCB.ItemsSource = Context._con.Employee.ToList();
        }

        private void CloseOpenMenu(object sender, RoutedEventArgs e)
        {
            if(Schlop.Width == 150)
            {
                Schlop.Width = 50;
            }
            else
            {
                Schlop.Width = 150;
            }
        }

        private void ToClients(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientsPage());
            HeaderTB.Text = "Абоненты ТНС";
        }

        public void GetAccess()
        {
            if(RoleCB.SelectedItem is Employee employee)
            {
                if(employee.RoleId == 1)
                {
                    SupportGrid.Visibility = Visibility.Collapsed;
                    ManageEquipGrid.Visibility = Visibility.Collapsed;
                    ActiveGrid.Visibility = Visibility.Collapsed;
                    BillGrid.Visibility = Visibility.Visible;
                    CRMGrid.Visibility = Visibility.Visible;
                }
                else if (employee.RoleId == 2)
                {
                    SupportGrid.Visibility = Visibility.Collapsed;
                    ManageEquipGrid.Visibility = Visibility.Collapsed;
                    ActiveGrid.Visibility = Visibility.Collapsed;
                    BillGrid.Visibility = Visibility.Collapsed;
                    CRMGrid.Visibility = Visibility.Visible;
                }
                else if(employee.RoleId == 3)
                {
                    SupportGrid.Visibility = Visibility.Visible;
                    ManageEquipGrid.Visibility = Visibility.Visible;
                    ActiveGrid.Visibility = Visibility.Collapsed;
                    BillGrid.Visibility = Visibility.Collapsed;
                    CRMGrid.Visibility = Visibility.Visible;
                }
                else if(employee.RoleId == 4)
                {
                    CRMGrid.Visibility = Visibility.Visible;
                    SupportGrid.Visibility = Visibility.Visible;
                    ManageEquipGrid.Visibility = Visibility.Visible;
                    ActiveGrid.Visibility = Visibility.Collapsed;
                    BillGrid.Visibility = Visibility.Collapsed;
                }
                else if(employee.RoleId == 5)
                {
                    CRMGrid.Visibility = Visibility.Collapsed;
                    SupportGrid.Visibility = Visibility.Collapsed;
                    ManageEquipGrid.Visibility = Visibility.Collapsed;
                    ActiveGrid.Visibility = Visibility.Visible;
                    BillGrid.Visibility = Visibility.Visible;
                } 
                else if(employee.RoleId == 6)
                {
                    CRMGrid.Visibility = Visibility.Visible;
                    SupportGrid.Visibility = Visibility.Visible;
                    ManageEquipGrid.Visibility = Visibility.Visible;
                    ActiveGrid.Visibility = Visibility.Visible;
                    BillGrid.Visibility = Visibility.Visible;
                } 
                else if(employee.RoleId == 7)
                {
                    CRMGrid.Visibility = Visibility.Visible;
                    SupportGrid.Visibility = Visibility.Collapsed;
                    ManageEquipGrid.Visibility = Visibility.Visible;
                    ActiveGrid.Visibility = Visibility.Visible;
                    BillGrid.Visibility = Visibility.Collapsed;
                }

                curEmployee = employee;
                UserGrid.DataContext = curEmployee;
                MainFrame.Navigate(new ClientsPage());
            }
        }

        private void RoleCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetAccess();
        }

        private void ToManageEquipment(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManageEquipmentPage());
            HeaderTB.Text = "Управление оборудованием";
        }

        private void ToActive(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ActivePage());
            HeaderTB.Text = "Активы";
        }

        private void ToBilling(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BillingPage());
            HeaderTB.Text = "Биллинг";
        }

        private void ToSupport(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserSupportPage());
            HeaderTB.Text = "Поддержка пользователей";
        }

        private void ToCrm(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CRMPage());
            HeaderTB.Text = "CRM";
        }
    }
}
