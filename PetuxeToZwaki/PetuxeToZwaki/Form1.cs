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
    public partial class Form1 : Form
    {

        private int duration = 60;
        private int tick = 850;
        public Form1()
        {
            InitializeComponent();
        }

        // Form load
        private void Form1_Load(object sender, EventArgs e)
        {

            startGame();

        }

        private void startGame()
        {

            // Set Game Difficulty
            Program.setDifficulty(Program.getDifficulty());

            // Instanciate Objects
            Program.setPokemon(pictureBox1);
            Program.setBomb(pictureBox2);

            // Fix tick based on game difficulty
            switch(Program.getDifficulty())
            {
                case 0:
                    tick = 1700;
                    break;

                case 1:
                    tick = 1150;
                    break;

                case 2:
                    tick = 800;
                    break;
            }

            // Initialize the Timer based on game difficulty ( Random Positions Tick )
            timer1.Interval = tick;
            timer1.Enabled = true;
            timer1.Start();

            // Initialize the Game Duration counter Timer
            gameDurationTimer.Interval = 1000;
            gameDurationTimer.Enabled = true;
            gameDurationTimer.Start();

            // Initialize the Score Updater
            updateScoreTimer.Interval = 100;
            updateScoreTimer.Enabled = true;
            updateScoreTimer.Start();


            // Apply a random location and show this shitty pokemon
            Program.getLocationManager().applyLocation();
            // Init timer

        }


        // Event of pokego click
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
            // Update Score when player clicks pokemon
            int score = Program.getUser().getScore();
            Program.getUser().setScore(score + 1);
            label1.Text = "Score: " + score;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Program.getLocationManager().applyLocation();
        }

        // Event of bomb click
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            User user = Program.getUser();
            int score = user.getScore();
            int deduct = 3;

            if (score - deduct < 0)
            {
                user.setScore(0);

            }
            else
            {
                user.setScore(score - deduct);
            }
        }

        // Update Score & Duration Counter every 1 second
        private void gameDurationTimer_Tick(object sender, EventArgs e)
        {
            duration--;
            label1.Text = "Score: " + Program.getUser().getScore();
            gameDurationLabel.Text = "Time Left: " + duration + " sec(s)";
            

            if(duration <= 0)
            {
                

                // New Form (End Form)
                Hide();
                Program.getMenu().Show();

                gameDurationTimer.Enabled = false;
                timer1.Enabled = false;
                updateScoreTimer.Enabled = false;

                stopGame();
                


            }

        }

        private void stopGame()
        { 
            // Save Data
            Program.getFileManager().saveUsers();

            duration = 0;
            updateScoreTimer.Stop();
            timer1.Stop();
            gameDurationTimer.Stop();

            MessageBox.Show("Game over!");


        }

        private void updateScoreTimer_Tick(object sender, EventArgs e)
        {
            User user = Program.getUser();
            label1.Text = "Score: " + user.getScore();
        }
    }
}
