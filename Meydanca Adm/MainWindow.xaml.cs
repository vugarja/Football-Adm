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

            CmbHours.Visibility = Visibility.Hidden;
            lblHours.Visibility = Visibility.Hidden;
            cmbStadiums.Visibility = Visibility.Hidden;
            lblStadium.Visibility = Visibility.Hidden;
            btnStadium.Visibility = Visibility.Hidden;
            lblUser.Visibility = Visibility.Hidden;
            CmbUsers.Visibility = Visibility.Hidden;
            btnUser.Visibility = Visibility.Hidden;
            btnComplete.Visibility = Visibility.Hidden;

        }

        #region registration

        //Calling functions when the data in date and hours change
        private void dtpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            FillHours();
            FillContacts();

            CmbHours.Visibility = Visibility.Visible;
            lblHours.Visibility = Visibility.Visible;
            cmbStadiums.Visibility = Visibility.Hidden;
            lblStadium.Visibility = Visibility.Hidden;


        }

        private void CmbHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillStadiumList();
            FillContacts();
            cmbStadiums.Visibility = Visibility.Visible;
            lblStadium.Visibility = Visibility.Visible;
            btnStadium.Visibility = Visibility.Visible;
        }


        private void cmbStadiums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblUser.Visibility = Visibility.Visible;
            CmbUsers.Visibility = Visibility.Visible;
            btnUser.Visibility = Visibility.Visible;

            
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

            lblStadium.Visibility = Visibility.Visible;
            cmbStadiums.Visibility=Visibility.Visible;
        }

        //Function to add stadiums from db to the list 
        private void FillStadiumList()
        {
            cmbStadiums.Items.Clear();

        
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
            CmbUsers.Items.Clear();
            foreach (Contact cnt in db.Contacts.OrderBy(c => c.Name).OrderBy(c => c.Surname).ToList())
            {
                CmbUsers.Items.Add(cnt.Name + " " + cnt.Surname + " " + cnt.Phone);
            }
            
        }

        //Adding new user to contacts list
        public void AddUser(int id)
        {
            FillContacts();

        }

        // Button to add a new  user
        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser(this);
            addUser.ShowDialog();
        }



        #endregion

        private void CmbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnComplete.Visibility = Visibility.Visible;
        }
    }
}
