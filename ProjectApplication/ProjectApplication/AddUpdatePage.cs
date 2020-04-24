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
    public partial class AddUpdatePage : Form
    {
        public AddUpdatePage()
        {
            InitializeComponent();
        }

        private void uxAddPatientButton_Click(object sender, EventArgs e)
        {
            AddPatientForm addPatient = new AddPatientForm();
            addPatient.Show();
        }

        private void uxAddDoctorButton_Click(object sender, EventArgs e)
        {
            AddDoctorForm addDoctor = new AddDoctorForm();
            addDoctor.Show();
        }

        private void uxAddPatientStay_Click(object sender, EventArgs e)
        {
            AddPatientStayForm addPatientStay = new AddPatientStayForm();
            addPatientStay.Show();
        }

        private void uxAddContactButton_Click(object sender, EventArgs e)
        {
            AddContactForm addContact = new AddContactForm();
            addContact.Show();
        }

        private void uxAddConditionButton_Click(object sender, EventArgs e)
        {
            AddConditionForm addCondition = new AddConditionForm();
            addCondition.Show();
        }

        private void uxAddTreatmentButton_Click(object sender, EventArgs e)
        {
            AddTreatementForm addTreatment = new AddTreatementForm();
            addTreatment.Show();
        }
    }
}
