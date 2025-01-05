using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.People.All.User_Control
{
    public partial class frmShowPersonCard : Form
    {
        private int _PersonID = 0;
        public frmShowPersonCard(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
         


        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this person?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(_PersonID))
                {
                    MessageBox.Show("Person was deleted successfully", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("Error Message:Person delete failed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonCard_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonData(_PersonID);
        }
    }
}
