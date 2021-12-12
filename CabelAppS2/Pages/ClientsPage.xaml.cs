using CabelAppS2.Model;
using CabelAppS2.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CabelAppS2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        List<Client> clients = new List<Client>();
        List<Event> events = new List<Event>();
        public ClientsPage()
        {
            InitializeComponent();
            StreetCB.ItemsSource = Context._con.Client.ToList();
            if(UserWindow.curEmployee == null)
            {
                UserWindow.curEmployee = Context._con.Employee.Where(p => p.RoleId == 1).FirstOrDefault();
            }
            Filter();
        }


        private void SecondNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        public void Filter()
        {
            clients = Context._con.Client.ToList();

            if (!string.IsNullOrWhiteSpace(SecondNameTB.Text))
            {
                clients = clients.Where(p => p.SecondName.Contains(SecondNameTB.Text))
                                 .ToList();
            }

            ClientDG.ItemsSource = clients;

            if (!string.IsNullOrWhiteSpace(BillTB.Text))
            {
                clients = clients.Where(p => p.GetBill.Contains(BillTB.Text))
                                 .ToList();
            }

            ClientDG.ItemsSource = clients;

            if (!string.IsNullOrWhiteSpace(DistrictTB.Text))
            {
                clients = clients.Where(p => p.Address.District.Name.Contains(DistrictTB.Text))
                                 .ToList();
            }

            ClientDG.ItemsSource = clients;

            if(StreetCB.SelectedItem is Client client)
            {
                clients = clients.Where(p => p.GetAddress == client.GetAddress)
                                 .ToList();
            }

            ClientDG.ItemsSource = clients;

            if ((bool)ActiveCB.IsChecked)
            {
                clients = clients.Where(p => p.Contract.FirstOrDefault().DateOfEnd == null)
                                 .ToList();
            }

            ClientDG.ItemsSource = clients;


            if ((bool)UnactiveCB.IsChecked)
            {
                clients = clients.Where(p => p.Contract.FirstOrDefault().DateOfEnd != null)
                                 .ToList();
            }

            ClientDG.ItemsSource = clients;


            if((bool)ActiveCB.IsChecked && (bool)UnactiveCB.IsChecked)
            {
                clients = Context._con.Client.ToList();
            }

            ClientDG.ItemsSource = clients;

            try
            {
                events = Context._con.Event.ToList()
                                       .Where(p => p?.EmployeeEvent?.FirstOrDefault()?.EmployeeId == UserWindow.curEmployee?.Id)?
                                       .ToList();
            }
            catch
            {

            }

            EventLB.ItemsSource = events;

        }

        private void StreetCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void ActiveCB_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void ToClientFullInfo(object sender, MouseButtonEventArgs e)
        {
            if(ClientDG.SelectedItem is Client client)
            {
                ClientInfoWindow clientInfoWindow = new ClientInfoWindow(client);
                clientInfoWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите клиента!");
            }
        }
    }
}
