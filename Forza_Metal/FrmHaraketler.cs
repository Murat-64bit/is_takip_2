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

namespace Forza_Metal
{
    public partial class FrmHaraketler : Form
    {
        public FrmHaraketler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void Haraketler_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLHARAKETLER",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        public int sayac=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac==15)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from TBLHARAKETLER", bgl.baglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            if (sayac==16)
            {
                sayac = 0;
            }
        }
    }
}
