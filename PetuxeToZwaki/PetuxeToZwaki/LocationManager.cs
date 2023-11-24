using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PetuxeToZwaki
{
    public class LocationManager
    {

        private Random random;
        private int lastLocationId;

        public LocationManager()
        {
            // Initialize objects
            random = new Random();


            // Initialize all Locations ( --= Hard Coded =-- (psttt. bad use..))
            Program.getLocations().Add(new Location(1, 134, 77));
            Program.getLocations().Add(new Location(2, 520, 74));
            Program.getLocations().Add(new Location(3, 924, 77));
            Program.getLocations().Add(new Location(4, 346, 240));
            Program.getLocations().Add(new Location(5, 739, 234));
            Program.getLocations().Add(new Location(6, 145, 407));
            Program.getLocations().Add(new Location(7, 530, 407));
            Program.getLocations().Add(new Location(8, 930, 409));


            Console.WriteLine("Locations were loaded successfully!");


        }


        // Apply a new location to the pokemon
        public void applyLocation()
        {


            if(!Program.getPokemon().Visible)
            {
                Program.getPokemon().Visible = true;
            }

            // Difficulty [2] which is the hard difficulty
            if (Program.getDifficulty() == 2)
            {

                int a = random.Next(0, 4);

                if(a == 1)
                {
                    // Summon the bomb
                    Location location = getRandomLocation();
                    lastLocationId = location.getId();
                    Program.getPokemon().Visible = false;
                    Program.getBomb().Visible = true;
                    Program.getBomb().Location = new Point(location.getX(), location.getY());

                }
                else
                {

                    // Turn off the bomb
                    if (Program.getBomb().Visible)
                    {
                        Program.getBomb().Visible = false;
                    }

                    // Get a random Location 
                    Location location = getRandomLocation();

                    // Save Location Id (for next location)
                    lastLocationId = location.getId();

                    // Apply Location to the pokemon
                    Program.getPokemon().Location = new Point(location.getX(), location.getY());

                }
                
  

            } // Difficulty [0-1]
            else
            {

                // Turn off the bomb
                if(Program.getBomb().Visible)
                {
                    Program.getBomb().Visible = false;
                }

                // Get a random Location 
                Location location = getRandomLocation();

                // Save Location Id (for next location)
                lastLocationId = location.getId();

                // Apply Location to the pokemon
                Program.getPokemon().Location = new Point(location.getX(), location.getY());
            }

            }

            public Location getRandomLocation()
        {
            Location location;

            int randomId;
            do
            {
                randomId = random.Next(1, 9);

            } while (randomId == lastLocationId);

            location = getLocationById(randomId);
            return location;
        }

        public Location getLocationById(int id)
        {
            foreach(Location locations in Program.getLocations())
            {
                if(locations.getId().Equals(id))
                {
                    return locations;
                }
            }
            return null;
        }
    }
}
