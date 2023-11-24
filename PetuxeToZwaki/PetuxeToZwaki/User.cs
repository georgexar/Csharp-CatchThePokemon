using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetuxeToZwaki
{
    public class User
    {
        private string name;
        private int score;


        public User(string name, int score)
        {
            this.name = name;
            this.score = score;
     
        }

        public string getName() { return this.name; }
        public int getScore() { return this.score; }
 
        public void setName(string name) { this.name = name; }
        public void setScore(int score) { this.score = score; }
    }
}
