using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExBD
{
    public partial class Cadastro : Form
    {
        private int? productId = null;
        Database db = new Database();

        private int id;
        private string nome;
        private decimal preco;

        // Construtor para adicionar ou editar
        public Cadastro()
        {
            InitializeComponent();
        }

        // Construtor para editar produto (com os parâmetros corretos)
        public Cadastro(int id, string nome, decimal preco)
        {
            InitializeComponent();
            productId = id;
            txtNome.Text = nome;
            txtPreco.Text = preco.ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            decimal preco = 0;

            // Verifica se o preço é válido
            if (!decimal.TryParse(txtPreco.Text.Trim(), out preco))
            {
                MessageBox.Show("Preço inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o nome não está vazio
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("O nome do produto não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tentativa de abrir a conexão e salvar o produto
            try
            {
                db.OpenConnection();
                string query;

                if (productId == null) // Inserção
                {
                    query = "INSERT INTO Produto (Nome, Preco) VALUES (@nome, @preco)";
                }
                else // Atualização
                {
                    query = "UPDATE Produto SET Nome = @nome, Preco = @preco WHERE Id = @id";
                }

                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@preco", preco);

                if (productId != null)
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                }

                // Executa a consulta
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Produto salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK; // Fecha o formulário
                }
                else
                {
                    MessageBox.Show("Nenhum produto foi inserido. Verifique a conexão ou os dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        public int Id => id;
        public string Nome => nome;
        public decimal Preco => preco;
    }
}
