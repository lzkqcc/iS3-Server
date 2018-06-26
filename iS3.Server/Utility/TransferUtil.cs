using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.Utility
{
    public class TransferUtil
    {
        public static int[] stringToInts(string s)
        {
            string[] ss = s.Split(',');
            int[] res = new int[ss.Length];
            for(int i = 0; i < ss.Length; i++)
            {
                res[i] = Int32.Parse(ss[i]);
            }
            return res;
        }
    }
}