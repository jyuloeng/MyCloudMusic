using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models.JsonMvInfoObject
{
    //  mv详情实体类
    public class JsonMvUrlInfoObject
    {

        public int code { get; set; }

        public Data data { get; set; }
    }

    public class Data
    {

        public double id { get; set; }

        public string url { get; set; }

        public double r { get; set; }

        public double size { get; set; }

        public string md5 { get; set; }

        public double code { get; set; }

        public double expi { get; set; }

        public double fee { get; set; }
 
        public double mvFee { get; set; }

        public double st { get; set; }

        public string msg { get; set; }
    }

}
