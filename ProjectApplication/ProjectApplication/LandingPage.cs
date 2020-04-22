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
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void uxSearch_Click(object sender, EventArgs e)
        {
            SearchPage searchPage = new SearchPage();
            searchPage.Show();
        }

        private void uxAddUpdate_Click(object sender, EventArgs e)
        {
            AddUpdatePage addUpdatePage = new AddUpdatePage();
            addUpdatePage.Show();
        }
    }
}
