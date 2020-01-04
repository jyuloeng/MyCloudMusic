using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    public class Music_Num
    {
        private string num = "0";
        public string Num
        {
            get
            {
                return "共" +num+"首";
            }
            set
            {
                num = value;

            }

        }
    }
}
