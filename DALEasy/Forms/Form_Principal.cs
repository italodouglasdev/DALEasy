using System;
using System.Collections.Generic;
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
                    MessageBox.Show("Finalizar");
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
                else if (Param.Banco.Tipo == "MsSQL")
                {

                }


                Param.Banco.Tabelas = ListaTabelas;


                if (Param.Salvar())
                {
                    comboBoxBanco.Enabled = false;
                    buttonImportar.Enabled = false;
                };


                foreach (var Tabela in Param.Banco.Tabelas)
                {
                    dataGridViewTabelas.Rows.Add(Tabela.Nome, Tabela.NomeFormatado);
                }

            }
            else
            {
                MessageBox.Show("O Banco de dados deve ser preenchido!");

            }



        }
    }
}
