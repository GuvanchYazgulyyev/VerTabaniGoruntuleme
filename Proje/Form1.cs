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

namespace sql_orek_ders_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=GUGA\\SQLEXPRESS;Initial Catalog=ogrenciler;Integrated Security=True ");

        private void verilerimigoster()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from bilgiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["adsoyad"].ToString();
                ekle.SubItems.Add(oku["şehir"].ToString());
                ekle.SubItems.Add(oku["okul"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            verilerimigoster();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
