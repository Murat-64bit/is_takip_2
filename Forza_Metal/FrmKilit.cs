using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forza_Metal
{
    public partial class FrmKilit : Form
    {
        public FrmKilit()
        {
            InitializeComponent();
        }
        FrmGiris fr = new FrmGiris();
        private void FrmKilit_Load(object sender, EventArgs e)
        {
          
        }

        private void FrmKilit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                fr.Show();

                this.Close();

            }
        }
    }
}
