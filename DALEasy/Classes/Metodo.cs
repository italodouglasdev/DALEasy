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

        public string DML { get; set; }

        public List<string> ListaColunas { get; set; }

        public List<string> ListaColunasWHERE { get; set; }

        public bool RetornaLista { get; set; }



        public static List<Metodo> GerarMetodosPadroes(Tabela tabela)
        {
            var ListaMetodosPadroes = new List<Metodo>();

            var MetodoSelect = new Metodo();
            MetodoSelect.Nome = "Select";
            MetodoSelect.DML = "SELECT";
            MetodoSelect.RetornaLista = false;
            MetodoSelect.ListaColunas = new List<string>();
            MetodoSelect.ListaColunasWHERE = new List<string>();

            foreach (var Coluna in tabela.Colunas)            
                MetodoSelect.ListaColunas.Add(Coluna.Nome);

            foreach (var Coluna in tabela.Colunas.FindAll(c => c.PK == true))
                MetodoSelect.ListaColunasWHERE.Add(Coluna.Nome);

            ListaMetodosPadroes.Add(MetodoSelect);

            var MetodoSelectAll = new Metodo();
            MetodoSelectAll.Nome = "SelectAll";
            MetodoSelectAll.DML = "SELECT";
            MetodoSelectAll.RetornaLista = true;
            MetodoSelectAll.ListaColunas = new List<string>();
            MetodoSelectAll.ListaColunasWHERE = new List<string>();

            foreach (var Coluna in tabela.Colunas)
                MetodoSelectAll.ListaColunas.Add(Coluna.Nome);

            //foreach (var Coluna in tabela.Colunas.FindAll(c => c.PK == true))
            //    MetodoSelectAll.ListaColunasWHERE.Add(Coluna.Nome);

            ListaMetodosPadroes.Add(MetodoSelectAll);

            var MetodoInsert = new Metodo();
            MetodoInsert.Nome = "Insert";
            MetodoInsert.DML = "INSERT";
            MetodoInsert.RetornaLista = false;
            MetodoInsert.ListaColunas = new List<string>();
            MetodoInsert.ListaColunasWHERE = new List<string>();

            foreach (var Coluna in tabela.Colunas)
                MetodoInsert.ListaColunas.Add(Coluna.Nome);

            foreach (var Coluna in tabela.Colunas.FindAll(c => c.PK == true))
                MetodoInsert.ListaColunasWHERE.Add(Coluna.Nome);

            ListaMetodosPadroes.Add(MetodoInsert);

            var MetodoUpdate = new Metodo();
            MetodoUpdate.Nome = "Update";
            MetodoUpdate.DML = "UPDATE";
            MetodoUpdate.RetornaLista = false;
            MetodoUpdate.ListaColunas = new List<string>();
            MetodoUpdate.ListaColunasWHERE = new List<string>();

            foreach (var Coluna in tabela.Colunas)
                MetodoUpdate.ListaColunas.Add(Coluna.Nome);

            foreach (var Coluna in tabela.Colunas.FindAll(c => c.PK == true))
                MetodoUpdate.ListaColunasWHERE.Add(Coluna.Nome);

            ListaMetodosPadroes.Add(MetodoUpdate);

            var MetodoDelete = new Metodo();
            MetodoDelete.Nome = "Delete";
            MetodoDelete.DML = "DELETE";
            MetodoDelete.RetornaLista = false;
            MetodoDelete.ListaColunas = new List<string>();
            MetodoDelete.ListaColunasWHERE = new List<string>();

            foreach (var Coluna in tabela.Colunas)
                MetodoDelete.ListaColunas.Add(Coluna.Nome);

            foreach (var Coluna in tabela.Colunas.FindAll(c => c.PK == true))
                MetodoDelete.ListaColunasWHERE.Add(Coluna.Nome);

            ListaMetodosPadroes.Add(MetodoDelete);

            return ListaMetodosPadroes;
        }
    }
}
