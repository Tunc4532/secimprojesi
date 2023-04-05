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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=25ikinciprojem;Integrated Security=True");
        private void btnoylama_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into tbl_seçim (KATİSİM,TATLI,İÇECEK,ANAYEMEK,MEZE,KURABİYE) values (@q1,@q2,@q3,@q4,@q5,@q6)", baglanti);
                komut.Parameters.AddWithValue("@q1", txtmekan.Text);
                komut.Parameters.AddWithValue("@q2", txttatlı.Text);
                komut.Parameters.AddWithValue("@q3", txtiçecek.Text);
                komut.Parameters.AddWithValue("@q4", txtanay.Text);
                komut.Parameters.AddWithValue("@q5", txtmeze.Text);
                komut.Parameters.AddWithValue("@q6", txtkurabiye.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Oy Girişi Başarılı");
            }
            catch (Exception)
            {
                MessageBox.Show("Girilen Değerleri Lütfen Kontrol Ediniz");
            }
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            frm_grafikler fr = new frm_grafikler();
            fr.Show();
            this.Hide();
        }
    }
}
