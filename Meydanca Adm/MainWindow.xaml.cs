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
using Meydanca_Adm.Models;


namespace Meydanca_Adm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AdmEntities db = new AdmEntities();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        #region registration

        //Calling functions when the data in date and hours change
        private void dtpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FillStadiumList();
            FillHours();
        }

        private void CmbHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillStadiumList();
        }


        private void cmbStadiums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CmbUsers.Text = "";
            if (!string.IsNullOrEmpty(CmbHours.Text))
            {
                FillContacts();

            }
        }

        //Function to fill hours
        private void FillHours()
        {

            CmbHours.Items.Clear();


            //Defining the working hours for stadiums
            TimeSpan StartTime = new TimeSpan(8, 0, 0);
            TimeSpan EndTime = new TimeSpan(1, 0, 0);

            int interval = (int)(EndTime.Subtract(StartTime).TotalHours + 24);

            for (int i = 0; i < interval; i++)
            {
                CmbHours.Items.Add(StartTime.ToString(@"hh\:mm"));

                StartTime = StartTime.Add(new TimeSpan(1, 0, 0));
               
                //Hours should show 00:00 when it is 24:00
                if (StartTime.Hours == 0)
                {
                    StartTime = new TimeSpan(0, 0, 0);
                }
  
            }

        }

        //Function to add stadiums from db to the list 
        private void FillStadiumList()
        {
            cmbStadiums.Items.Clear();

            //lblUser.Visibility = Visibility.Hidden;
            //CmbUsers.Visibility = Visibility.Hidden;
            CmbUsers.Items.Clear();

            cmbStadiums.Text = "";
            CmbHours.Text = "";
            CmbUsers.Text = "";


            DateTime BookingDate = dtpDate.SelectedDate.Value;
            if (CmbHours.SelectedItem != null)
            {
                string hour = CmbHours.SelectedItem.ToString();
                TimeSpan time = TimeSpan.Parse(hour);

                foreach (Stadium stadium in db.Stadiums.Where(s => s.Bookings.Where(b => b.Date == BookingDate && b.Time == time).Count() == 0).ToList())
                {
                    cmbStadiums.Items.Add(stadium.name);
                }
            }
            
        }

        //Function to add contact
        private void FillContacts()
        {
            foreach (Contact cnt in db.Contacts.OrderBy(c => c.Name).OrderBy(c => c.Surname).ToList())
            {
                CmbUsers.Items.Add(cnt.Name + " " + cnt.Surname + " " + cnt.Phone);
            }
            
        }

        #endregion

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
        }
    }
}
