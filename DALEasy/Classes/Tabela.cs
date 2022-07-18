using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALEasy
{
    public class Tabela
    {
        public string Nome { get; set; }

        public string NomeFormatado { get; set; }

        public string NomeBanco { get; set; }

        public List<Coluna> Colunas { get; set; }

        public List<PK> PKs { get; set; }

        public List<Metodo> Metodos { get; set; }


        public Tabela Clone()
        {
            return (Tabela)this.MemberwiseClone();
        }

        public static List<Tabela> MsSQLSelectAll(Banco banco)
        {
            var ListaTabelas = new List<Tabela>();
            var Tabela = new Tabela();

            SqlConnection conexaoMSDE = new SqlConnection();
            SqlCommand comandoSQL = new SqlCommand();
            conexaoMSDE = new SqlConnection("Initial Catalog='" + banco.Nome + "';User ID='" + banco.Usuario + "';Password='" + banco.Senha + "';Data Source='" + banco.Servidor + "'");
            comandoSQL.Connection = conexaoMSDE;
            comandoSQL.CommandText = "SELECT Table_Name as Nome FROM information_schema.tables order by Table_Name;";

            try
            {
                conexaoMSDE.Open();
                SqlDataReader dr;
                dr = comandoSQL.ExecuteReader();
                while (dr.Read())
                {

                    Tabela = new Tabela()
                    {
                        Nome = !string.IsNullOrEmpty(dr["Nome"].ToString()) ? (string)dr["Nome"] : ""

                    };

                    Tabela.NomeBanco = banco.Nome;
                    Tabela.GerarNomeFormatado();
                    Tabela.GerarListaPKsMsSQL(banco);
                    Tabela.Colunas = Coluna.MsSQLSelectAll(banco, Tabela);
                    ListaTabelas.Add(Tabela);
                }

                return ListaTabelas;

            }
            catch (Exception ex)
            {
                return ListaTabelas;
            }

            finally
            {
                conexaoMSDE.Close();
            }
        }

        public static List<Tabela> PostgreSQLSelectAll(Banco banco)
        {
            var ListaTabelas = new List<Tabela>();
            var Tabela = new Tabela();


            NpgsqlConnection conexaoMSDE = new NpgsqlConnection();
            NpgsqlCommand comandoSQL = new NpgsqlCommand();
            conexaoMSDE = new NpgsqlConnection("Server=" + banco.Servidor + ";Port=5432;Database=" + banco.Nome + ";User Id=" + banco.Usuario + ";Password=" + banco.Senha + ";");
            comandoSQL.Connection = conexaoMSDE;
            comandoSQL.CommandText = "SELECT table_name as \"Nome\" FROM information_schema.tables WHERE table_schema = 'public' order by table_name;";


            try
            {
                conexaoMSDE.Open();
                NpgsqlDataReader dr;
                dr = comandoSQL.ExecuteReader();
                while (dr.Read())
                {

                    Tabela = new Tabela()
                    {
                        Nome = !string.IsNullOrEmpty(dr["Nome"].ToString()) ? (string)dr["Nome"] : ""

                    };

                    Tabela.NomeBanco = banco.Nome;
                    Tabela.GerarNomeFormatado();
                    Tabela.GerarListaPKsPostgreSQL(banco);
                    Tabela.Colunas = Coluna.PostgreSQLSelectAll(banco, Tabela);

                    ListaTabelas.Add(Tabela);
                }

                return ListaTabelas;

            }
            catch (Exception ex)
            {
                return ListaTabelas;
            }

            finally
            {
                conexaoMSDE.Close();
            }
        }

        public string GerarParametros(Parametros Param, Metodo metodo)
        {
            StringBuilder Script = new StringBuilder();

            var ListaColunasWHERE = this.Colunas.FindAll(c => metodo.ListaColunasWHERE.Any(cm => c.Nome == cm));

            foreach (Coluna coluna in ListaColunasWHERE)
            {
                if (Param.Linguagem.Nome == "C#")
                {
                    Script.Append("" + coluna.GerarTipoLinguagem(Param) + " " + coluna.NomeFormatado.ToLower() + "");
                    if (ListaColunasWHERE.IndexOf(coluna) != ListaColunasWHERE.Count - 1)
                        Script.Append(" ");
                }
                else if (Param.Linguagem.Nome == "VB.Net")
                {
                    Script.Append("" + coluna.NomeFormatado.ToLower() + " as " + coluna.GerarTipoLinguagem(Param) + "");
                    if (ListaColunasWHERE.IndexOf(coluna) != ListaColunasWHERE.Count - 1)
                        Script.Append(" ");
                }

            }

            return Script.ToString();

        }

        private void GerarNomeFormatado()
        {

            this.NomeFormatado = Util.RemoverCaracteresEspeciais(this.Nome);
        }

        private void GerarListaPKsMsSQL(Banco banco)
        {

            this.PKs = new List<PK>();

            this.PKs = PK.SelectAllMsSQL(banco).FindAll(x => x.Tabela == this.Nome);

            this.Nome = this.Nome;

        }

        private void GerarListaPKsPostgreSQL(Banco banco)
        {

            this.PKs = new List<PK>();

            this.PKs = PK.SelectAllPostgreSQL(banco).FindAll(x => x.Tabela == this.Nome);


            this.Nome = this.Nome;

        }

        public string GerarComandoMsSQL(Parametros Param, Metodo metodo)
        {
            StringBuilder Script = new StringBuilder();

            Script.Append(metodo.DML + " ");

            if (metodo.DML == "SELECT")
            {

                var ListaColunas = this.Colunas.FindAll(c => metodo.ListaColunas.Any(cm => c.Nome == cm));

                foreach (Coluna coluna in ListaColunas)
                {
                    Script.Append("[" + coluna.Nome + "]");
                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append(", ");

                }

                Script.Append(" FROM [" + this.Nome + "] ");


                var ListaColunasWHERE = this.Colunas.FindAll(c => metodo.ListaColunasWHERE.Any(cm => c.Nome == cm));

                if (ListaColunasWHERE.Count > 0)
                {
                    Script.Append("WHERE ");
                    foreach (Coluna coluna in ListaColunasWHERE)
                    {
                        Script.Append("[" + coluna.Nome + "] = '\" + " + coluna.NomeFormatado.ToLower() + " + \"'");
                        if (ListaColunasWHERE.IndexOf(coluna) != ListaColunasWHERE.Count - 1)
                            Script.Append(" AND ");
                    }
                }

            }
            else if (metodo.DML == "SELECTALL")
            {

                var ListaColunas = this.Colunas.FindAll(c => metodo.ListaColunas.Any(cm => c.Nome == cm));

                foreach (Coluna coluna in ListaColunas)
                {
                    Script.Append("[" + coluna.Nome + "]");
                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append(", ");

                }

                Script.Append(" FROM [" + this.Nome + "] ");


                var ListaColunasWHERE = this.Colunas.FindAll(c => metodo.ListaColunasWHERE.Any(cm => c.Nome == cm));

                if (ListaColunasWHERE.Count > 0)
                {
                    Script.Append("WHERE ");
                    foreach (Coluna coluna in ListaColunasWHERE)
                    {
                        Script.Append("[" + coluna.Nome + "] =  '\" + " + coluna.Nome + " + \"'");
                        if (ListaColunasWHERE.IndexOf(coluna) != ListaColunasWHERE.Count - 1)
                            Script.Append(" AND ");
                    }
                }

            }
            else if (metodo.DML == "INSERT")
            {

                Script.Append("INTO [" + this.Nome + "] (");

                var ListaColunas = this.Colunas.FindAll(c => metodo.ListaColunas.Any(cm => c.Nome == cm));

                foreach (Coluna coluna in ListaColunas)
                {
                    Script.Append("[" + coluna.Nome + "]");
                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append(", ");
                }

                Script.Append(") OUTPUT ");

                foreach (Coluna coluna in ListaColunas)
                {
                    Script.Append("Inserted.[" + coluna.Nome + "] ");


                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append("Inserted.[" + coluna.Nome + "], ");

                }

                Script.Append(" VALUES (");

                foreach (Coluna coluna in ListaColunas)
                {
                    if (coluna.Tipo.Contains("decimal") == true)
                    {
                        Script.Append("'\" + Util.FormatMoney(" + coluna.NomeFormatado + ") + \"'");
                    }
                    else
                    {
                        Script.Append("'\" + " + coluna.NomeFormatado + " + \"'");
                    }

                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append(", ");
                }

                Script.Append(")");

            }
            else if (metodo.DML == "UPDATE")
            {
                Script.Append("[" + this.Nome + "] SET ");

                var ListaColunas = this.Colunas.FindAll(c => metodo.ListaColunas.Any(cm => c.Nome == cm));

                foreach (Coluna coluna in ListaColunas)
                {

                    if (coluna.Tipo.Contains("decimal") == true)
                    {
                        Script.Append("[" + coluna.Nome + "] = '\" + Util.FormatMoney(" + coluna.NomeFormatado + ") + \"'");
                    }
                    else
                    {
                        Script.Append("[" + coluna.Nome + "] = '\" + " + coluna.NomeFormatado + " + \"'");
                    }

                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append(", ");
                }

                var ListaColunasWHERE = this.Colunas.FindAll(c => metodo.ListaColunasWHERE.Any(cm => c.Nome == cm));

                if (ListaColunasWHERE.Count > 0)
                {
                    Script.Append(" WHERE ");
                    foreach (Coluna coluna in ListaColunasWHERE)
                    {
                        Script.Append("[" + coluna.Nome + "] =  '\" + this." + coluna.Nome + " + \"'");
                        if (ListaColunasWHERE.IndexOf(coluna) != ListaColunasWHERE.Count - 1)
                            Script.Append(" AND ");
                    }
                }

            }
            else if (metodo.DML == "DELETE")
            {

                var ListaColunasWHERE = this.Colunas.FindAll(c => metodo.ListaColunasWHERE.Any(cm => c.Nome == cm));

                Script.Append("FROM [" + this.Nome + "]");

                if (ListaColunasWHERE.Count > 0)
                {
                    Script.Append(" WHERE ");
                    foreach (Coluna coluna in ListaColunasWHERE)
                    {
                        Script.Append("[" + coluna.Nome + "] =  '\" + this." + coluna.Nome + " + \"'");
                        if (ListaColunasWHERE.IndexOf(coluna) != ListaColunasWHERE.Count - 1)
                            Script.Append(" AND ");
                    }
                }
            }

            Script.Append(";");

            if (Param.Linguagem.Nome == "VB.Net")
                Script.Replace("this.", "Me.").Replace("+", "&");

            return Script.ToString();

        }

        public string GerarComandoPostgreSQL(Parametros Param, Metodo metodo)
        {
            StringBuilder Script = new StringBuilder();

            Script.Append(metodo.DML + " ");

            if (metodo.DML == "SELECT")
            {

                var ListaColunas = this.Colunas.FindAll(c => metodo.ListaColunas.Any(cm => c.Nome == cm));

                foreach (Coluna coluna in ListaColunas)
                {
                    Script.Append("\\\"" + coluna.Nome + "\\\"");
                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append(", ");

                }

                Script.Append(" FROM \\\"" + this.Nome + "\\\" ");


                var ListaColunasWHERE = this.Colunas.FindAll(c => metodo.ListaColunasWHERE.Any(cm => c.Nome == cm));

                if (ListaColunasWHERE.Count > 0)
                {
                    Script.Append("WHERE ");
                    foreach (Coluna coluna in ListaColunasWHERE)
                    {
                        Script.Append("\\\"" + coluna.Nome + "\\\" = '\" + " + coluna.NomeFormatado.ToLower() + " + \"'");
                        if (ListaColunasWHERE.IndexOf(coluna) != ListaColunasWHERE.Count - 1)
                            Script.Append(" AND ");
                    }
                }

            }
            else if (metodo.DML == "SELECTALL")
            {

                var ListaColunas = this.Colunas.FindAll(c => metodo.ListaColunas.Any(cm => c.Nome == cm));

                foreach (Coluna coluna in ListaColunas)
                {
                    Script.Append("\\\"" + coluna.Nome + "\\\"");
                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append(", ");

                }

                Script.Append(" FROM \\\"" + this.Nome + "\\\" ");


                var ListaColunasWHERE = this.Colunas.FindAll(c => metodo.ListaColunasWHERE.Any(cm => c.Nome == cm));

                if (ListaColunasWHERE.Count > 0)
                {
                    Script.Append("WHERE ");
                    foreach (Coluna coluna in ListaColunasWHERE)
                    {
                        Script.Append("\\\"" + coluna.Nome + "\\\" =  '\" + " + coluna.Nome + " + \"'");
                        if (ListaColunasWHERE.IndexOf(coluna) != ListaColunasWHERE.Count - 1)
                            Script.Append(" AND ");
                    }
                }

            }
            else if (metodo.DML == "INSERT")
            {

                Script.Append("INTO \\\"" + this.Nome + "\\\" (");

                var ListaColunas = this.Colunas.FindAll(c => metodo.ListaColunas.Any(cm => c.Nome == cm));

                foreach (Coluna coluna in ListaColunas)
                {
                    Script.Append("\\\"" + coluna.Nome + "\\\"");
                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append(", ");
                }

                Script.Append(") ");

                Script.Append(" VALUES (");

                foreach (Coluna coluna in ListaColunas)
                {
                    if (coluna.Tipo.Contains("decimal") == true)
                    {
                        Script.Append("'\" + Util.FormatMoney(" + coluna.NomeFormatado + ") + \"'");
                    }
                    else
                    {
                        Script.Append("'\" + " + coluna.NomeFormatado + " + \"'");
                    }

                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append(", ");
                }

                Script.Append(")  RETURNING *");

            }
            else if (metodo.DML == "UPDATE")
            {
                Script.Append("\\\"" + this.Nome + "\\\" SET ");

                var ListaColunas = this.Colunas.FindAll(c => metodo.ListaColunas.Any(cm => c.Nome == cm));

                foreach (Coluna coluna in ListaColunas)
                {

                    if (coluna.Tipo.Contains("decimal") == true)
                    {
                        Script.Append("\\\"" + coluna.Nome + "\\\" = '\" + Util.FormatMoney(" + coluna.NomeFormatado + ") + \"'");
                    }
                    else
                    {
                        Script.Append("\\\"" + coluna.Nome + "\\\" = '\" + " + coluna.NomeFormatado + " + \"'");
                    }

                    if (ListaColunas.IndexOf(coluna) != ListaColunas.Count - 1)
                        Script.Append(", ");
                }

                var ListaColunasWHERE = this.Colunas.FindAll(c => metodo.ListaColunasWHERE.Any(cm => c.Nome == cm));

                if (ListaColunasWHERE.Count > 0)
                {
                    Script.Append(" WHERE ");
                    foreach (Coluna coluna in ListaColunasWHERE)
                    {
                        Script.Append("\\\"" + coluna.Nome + "\\\" =  '\" + this." + coluna.Nome + " + \"'");
                        if (ListaColunasWHERE.IndexOf(coluna) != ListaColunasWHERE.Count - 1)
                            Script.Append(" AND ");
                    }
                }

            }
            else if (metodo.DML == "DELETE")
            {

                var ListaColunasWHERE = this.Colunas.FindAll(c => metodo.ListaColunasWHERE.Any(cm => c.Nome == cm));

                Script.Append("FROM \\\"" + this.Nome + "\\\"");

                if (ListaColunasWHERE.Count > 0)
                {
                    Script.Append(" WHERE ");
                    foreach (Coluna coluna in ListaColunasWHERE)
                    {
                        Script.Append("\\\"" + coluna.Nome + "\\\" =  '\" + this." + coluna.Nome + " + \"'");
                        if (ListaColunasWHERE.IndexOf(coluna) != ListaColunasWHERE.Count - 1)
                            Script.Append(" AND ");
                    }
                }
            }

            Script.Append(";");

            if (Param.Linguagem.Nome == "VB.Net")
                Script.Replace("this.", "Me.").Replace("+", "&");

            return Script.ToString();

        }

    }
}
