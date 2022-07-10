using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace DALEasy
{
    public class Parametros
    {     

        public Banco Banco { get; set; }

        


        public bool Salvar()
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + @"\config"))
                    Directory.CreateDirectory(Application.StartupPath + @"\config");

                File.WriteAllText(Application.StartupPath + @"\config\Configuracao.json", JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented));

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

                return false;
            }

        }

        public static Config Carregar()
        {
            var config = new Config();

            try
            {       
                var Json = File.ReadAllText(Application.StartupPath + @"\config\Configuracao.json");
                config = JsonConvert.DeserializeObject<Config>(Json);
                return config;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return config;
            }            

        }

    }
}
