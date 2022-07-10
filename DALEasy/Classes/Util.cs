using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DALEasy
{
    public class Util
    {
        public static string RemoverCaracteresEspeciais(string source)
        {

            if (string.IsNullOrEmpty(source))
                return "";

            var encodeEightBit = Encoding.GetEncoding(1251).GetBytes(source);
            var stringSevenBits = Encoding.UTF8.GetString(encodeEightBit);
            var regex = new Regex("[^a-zA-Z0-9]=-_/ºª");
            var retotno = regex.Replace(stringSevenBits, " ");
            return retotno.Replace(" ", "_").Replace("?", "").Replace("º", "").Replace("ª", "");
        }



        public static string FormatMoney(decimal? Valor)
        {
            return Convert.ToString(Valor).Replace(".", "").Replace(", ", ".");
        }


    }
}