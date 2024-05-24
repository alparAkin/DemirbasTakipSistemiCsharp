using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace demirbasREMASTERED
{
    public partial class Donanim : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DemirbasDbConnectionString"].ConnectionString;
        private string sicilNumarasi;

        public Donanim(string sicilNumarasi)
        {
            InitializeComponent();
            this.sicilNumarasi = sicilNumarasi;
        }

        private void Donanim_Load(object sender, EventArgs e)
        {
            string query = "SELECT marka, model, aciklama, verildigiTarih FROM bilgilerdemirbas WHERE sicilnumarasi = @sicilnumarasi";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@sicilNumarasi", sicilNumarasi);

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }

                    // "Sil" butonunu ekle
                    DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                    deleteButton.HeaderText = "Sil";
                    deleteButton.Text = "Sil";
                    deleteButton.Name = "Sil";
                    deleteButton.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(deleteButton);

                    dataGridView1.CellClick += dataGridView1_CellClick;
                }
                catch (MySqlConversionException ex)
                {
                    MessageBox.Show("Date conversion error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Onay penceresi açalım
                var result = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string marka = dataGridView1.Rows[e.RowIndex].Cells["marka"].Value.ToString();
                    string model = dataGridView1.Rows[e.RowIndex].Cells["model"].Value.ToString();
                    string aciklama = dataGridView1.Rows[e.RowIndex].Cells["aciklama"].Value.ToString();
                    string verildigiTarih = dataGridView1.Rows[e.RowIndex].Cells["verildigiTarih"].Value.ToString();

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string deleteQuery = "DELETE FROM bilgilerdemirbas WHERE marka = @marka AND model = @model AND aciklama = @aciklama AND verildigiTarih = @verildigiTarih";
                            MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                            command.Parameters.AddWithValue("@marka", marka);
                            command.Parameters.AddWithValue("@model", model);
                            command.Parameters.AddWithValue("@aciklama", aciklama);
                            command.Parameters.AddWithValue("@verildigiTarih", verildigiTarih);

                            command.ExecuteNonQuery();

                            dataGridView1.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Kayıt başarıyla silindi.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Veritabanı hatası: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void button_kasaBilgileri_Click(object sender, EventArgs e)
        {
            // KasaBilgileri formunu açıyoruz ve sicilNumarasi geçiyoruz
            KasaBilgileri kasaBilgileri = new KasaBilgileri(sicilNumarasi);
            kasaBilgileri.Show();
        }
    }
}
