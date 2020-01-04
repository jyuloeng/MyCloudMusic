using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MyCloudMusic.Models
{
    public class UserModel 
    {
        private string userName;    //  用户名称
        private string avatarUrl;   //  用户头像的url地址

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value; 
            }
        }

        public string AvatarUrl
        {
            get
            {
                return avatarUrl;
            }

            set
            {
                avatarUrl = value; 
            }
        }
    }
}
