using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherEWT.Tools
{
    internal class PassToToken
    {
        string key = "20171109124536982017110912453698";
        string offset = "2017110912453698";

        public static string GetPKCS7(string s)
        {
            byte[] s_b = Encoding.UTF8.GetBytes(s);
            string bs = Encoding.UTF8.GetString(s_b);
            int fillnum = 16;
            int count = fillnum - bs.Length;
            int c = 0;
            if (count == 0)
                c = 16;
            else c = count;
            for(int i = 0; i <= c; i++)
            {
                bs = bs + i.ToString();
            }
            return bs;
        }
        public static string ToToken(string password)
        {
            
        }
    }
}
