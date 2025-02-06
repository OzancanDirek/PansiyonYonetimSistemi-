using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace DirekPansiyon
{
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=DirekPansiyon;Integrated Security=True");

        private void veriler()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Stoklar ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Gida"].ToString();
                ekle.SubItems.Add(oku["Icecek"].ToString());
                ekle.SubItems.Add(oku["Atistirmalik"].ToString());
                listView1.Items.Add(ekle);


            }
            baglanti.Close();
        }
        private void veriler2()
        {

            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Faturalar ", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku2["Elektrik"].ToString();
                ekle.SubItems.Add(oku2["Su"].ToString());
                ekle.SubItems.Add(oku2["Internet"].ToString());
                listView2.Items.Add(ekle);


            }
            baglanti.Close();
        }

            private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Stoklar (Gida, Icecek, Atistirmalik) VALUES (@gida, @icecek, @atistirmalik)", baglanti);

            komut.Parameters.AddWithValue("@gida", TxtGidalar.Text);
            komut.Parameters.AddWithValue("@icecek", Txtİcecekler.Text);
            komut.Parameters.AddWithValue("@atistirmalik", TxtAtistirmaliklar.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            veriler();
        }

        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            veriler();
            veriler2();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("INSERT INTO Faturalar (Elektrik, Su, Internet) VALUES (@Elektrik, @Su, @Internet)", baglanti);

            komut2.Parameters.AddWithValue("@Elektrik", TxtElektrik.Text);
            komut2.Parameters.AddWithValue("@Su", TxtSu.Text);
            komut2.Parameters.AddWithValue("@Internet", TxtInternet.Text);

            komut2.ExecuteNonQuery();
            baglanti.Close();

            veriler2();
        }
    }
}
