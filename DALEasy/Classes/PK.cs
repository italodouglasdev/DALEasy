using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DALEasy
{
    public class PK
    {
        public string Tabela { get; set; }
        public string Coluna { get; set; }
        public int Ordem { get; set; }


        public static List<PK> SelectAllMsSQL(Banco banco)
        {
            List<PK> ListaPKs = new List<PK>();
            PK PK = new PK();

            SqlConnection conexaoMSDE = new SqlConnection();
            SqlCommand comandoSQL = new SqlCommand();
            conexaoMSDE = new SqlConnection("Initial Catalog='" + banco.Nome + "';User ID='" + banco.Usuario + "';Password='" + banco.Senha + "';Data Source='" + banco.Servidor + "'");
            comandoSQL.Connection = conexaoMSDE;
            comandoSQL.CommandText = "SELECT table_name AS Tabela, column_name AS Coluna, constraint_name AS [CONSTRAINT], constraint_schema AS [SCHEMA], ordinal_position AS Ordem FROM information_schema.key_column_usage WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 order by table_name, column_name";

            try
            {
                conexaoMSDE.Open();
                SqlDataReader dr;
                dr = comandoSQL.ExecuteReader();
                while (dr.Read())
                {

                    PK = new PK()
                    {
                        Tabela = !string.IsNullOrEmpty(dr["Tabela"].ToString()) ? (string)dr["Tabela"] : "",
                        Coluna = !string.IsNullOrEmpty(dr["Coluna"].ToString()) ? (string)dr["Coluna"] : "",
                        Ordem = !string.IsNullOrEmpty(dr["Ordem"].ToString()) ? (int)dr["Ordem"] : 0
                    };


                    ListaPKs.Add(PK);
                }

                return ListaPKs;

            }
            catch (Exception ex)
            {
                return ListaPKs;
            }

            finally
            {
                conexaoMSDE.Close();
            }
        }

        public static List<PK> SelectAllPostgreSQL(Banco banco)
        {
            List<PK> ListaPKs = new List<PK>();
            PK PK = new PK();

            NpgsqlConnection conexaoMSDE = new NpgsqlConnection();
            NpgsqlCommand comandoSQL = new NpgsqlCommand();
            conexaoMSDE = new NpgsqlConnection("Server=" + banco.Servidor + ";Port=5432;Database=" + banco.Nome + ";User Id=" + banco.Usuario + ";Password=" + banco.Senha + ";");
            comandoSQL.Connection = conexaoMSDE;
            comandoSQL.CommandText = "select kcu.table_name as \"Tabela\", kcu.column_name as \"Coluna\", kcu.ordinal_position as \"Ordem\" from information_schema.table_constraints tco join information_schema.key_column_usage kcu          on	kcu.constraint_name = tco.constraint_name	and kcu.constraint_schema = tco.constraint_schema	and kcu.constraint_name = tco.constraint_name where	tco.constraint_type = 'PRIMARY KEY' order by kcu.table_schema,	kcu.table_name;";

            try
            {
                conexaoMSDE.Open();
                NpgsqlDataReader dr;
                dr = comandoSQL.ExecuteReader();
                while (dr.Read())
                {

                    PK = new PK()
                    {
                        Tabela = !string.IsNullOrEmpty(dr["Tabela"].ToString()) ? (string)dr["Tabela"] : "",
                        Coluna = !string.IsNullOrEmpty(dr["Coluna"].ToString()) ? (string)dr["Coluna"] : "",
                        Ordem = !string.IsNullOrEmpty(dr["Ordem"].ToString()) ? (int)dr["Ordem"] : 0
                    };


                    ListaPKs.Add(PK);
                }

                return ListaPKs;

            }
            catch (Exception ex)
            {
                return ListaPKs;
            }

            finally
            {
                conexaoMSDE.Close();
            }
        }

    }
}
