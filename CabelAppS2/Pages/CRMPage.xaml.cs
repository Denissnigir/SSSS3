using CabelAppS2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Windows.Threading;

namespace CabelAppS2.Pages
{
    /// <summary>
    /// Логика взаимодействия для CRMPage.xaml
    /// </summary>
    public partial class CRMPage : Page
    {
        Request request;
        public static readonly HttpClient httpClient = new HttpClient();
        public CRMPage()
        {
            InitializeComponent();
            PhoneCB.ItemsSource = Context._con.Client.ToList();
            SecondNameCB.ItemsSource = Context._con.Client.ToList();
            ServiceCB.ItemsSource = Context._con.Service.ToList();
            ServiceVariationCB.ItemsSource = Context._con.ServiceVariation.ToList();
            ServiceTypeCB.ItemsSource = Context._con.ServiceType.ToList();
            StatusCB.ItemsSource = Context._con.ServiceStatus.ToList();
            ProblemTypeCB.ItemsSource = Context._con.ProblemType.ToList();
            StatusCB.SelectedIndex = 0;
           

        }


        private void PhoneCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(PhoneCB.SelectedItem is Client client)
            {
                SecondNameCB.SelectedItem = client;
            }

            if(SecondNameCB.SelectedItem is Client client1)
            {
                PhoneCB.SelectedItem = client1;
            }
        }

        private void SearchClient(object sender, RoutedEventArgs e)
        {
            ClientGrid.DataContext = PhoneCB.SelectedItem as Client;
            RequestGrid.Visibility = Visibility.Visible;
            ButtonGrid.Visibility = Visibility.Visible;
        }

        private void CreateRequest(object sender, RoutedEventArgs e)
        {
            Request request = new Request();
            request.Number = RequestNumberTB.Text;
            request.StartDate = DateTime.Now;
            request.ContractId = (PhoneCB.SelectedItem as Client).Contract.FirstOrDefault().Id;
            request.ServiceId = (ServiceCB.SelectedItem as Service).Id;
            request.ServiceVariationId = (ServiceVariationCB.SelectedItem as ServiceVariation).Id;
            request.ServiceTypeId = (ServiceTypeCB.SelectedItem as ServiceType).Id;
            request.ServiceStatusId = (ServiceTypeCB.SelectedItem as ServiceType).Id;
            request.ServiceType = "IP";
            request.ProblemDescription = DescriptionTB.Text;
            request.ProblemTypeId = (ProblemTypeCB.SelectedItem as ProblemType).Id;
            Context._con.Request.Add(request);
            Context._con.SaveChanges();
            MessageBox.Show("Заявка успешно добавлена!");
        }

        private async void CheckEquipment(object sender, RoutedEventArgs e)
        {
            string xy = (PhoneCB.SelectedItem as Client).GetSerial;
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:62727/api/equipment/state/?serialNumber={xy}");
            var x = await httpResponseMessage.Content.ReadAsStringAsync();
            var y = JsonConvert.DeserializeObject<int>(x);
            if(y == 1)
            {
                StatusCB.SelectedIndex = 2;
                MessageBox.Show("Оборудование исправно!");
                DateOfEndTB.Text = DateTime.Now.ToString();
            }  
            else if(y == 0)
            {
                StatusCB.SelectedIndex = 1;
                MessageBox.Show("Требуется выезд");
                DateOfEndTB.Text = "";
            }
        }
    }
}
