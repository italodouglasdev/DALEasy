using System;
using System.Data.SqlClient;

namespace DALEasy
{
    class ConexaoSQL
    {

        public static string ExecutarSQL(string Servidor, string Banco, string Login, string Senha, string SQL)
        {
            SqlConnection conexaoMSDE = new SqlConnection();
            SqlCommand comandoSQL = new SqlCommand();
            conexaoMSDE = new SqlConnection("Initial Catalog='" + Banco + "';User ID='" + Login + "';Password='" + Senha + "';Data Source='" + Servidor + "'");
            comandoSQL.Connection = conexaoMSDE;
            comandoSQL.CommandText = SQL;

            try
            {
                conexaoMSDE.Open();

                return (string)comandoSQL.ExecuteScalar();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            finally
            {
                conexaoMSDE.Close();
            }
        }


    }
}
