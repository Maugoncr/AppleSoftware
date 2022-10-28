using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppleSoftware.Forms
{
    public partial class FrmMainSystem : Form
    {
        public FrmMainSystem()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMainSystem_Load(object sender, EventArgs e)
        {

        }
    }
}
