using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectApplication
{
    public partial class SearchPage : Form
    {
        private string connectionString;

        public SearchPage()
        {
            InitializeComponent();
            this.ActiveControl = uxPatientFirstName;
            connectionString = @"Data Source=(localDB)\MSSQLLocalDB;Integrated Security=True";
        }

        private void uxGetPatientStays_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetPatientStays", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@BirthDate", birthDate);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetPatientInfo_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetPatientInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@BirthDate", birthDate);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetPatientDoctors_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetDoctorByPatient", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@BirthDate", birthDate);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetPatientConditions_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetConditionByPatientName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@BirthDate", birthDate);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetPatientEmergencyContactInfo_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetPatientEmergencyContactInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@BirthDate", birthDate);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetPatientTreatments_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetTreatmentByPatientName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@BirthDate", birthDate);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetDoctorInfo_Click(object sender, EventArgs e)
        {
            string firstName = uxDoctorFirstName.Text;
            string lastName = uxDoctorLastName.Text;
            string unit = uxDoctorUnit.Text;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetDoctorInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Unit", unit);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetDoctorPatients_Click(object sender, EventArgs e)
        {
            string firstName = uxDoctorFirstName.Text;
            string lastName = uxDoctorLastName.Text;
            string unit = uxDoctorUnit.Text;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetPatientByDoctor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Unit", unit);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetDoctorConditionHistory_Click(object sender, EventArgs e)
        {
            string firstName = uxDoctorFirstName.Text;
            string lastName = uxDoctorLastName.Text;
            string unit = uxDoctorUnit.Text;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetDoctorConditionHistory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Unit", unit);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetConditionDoctors_Click(object sender, EventArgs e)
        {
            string commonName = uxConditionCommonName.Text;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetDoctorTreatingConditionWithComTreatment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ConditionName", commonName);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetConditionHistory_Click(object sender, EventArgs e)
        {
            string commonName = uxConditionCommonName.Text;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetHospitalConditionHistory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ConditionName", commonName);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void uxGetConditionPatients_Click(object sender, EventArgs e)
        {
            string commonName = uxConditionCommonName.Text;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Hospital.GetPatientsWithConditionByDoctor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ConditionName", commonName);

                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        uxResultsGrid.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }
    }
}
