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
    public partial class FrmSecenekler : Form
    {
        public FrmSecenekler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select kad,dil from TBLADMIN", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bunifuDataGridView1.DataSource = dt;
        }
        private void FrmSeceneklercs_Load(object sender, EventArgs e)
        {
            listele();
            SqlCommand dil = new SqlCommand("select dil from TBLADMIN",bgl.baglanti());
            SqlDataReader dr = dil.ExecuteReader();
            if (dr.Read())
            {
                lbllang.Text = dr[0].ToString();
            }
            if (lbllang.Text == "France")
            {
                btnkaydet.Text = "Sauvegarder";
                btnGuncelle.Text = "Mettre à jour";
                btnSil.Text = "Effacer";

            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblDil.Text = "Turkish";
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            lblDil.Text = "France";

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (lblDil.Text !="Dil")
            {
                SqlCommand komut = new SqlCommand("insert into TBLADMIN (kad,ksifre,dil) values (@p1,@p2,@p3)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtUsername.Text);
                komut.Parameters.AddWithValue("@p2", txtPassword.Text);
                komut.Parameters.AddWithValue("@p3", lblDil.Text);
                komut.ExecuteNonQuery();
                lblBasari.Visible = true;
                lblBasari.Text = "Kullanıcı başarı ile eklendi";
                listele();
            }
            else
            {
                MessageBox.Show("Vous n'avez pas choisi de langue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text!="Password")
            {
                SqlCommand komut = new SqlCommand("update TBLADMIN set kad=@p1,ksifre=@p2,dil=@p3 where kad=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtUsername.Text);
                komut.Parameters.AddWithValue("@p2", txtPassword.Text);
                komut.Parameters.AddWithValue("@p3", lblDil.Text);
                komut.ExecuteNonQuery();
                lblBasari.Visible = true;
                lblBasari.Text = "Kullanıcı başarı ile güncellendi";
                listele();
            }
            else
            {
                MessageBox.Show("s'il vous plait entrez votre mot de passe", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }



        private void btnSil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete TBLADMIN where kad=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUsername.Text);
            komut.ExecuteNonQuery();
            lblBasari.Visible = true;
            lblBasari.Text = "Kullanıcı başarı ile silindi";
            listele();

        }

        private void bunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDilKaydet_Click(object sender, EventArgs e)
        {

        }
    }
}
