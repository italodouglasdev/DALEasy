using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEasy
{
    public class Coluna
    {
        public string Nome { get;  set; }
        public int Tamanho { get;  set; }
        public string NomeFormatado { get;  set; }
        public bool PermiteNulo { get;  set; }
        public bool PK { get;  set; }
        public string Tipo { get;  set; }

        public Coluna Clone()
        {
            return (Coluna)this.MemberwiseClone();
        }

        public static List<Coluna> MsSQLSelectAll(Banco banco, Tabela Tabela)
        {

            var ListaColunas = new List<Coluna>();
            var Coluna = new Coluna();

            SqlConnection conexaoMSDE = new SqlConnection();
            SqlCommand comandoSQL = new SqlCommand();
            conexaoMSDE = new SqlConnection("Initial Catalog='" + banco.Nome + "';User ID='" + banco.Usuario + "';Password='" + banco.Senha + "';Data Source='" + banco.Servidor + "'");
            comandoSQL.Connection = conexaoMSDE;
            comandoSQL.CommandText = "SELECT COLUMN_NAME as Nome, DATA_TYPE as Tipo, CHARACTER_MAXIMUM_LENGTH as Tamanho, IS_NULLABLE as PermiteNulo from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME= '" + Tabela.Nome + "'";

            try
            {
                conexaoMSDE.Open();
                SqlDataReader dr;
                dr = comandoSQL.ExecuteReader();
                while (dr.Read())
                {

                    Coluna = new Coluna()
                    {
                        Nome = !string.IsNullOrEmpty(dr["Nome"].ToString()) ? (string)dr["Nome"] : "",
                        Tipo = !string.IsNullOrEmpty(dr["Tipo"].ToString()) ? (string)dr["Tipo"] : null,
                        Tamanho = !string.IsNullOrEmpty(dr["Tamanho"].ToString()) ? (int)dr["Tamanho"] : 0,
                    };

                    Coluna.GerarNomeFormatado();
                    Coluna.VeriricarPk(Tabela);

                    if ((!string.IsNullOrEmpty(dr["PermiteNulo"].ToString()) ? (string)dr["PermiteNulo"] : "NO") == "YES")
                    {
                        Coluna.PermiteNulo = true;
                    }
                    else
                    {
                        Coluna.PermiteNulo = false;
                    }


                    ListaColunas.Add(Coluna);
                }

                return ListaColunas;

            }
            catch (Exception ex)
            {
                return ListaColunas;
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

        private void VeriricarPk(Tabela tabela)
        {
            var pks = tabela.ListaPKs.FindAll(x => x.Coluna == this.Nome);

            if (pks.Count > 0)
            {
                this.PK = true;
                //this.FiltroSelect = true;

                //this.FiltroInsert = true;
                //this.FiltroUpdate = true;
                //this.FiltroDelete = true;
            }

        }

    }
}
