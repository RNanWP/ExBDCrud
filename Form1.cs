using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ExBD
{
    public partial class Form1 : Form
    {
        Database db = new Database();

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void LoadData()
        {
            db.OpenConnection();
            string query = "SELECT * FROM Produto";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            db.CloseConnection();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) { }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            if (cadastro.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Recarrega os dados após adicionar
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                string nome = dataGridView1.SelectedRows[0].Cells["Nome"].Value.ToString();
                decimal preco = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["Preco"].Value);

                Cadastro cadastro = new Cadastro(id, nome, preco);
                if (cadastro.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Recarrega os dados após atualizar
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para editar.");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                db.OpenConnection();
                string query = "DELETE FROM Produto WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                db.CloseConnection();
                LoadData(); // Recarrega os dados após excluir
            }
            else
            {
                MessageBox.Show("Selecione um produto para excluir.");
            }
        }
    }
}
