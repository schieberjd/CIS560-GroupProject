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
    public partial class AddPatientStayForm : Form
    {
        public AddPatientStayForm()
        {
            InitializeComponent();
        }

        private void uxAddPatientStayToDatabaseButton_Click(object sender, EventArgs e)
        {
            //get the data from the GUI
            string patientId = uxPatientIDBox.Text;
            DateTime addmittanceDate = dateTimePicker1.Value;
            string DoctorId = uxDoctorIDBox.Text;
            DateTime dischargeDate = dateTimePicker2.Value;
            string room = uxRoomNumberBox.Text;
            string unit = uxUnitBox.Text;
            int condition = Convert.ToInt32( uxConditionBox.Text);
            int treatment = Convert.ToInt32( uxTreatmentBox.Text);

            //set up SQL connection
            string connectionString = @"Server=localhost\MSSQLSERVER01;Database=CIS560_FINAL_PROJECT;User ID=Ethan;
                                        Integrated Security=SSPI";
            var cnn = new SqlConnection(connectionString);

            var cmd = new SqlCommand("EXEC Hospital.AddPatientStay @PatientID, @AdmittanceDate, @DischargeDate, @Unit, @RoomNumber, @ConditionID, @DoctorID, @TreatmentID;", cnn);

            cmd.Parameters.AddWithValue("@PatientId", patientId);
            cmd.Parameters.AddWithValue("@AdmittanceDate", addmittanceDate);
            cmd.Parameters.AddWithValue("@DischargeDate", dischargeDate);
            cmd.Parameters.AddWithValue("@Unit", unit);
            cmd.Parameters.AddWithValue("@RoomNumber", room);
            cmd.Parameters.AddWithValue("@ConditionID", condition);
            cmd.Parameters.AddWithValue("@DoctorID", DoctorId);
            cmd.Parameters.AddWithValue("@TreatmentID", treatment);
          

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

        private void uxConditionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
