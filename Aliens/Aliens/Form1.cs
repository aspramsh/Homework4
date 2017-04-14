using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliens
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The length of rectangle for drawing objects on UI
        /// </summary>
        public const int Length = 20;
        /// <summary>
        /// The thickness of pen for drawing
        /// </summary>
        private const int PenThickness = 2;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// A function that updates UI from another thread
        /// </summary>
        public void UpdateUI()
        {
            int x = Updater.MyHero.GetCurrent().X;
            int y = Updater.MyHero.GetCurrent().Y;
            Graphics g = playArea.CreateGraphics();
            // drawing a rectangle that represents an object on UI
            using (Pen pen = new Pen(Color.Green, PenThickness))
            {
                g.DrawRectangle(pen, new Rectangle(x, y, Length, Length));
            }
            Updater.GetAliensData();
            foreach (Point p in Updater.KindAlienData)
            {
                using (Pen pen = new Pen(Color.Blue, PenThickness))
                {
                    g.DrawRectangle(pen, new Rectangle(p.X, p.Y, Length, Length));
                }
            }
            foreach (Point p in Updater.EvilAlienData)
            {
                using (Pen pen = new Pen(Color.Red, PenThickness))
                {
                    g.DrawRectangle(pen, new Rectangle(p.X, p.Y, Length, Length));
                }
            }
            
        }
        /// <summary>
        /// A function that starts the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            // before finishing the game user can't press start button
            startButton.Enabled = false;
            Initializer.InitializeDatastore();
            timer1.Start();
        }
        /// <summary>
        /// A method for moving the hero rectangle with keyboard
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int x = Updater.MyHero.GetCurrent().X;
            int y = Updater.MyHero.GetCurrent().Y;
            Graphics g = playArea.CreateGraphics();
            // a scenario when user presses the left key
            if (keyData == Keys.Left)
            {
                using (Pen pen = new Pen(playArea.BackColor, PenThickness))
                {
                    g.DrawRectangle(pen, new Rectangle(x, y, Length, Length));
                }
                Updater.MyHero.direction = Hero.Direction.Left;
                Updater.UpdateHeroData();
                x = Updater.MyHero.GetNext(x);
                using (Pen pen = new Pen(Color.Green, PenThickness))
                {
                    g.DrawRectangle(pen, new Rectangle(x, y, Length, Length));
                }
                return true;
            }
            // a scenario when user presses the right key
            else if (keyData == Keys.Right)
            {
                using (Pen pen = new Pen(playArea.BackColor, PenThickness))
                {
                    g.DrawRectangle(pen, new Rectangle(x, y, Length, Length));
                }
                Updater.MyHero.direction = Hero.Direction.Right;
                Updater.UpdateHeroData();
                x = Updater.MyHero.GetNext(x);
                using (Pen pen = new Pen(Color.Green, PenThickness))
                {
                    g.DrawRectangle(pen, new Rectangle(x, y, Length, Length));
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = playArea.CreateGraphics();
            g.Clear(this.playArea.BackColor);
            Updater.UpdateAliensData();
            progressBar1.Value = Datastore.NumberOfLifes;
            label1.Text = "Lifes Left: " + progressBar1.Value.ToString();
            label1.Update();
            // A distinct thread that updates UI
            Task.Run(() =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    UpdateUI();
                }));
            });
            // A condition that finishes the game
            if (Datastore.NumberOfLifes == 0)
            {
                timer1.Stop();
                startButton.Enabled = true;
                MessageBox.Show("Game over!");
            }
        }
    }
}
