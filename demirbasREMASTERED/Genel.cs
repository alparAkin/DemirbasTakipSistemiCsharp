using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demirbasREMASTERED
{
    public partial class Genel : Form
    {

        string connectionString = "datasource=127.0.0.1; database=demirbasyeni; port = 3306;user=root;";
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;
        private string kullaniciadi;

        public Genel(string kullaniciadi)
        {
            InitializeComponent();
            this.kullaniciadi = kullaniciadi;
            connection = new MySqlConnection(connectionString); // Connection nesnesini oluştur
        }

        private void donanımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sicilNumarasi = textBox_sicilno.Text;
            Donanim donanim = new Donanim(sicilNumarasi);
            donanim.Show();
        }

        private void Genel_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void VerileriYukle()
        {
            try
            {
                connection.Open();
                string query = "SELECT ad, soyad, sicilnumarasi, unvan, bolum, eposta, oda_numarası, ise_baslama_tarihi, notlar FROM bilgilerdemirbas WHERE kullaniciadi = @kullaniciAdi";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    textBox_ad.Text = reader["ad"].ToString();
                    textBox_soyad.Text = reader["soyad"].ToString();
                    textBox_sicilno.Text = reader["sicilnumarasi"].ToString();
                    textBox_unvan.Text = reader["unvan"].ToString();
                    textBox_bolum.Text = reader["bolum"].ToString();
                    textBox_eposta.Text = reader["eposta"].ToString();
                    textBox_odanumarasi.Text = reader["oda_numarası"].ToString();
                    textBox_isebaslamatarihi.Text = reader["ise_baslama_tarihi"].ToString();
                    textBox_notlar.Text = reader["notlar"].ToString();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string ad = textBox_ad.Text;
                string soyad = textBox_soyad.Text;
                string sicilnumarasi = textBox_sicilno.Text;
                string unvan = textBox_unvan.Text;
                string bolum = textBox_bolum.Text;
                string eposta = textBox_eposta.Text;
                string oda_numarasi = textBox_odanumarasi.Text;
                string ise_baslama_tarihi = textBox_isebaslamatarihi.Text;
                string notlar = textBox_notlar.Text;

                string query = "UPDATE bilgilerdemirbas SET ad = @ad, soyad = @soyad, sicilnumarasi = @sicilnumarasi, unvan = @unvan, bolum = @bolum, eposta = @eposta, oda_numarası = @oda_numarasi, ise_baslama_tarihi = @ise_baslama_tarihi, notlar = @notlar WHERE kullaniciadi = @kullaniciadi";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@soyad", soyad);
                command.Parameters.AddWithValue("@sicilnumarasi", sicilnumarasi);
                command.Parameters.AddWithValue("@unvan", unvan);
                command.Parameters.AddWithValue("@bolum", bolum);
                command.Parameters.AddWithValue("@eposta", eposta);
                command.Parameters.AddWithValue("@oda_numarasi", oda_numarasi);
                command.Parameters.AddWithValue("@ise_baslama_tarihi", ise_baslama_tarihi);
                command.Parameters.AddWithValue("@notlar", notlar);
                command.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);

                command.ExecuteNonQuery();

                MessageBox.Show("Veriler başarıyla güncellendi.");

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri güncelleme hatası: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

    }
}
