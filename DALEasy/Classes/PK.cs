using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DALEasy
{
    public class PK
    {
        public string Tabela { get; set; }
        public string Coluna { get; set; }
        public int Ordem { get; set; }


        public static List<PK> SelectAll(string Servidor, string Banco, string Login, string Senha)
        {
            List<PK> ListaPKs = new List<PK>();
            PK PK = new PK();

            SqlConnection conexaoMSDE = new SqlConnection();
            SqlCommand comandoSQL = new SqlCommand();
            conexaoMSDE = new SqlConnection("Initial Catalog='" + Banco + "';User ID='" + Login + "';Password='" + Senha + "';Data Source='" + Servidor + "'");
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



    }
}
