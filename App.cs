using System;
using System.IO;
using iBoxDB.LocalServer;

namespace Game
{
    using Game.Models;
    public class App
    {
        public static AutoBox Auto;
        public static String[] Roms;

        public static IDatabase Start()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "GameDB");
            Directory.CreateDirectory(path);
            Console.WriteLine("DBPath: " + path);

            DB.Root(path);
            DB db = new DB(1L);
            db.GetConfig().EnsureTable<User>("User", "ID")
            .EnsureUpdateIncrementIndex<User>("User", "Ver");

            Auto = db.Open();

            var temp = Directory.GetFiles(
                Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "roms"), "*.nes");
            Roms = new string[temp.Length];
            for (int i = 0; i < Roms.Length; i++)
            {
                Roms[i] = Path.GetFileName(temp[i]);
            }
            Console.WriteLine("Roms: " + DB.ToString(Roms));
            if (Roms.Length == 0)
            {
                var src = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Copy .nes(s) to ./wwwroot/roms");
                Console.ForegroundColor = src;
                Roms = new string[]{""};
            }
            return Auto.GetDatabase();
        }
    }
}