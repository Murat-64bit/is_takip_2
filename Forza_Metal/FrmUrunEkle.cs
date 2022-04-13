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
    public partial class FrmUrunEkle : Form
    {
        public FrmUrunEkle()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLURUNLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //void guncelle()
        //{
        //    SqlCommand komut = new SqlCommand("update TBLURUNLER set profilno=@p1,ad=@p2,depogiris=@p3 where id=@p4",bgl.baglanti());
        //    komut.Parameters.AddWithValue("@p1", txtprofilno.Text);
        //    komut.Parameters.AddWithValue("@p2", txtad.Text);
        //    komut.Parameters.AddWithValue("@p3", txtdepogiris.Text);
        //    komut.Parameters.AddWithValue("@p4", txtid.Text);
        //    komut.ExecuteNonQuery();
        //    MessageBox.Show("The product has been successfully updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        void sil()
        {
            SqlCommand komut = new SqlCommand("delete from TBLURUNLER where id=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtid.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("The product has been deleted successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void ekle()
        {
            SqlCommand komut = new SqlCommand("insert into TBLURUNLER (profilno,ad,depogiris) values (@p1,@p2,@p3)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtprofilno.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtdepogiris.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("The product has been successfully added", "Notification", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtprofilno.Text = "";
            txtdepogiris.Text = "";
        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmUrunEkle_Load(object sender, EventArgs e)
        {
            listele();

            if (txtDepoEkle.Text == "")
            {
                btnkaydet.Text = "Kaydet";
            }

            SqlCommand dil = new SqlCommand("select dil from TBLADMIN", bgl.baglanti());
            SqlDataReader dr = dil.ExecuteReader();
            if (dr.Read())
            {
                lbllang.Text = dr[0].ToString();
            }
            if (lbllang.Text == "France")
            {
                dildepogiris.Text = "Pièce:";
                dilprofilno.Text = "Num de profil:";
                dilad.Text = "Nom:";
                dilEkle.Text = "Ajouter:";
                btnkaydet.Text = "Sauvegarder";
                btnsil.Text = "Effacer";
                btnTemizle.Text = "Propre";
                btnListele.Text = "Lister";
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (btnkaydet.Text =="Kaydet")
            {
                ekle();
                listele();
                temizle();
            }

            if (btnkaydet.Text == "Ekle")
            {
                SqlCommand komut = new SqlCommand("update TBLURUNLER set depogiris=depogiris+@p1 where profilno=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtDepoEkle.Text);
                komut.Parameters.AddWithValue("@p2", txtprofilno.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ürün depo başarı ile eklendi", "Bildirim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
            if (btnkaydet.Text == "Sauvegarder")
            {
                ekle();
                listele();
                temizle();
            }

            if (btnkaydet.Text == "Ajouter")
            {
                SqlCommand komut = new SqlCommand("update TBLURUNLER set depogiris=depogiris+@p1 where profilno=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtDepoEkle.Text);
                komut.Parameters.AddWithValue("@p2", txtprofilno.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Le produit a été ajouté avec succès à l'entrepôt", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }



        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr !=null)
            {
                txtid.Text = dr["id"].ToString();
                txtad.Text = dr["ad"].ToString();
                txtprofilno.Text = dr["profilno"].ToString();
                txtdepogiris.Text = dr["depogiris"].ToString();
            }
               

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            sil();
            listele();
            temizle();
        }



        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void txtDepoEkle_TextChanged(object sender, EventArgs e)
        {
            if (lbllang.Text=="France")
            {
                btnkaydet.Text = "Ajouter";
            }
            if (lbllang.Text =="Turkish")
            {
                btnkaydet.Text = "Ekle";

            }
            if (txtDepoEkle.Text == "" && lbllang.Text =="Turkish")
            {
                btnkaydet.Text = "Kaydet";
            }
            if (txtDepoEkle.Text == "" && lbllang.Text == "France")
            {
                btnkaydet.Text = "Sauvegarder";
            }
        }

        private void txtdepogiris_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {

        }
    }
}
