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
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public string NomeFormatado { get; set; }
        public bool PermiteNulo { get; set; }
        public bool PK { get; set; }
        public string Tipo { get; set; }

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
            var pks = tabela.PKs.FindAll(x => x.Coluna == this.Nome);

            if (pks.Count > 0)
                this.PK = true;



        }

        public string GerarTipoLinguagem(Parametros Param)
        {

            var TipoLinguagem = "";


            switch (this.Tipo)
            {
                case "bigint":
                    TipoLinguagem = "long";
                    break;

                case "binary":
                    TipoLinguagem = "byte[]";
                    if (Param.Linguagem.Nome == "VB.Net")
                        TipoLinguagem = "byte()";
                    break;

                case "bit":
                    TipoLinguagem = "bool";
                    if (this.Tipo == "VB.Net")
                        TipoLinguagem = "boolean";
                    break;

                case "char":
                    TipoLinguagem = "string";
                    break;

                case "date":
                    TipoLinguagem = "DateTime";
                    break;

                case "datetime":
                    TipoLinguagem = "DateTime";
                    break;

                case "datetime2":
                    TipoLinguagem = "DateTime";
                    break;

                case "datetime2(7)":
                    TipoLinguagem = "DateTime";
                    break;

                case "datetimeoffset":
                    TipoLinguagem = "DateTimeOffset";
                    break;

                case "decimal":
                    TipoLinguagem = "decimal";
                    break;

                case "float":
                    TipoLinguagem = "double";
                    break;

                case "image":
                    TipoLinguagem = "byte[]";
                    if (this.Tipo == "VB.Net")
                        TipoLinguagem = "byte()";

                    break;
                case "int":
                    TipoLinguagem = "int";

                    if (this.Tipo == "VB.Net")
                        TipoLinguagem = "integer";

                    break;
                case "money":
                    TipoLinguagem = "decimal";
                    break;
                case "nchar":
                    TipoLinguagem = "char";
                    break;
                case "ntext":
                    TipoLinguagem = "string";
                    break;
                case "numeric":
                    TipoLinguagem = "decimal";
                    break;
                case "nvarchar":
                    TipoLinguagem = "string";
                    break;
                case "real":
                    TipoLinguagem = "double";
                    break;
                case "smalldatetime":
                    TipoLinguagem = "DateTime";
                    break;
                case "smallint":
                    TipoLinguagem = "short";
                    break;
                case "smallmoney":
                    TipoLinguagem = "decimal";
                    break;
                case "text":
                    TipoLinguagem = "string";
                    break;
                case "time":
                    TipoLinguagem = "TimeSpan";
                    break;
                case "timestamp":
                    TipoLinguagem = "DateTime";
                    break;
                case "tinyint":
                    TipoLinguagem = "byte";
                    break;
                case "uniqueidentifier":
                    TipoLinguagem = "Guid";
                    break;
                case "varbinary":
                    TipoLinguagem = "byte[]";

                    if (this.Tipo == "VB.Net")
                        TipoLinguagem = "byte()";

                    break;
                case "varchar":
                    TipoLinguagem = "string";
                    break;
                case "UNKNOWN_":
                    TipoLinguagem = this.Tipo;
                    break;
            }

            //Validação para saber se deve ser adicionado ? na propriedade, que para o C# quer dizer que o valor permite nulo
            var ListaPermiteNula = new string[] { "bigint", "bit", "date", "datetime", "datetime2", "datetimeoffset", "decimal", "float", "int", "money", "numeric", "real", "smalldatetime", "smallint", "smallmoney", "time", "tinyint", "uniqueidentifier" };

            var TipoPermiteNulo = Array.Exists(ListaPermiteNula, e => e == this.Tipo);

            if (this.PermiteNulo && TipoPermiteNulo)
                TipoLinguagem += "?";

            return TipoLinguagem;


        }


        public string GerarPropriedade(Parametros Param)
        {

            var PropriedadeString = "";

            PropriedadeString = "public " + this.GerarTipoLinguagem(Param) + " " + this.NomeFormatado + " { get; set; }";

            if (Param.Linguagem.Nome == "VB.Net")
                PropriedadeString = "Public Property " + this.NomeFormatado + " As " + this.Tipo;


            return PropriedadeString;

        }


        public string GerarDataRead(Parametros Param, Tabela tabela)
        {

            var DataRead = "";

            if (this.Tipo.Contains("integer") || this.Tipo.Contains("int") || this.Tipo.Contains("double") || this.Tipo.Contains("decimal") || this.Tipo.Contains("long"))
            {
                DataRead = tabela.Nome + "." + this.NomeFormatado + " = !string.IsNullOrEmpty(dr[\"" + this.Nome + "\"].ToString())?(" + this.GerarTipoLinguagem(Param) + ")dr[\"" + this.Nome + "\"] : 0;";

                if (Param.Linguagem.Nome == "VB.Net")
                   DataRead = tabela.Nome + "." + this.NomeFormatado + " = If(Not String.IsNullOrEmpty(dr(\"" + this.Nome + "\").ToString()), CType(dr(\"" + this.Nome + "\"), " + this.GerarTipoLinguagem(Param) + "), 0)";

            }
            else if (this.Tipo.Contains("short"))
            {
                DataRead = tabela.Nome + "." + this.NomeFormatado + " = !string.IsNullOrEmpty(dr[\"" + this.Nome + "\"].ToString())?(" + this.GerarTipoLinguagem(Param) + ")dr[\"" + this.Nome + "\"] : new short();";

                if (Param.Linguagem.Nome == "VB.Net")
                    DataRead = tabela.Nome + "." + this.NomeFormatado + " = If(Not String.IsNullOrEmpty(dr(\"" + this.Nome + "\").ToString()), CType(dr(\"" + this.Nome + "\"), " + this.GerarTipoLinguagem(Param) + "), \"\")";

            }
            else if (this.Tipo.Contains("Date"))
            {
                DataRead = tabela.Nome + "." + this.NomeFormatado + " = !string.IsNullOrEmpty(dr[\"" + this.Nome + "\"].ToString())?(" + this.GerarTipoLinguagem(Param) + ")dr[\"" + this.Nome + "\"] : new DateTime();";

                if (Param.Linguagem.Nome == "VB.Net")
                    DataRead = tabela.Nome + "." + this.NomeFormatado + " = If(Not String.IsNullOrEmpty(dr(\"" + this.Nome + "\").ToString()), CType(dr(\"" + this.Nome + "\"), " + this.GerarTipoLinguagem(Param) + "), new DateTime())";

            }
            else if (this.Tipo.Contains("bool") || this.Tipo.Contains("bit"))
            {
                DataRead = tabela.Nome + "." + this.NomeFormatado + " = !string.IsNullOrEmpty(dr[\"" + this.Nome + "\"].ToString())?(" + this.GerarTipoLinguagem(Param) + ")dr[\"" + this.Nome + "\"] : false;";

                if (Param.Linguagem.Nome == "VB.Net")
                    DataRead = tabela.Nome + "." + this.NomeFormatado + " = If(Not String.IsNullOrEmpty(dr(\"" + this.Nome + "\").ToString()), CType(dr(\"" + this.Nome + "\"), " + this.GerarTipoLinguagem(Param) + "), False)";

            }
            else if (this.Tipo.Contains("Guid"))
            {
                DataRead = tabela.Nome + "." + this.NomeFormatado + " = !string.IsNullOrEmpty(dr[\"" + this.Nome + "\"].ToString())?(" + this.GerarTipoLinguagem(Param) + ")dr[\"" + this.Nome + "\"] : new Guid();";

                if (Param.Linguagem.Nome == "VB.Net")
                    DataRead = tabela.Nome + "." + this.NomeFormatado + " = If(Not String.IsNullOrEmpty(dr(\"" + this.Nome + "\").ToString()), CType(dr(\"" + this.Nome + "\"), " + this.GerarTipoLinguagem(Param) + "), New Guid())";

            }
            else if (this.Tipo.Contains("byte"))
            {
                DataRead = tabela.Nome + "." + this.NomeFormatado + " = !string.IsNullOrEmpty(dr[\"" + this.Nome + "\"].ToString())?(" + this.GerarTipoLinguagem(Param) + ")dr[\"" + this.Nome + "\"] : new byte[] { };";

                if (Param.Linguagem.Nome == "VB.Net")
                    DataRead = tabela.Nome + "." + this.NomeFormatado + " = If(Not String.IsNullOrEmpty(dr(\"" + this.Nome + "\").ToString()), CType(dr(\"" + this.Nome + "\"), " + this.GerarTipoLinguagem(Param) + "), New Byte() { })";

            }
            else if (this.Tipo.Contains("char") && this.Tipo != "nvarchar")
            {
                DataRead = tabela.Nome + "." + this.NomeFormatado + " = !string.IsNullOrEmpty(dr[\"" + this.Nome + "\"].ToString())?(" + this.GerarTipoLinguagem(Param) + ")dr[\"" + this.Nome + "\"] : new char();";
                if (Param.Linguagem.Nome == "VB.Net")
                    DataRead = tabela.Nome + "." + this.NomeFormatado + " = If(Not String.IsNullOrEmpty(dr(\"" + this.Nome + "\").ToString()), CType(dr(\"" + this.Nome + "\"), " + this.GerarTipoLinguagem(Param) + "), New Char())";

            }
            else
            {
                DataRead = tabela.Nome + "." + this.NomeFormatado + " = !string.IsNullOrEmpty(dr[\"" + this.Nome + "\"].ToString())?(" + this.GerarTipoLinguagem(Param) + ")dr[\"" + this.Nome + "\"] : \"\";";

                if (Param.Linguagem.Nome == "VB.Net")
                    DataRead = tabela.Nome + "." + this.NomeFormatado + " = If(Not String.IsNullOrEmpty(dr(\"" + this.Nome + "\").ToString()), CType(dr(\"" + this.Nome + "\"), " + this.GerarTipoLinguagem(Param) + "), \"\")";

            }

            return DataRead;


        }

    }
}
