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
    public partial class FrmAnaSayfa : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public FrmAnaSayfa()
        {
            InitializeComponent();
            if (fr5 == null || fr5.IsDisposed)

            {

                fr5 = new FrmAna();

                fr5.MdiParent = this;

                fr5.Show();

            }
            else

            {

                fr5.Focus();

            }





        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            panel1.Size = new Size(49, 572);
            btnsolkaydir.Visible = true;
            pictureBox1.Visible = false;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            panel1.Size = new Size(261,572);
            btnsolkaydir.Visible = false;
            pictureBox1.Visible = true;
        }
        FrmUrunEkle fr;
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (fr == null || fr.IsDisposed)

            {

                fr = new FrmUrunEkle();

                fr.MdiParent = this;

                fr.Show();

            }

            else

            {

                fr.Focus();

            }
        }
        FrmVeriGirisi fr2;
        private void btnVeriGirisi_Click(object sender, EventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)

            {

                fr2 = new FrmVeriGirisi();

                fr2.MdiParent = this;

                fr2.Show();

            }

            else

            {

                fr2.Focus();

            }
        }
        FrmHaraketler fr3;
        private void btnHareketler_Click(object sender, EventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)

            {

                fr3 = new FrmHaraketler();

                fr3.MdiParent = this;

                fr3.Show();

            }

            else

            {

                fr3.Focus();

            }
        }


        FrmKilit kilit = new FrmKilit();
        private void btnKilit_Click(object sender, EventArgs e)
        {
            kilit.Show();
            this.Hide();
        }

        FrmSecenekler fr4;
        private void BtnSecenekler_Click(object sender, EventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)

            {

                fr4 = new FrmSecenekler();

                fr4.MdiParent = this;

                fr4.Show();

            }

            else

            {

                fr4.Focus();

            }
        }
        FrmAna fr5;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)

            {

                fr5 = new FrmAna();

                fr5.MdiParent = this;

                fr5.Show();

            }

            else

            {

                fr5.Focus();

            }
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            // Dil
            SqlCommand dil = new SqlCommand("select dil from TBLADMIN", bgl.baglanti());
            SqlDataReader dillur = dil.ExecuteReader();
            if (dillur.Read())
            {
                lbllang.Text = dillur[0].ToString();
            }
            if (lbllang.Text == "France")
            {
                btnHareketler.Text = "      Mouvements";
                btnUrunEkle.Text = "      Ajouter un produit";
                btnVeriGirisi.Text = "      Entrée de données";
                BtnSecenekler.Text = "      Options";
                btnAnaSayfa.Text = "      Page d'accueil";
                btnKilit.Text = "      Fermer à clé";
            }
        }
    }
}
