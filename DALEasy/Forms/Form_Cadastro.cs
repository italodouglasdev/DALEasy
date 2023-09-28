using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALEasy
{
    public partial class Form_Cadastro : Form
    {
        public Form_Cadastro()
        {
            InitializeComponent();
        }


        private object Objeto { get; set; }

        private string NomeBanco { get; set; }

        private string NomeTabela { get; set; }

        public Object CarregarCadastro(object _Objeto, string _NomeBanco, string _NomeTabela)
        {
            Objeto = new object();
            Objeto = _Objeto;
            NomeBanco = _NomeBanco;
            NomeTabela = _NomeTabela;

            this.ShowDialog();

            return Objeto;

        }


        private void Form_Cadastro_Load(object sender, EventArgs e)
        {
            gboCadastro.CarregarDadosDoObjeto(Objeto);

        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja Salvar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (Objeto.GetType() == typeof(Tabela))
                {
                    var Tabela = (Tabela)Objeto;

                    gboCadastro.CarregarDadosParaObjeto(Tabela);

                    Tabela.AtualizarNaParametrizacao(Tabela);

                }
                else if (Objeto.GetType() == typeof(Coluna))
                {
                    var Coluna = (Coluna)Objeto;

                    gboCadastro.CarregarDadosParaObjeto(Coluna);

                    Coluna.AtualizarNaParametrizacao(Coluna, NomeTabela);

                }

                MessageBox.Show("Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

            }



        }


    }
}
