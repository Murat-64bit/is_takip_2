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
    public partial class FrmVeriGirisi : Form
    {
        public FrmVeriGirisi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec Stokliste",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void ekle()
        {
            SqlCommand komut = new SqlCommand("insert into TBLSTOK (profilno,urunid,depocikis,tarih,gramaj,metraj,toplam) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtprofilno.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtdepocikis.Text);
            komut.Parameters.AddWithValue("@p4", lblTarih.Text);
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtGramaj.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtMetraj.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtToplam.Text));
            komut.ExecuteNonQuery();
            SqlCommand komut3 = new SqlCommand("insert into TBLHARAKETLER (ad,tarih,oncekiadet,sonrakiadet,fark) values (@s1,@s2,@s3,@s4,@s5)", bgl.baglanti());
            komut3.Parameters.AddWithValue("@s1", txtad.Text);
            komut3.Parameters.AddWithValue("@s2", lblTarih.Text);
            komut3.Parameters.AddWithValue("@s3", lblOncekiAdet.Text);
            komut3.Parameters.AddWithValue("@s4", lblSonrakiAdet.Text);
            komut3.Parameters.AddWithValue("@s5", txtdepocikis.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            SqlCommand komut4 = new SqlCommand("update TBLURUNLER set depogiris=depogiris-@t1 where id=@t2", bgl.baglanti());
            komut4.Parameters.AddWithValue("@t1", txtdepocikis.Text);
            komut4.Parameters.AddWithValue("@t2", txtad.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Stock entry has been successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void sil()
        {
            SqlCommand komut = new SqlCommand("delete TBLSTOK where id=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Stock exit has been deleted successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void guncelle()
        {
            SqlCommand komut = new SqlCommand("update TBLSTOK set profilno=@p1,urunid=@p2,depocikis=@p3,gramaj=@p4,metraj=@p5,toplam=@p6 where id=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtprofilno.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtdepocikis.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtGramaj.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtMetraj.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtToplam.Text));
            komut.Parameters.AddWithValue("@p7", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Stock exit has been updated successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmVeriGirisi_Load(object sender, EventArgs e)
        {
            listele();
            lblTarih.Text = DateTime.Now.ToString();
            SqlCommand dil = new SqlCommand("select dil from TBLADMIN", bgl.baglanti());
            SqlDataReader dr = dil.ExecuteReader();
            if (dr.Read())
            {
                lbllang.Text = dr[0].ToString();
            }
            if (lbllang.Text == "France")
            {
                dildepocikis.Text = "Pièce:";
                dilgramaj.Text = "Poids:";
                dilmetraj.Text = "Quantité:";
                dilprofilno.Text = "Num de profil:";
                diltoplam.Text = "Total:";
                dilurunid.Text = "ID produit:";
                btnkaydet.Text = "Sauvegarder";
                btnsil.Text = "Effacer";
                btnTemizle.Text = "Propre";
            }



        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double gramaj, toplam, metraj;
                int miktar;
                metraj = Convert.ToDouble(txtMetraj.Text);
                miktar = Convert.ToInt32(txtdepocikis.Text);
                gramaj = Convert.ToDouble(txtGramaj.Text);
                toplam = miktar * gramaj * metraj;

                txtToplam.Text = toplam.ToString();
            }
            catch (Exception)
            {


            }


        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double gramaj, toplam, metraj;
                int miktar;
                metraj = Convert.ToDouble(txtMetraj.Text);
                miktar = Convert.ToInt32(txtdepocikis.Text);
                gramaj = Convert.ToDouble(txtGramaj.Text);
                toplam = miktar * gramaj * metraj;

                txtToplam.Text = toplam.ToString();
            }
            catch (Exception)
            {


            }
        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select depogiris from tblurunler where id=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblOncekiAdet.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

       
        }

        private void txtdepocikis_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double gramaj, toplam, metraj;
                int miktar;
                metraj = Convert.ToDouble(txtMetraj.Text);
                miktar = Convert.ToInt32(txtdepocikis.Text);
                gramaj = Convert.ToDouble(txtGramaj.Text);
                toplam = miktar * gramaj * metraj;

                txtToplam.Text = toplam.ToString();
            }
            catch (Exception)
            {


            }

            SqlCommand komut2 = new SqlCommand("select depogiris=depogiris-@p1 from tblurunler where id=@p2", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtdepocikis.Text);
            komut2.Parameters.AddWithValue("@p2", txtad.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblSonrakiAdet.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
   

            ekle();

           
            listele();
        }

        private void txtprofilno_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select id from tblurunler where profilno=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtprofilno.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
    

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            guncelle();
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["id"].ToString();
                txtad.Text = dr["urunid"].ToString();
                txtprofilno.Text = dr["profilno"].ToString();
                txtdepocikis.Text = dr["depocikis"].ToString();
                txtGramaj.Text = dr["gramaj"].ToString();
                txtMetraj.Text = dr["metraj"].ToString();
                txtToplam.Text = dr["toplam"].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            sil();
            listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtad.Text = "";
            txtprofilno.Text = "";
            txtdepocikis.Text = "";
            txtGramaj.Text = "";
            txtMetraj.Text = "";
            txtToplam.Text = "";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            listele();

        }
    }
}
