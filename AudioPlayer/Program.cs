using AudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Audioplayer
{
    static class ShufleExtension 
    {
        public static Random rndAA = new Random(); 
        public static CompareHelper Comp = new CompareHelper(); 
        public static List<Song> ExtenShufle(this Player player, List<Song> oldList) 
        {  

            List<Song> newList = new List<Song>(); 

            for (int i = 0; i < oldList.Count + 1000; i++) 
            { 
                int index = rndAA.Next(0, oldList.Count); 
                if (!newList.Contains(oldList[index])) 
                { 
                    newList.Add(oldList[index]); 
                } 
                else if (newList.Contains(oldList[index])) 
                { 
                    continue; 
                } 
            } 
            return newList; 
        } 
        public static List<Song> ExtenSortByTitle(this Player player, List<Song> oldList)  
        { 
            List<Song> sortedSongsList = new List<Song>();  
            List<string> titleList = new List<string>();  
            foreach (Song item in oldList)  
            { 
                titleList.Add(item.title);  
            } 
            titleList.Sort(Comp); 
            foreach (string item in titleList) { player.SkinForm.Render("rrr  " + item); } //WriteLine("rrr  " + item)
            for (int i = 0; i < titleList.Count; i++)  
            { 
                foreach (Song t in oldList) 
                { 
                    if (titleList[i] == t.title) 
                    { 
                        sortedSongsList.Add(t); 
                    } 
                    else if (titleList[i] != t.title) 
                    { 
                        continue; 
                    } 
                } 
            } 
            return sortedSongsList; 
        } 
    } 
    public static class StringExtension 
    { 
        public static string StringSeparator(this string str) 
        { 
            string sInsert = str.Insert(13, "^Nnn"); 
            string[] separ = { "^Nnn" }; 
            string[] sss = sInsert.Split(separ, StringSplitOptions.None); 
            string lastvar = sss[0] + "..."; 
            return lastvar; 
        } 
    } 
    [Flags] 
    public enum Genres 
    { 
        Pop = 1, Rock = 2, Metal = 4, Electro = 8  
    } 
    class Program
    {
        
        public static int TotalDur;
        public static string Prop = "s";
        public static int CreateSong(List<Song> s, ref int xshort, ref int ylong, out string _shortname, out string _longname)
        {
            Random rnd = new Random();
            _shortname = Prop;
            _longname = Prop;
            for (int i = 0; i < s.Count; i++)
            {
                
                s[i] = new Song();
                s[i].title = "songN" + i;
                WriteLine(s[i].title);
                s[i].duration = rnd.Next(500);
                WriteLine(s[i].duration);
                TotalDur = TotalDur + s[i].duration;
                WriteLine($"iteration {i} " + TotalDur);
                if (s[i].duration < xshort)
                {
                    xshort = s[i].duration;
                    _shortname = s[i].title;
                }
                if (s[i].duration > ylong)
                {
                    ylong = s[i].duration;
                    _longname = s[i].title;
                }
            }
            WriteLine(xshort + " " + _shortname);
            WriteLine(ylong + " " + _longname);
            return TotalDur;
        }
        
        public static string GeneratorRandomStrings()
            
        {
            Random rndgen = new Random();
            string randomstring = "s";
            for (int i = 1; i < 5; i++)
            {
                randomstring = randomstring + Convert.ToString((char)rndgen.Next(100));
            }
            WriteLine("Result random generate" + randomstring);
            return randomstring;
        }
        
        public static Song InitSong()
        {
            Random rndDefault = new Random();
            Song defaultsong = new Song();
            defaultsong.title = GeneratorRandomStrings();
            defaultsong.duration = rndDefault.Next(500);
            defaultsong.album = new Album ();
            defaultsong.artist = new Artist();
            defaultsong.lyrics = GeneratorRandomStrings();
            defaultsong.songPath = GeneratorRandomStrings();
            defaultsong.playlists = new List<Playlist>();
            return defaultsong;
        }
        public static Song InitSong(string _name)
        {
            var defsong = InitSong();
            defsong.title = _name;
            return defsong;
        }
        public static Song InitSong(string _title, int dur, Album _album, Artist _artist, string _lyrics, List<Playlist> _playlist)
        {
            Song initsong = new Song();
            initsong.title = _title;
            initsong.duration = dur;
            initsong.album = _album;
            initsong.artist = _artist;
            initsong.lyrics = _lyrics;
            initsong.songPath = GeneratorRandomStrings();
            initsong.playlists = _playlist;
            return initsong;
        }
        
        public static Artist AddArtist(string _name = "unknown artist")
        {
            Artist artist = new Artist();
            artist.name = _name;
            return artist;
        }
        public static Album AddAlbum(string _name = "unknown album", int _year = 0)
        {
            Album album = new Album();
            album.name = _name;
            album.year = _year;
            return album;
        }
        public static List<Song> FilterByGenres(List<Song> songs, Genres genre) 
        { 
            List<Song> FilterdList = new List<Song>(); 
            IEnumerable<Song> selectedSongs = from t in songs  
                                              where (t.songGenre & genre) == genre  
                                              select t; 
            foreach (Song t in selectedSongs) 
            { 
                    FilterdList.Add(t);  
            } 
            return FilterdList; 
        } 
        static void Main(string[] args)
        {
            ColorSkin ColorSkn = new ColorSkin(ConsoleColor.Blue); //A.L2.Player1/1
            ClassicSkin ClassicSkn = new ClassicSkin();  //A.L2.Player1/1
            Player player = new Player(ColorSkn); //A.L2.Player1/1
            player.songs = new List<Song>(); 
            for (int i = 0; i < 25; i++) 
            {
                player.songs.Add(new Song { title = i + "sssssssssss", IsNext=false, duration = 540, songGenre=Genres.Pop });

                if (i == 8 || i == 7 || i == 23 || i == 24) { player.songs[i].songGenre = Genres.Rock | Genres.Pop; }
                if (i == 1 || i == 2 || i == 20 || i == 13) { player.songs[i].songGenre = Genres.Rock | Genres.Pop | Genres.Electro; }
                if (i == 3 || i == 5 || i == 15 || i == 22) { player.songs[i].songGenre = Genres.Rock | Genres.Metal; }

                if (i == 3 || i == 7 || i == 23) { player.songs[i].LikeMethod(); }  
                if (i == 5 || i == 8 || i == 22 || i == 21) { player.songs[i].DislikeMethod(); } 
            }
            Genres testfilter = Genres.Rock | Genres.Pop; 
            List<Song> ListAfterFilter = FilterByGenres(player.songs, testfilter); 
            player.ListSong(ListAfterFilter); 
            // B5-Player2/10. Fields.
            Song song1 = new Song();
            song1.duration = 300;
            song1.title = "Cvet nastroenia sinii";
            //song1.songGenre = "Metal";
            song1.lyrics = "lalala";
            song1.artist = new Artist{name = "Kirkorov"};

            // B5-Player2/10. Fields.
            Song song2 = new Song();
            song2.duration = 300;
            song2.title = "Anaconda";
            //song2.songGenre = "Pop";
            song2.lyrics = "lalala";
            song2.artist = new Artist
            {
                name = "Minaj",
                band = new Band
                {
                    bandYear = 1988,
                    isExist = true
                }
            };
            song2.album = new Album
            {
                name = "MinajAlbum",
                path = "pathAlbum",
                year = 1988
            };
            
            song2.artist.band.bandTitle = "MinajBand";
            

            WriteLine("Now we try to use your keyboard");

            
            while (true)
            {
                switch (ReadLine())
                {
                    case "a":
                        {
                            player.VolumeUp();
                            break;
                        }
                    case "s":
                        {
                            player.VolumeDown();
                            break;
                        }
                    case "d":
                        {
                            player.Play();
                            break;
                        }
                    case "q":
                        {
                            player.Lock();
                            break;
                        }
                    case "w":
                        {
                            player.UnLock();
                            break;
                        }
                    case "e":
                        {
                            player.Start();
                            break;
                        }
                    case "r":
                        {
                            player.Stop();
                            break;
                        }

                }
            }



            ReadLine();
        }
    }
}