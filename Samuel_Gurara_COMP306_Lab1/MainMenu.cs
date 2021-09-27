using System;
using System.Windows.Forms;

namespace Samuel_Gurara_COMP306_Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateBucket_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateBucket createBucket = new CreateBucket();
            createBucket.Show();
        }

        private void btnObjectLevelOperation_Click(object sender, EventArgs e)
        {
            this.Hide();
            ObjectLevel objectLevel = new ObjectLevel();
            objectLevel.Show();
        }
    }
}
