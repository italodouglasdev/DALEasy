using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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


        public object Objeto { get; set; }

        public Object CarregarCadastro(object _Objeto)
        {
            Objeto = new object();
            Objeto = _Objeto;

            this.ShowDialog();

            return Objeto;
            
        }


        private void Form_Cadastro_Load(object sender, EventArgs e)
        {
            var PropIndex = 0;
            foreach (var property in Objeto.GetType().GetProperties())
            {
                PropIndex += 1;
                var PropNome = property.Name;
                var PropTipo = property.PropertyType.Name;
                var PropValor = property.GetValue(Objeto, null).ToString();


                Cadastro.AlterarFonteLabel(false, false, Color.Black);

                if (PropTipo.ToLower() == "string")
                {
                    Cadastro.AddTextBox(PropNome, PropIndex, PropNome, false, PropValor);
                }
                else if (PropTipo.ToLower() == "int32")
                {
                    Cadastro.AddNumericUpDown(PropNome, PropIndex, PropNome, "", 0, 0, 5000, Convert.ToDecimal(PropValor));
                }
                else if (PropTipo.ToLower() == "boolean")
                {
                    var Bolean = bool.Parse(PropValor);

                    Cadastro.AddCheckBox(PropNome, PropIndex, null, PropNome, Bolean);
                }

            }
          

        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            var Param = Parametros.Carregar();

            this.Close();


        }
    }
}
