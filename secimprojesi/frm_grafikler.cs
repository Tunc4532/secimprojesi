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

namespace secimprojesi
{
    public partial class frm_grafikler : Form
    {
        public frm_grafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=25ikinciprojem;Integrated Security=True");
        private void frm_grafikler_Load(object sender, EventArgs e)
        {
            //katagori isimlerini comboboxa çekme işlemi 
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select KATİSİM from tbl_seçim", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            //chart aracımıza sonuç getirme işlemi 
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select SUM(TATLI),SUM(İÇECEK),SUM(ANAYEMEK),SUM(MEZE),SUM(KURABİYE) from tbl_seçim", baglanti);
            SqlDataReader dre = komut3.ExecuteReader();
            while(dre.Read())
            {
                chart1.Series["Seçimler"].Points.AddXY("TATLI", dre[0]);
                chart1.Series["Seçimler"].Points.AddXY("İÇECEK", dre[1]);
                chart1.Series["Seçimler"].Points.AddXY("ANAYEMEK", dre[2]);
                chart1.Series["Seçimler"].Points.AddXY("MEZE", dre[3]);
                chart1.Series["Seçimler"].Points.AddXY("KURABİYE", dre[4]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * from tbl_seçim where KATİSİM=@e1", baglanti);
            komut5.Parameters.AddWithValue("@e1", comboBox1.Text);
            SqlDataReader se = komut5.ExecuteReader();
            while(se.Read())
            {
                progressBar1.Value = int.Parse(se[2].ToString());
                progressBar2.Value = int.Parse(se[3].ToString());
                progressBar3.Value = int.Parse(se[4].ToString());
                progressBar4.Value = int.Parse(se[5].ToString());
                progressBar5.Value = int.Parse(se[6].ToString());

                lbl1.Text = se[2].ToString();
                lbl2.Text = se[3].ToString();
                lbl3.Text = se[4].ToString();
                lbl4.Text = se[5].ToString();
                lbl5.Text = se[6].ToString();
            }
            baglanti.Close();

        }
    }
}
