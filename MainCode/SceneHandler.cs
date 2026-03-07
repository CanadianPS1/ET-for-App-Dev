using System.Drawing;
using System.Windows.Forms;
using System;
using System.Xml.Linq;
namespace MainCode{
    public class SceneHandler{
        public PictureBox  background = new PictureBox();
        public Image pit3 = Image.FromFile(@"seperated sprites\Screens\Pits03.png");
        public Image pit2 = Image.FromFile(@"seperated sprites\Screens\Pits02.png");
        public Image forest = Image.FromFile(@"seperated sprites\Screens\Forest.png");
        public Image pit4 = Image.FromFile(@"seperated sprites\Screens\Pits04.png");
        public Image pit1 = Image.FromFile(@"seperated sprites\Screens\Pits01.png");
        public Image DC = Image.FromFile(@"seperated sprites\Screens\DC.png");
        public Image insidePit = Image.FromFile(@"seperated sprites\Screens\InsidePit.png");
        public Image phonePiece1 = Image.FromFile(@"seperated sprites\E.T\PhonePieces\PhonePiece01.png");
        public Image phonePiece2 = Image.FromFile(@"seperated sprites\E.T\PhonePieces\PhonePiece02.png");
        public Image phonePiece3 = Image.FromFile(@"seperated sprites\E.T\PhonePieces\PhonePiece03.png");
        public Label energyDisplay;
        public Label reesesDisplay;
        protected Form game;
        public int energy;
        public int reeses;
        public int currentScreen;
        public static int reesesCount = 10;
        private Movement movement;
        public int[] pieceLocations = [0,0,0];
        public int[] reesesPeesesX = new int[reesesCount];
        public int[] reesesPeesesY = new int[reesesCount];
        public int[] reesesPeesesMap = new int[reesesCount];
        public Label[] reesesPeeses = new Label[reesesCount];
        private readonly Random random = new();
        public void FirstRun(Form g){
            background.Size = new Size(320, 210);
            background.Visible = true;
            game = g;
            energy = 9999;
            reeses = 0;
            reesesDisplay = new Label{
                Size = new Size(10, 20),
                Location = new Point(125,167),
                Visible = true,
                Text = reeses.ToString(),
                Parent = background,
                BackColor = Color.Transparent,
                ForeColor = Color.Orange,
            };
            energyDisplay = new Label{
                Size = new Size(34, 20),
                Location = new Point(135,167),
                Visible = true,
                Text = energy.ToString(),
                Parent = background,
                BackColor = Color.Transparent,
                ForeColor = Color.DarkGreen,
            };
            movement = new Movement(game, background, this);
            game.Focus();  
            background.Controls.Add(energyDisplay);          
            game.Controls.Add(background);
            currentScreen = 3;
            SpawnPhonePieces();
            ChangeBackground();
        }
        public void LowerEnergy(int amount){
            energy -= amount;
            energyDisplay.Text = energy.ToString();
        }
        public void HeigherEnergy(int amount){
            energy += amount;
            energyDisplay.Text = energy.ToString();
        }
        public void LowerPieces(int amount){
            reeses -= amount;
            reesesDisplay.Text = reeses.ToString();
        }
        public void HeigherPieces(int amount){
            reeses += amount;
            reesesDisplay.Text = reeses.ToString();
        }
        public void ChangeScene(int sideHit){
            for(int i = 0; i < reesesCount; i++){
                if(currentScreen == reesesPeesesMap[i]){
                    reesesPeeses[i].Visible = false;
                }
            }
            if(currentScreen == 1){
                if(sideHit == 1) currentScreen = 6;
                else if(sideHit == 2) currentScreen = 4;
                else if(sideHit == 3) currentScreen = 3;
                else if(sideHit == 4) currentScreen = 2;
            }else if(currentScreen == 2){
                if(sideHit == 1) currentScreen = 1;
                else if(sideHit == 2) currentScreen = 3;
                else if(sideHit == 3) currentScreen = 6;
                else if(sideHit == 4) currentScreen = 5;
            }else if(currentScreen == 3){
                if(sideHit == 1) currentScreen = 1;
                else if(sideHit == 2) currentScreen = 4;
                else if(sideHit == 3) currentScreen = 6;
                else if(sideHit == 4) currentScreen = 2;
            }else if(currentScreen == 4){
                if(sideHit == 1) currentScreen = 1;
                else if(sideHit == 2) currentScreen = 5;
                else if(sideHit == 3) currentScreen = 6;
                else if(sideHit == 4) currentScreen = 3;
            }else if(currentScreen == 5){
                if(sideHit == 1) currentScreen = 1;
                else if(sideHit == 2) currentScreen = 2;
                else if(sideHit == 3) currentScreen = 6;
                else if(sideHit == 4) currentScreen = 4;
            }else if(currentScreen == 6){
                if(sideHit == 1) currentScreen = 3;
                else if(sideHit == 2) currentScreen = 4;
                else if(sideHit == 3) currentScreen = 1;
                else if(sideHit == 4) currentScreen = 2;
            }
            
            ChangeBackground();
        }
        public void ChangeBackground(){
            if(currentScreen == 1) background.Image = pit3;
            else if(currentScreen == 2) background.Image = pit2;
            else if(currentScreen == 3) background.Image = forest;
            else if(currentScreen == 4) background.Image = pit4;
            else if(currentScreen == 5) background.Image = DC;
            else if(currentScreen == 6) background.Image = pit1;
            if(movement.inPit) background.Image = insidePit;
            for(int i = 0; i < reesesCount; i++){
                if(currentScreen == reesesPeesesMap[i]){
                    reesesPeeses[i] = new Label
                    {
                        Size = new Size(5, 5),
                        Location = new Point(reesesPeesesX[i], reesesPeesesY[i]),
                        Visible = true,
                        Parent = background,
                        BackColor = Color.YellowGreen,
                    };
                }
            }
        }
        public void SpawnPhonePieces(){
            for(int i = 0; i < 3; i++){
                int randomNumber;
                while(true){
                    randomNumber = random.Next(20);
                    randomNumber += 1;
                    if(pieceLocations[1] != randomNumber) break;
                    if(pieceLocations[2] != randomNumber) break;
                }
                pieceLocations[i] = randomNumber;
                Console.WriteLine(pieceLocations[i]);
            }
            for(int i = 0; i < reesesCount; i++){
                int x = random.Next(49,253);
                int y = random.Next(29,135);
                int map = random.Next(5);
                map += 1;
                x += 1;
                y += 1;
                reesesPeesesX[i] = x;
                reesesPeesesY[i] = y;
                reesesPeesesMap[i] = map;
                Console.WriteLine(reesesPeesesMap[i] + " : [ " + reesesPeesesX[i] + "," + reesesPeesesY[i] + " ]");
            }
        }
    }
}