using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Tabela.GerarListaPKs(banco.Servidor, banco.Nome, banco.Usuario, banco.Senha);
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

        private void GerarNomeFormatado()
        {

            this.NomeFormatado = Util.RemoverCaracteresEspeciais(this.Nome);
        }

        private void GerarListaPKs(string Servidor, string Banco, string Login, string Senha)
        {

            this.PKs = new List<PK>();
            this.PKs = PK.SelectAll(Servidor, Banco, Login, Senha).FindAll(x => x.Tabela == this.Nome);

            this.Nome = this.Nome;

        }

    }
}
