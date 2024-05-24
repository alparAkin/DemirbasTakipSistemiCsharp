using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace demirbasREMASTERED
{
    public partial class Login : Form
    {
        string connectionString = "datasource=127.0.0.1; database=demirbasyeni; port = 3306;user=root;";

        public Login()
        {
            InitializeComponent();
        }

       // string connectionString = "datasource=127.0.0.1; database=demirbasyeni; port = 3306;user=root;";

        public void login()
        {
            string query = "SELECT * FROM bilgilerdemirbas WHERE kullaniciadi = @kullaniciadi AND sifre = @sifre";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@kullaniciadi", textBox_kullaniciadi.Text);
            command.Parameters.AddWithValue("@sifre", textBox_sifre.Text);
            command.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string kullaniciadi = reader["kullaniciadi"].ToString();
                        MessageBox.Show("Başarılı giriş yapıldı");
                        Genel genel = new Genel(kullaniciadi); // Pass the kullaniciAdi to the Genel form
                        genel.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Yanlış Girildi");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
           // groupBox1.BackColor = Color.Transparent;

        }

       

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void buttonGirisYap_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}

