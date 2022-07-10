using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DALEasy   
{
  public  class Banco
    {
        public string Nome { get; set; }

        public string Servidor { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public TipoBanco Tipo { get; set; }

        public List<Tabela> Tabelas { get; set; }

        public static List<Banco> SelectAll(string Servidor, string Usuario, string Senha)
        {
            List<Banco> ListaBancos = new List<Banco>();
            Banco BancoDados = new Banco();

            SqlConnection conexaoMSDE = new SqlConnection();
            SqlCommand comandoSQL = new SqlCommand();
            conexaoMSDE = new SqlConnection("Initial Catalog='master';User ID='" + Usuario + "';Password='" + Senha + "';Data Source='" + Servidor + "'");
            comandoSQL.Connection = conexaoMSDE;
            comandoSQL.CommandText = "SELECT name as Nome FROM sys.databases;";

            try
            {
                conexaoMSDE.Open();
                SqlDataReader dr;
                dr = comandoSQL.ExecuteReader();
                while (dr.Read())
                {

                    BancoDados = new Banco()
                    {
                        Nome = !string.IsNullOrEmpty(dr["Nome"].ToString()) ? (string)dr["Nome"] : ""
                    };


                    ListaBancos.Add(BancoDados);
                }

                return ListaBancos;

            }
            catch (Exception ex)
            {
                return ListaBancos;
            }

            finally
            {
                conexaoMSDE.Close();
            }
        }


    }


    public enum TipoBanco
    {
        MsSQL,
        PostgreSQL
    }

}
