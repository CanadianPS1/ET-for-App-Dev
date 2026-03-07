using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Runtime.CompilerServices;
namespace MainCode{
    public class StartMenu{
        public Form game;
        public int energy = 9999;
        private Image startScreenIcon;
        private Button startButton;
        private SoundPlayer strSound;
        public StartMenu(){
            startScreenIcon = Image.FromFile(@"seperated sprites\Screens\MainMenue.png");
            //Icon gameIcon = new Icon(@"seperated sprites\E.T\ETIdle.png");
            game = new Form
            {
                Text = "Extra Terrestrial"
            };
            game.SetBounds(700, 300, 325, 240);
            //game.Icon = gameIcon;
            game.Show();
            startButton = new Button
            {
                Size = new Size(310, 210),
                Image = startScreenIcon,
                Visible = true
            };
            game.Controls.Add(startButton);
            game.Refresh();
            startButton.Click += ActionPerformed;
            strSound = new SoundPlayer(@"Sounds\MainMenu.wav");
            strSound.PlayLooping();
        }
        public void ActionPerformed(object sender, EventArgs e){
            startButton.Visible = false;
            game.Controls.Remove(startButton);
            game.Refresh();
            strSound.Stop();
            SceneHandler handler = new SceneHandler();
            handler.FirstRun(game);
        }
    }
}