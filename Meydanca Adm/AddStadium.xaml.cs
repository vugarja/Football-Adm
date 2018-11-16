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
using Meydanca_Adm.Models;

namespace Meydanca_Adm
{
    /// <summary>
    /// Interaction logic for AddStadium.xaml
    /// </summary>
    
    // New window to add a stadium into database
    public partial class AddStadium : Window
    {
        private Mey_Entities db = new Mey_Entities();

        private MainWindow Main;

        //Creating connection between windows
        public AddStadium(MainWindow window)
        {
            InitializeComponent();
            Main = window;
        }

        //Button to add a new stadium to database
        private void btnNewStadium_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewStadium.Text))
            {
                MessageBox.Show("Stadionun adını daxil edin");
                return;
            }

            if (db.Stadiums.FirstOrDefault(s=>s.name==txtNewStadium.Text)==null)
            {
                Stadium stdm = new Stadium
                {
                    name = txtNewStadium.Text,
                };

                db.Stadiums.Add(stdm);
                db.SaveChanges();
            
                MessageBox.Show("Yeni stadion yaradıldı");

                Main.AddStadium(stdm.Id);
            }
            else
            {
                MessageBox.Show("Bu adda artıq stadion var");
                return;
            }

            this.Close();
        }
    }
}
