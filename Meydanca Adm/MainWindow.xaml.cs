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

        //Defining the working hours for stadiums
        TimeSpan StartTime = new TimeSpan(8, 0, 0);
        TimeSpan EndTime = new TimeSpan(1, 0, 0);

        public MainWindow()
        {
            InitializeComponent();
            FillHours();
        }

        #region registration

   
        //Function to fill hours
        private void FillHours()
        {
       
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

            foreach (Stadium stadium in db.Stadiums.ToList())
            {
                cmbStadiums.Items.Add(stadium.name);
            }

            Stadium stad = db.Stadiums.FirstOrDefault(s => s.name == cmbStadiums.Text);


            DateTime BookingDate = dtpDate.SelectedDate.Value;

            int count = db.Bookings.Where(b => b.Date == BookingDate.Date && b.Time == StartTime && b.StadiumId == stad.Id).Count();

            MessageBox.Show(count.ToString());

            
        }


        #endregion

        private void dtpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FillStadiumList();
        }

        private void CmbHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillStadiumList();
        }
    }
}
