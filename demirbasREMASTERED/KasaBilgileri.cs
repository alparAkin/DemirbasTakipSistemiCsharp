using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;
using System.Configuration;



namespace demirbasREMASTERED
{
    public partial class KasaBilgileri : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DemirbasDbConnectionString"].ConnectionString;
        private string sicilNumarasi;

        public KasaBilgileri(string sicilNumarasi)
        {
            InitializeComponent();
            this.sicilNumarasi = sicilNumarasi;
        }

        private void KasaBilgileri_Load(object sender, EventArgs e)
        {
            LoadKasaBilgileri();
        }

        private void LoadKasaBilgileri()
        {
            string query = "SELECT kasaDemirbasNo, sicilnumarasi, isletimSistemi, islemciMarkaModel, ram, sabitDiskKapasitesi, ekranKarti, pcModel, islemciHizi, cekirdekSayisi, monitorBoyutu FROM bilgilerdemirbas WHERE sicilnumarasi = @sicilnumarasi";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@sicilnumarasi", sicilNumarasi);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox_kasaDemirbasNo.Text = reader["kasaDemirbasNo"].ToString();
                        textBox_calisanSicilNo.Text = reader["sicilnumarasi"].ToString();
                        textBox_isletimSistemi.Text = reader["isletimSistemi"].ToString();
                        textBox_islemciMarkaModel.Text = reader["islemciMarkaModel"].ToString();
                        textBox_ram.Text = reader["ram"].ToString();
                        textBox_sabitDiskKapasitesi.Text = reader["sabitDiskKapasitesi"].ToString();
                        textBox_ekranKarti.Text = reader["ekranKarti"].ToString();
                        textBox_pcModel.Text = reader["pcModel"].ToString();
                        textBox_islemciHizi.Text = reader["islemciHizi"].ToString();
                        textBox_cekirdekSayisi.Text = reader["cekirdekSayisi"].ToString();
                        textBox_monitorBoyutu.Text = reader["monitorBoyutu"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcıya ait kasa bilgileri bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void button_kaydet_Click_1(object sender, EventArgs e)
        {
            string query = "UPDATE bilgilerdemirbas SET isletimSistemi = @isletimSistemi, islemciMarkaModel = @islemciMarkaModel, ram = @ram, sabitDiskKapasitesi = @sabitDiskKapasitesi, ekranKarti = @ekranKarti, pcModel = @pcModel, islemciHizi = @islemciHizi, cekirdekSayisi = @cekirdekSayisi, monitorBoyutu = @monitorBoyutu WHERE kasaDemirbasNo = @kasaDemirbasNo AND sicilnumarasi = @sicilnumarasi";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@kasaDemirbasNo", textBox_kasaDemirbasNo.Text);
                    command.Parameters.AddWithValue("@sicilnumarasi", sicilNumarasi);
                    command.Parameters.AddWithValue("@isletimSistemi", textBox_isletimSistemi.Text);
                    command.Parameters.AddWithValue("@islemciMarkaModel", textBox_islemciMarkaModel.Text);
                    command.Parameters.AddWithValue("@ram", textBox_ram.Text);
                    command.Parameters.AddWithValue("@sabitDiskKapasitesi", textBox_sabitDiskKapasitesi.Text);
                    command.Parameters.AddWithValue("@ekranKarti", textBox_ekranKarti.Text);
                    command.Parameters.AddWithValue("@pcModel", textBox_pcModel.Text);
                    command.Parameters.AddWithValue("@islemciHizi", textBox_islemciHizi.Text);
                    command.Parameters.AddWithValue("@cekirdekSayisi", textBox_cekirdekSayisi.Text);
                    command.Parameters.AddWithValue("@monitorBoyutu", textBox_monitorBoyutu.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt güncellenemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

       
        }
        private void button_kaydisil_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM bilgilerdemirbas WHERE kasaDemirbasNo = @kasaDemirbasNo AND sicilnumarasi = @sicilnumarasi";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@kasaDemirbasNo", textBox_kasaDemirbasNo.Text);
                        command.Parameters.AddWithValue("@sicilnumarasi", sicilNumarasi);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla silindi.");
                            ClearTextBoxes();
                        }
                        else
                        {
                            MessageBox.Show("Kayıt silinemedi.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
       
            }
        }

        private void ClearTextBoxes()
        {
            textBox_kasaDemirbasNo.Clear();
            textBox_calisanSicilNo.Clear();
            textBox_isletimSistemi.Clear();
            textBox_islemciMarkaModel.Clear();
            textBox_ram.Clear();
            textBox_sabitDiskKapasitesi.Clear();
            textBox_ekranKarti.Clear();
            textBox_pcModel.Clear();
            textBox_islemciHizi.Clear();
            textBox_cekirdekSayisi.Clear();
            textBox_monitorBoyutu.Clear();
        }

        
    }
}
