using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALEasy
{
    public class Classe
    {

        public static void GerarClasses(Parametros Param)
        {
            foreach (var Tabela in Param.Banco.Tabelas)
                GerarClasse(Param, Tabela);
        }

        public static string GerarClasse(Parametros Param, Tabela tabela)
        {

            var Script = "";

            if (Param.Linguagem.Nome == "C#")
            {
                Script = GerarClasseCSharp(Param, tabela);
            }
            else if (Param.Linguagem.Nome == "VB.Net")
            {
                Script = GerarClasseVB(Param, tabela);
            }

            var dadosBytes = Encoding.UTF8.GetBytes(Script.ToString());


            if (!Directory.Exists(Application.StartupPath + @"\Classes"))
                Directory.CreateDirectory(Application.StartupPath + @"\Classes");

            if (Param.Linguagem.Nome == "C#")
            {
                File.WriteAllBytes(Application.StartupPath + @"\Classes\" + tabela.NomeFormatado + ".cs", dadosBytes);
            }
            else if (Param.Linguagem.Nome == "VB.Net")
            {
                File.WriteAllBytes(Application.StartupPath + @"\Classes\" + tabela.NomeFormatado + ".vb", dadosBytes);
            }

            return Script.ToString();


        }

        public static string GerarClasseCSharp(Parametros Param, Tabela tabela)
        {

            StringBuilder Script = new StringBuilder();

            Script.Append("using System; \n");
            Script.Append("using System.Collections.Generic; \n");

            if (Param.Banco.Tipo == "MsSQL")
            {
                Script.Append("using System.Data.SqlClient; \n");
            }
            if (Param.Banco.Tipo == "PostgreSQL")
            {
                Script.Append("using Npgsql; \n");
            }

   
       
            Script.Append("\n");
            Script.Append("namespace " + Param.Linguagem.NamespaceMetodos + " \n");
            Script.Append("{ \n");
            Script.Append("public class " + tabela.NomeFormatado + " \n");
            Script.Append("{ \n");


            foreach (Coluna coluna in tabela.Colunas)
            {
                Script.Append(coluna.GerarPropriedade(Param) + " \n");
            }


            foreach (var metodo in tabela.Metodos)
            {
                Script.Append(" \n");
                Script.Append(" \n");

                if (metodo.RetornaLista == true)
                {
                    Script.Append(" public static List<" + tabela.NomeFormatado + "> " + metodo.Nome + "() { \n");
                }
                else
                {
                    if (metodo.DML == "SELECT")
                    {
                        Script.Append(" public static " + tabela.NomeFormatado + " " + metodo.Nome + "(" + tabela.GerarParametros(Param, metodo) + ") { \n");
                    }
                    else
                    {
                        Script.Append(" public " + tabela.NomeFormatado + " " + metodo.Nome + "() { \n");
                    }
                }

                if (metodo.RetornaLista == true)
                    Script.Append("List<" + tabela.NomeFormatado + "> Lista" + tabela.NomeFormatado + " = new List<" + tabela.NomeFormatado + ">(); \n");

                Script.Append("" + tabela.NomeFormatado + " " + tabela.NomeFormatado + " = new " + tabela.NomeFormatado + "(); \n");


                if (Param.Banco.Tipo == "MsSQL")
                {
                    Script.Append(" SqlConnection conexaoMSDE = new SqlConnection(); \n");
                    Script.Append(" SqlCommand comandoSQL = new SqlCommand(); \n");
                    Script.Append(" conexaoMSDE = new SqlConnection(\"Initial Catalog=" + Param.Banco.Nome + "; User ID=" + Param.Banco.Usuario + "; Password=" + Param.Banco.Senha + "; Data Source=" + Param.Banco.Servidor + "\"); \n");
                    Script.Append(" comandoSQL.Connection = conexaoMSDE; \n");
                    Script.Append(" comandoSQL.CommandText = \"" + tabela.GerarComandoMsSQL(Param, metodo) + "\"; \n");
                    Script.Append(" try \n");
                    Script.Append(" { \n");
                    Script.Append(" conexaoMSDE.Open(); \n");
                    Script.Append(" SqlDataReader dr; \n");
                    Script.Append(" dr = comandoSQL.ExecuteReader(); \n");
                }
                if (Param.Banco.Tipo == "PostgreSQL")
                {
                    Script.Append(" NpgsqlConnection conexaoMSDE = new NpgsqlConnection(); \n");
                    Script.Append(" NpgsqlCommand comandoSQL = new NpgsqlCommand(); \n");
                    Script.Append(" conexaoMSDE = new NpgsqlConnection(\"Database=" + Param.Banco.Nome + "; User Id=" + Param.Banco.Usuario + "; Password=" + Param.Banco.Senha + "; Port=5432; Server=" + Param.Banco.Servidor + "\"); \n");
                    Script.Append(" comandoSQL.Connection = conexaoMSDE; \n");
                    Script.Append(" comandoSQL.CommandText = \"" + tabela.GerarComandoPostgreSQL(Param, metodo) + "\"; \n");
                    Script.Append(" try \n");
                    Script.Append(" { \n");
                    Script.Append(" conexaoMSDE.Open(); \n");
                    Script.Append(" NpgsqlDataReader dr; \n");
                    Script.Append(" dr = comandoSQL.ExecuteReader(); \n");
                }



                if (metodo.RetornaLista == true)
                {
                    Script.Append(" while (dr.Read()) \n");
                    Script.Append(" { \n");
                }
                else
                {
                    Script.Append(" dr.Read(); \n");
                }

                Script.Append(" \n");

                foreach (Coluna coluna in tabela.Colunas)
                {
                    Script.Append(coluna.GerarDataRead(Param, tabela) + " \n");
                }

                Script.Append(" \n");

                if (metodo.RetornaLista == true)
                {
                    Script.Append(" Lista" + tabela.NomeFormatado + ".Add(" + tabela.NomeFormatado + "); \n");
                    Script.Append(" } \n");
                }

                Script.Append(" \n");

                if (metodo.RetornaLista == true)
                {
                    Script.Append(" return Lista" + tabela.NomeFormatado + "; \n");
                }
                else
                {
                    Script.Append(" return " + tabela.NomeFormatado + "; \n");
                }


                Script.Append(" } \n");
                Script.Append(" catch (Exception ex) \n");
                Script.Append(" { \n");

                if (metodo.RetornaLista == true)
                {
                    Script.Append(" return Lista" + tabela.NomeFormatado + "; \n");
                }
                else
                {
                    Script.Append(" return " + tabela.NomeFormatado + "; \n");
                }

                Script.Append(" } \n");
                Script.Append(" finally \n");
                Script.Append(" { \n");
                Script.Append(" conexaoMSDE.Close(); \n");
                Script.Append(" } \n");
                Script.Append(" } \n");

            }

            Script.Append("} \n");
            Script.Append("}\n");
            Script.Append(" \n");

            return Script.ToString();


        }

        public static string GerarClasseVB(Parametros Param, Tabela tabela)
        {

            StringBuilder Script = new StringBuilder();

            Script.Append("Imports System \n");
            Script.Append("Imports System.Collections.Generic \n");
            Script.Append("Imports System.Data.SqlClient \n");
            Script.Append("\n");
            Script.Append("Namespace " + Param.Linguagem.NamespaceMetodos + " \n");
            Script.Append("\n");
            Script.Append("Public Class " + tabela.NomeFormatado + " \n");
            Script.Append("\n");


            foreach (Coluna coluna in tabela.Colunas)
            {
                Script.Append(coluna.GerarPropriedade(Param) + " \n");
            }


            foreach (var metodo in tabela.Metodos)
            {
                Script.Append(" \n");
                Script.Append(" \n");

                if (metodo.RetornaLista == true)
                {
                    Script.Append(" Public Shared Function [" + metodo.Nome + "] (" + tabela.GerarParametros(Param, metodo) + ") as List(Of " + tabela.NomeFormatado + ") \n");
                }
                else
                {
                    if (metodo.DML == "SELECT")
                    {
                        Script.Append(" Public Shared Function [" + metodo.Nome + "] (" + tabela.GerarParametros(Param, metodo) + ") as " + tabela.NomeFormatado + " \n");
                    }
                    else
                    {
                        Script.Append(" Public Function " + metodo.Nome + " (" + tabela.GerarParametros(Param, metodo) + ") as " + tabela.NomeFormatado + " \n");

                    }
                }

                if (metodo.RetornaLista == true)
                    Script.Append("Dim Lista" + tabela.NomeFormatado + " = new List(Of " + tabela.NomeFormatado + ") \n");

                Script.Append("Dim " + tabela.NomeFormatado + " = new " + tabela.NomeFormatado + "() \n");

                Script.Append(" Dim conexaoMSDE = new SqlConnection() \n");
                Script.Append(" Dim comandoSQL = new SqlCommand() \n");
                Script.Append(" conexaoMSDE = new SqlConnection(\"Initial Catalog=" + Param.Banco.Nome + "; User ID=" + Param.Banco.Usuario + "; Password=" + Param.Banco.Senha + "; Data Source=" + Param.Banco.Servidor + "\") \n");
                Script.Append(" comandoSQL.Connection = conexaoMSDE \n");
                Script.Append(" comandoSQL.CommandText = \"" + tabela.GerarComandoMsSQL(Param, metodo) + "\"\n");
                Script.Append(" \n");
                Script.Append(" Try \n");
                Script.Append(" conexaoMSDE.Open() \n");
                Script.Append(" Dim dr As SqlDataReader \n");
                Script.Append(" dr = comandoSQL.ExecuteReader() \n");

                if (metodo.RetornaLista == true)
                {
                    Script.Append(" While dr.Read() \n");
                }
                else
                {
                    Script.Append(" dr.Read() \n");
                }

                Script.Append(" \n");

                foreach (Coluna coluna in tabela.Colunas)
                {
                    Script.Append(coluna.GerarDataRead(Param, tabela) + " \n");
                }

                Script.Append(" \n");

                if (metodo.RetornaLista == true)
                {
                    Script.Append(" Lista" + tabela.NomeFormatado + ".Add(" + tabela.NomeFormatado + ") \n");
                    Script.Append(" End While\n");
                }

                Script.Append(" \n");

                if (metodo.RetornaLista == true)
                {
                    Script.Append(" Return Lista" + tabela.NomeFormatado + " \n");
                }
                else
                {
                    Script.Append(" Return " + tabela.NomeFormatado + " \n");
                }

                Script.Append(" Catch ex As Exception \n");


                if (metodo.RetornaLista == true)
                {
                    Script.Append(" Return Lista" + tabela.NomeFormatado + " \n");
                }
                else
                {
                    Script.Append(" Return " + tabela.NomeFormatado + " \n");
                }

                Script.Append(" Finally \n");
                Script.Append(" conexaoMSDE.Close() \n");
                Script.Append(" End Try \n");
                Script.Append(" End Function \n");

            }

            Script.Append("End Class \n");
            Script.Append("End Namespace \n");
            Script.Append(" \n");


            return Script.ToString();


        }

    }
}
