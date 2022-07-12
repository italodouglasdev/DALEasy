using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEasy
{
    public class Metodo
    {

        public string Nome { get; set; }

        //DML - Linguagem de Manipulação de Dados
        //INSERT / UPDATE / DELETE
        public string DML { get; set; }
        
        public List<string> ListaColunas { get; set; }

        public List<string> ListaColunasWHERE { get; set; }



        public static List<Metodo> GerarMetodosPadroes()
        {
            var ListaMetodosPadroes = new List<Metodo>();

            var MetodoSelect = new Metodo();
            MetodoSelect.DML = "SELEC";
            MetodoSelect.Nome = "Select";
            //MetodoSelect.


            return ListaMetodosPadroes;
        }
    }
}
