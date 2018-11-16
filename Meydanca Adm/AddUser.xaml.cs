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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    // A windown to create a new User
    public partial class AddUser : Window
    {

        private Mey_Entities db = new Mey_Entities();

        private MainWindow Main;
        
        //Creating connection between windows
        public AddUser(MainWindow Wndw)
        {
            Main = Wndw;
            InitializeComponent();
        }


        //Btn to add a new user into database
        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            int errCount = 0;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errCount++;
                MessageBox.Show("Şəxsin adını girin");
            }
            else
            {
                errCount--;
            }
            if (string.IsNullOrEmpty(txtSurname.Text))
            {
                errCount++;
                MessageBox.Show("Şəxsin soyadını daxil edin");
            }
            else
            {
                errCount--;
            }
            if (string.IsNullOrEmpty(txtUserPhone.Text))
            {
                errCount++;
                MessageBox.Show("Şəxsin telefon nömrəsini daxil edin");
            }
            else
            {
                errCount--;
            }
            if (errCount>0)
            {
                return;
            }

            if (db.Contacts.FirstOrDefault(c=>c.Phone == txtUserPhone.Text)==null)
            {
               
                Contact cnt = new Contact
                {
                    Name = txtUserName.Text,
                    Surname = txtSurname.Text,
                    Phone = txtUserPhone.Text,
                };
                db.Contacts.Add(cnt);
                db.SaveChanges();
                MessageBox.Show("Yeni şəxs yaradıldı");
                Main.AddUser(cnt.Id);

            }
            else
            {
                MessageBox.Show("Bu nömrə ilə şəxs artıq mövcuddur");
                return;
                
            }

            //this.Close();
        }
    }
}
