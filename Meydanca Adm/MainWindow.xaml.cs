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
            FillStadiumList();
        }

        #region registration

        //Function to add stadiums from db to the list
        private void FillStadiumList()
        {
            foreach (Stadium stadium in db.Stadiums.ToList())
            {
                cmbStadiums.Items.Add(stadium.name);
            }
        }

        //Function to see the available hours for games
        private void FillAvailableStadiums()
        {
            if (string.IsNullOrEmpty(dtpDate.Text))
            {
                MessageBox.Show("Zəhmət olmasa tarix seçin");
                return;
            }

            TimeSpan StartTime = new TimeSpan(8, 0, 0);
            TimeSpan EndTime = new TimeSpan(1, 0, 0);

            int interval = (int)(EndTime.Subtract(StartTime).TotalHours + 24);

            for (int i = 0; i < interval; i++)
            {
                CmbHours.Items.Add(StartTime.ToString(@"hh\:mm"));
                StartTime = StartTime.Add(new TimeSpan(1, 0, 0));

                if (StartTime.Hours == 0)
                {
                    StartTime = new TimeSpan(0, 0, 0);
                }
            }

        }

        //Available stadiums should change based on selected date
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FillAvailableStadiums();
        }
        //Available stadiums should change based on selected hour
        private void CmbHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillAvailableStadiums();
        }


        #endregion

        
    }
}
