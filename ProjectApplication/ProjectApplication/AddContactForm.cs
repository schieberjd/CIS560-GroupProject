using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectApplication
{
    public partial class AddContactForm : Form
    {
        public AddContactForm()
        {
            InitializeComponent();
        }

        private void uxAddContactToDatabaseButton_Click(object sender, EventArgs e)
        {
            //get the data from the GUI
            string first = uxFirstBox.Text;
            string last = uxLastBox.Text;
            string phone = uxPhoneBox.Text;
            string email = uxEmailBox.Text;
            string address = uxAddressBox.Text;
            string city = uxCityBox.Text;
            string state = uxStateBox.Text;
            string zip = uxZipBox.Text;
            string country = uxCountryBox.Text;
            
            //set up SQL connection
            string connectionString = @"Server=localhost\MSSQLSERVER01;Database=CIS560_FINAL_PROJECT;User ID=Ethan;
                                        Integrated Security=SSPI";
            var cnn = new SqlConnection(connectionString);

            var cmd = new SqlCommand("EXEC Hospital.AddContact @First, @Last, @Phone, @Email, @Address, @City, @State, @Zip, @Country;", cnn);

            cmd.Parameters.AddWithValue("@First", first);
            cmd.Parameters.AddWithValue("@Last", last);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@City", city);
            cmd.Parameters.AddWithValue("@State", state);
            cmd.Parameters.AddWithValue("@Zip", zip);
            cmd.Parameters.AddWithValue("@Country", country);


            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data added");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
