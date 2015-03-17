using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Reflection;

namespace EnviaNomina
{
    public static class Extension
    {
        public static string RemoveAccents(this string text)
        {
            //var normalizedString = text.Normalize(NormalizationForm.FormD);
            //var stringBuilder = new StringBuilder();

            //foreach (var c in normalizedString)
            //{
            //    var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            //    if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            //    {
            //        stringBuilder.Append(c);
            //    }
            //}
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(text);
            string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
            return asciiStr;
            //return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string[] RemoveAccents(this string[] text)
        {
            int idx = 0;
            foreach (var item in text)
            {
                byte[] tempBytes;
                tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(item);
                string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
                text[idx] = asciiStr;
                idx++;
            }
            return text;
        }

        public static string FormatDate(this string date, string format)
        {
            DateTime dt = Convert.ToDateTime(date);
            return dt.ToString(format);
        }
    }
}
