using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetuxeToZwaki
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Program.setMenu(this);

        }



        private void playButton_Click(object sender, EventArgs e)
        {

            if (usernameTextBox.Text == null || usernameTextBox.Text == "" || usernameTextBox.Text.Equals("Enter Username"))
            {
                MessageBox.Show("Please enter a username first before continuing!");
                return;
            }

            if (!comboBox1.Text.Equals("Easy") && !comboBox1.Text.Equals("Normal") && !comboBox1.Text.Equals("Hard"))
            {
                MessageBox.Show("Please specify a correct difficulty!");
                return;
            }

            // Run if all the other checks are succeed
            Program.setDifficulty(comboBox1.SelectedIndex);
            MessageBox.Show("Good Luck!");

            // Get User Object and If null create
            User user = Program.getDataManager().getUser(usernameTextBox.Text);

            if (user == null)
            {
                user = new User(usernameTextBox.Text, 0);
                Program.getUsers().Add(user);
            }

            // Set score to 0
            user.setScore(0);

            // Set Global User Object
            Program.setUser(user);

            Hide();
            new Form1().Show();



        }

        private void usernameTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "Enter Username")
            {
                usernameTextBox.Text = "";
            }
        }

        // Open-Up Leaderboards
        private void toptenButton_Click(object sender, EventArgs e)
        {
                new LeaderboardsDb().Show();
            
        }


        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
