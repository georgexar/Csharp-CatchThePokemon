using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetuxeToZwaki
{
    internal static class Program
    {

        // Managers
        private static DataManager dataManager;
        private static LocationManager locationManager;
        private static FileManager fileManager;

        // HashSets & Lists
        private static HashSet<User> USERS;
        private static HashSet<Location> LOCATIONS;

        // Objects
        private static User user;
        private static PictureBox pokemon;
        private static PictureBox bomb;
        private static Form menu;


        // Attributes
        private static int difficulty = 0;
        public static string leaderboards = "";
        public static bool useDatabase;
        public static int orderPos = 0;


        public static void Main()
        {

            init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
             
        }

        private static void init()
        {
            // Load Lists & HashSets
            USERS = new HashSet<User>();
            LOCATIONS = new HashSet<Location>();


            // Load Managers
            loadManagers();

        }

        private static void loadManagers()
        {
            dataManager = new DataManager();
            locationManager = new LocationManager();
            fileManager = new FileManager();
        }


        public static DataManager getDataManager() { return dataManager; }
        public static LocationManager getLocationManager() { return locationManager; }
        public static FileManager getFileManager() { return fileManager; }
        public static HashSet<User> getUsers() { return USERS; }
        public static HashSet<Location> getLocations() { return LOCATIONS; }
        public static Form getMenu() { return menu; }
        public static User getUser() { return user; }
        public static void setUser(User a) { user = a; }
        public static PictureBox getPokemon() { return pokemon; }
        public static void setPokemon(PictureBox pictureBox) { pokemon = pictureBox; }

        public static PictureBox getBomb() { return bomb; }
        public static void setBomb(PictureBox pictureBox) { bomb = pictureBox; }
        public static void setDifficulty(int diff) { difficulty = diff; }
        public static int getDifficulty() { return difficulty; }

        public static void setMenu(Form a)
        {
            menu = a;
        }


    }
}
