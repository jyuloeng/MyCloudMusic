using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyCloudMusic.Utils
{
    public class MusicPlayer
    {
        public static string Url = "";  //  播放url地址
        private static MusicPlayer instance = null; //  单例对象
        private static MediaPlayer player = null;  //  播放器对象

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">url地址</param>
        private MusicPlayer(string url)
        {
            player = new MediaPlayer();
            player.Open(new Uri(url, UriKind.Absolute));
        }

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static MusicPlayer GetInstance(string url)
        {
            if (instance == null)
            {
                instance = new MusicPlayer(url);
                Url = url;
            }
            return instance;
        }

        /// <summary>
        /// 清空单例
        /// </summary>
        /// <returns></returns>
        public static MusicPlayer ResetInstance(string url)
        {
            if (url != Url)
            {
                instance = null;
            }

            if (player != null)
            {
                _Stop();
            }
            return instance;
        }

        //  供内部使用，停止播放
        public static void _Stop()
        {
            player.Stop();
        }

        //  播放
        public void Play()
        {
            player.Play();
        }

        //  暂停
        public void Pause()
        {
            player.Pause();
        }

        //  获得歌曲总时间
        public double GetDuration()
        {
            TimeSpan t = player.NaturalDuration.TimeSpan;
            return t.TotalSeconds;
        }

        //  获得歌曲的总分钟数
        public int GetSongTimeMinutes()
        {
            TimeSpan t = player.NaturalDuration.TimeSpan;
            return t.Minutes;
        }

        //  获得歌曲的总秒数
        public int GetSongTimeSeconds()
        {
            TimeSpan t = player.NaturalDuration.TimeSpan;
            return t.Seconds;
        }

        //  获得歌曲当前播放时间
        public TimeSpan GetPosition()
        {
            return player.Position;
        }

        //  设置歌曲当前播放时间
        public void SetPosition(double pos)
        {
            player.Position = TimeSpan.FromSeconds(pos);
        }

        //  获得歌曲声音
        public double GetVolume()
        {
            return player.Volume;
        }

        //  设置歌曲声音
        public void SetVolume(double volume)
        {
            player.Volume = volume;
        }
    }
}
