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
        private void FillAvailableHours()
        {

        }

        //Available hours should change based on selected stadium
        private void cmbStadiums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillAvailableHours();
        }

        //Available hours should change based on selected date
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FillAvailableHours();
        }

        #endregion


    }
}
