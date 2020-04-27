﻿using System;
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
    public partial class AddTreatementForm : Form
    {
        public AddTreatementForm()
        {
            InitializeComponent();
        }

        private void uxAddTreatmentToDatabaseButton_Click(object sender, EventArgs e)
        {
            //get the data from the GUI
            string treatment = uxNameBox.Text;
            string appType = uxAppTypeBox.Text;
            string appFreq = uxAppFreqBox.Text;

            //set up SQL connection
            string connectionString = @"Server=localhost\MSSQLSERVER01;Database=CIS560_FINAL_PROJECT;User ID=Ethan;
                                        Integrated Security=SSPI";
            var cnn = new SqlConnection(connectionString);

            var cmd = new SqlCommand("EXEC Hospital.AddTreatment @Treatment, @AppFreq, @AppType;", cnn);

            cmd.Parameters.AddWithValue("@Treatment", treatment);
            cmd.Parameters.AddWithValue("@AppType", appType);
            cmd.Parameters.AddWithValue("@AppFreq", appFreq);


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
