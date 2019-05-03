using AudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Audioplayer
{
    public class CompareHelper : IComparer<string> 
    {
        public int Compare(string x, string y) 
        {
            if (Convert.ToInt32(x[0]) < Convert.ToInt32(y[0])) 
            {
                return -1;
            }
            else if (Convert.ToInt32(x[0]) > Convert.ToInt32(y[0]))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    class Player
    {
        private int volume;
        public const int minVolume = 0;
        public const int maxVolume = 100;
        public bool isLock;
        private bool playing;
        public List<Song> songs; 
        public Random rnd = new Random();
        public CompareHelper Comp = new CompareHelper();
        public Skin SkinForm { get; set; }
        public Player()
        {

        }
        public Player(Skin skn)
        {
            SkinForm = skn;
        }
        public bool Playing
        {
            get
            {
                return playing;
            }
        }
         
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value < minVolume)
                {
                    volume = minVolume;
                }
                else if (value > maxVolume)
                {
                    volume = maxVolume;
                }
                else
                {
                    volume = value;
                }
            }

        }
        public void ParametrSong(params Song[] SongList)
        {
            foreach (Song item in SongList)
            {
                SkinForm.Render(item.title);
            }
        }
        public (string Title, bool IsNext, (int Sec, int Min, int Hour)) GetSongData(Song song) //L9-HW-Player-3/3. 
        { 
            var (str, boo, sec, min, hour) = song; 
            string s = str; 
            bool d = boo; 
            int f = sec; 
            int f1 = min; 
            int f2 = hour; 
            return (Title: s, IsNext:d, (Sec: f, Min: f1, Hour: f2)); 
        } 
        public void ListSong(List<Song> list)
        {
            foreach (Song item in list)
            {
               var tuple =  GetSongData(item);
                if (item.Like == true) { Console.ForegroundColor = ConsoleColor.Green; }
                else if (item.Like == false) { Console.ForegroundColor = ConsoleColor.Red; }
                else if (item.Like == null) { Console.ResetColor(); }
                string paramertString = $"{tuple.Title}, {item.songGenre} - {tuple.Item3.Hour}:{tuple.Item3.Min}:{tuple.Item3.Sec}";
                string outputString = paramertString.StringSeparator();
                SkinForm.Render(outputString);
            }
        }
        public void VolumeUp()
        {
            Volume = Volume + 1;
            SkinForm.Render($"Volume up {Volume}");

        }
        public void VolumeDown()
        {
            Volume = Volume - 1;
            SkinForm.Render("Volume " + Volume);
        }
        public void VolumeChange(int Step, string op)
        {
            if (op == "+")
            {
                SkinForm.Render($"up volume {Step}");
                Volume = Volume + Step;
            }
            else if (op == "-")
            {
                SkinForm.Render($"down volume {Step}");
                Volume = Volume - Step;
            }
        }
        public void Play(bool Loop = false) 
        {
            if (Loop == false) 
            {
                ShufleExtension.ExtenShufle(this, songs);
            }
            else 
            {
                for (int i = 0; i < 5; i++) 
                {
                    ShufleExtension.ExtenShufle(this, songs);
                }
            }
            if (playing == true)
            {
                SkinForm.Render("to Play has started");
                for (int i = 0; i < songs.Count; i++)
                {
                    SkinForm.Render(songs[i].title);
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }
        public void LyricsOutput() 
        {
            foreach (Song item in songs) 
            {
                SkinForm.Render($"{item.title} --- {item.lyrics}");
            }
        }
        public bool Stop()
        {
            if (isLock == false)
            {
                SkinForm.Render("Stop");
                playing = false;
            }
            return playing;
        }
        public bool Start()
        {
            if (isLock == false)
            {
                SkinForm.Render("Start");
                playing = true;
            }
            return playing;
        }
        public void Pause()
        {
        }
        public void Lock()
        {
            SkinForm.Render("Player is locked");
            isLock = true;
        }
        public void UnLock()
        {
            SkinForm.Render("Player is unlocked");
            isLock = false;
        }
        public void Load()
        {
        }
        public void Save()
        {
        }
    }
}