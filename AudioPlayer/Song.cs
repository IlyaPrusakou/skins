using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audioplayer
{
    class Song
    {
        
        public int duration;
        public string title;
        public string songPath;
        public string lyrics;
        public Genres songGenre; 
        public Artist artist;
        public Album album;
        public Player player;
        public List<Playlist> playlists = new List<Playlist>();
        public bool IsNext { get; set; }
        public bool? Like { get; set; }
        public void LikeMethod()
        {
            Like = true;
        }
        public void DislikeMethod()
        {
            Like = false;
        }
        public void Deconstruct(out string str, out bool boo, out int sec, out int min, out int hour) //L9-HW-Player-3/3.
        { 
            str = title; //L9-HW-Player-3/3.
            boo = IsNext; //L9-HW-Player-3/3.
            sec = duration; //L9-HW-Player-3/3.
            min = sec / 60; //L9-HW-Player-3/3.
            hour = sec / 3600; //L9-HW-Player-3/3.
        } 
    }
}