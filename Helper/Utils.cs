using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace SendEmail.Helper
{
    public class Utils
    {
        public static string ReadFile(string path)
        {
            string receversList = string.Empty;
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                receversList = sr.ReadToEnd();
            }
            return receversList;
        }

        /// <summary>
        /// 按行读取，指定拼接字符
        /// </summary>
        /// <param name="path"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ReadByLine(string path, char c)
        {
            StringBuilder sb = new StringBuilder();
            string line = string.Empty;
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        sb.Append(line + c);
                }
            }

            return sb.Remove(sb.Length - 1, 1).ToString();
        }
    }
}