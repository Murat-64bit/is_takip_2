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
using DevExpress.XtraCharts;


namespace Forza_Metal
{
    public partial class FrmAna : Form
    {
        public FrmAna()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            // SELECT tblurunler.ad, sum(depogiris) AS YuksekFiyat FROM TBLURUNLER WHERE depogiris < 20 group by TBLURUNLER.ad
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT tblurunler.ad,depogiris AS 'Stok' FROM TBLURUNLER WHERE depogiris < 20 ", bgl.baglanti());
            
            da.Fill(dt);
            bunifuDataGridView1.DataSource = dt;
        }

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void FrmAna_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT sum(depogiris) AS YuksekFiyat FROM TBLURUNLER",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                lblToplamStok.Text =dr[0].ToString();
            }         
            
            SqlCommand komut2 = new SqlCommand("SELECT avg(depogiris) FROM TBLURUNLER", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            if (dr2.Read())
            {
                lblOrtalama.Text =dr2[0].ToString();
            }       
            SqlCommand komut3 = new SqlCommand("SELECT left(tarih,10) FROM TBLHARAKETLER ORDER BY id DESC", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            if (dr3.Read())
            {
                lblSonSatisGun.Text =dr3[0].ToString();
            }     
            SqlCommand komut4 = new SqlCommand("SELECT max(fark) FROM TBLHARAKETLER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            if (dr4.Read())
            {
                lblEnyukseksatis.Text =dr4[0].ToString();
            }
            listele();
            SqlCommand komut5 = new SqlCommand("select ad,sum(depogiris) as 'Miktar' from tblurunler group by ad", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr5[0]), int.Parse(dr5[1].ToString()));
            }
            // Dil
            SqlCommand dil = new SqlCommand("select dil from TBLADMIN", bgl.baglanti());
            SqlDataReader dillur = dil.ExecuteReader();
            if (dillur.Read())
            {
                lbllang.Text = dillur[0].ToString();
            }
            if (lbllang.Text == "France")
            {
                dilenyuksekcikis.Text = "Quantité élevée:";
                dilsoncikisgun.Text = "Dernière sortie:";
                dilortalamgiris.Text = "Numéro médiane:";
                diltoplamstok.Text = "Stock total";
                dil20dendusukstok.Text = "Stock inférieur à 20";
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT sum(depogiris) AS YuksekFiyat FROM TBLURUNLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                lblToplamStok.Text = dr[0].ToString();
            }

            SqlCommand komut2 = new SqlCommand("SELECT avg(depogiris) FROM TBLURUNLER", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            if (dr2.Read())
            {
                lblOrtalama.Text = dr2[0].ToString();
            }
            SqlCommand komut3 = new SqlCommand("SELECT left(tarih,10) FROM TBLHARAKETLER ORDER BY id DESC", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            if (dr3.Read())
            {
                lblSonSatisGun.Text = dr3[0].ToString();
            }
            SqlCommand komut4 = new SqlCommand("SELECT max(fark) FROM TBLHARAKETLER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            if (dr4.Read())
            {
                lblEnyukseksatis.Text = dr4[0].ToString();
            }
            listele();
            SqlCommand komut5 = new SqlCommand("select ad,sum(depogiris) as 'Miktar' from tblurunler group by ad", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr5[0]), int.Parse(dr5[1].ToString()));
            }

        }
    }
}
