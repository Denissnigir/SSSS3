using CabelAppS2.Model;
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
    /// Логика взаимодействия для UserSupportPage.xaml
    /// </summary>
    public partial class UserSupportPage : Page
    {

        public UserSupportPage()
        {
            InitializeComponent();
            RequestList.ItemsSource = Context._con.Request.ToList()
                                                          .Where(p => p.StartDate >= DateTime.Now.AddHours(-240) && p.StartDate <= DateTime.Now.AddHours(240));
        }

        private void RequestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(RequestList.SelectedItem is Request request)
            {
                FullInfoGrid.DataContext = request;
            }
        }

        private void RequestList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(RequestList.SelectedItem is Request request && request.ServiceStatusId == 2)
            {
                NavigationService.Navigate(new OfflineSupport(request));
            }
            else
            {
                MessageBox.Show("Заявка не выбрана, или не требует выезда!");
            }
        }
    }
}
