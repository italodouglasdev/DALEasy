﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                if (!Directory.Exists(Application.StartupPath + @"\Parametros"))
                    Directory.CreateDirectory(Application.StartupPath + @"\Parametros");

                File.WriteAllText(Application.StartupPath + @"\Parametros\Parametros.json", JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented));

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

                return false;
            }

        }

        public static Parametros Carregar()
        {
            var Param = new Parametros();
            Param.Banco = new Banco();
            Param.Banco.Tabelas = new List<Tabela>();

            try
            {
                var Json = File.ReadAllText(Application.StartupPath + @"\Parametros\Parametros.json");
                Param = JsonConvert.DeserializeObject<Parametros>(Json);


                if (Param.Banco == null)
                    Param.Banco = new Banco();

                if (Param.Banco.Tabelas == null)
                    Param.Banco.Tabelas = new List<Tabela>();


                return Param;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return Param;
            }

        }

    }
}