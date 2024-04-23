using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        Graphics g;

        SolidBrush darkGreenBrush = new SolidBrush(Color.DarkGreen);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush solidBrush = new SolidBrush(Color.White);

        Image sourceImage = Properties.Resources.Bird;

        SoundPlayer birdSoundEffect = new SoundPlayer(Properties.Resources.Cinematic_Eagle_Cry_Sound_Effect);
        SoundPlayer nationalAnthem = new SoundPlayer(Properties.Resources.National_Anthem);
        private Font Font(int fontSize)
        {
            Font font = new Font("Arial", 1 + fontSize, FontStyle.Bold);

            return font;
        }

        private void Background(int yTranslation)
        {
            g.FillRectangle(darkGreenBrush, 0, -yTranslation, 71, 500);
            g.FillRectangle(yellowBrush, 71, yTranslation, 71, 500);
            g.FillRectangle(redBrush, 142, -yTranslation, 71, 500);
            g.FillRectangle(blackBrush, 213, yTranslation, 71, 500);
            g.FillRectangle(redBrush, 284, -yTranslation, 71, 500);
            g.FillRectangle(yellowBrush, 355, yTranslation, 71, 500);
            g.FillRectangle(darkGreenBrush, 426, -yTranslation, 71, 500);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            for (int i = 500; i >= 0; i -= 5)
            {
                g.Clear(Color.White);

                Background(i);

                Thread.Sleep(5);
            }

            for (int i = 0; i <= 30; i++)
            {
                g.Clear(Color.White);

                Background(0);

                g.DrawString("Click to open card", Font(i), solidBrush, 70, i);

                Thread.Sleep(10);
            }

            Thread.Sleep(1000);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            birdSoundEffect.Play();

            for (int i = 500; i >= 50; i -= 5)
            {
                g.Clear(Color.White);

                Background(0);
                g.DrawImage(sourceImage, 95, i);

                Thread.Sleep(5);
            }

            string happyBirthdayFullText = "Happy birthday Zimbabwe!";
            string happyBirthdayCurrent = "";

            for (int i = 0; i < happyBirthdayFullText.Length; i++)
            {
                happyBirthdayCurrent += happyBirthdayFullText[i];
                g.DrawString(happyBirthdayCurrent, Font(20), solidBrush, 75, 350);

                Thread.Sleep(10);
            }

            nationalAnthem.Play();
        }
    }
}