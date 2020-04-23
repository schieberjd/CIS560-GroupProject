using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectApplication
{
    public partial class SearchPage : Form
    {
        public SearchPage()
        {
            InitializeComponent();
            this.ActiveControl = uxPatientFirstName;
        }

        private void uxGetPatientStays_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;
        }

        private void uxGetPatientInfo_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;
        }

        private void uxGetPatientDoctors_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;
        }

        private void uxGetPatientConditions_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;
        }

        private void uxGetPatientEmergencyContactInfo_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;
        }

        private void uxGetPatientTreatments_Click(object sender, EventArgs e)
        {
            string firstName = uxPatientFirstName.Text;
            string lastName = uxPatientLastName.Text;
            DateTime birthDate = uxPatientBirthDate.Value;
        }

        private void uxGetDoctorInfo_Click(object sender, EventArgs e)
        {
            string firstName = uxDoctorFirstName.Text;
            string lastName = uxDoctorLastName.Text;
            string unit = uxDoctorUnit.Text;
        }

        private void uxGetDoctorPatients_Click(object sender, EventArgs e)
        {
            string firstName = uxDoctorFirstName.Text;
            string lastName = uxDoctorLastName.Text;
            string unit = uxDoctorUnit.Text;
        }

        private void uxGetDoctorConditionHistory_Click(object sender, EventArgs e)
        {
            string firstName = uxDoctorFirstName.Text;
            string lastName = uxDoctorLastName.Text;
            string unit = uxDoctorUnit.Text;
        }

        private void uxGetConditionDoctors_Click(object sender, EventArgs e)
        {
            string commonName = uxConditionCommonName.Text;
        }

        private void uxGetConditionHistory_Click(object sender, EventArgs e)
        {
            string commonName = uxConditionCommonName.Text;
        }

        private void uxGetConditionPatients_Click(object sender, EventArgs e)
        {
            string commonName = uxConditionCommonName.Text;
        }
    }
}
