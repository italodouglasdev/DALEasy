using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DALEasy
{
    public class Util
    {
        public static string RemoverCaracteresEspeciais(string source)
        {

            if (string.IsNullOrEmpty(source))
                return "";

            var encodeEightBit = Encoding.GetEncoding(1251).GetBytes(source);
            var stringSevenBits = Encoding.UTF8.GetString(encodeEightBit);
            var regex = new Regex("[^a-zA-Z0-9]=-_/ºª");
            var retotno = regex.Replace(stringSevenBits, " ");
            return retotno.Replace(" ", "_").Replace("?", "").Replace("º", "").Replace("ª", "");
        }



        public static string FormatMoney(decimal? Valor)
        {
            return Convert.ToString(Valor).Replace(".", "").Replace(", ", ".");
        }


        public static void ResetarFormulario(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }
            }
        }


    }
}