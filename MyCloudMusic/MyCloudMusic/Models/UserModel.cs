using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MyCloudMusic.Models
{
    public class UserModel : ObservableObject
    {
        private string userName;
        private string avatarUrl;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value; RaisePropertyChanged(() => UserName);
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
                avatarUrl = value; RaisePropertyChanged(() => AvatarUrl);
            }
        }

        public static implicit operator DataContext(UserModel v)
        {
            throw new NotImplementedException();
        }
    }
}
