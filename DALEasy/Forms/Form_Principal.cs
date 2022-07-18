using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DALEasy
{
    public partial class Form_Principal : Form
    {
        public Form_Principal()
        {
            InitializeComponent();
        }


        private void Form_Principal_Load(object sender, EventArgs e)
        {
            var Param = Parametros.Carregar();
            comboBoxTipoBanco.Text = Param.Banco.Tipo;
            textBoxServidor.Text = Param.Banco.Servidor;
            textBoxUsuario.Text = Param.Banco.Usuario;
            textBoxSenha.Text = Param.Banco.Senha;
            comboBoxBanco.Text = Param.Banco.Nome;
            comboBoxLinguagem.Text = Param.Linguagem.Nome;
            textBoxNameSpace.Text = Param.Linguagem.NamespaceMetodos;


            if (!string.IsNullOrEmpty(Param.Banco.Nome))
                groupBoxBancoDeDados.Enabled = false;

            foreach (var Tabela in Param.Banco.Tabelas)
            {
                dataGridViewTabelas.Rows.Add(Tabela.Nome, Tabela.NomeFormatado);
            }




        }

        private void buttonConectar_Click(object sender, EventArgs e)
        {

            var ListaBancos = new List<Banco>();
            var FormularioValido = true;

            if (string.IsNullOrEmpty(comboBoxTipoBanco.Text) || string.IsNullOrEmpty(textBoxServidor.Text) || string.IsNullOrEmpty(textBoxUsuario.Text) || string.IsNullOrEmpty(textBoxSenha.Text))
            {
                FormularioValido = false;
            }


            if (FormularioValido)
            {

                if (comboBoxTipoBanco.Text == "MsSQL")
                {
                    ListaBancos = Banco.MsSQLSelectAll(textBoxServidor.Text, textBoxUsuario.Text, textBoxSenha.Text);
                }
                else if (comboBoxTipoBanco.Text == "PostgreSQL")
                {
                    ListaBancos = Banco.PostgreSQLSelectAll(textBoxServidor.Text, textBoxUsuario.Text, textBoxSenha.Text);

                };



                if (ListaBancos.Count > 0)
                {

                    var Param = Parametros.Carregar();
                    Param.Banco.Tipo = comboBoxTipoBanco.Text;
                    Param.Banco.Servidor = textBoxServidor.Text;
                    Param.Banco.Usuario = textBoxUsuario.Text;
                    Param.Banco.Senha = textBoxSenha.Text;

                    if (Param.Salvar())
                    {
                        comboBoxTipoBanco.Enabled = false;
                        textBoxServidor.ReadOnly = true;
                        textBoxUsuario.ReadOnly = true;
                        textBoxSenha.Enabled = false;
                        buttonConectar.Enabled = false;
                    }

                    foreach (Banco banco in ListaBancos)
                    {
                        comboBoxBanco.Items.Add(banco.Nome);
                    }

                    MessageBox.Show("Conexão realizada e bancos de dados listados com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não foi possível listar os bancos de dados!");
                }

            }
            else
            {
                MessageBox.Show("Existem campos em branco!");

            }


        }

        private void buttonImportar_Click(object sender, EventArgs e)
        {

            var Param = Parametros.Carregar();


            var ListaTabelas = new List<Tabela>();
            var FormularioValido = true;


            if (string.IsNullOrEmpty(comboBoxBanco.Text))
            {
                FormularioValido = false;
            }


            if (FormularioValido)
            {

                Param.Banco.Nome = comboBoxBanco.Text;


                if (Param.Banco.Tipo == "MsSQL")
                {
                    ListaTabelas = Tabela.MsSQLSelectAll(Param.Banco);
                }
                else if (Param.Banco.Tipo == "PostgreSQL")
                {
                    ListaTabelas = Tabela.PostgreSQLSelectAll(Param.Banco);
                }

                Param.Banco.Tabelas = ListaTabelas;


                foreach (var Tabela in Param.Banco.Tabelas)
                {
                    dataGridViewTabelas.Rows.Add(Tabela.Nome, Tabela.NomeFormatado);
                    Tabela.Metodos = Metodo.GerarMetodosPadroes(Tabela);
                }

                comboBoxLinguagem.Text = "C#";
                Param.Linguagem.Nome = comboBoxLinguagem.Text;

                textBoxNameSpace.Text = comboBoxBanco.Text + "Db";
                Param.Linguagem.NamespaceMetodos = textBoxNameSpace.Text;


                if (Param.Salvar())
                {
                    comboBoxBanco.Enabled = false;
                    buttonImportar.Enabled = false;
                };
            }
            else
            {
                MessageBox.Show("O Banco de dados deve ser preenchido!");

            }



        }

        private void dataGridViewTabelas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewTabelas.Rows[e.RowIndex];

                var NomeTabela = row.Cells[1].Value.ToString();

                var Param = Parametros.Carregar();

                if (Param.Banco.Tabelas.Count > 0)
                {
                    var tabela = Param.Banco.Tabelas.Find(t => t.NomeFormatado == NomeTabela);

                    if (tabela != null)
                    {
                        if (dataGridViewColunas.Rows.Count > 0)
                            dataGridViewColunas.Rows.Clear();

                        foreach (Coluna coluna in tabela.Colunas)
                        {
                            dataGridViewColunas.Rows.Add(coluna.Nome, coluna.NomeFormatado, coluna.Tipo, coluna.Tamanho, coluna.PK, coluna.PermiteNulo);
                        }


                        if (dataGridViewMetodos.Rows.Count > 0)
                            dataGridViewMetodos.Rows.Clear();

                        foreach (Metodo metodo in tabela.Metodos)
                        {
                            dataGridViewMetodos.Rows.Add(metodo.Nome, metodo.DML);
                        }

                    }

                }

            }
        }

        private void dataGridViewColunas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var Param = Parametros.Carregar();

            if (e.RowIndex >= 0)
            {
                var row = dataGridViewTabelas.Rows[e.RowIndex];
                var NomeTabela = dataGridViewTabelas.SelectedCells[0].Value.ToString();
                var NomeColuna = dataGridViewColunas.SelectedCells[0].Value.ToString();

                var Coluna = Param.Banco.Tabelas.Find(t => t.Nome == NomeTabela).Colunas.Find(c => c.Nome == NomeColuna);

                var FormCadastro = new Form_Cadastro();
                FormCadastro.CarregarCadastro(Coluna);
            }
        }

        private void dataGridViewTabelas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var Param = Parametros.Carregar();

            if (e.RowIndex >= 0)
            {
                var row = dataGridViewTabelas.Rows[e.RowIndex];
                var NomeTabela = dataGridViewTabelas.SelectedCells[0].Value.ToString();

                var Tabela = Param.Banco.Tabelas.Find(t => t.Nome == NomeTabela);

                var FormCadastro = new Form_Cadastro();
                FormCadastro.CarregarCadastro(Tabela);
            }
        }


        private void comboBoxLinguagem_MouseLeave(object sender, EventArgs e)
        {
            var Param = Parametros.Carregar();
            Param.Linguagem.Nome = comboBoxLinguagem.Text;
            Param.Salvar();

        }

        private void textBoxNameSpace_MouseLeave(object sender, EventArgs e)
        {
            var Param = Parametros.Carregar();
            Param.Linguagem.NamespaceMetodos = textBoxNameSpace.Text;
            Param.Salvar();
        }

        private void buttonGerarClasse_Click(object sender, EventArgs e)
        {

            var Param = Parametros.Carregar();

            var NomeTabela = dataGridViewTabelas.SelectedCells[0].Value.ToString();

            var Tabela = Param.Banco.Tabelas.Find(t => t.Nome == NomeTabela);

            Classe.GerarClasse(Param, Tabela);

            if (MessageBox.Show("Abrir diretório?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start("Explorer", Application.StartupPath + @"\Classes\");
            }


        }

        private void buttonGerarClasses_Click(object sender, EventArgs e)
        {
            var Param = Parametros.Carregar();

            Classe.GerarClasses(Param);

            if (MessageBox.Show("Abrir diretório?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start("Explorer", Application.StartupPath + @"\Classes\");
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {

            //Finalizar implementação
            var Param = Parametros.Carregar();
            Param.Limpar();

            this.Dispose();

        }

        private void dataGridViewMetodos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var Param = Parametros.Carregar();

            if (e.RowIndex >= 0)
            {
                var row = dataGridViewTabelas.Rows[e.RowIndex];
                var NomeTabela = dataGridViewTabelas.SelectedCells[0].Value.ToString();
                var NomeMetodo = dataGridViewMetodos.SelectedCells[0].Value.ToString();

                var Tabela = Param.Banco.Tabelas.Find(t => t.Nome == NomeTabela);
                var Metodo = Tabela.Metodos.Find(m => m.Nome == NomeMetodo);

                //var FormCadastro = new Form_Cadastro();
                //Metodo = (Metodo)FormCadastro.CarregarCadastro(Metodo);


                foreach (var tbl in Param.Banco.Tabelas)
                {
                    if (tbl.Nome == NomeTabela)
                    {
                        foreach (var mtd in tbl.Metodos)
                        {
                            if (mtd.Nome == Metodo.Nome)
                            {
                                var FormCadastro = new Form_Cadastro();
                                Metodo = (Metodo)FormCadastro.CarregarCadastro(Metodo);

                                tbl.Metodos.Remove(mtd);
                                tbl.Metodos.Add(Metodo);
                                break;
                            }


                        }
                    }
                }

                Param.Salvar();

            }
        }
    }
}
