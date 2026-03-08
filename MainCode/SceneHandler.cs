using System.Drawing;
using System.Windows.Forms;
using System;
using System.Xml.Linq;
namespace MainCode{
    public class SceneHandler{
        public PictureBox  background = new PictureBox();
        public Image phonePiece1 = Image.FromFile(@"seperated sprites\E.T\PhonePieces\PhonePiece01.png");
        public Image phonePiece2 = Image.FromFile(@"seperated sprites\E.T\PhonePieces\PhonePiece02.png");
        public Image phonePiece3 = Image.FromFile(@"seperated sprites\E.T\PhonePieces\PhonePiece03.png");
        public Image insidePit = Image.FromFile(@"seperated sprites\Screens\InsidePit.png");
        public Image forest = Image.FromFile(@"seperated sprites\Screens\Forest.png");
        public Image pit4 = Image.FromFile(@"seperated sprites\Screens\Pits04.png");
        public Image pit1 = Image.FromFile(@"seperated sprites\Screens\Pits01.png");
        public Image pit3 = Image.FromFile(@"seperated sprites\Screens\Pits03.png");
        public Image pit2 = Image.FromFile(@"seperated sprites\Screens\Pits02.png");
        public Image DC = Image.FromFile(@"seperated sprites\Screens\DC.png");
        public Label[] reesesPeeses = new Label[reesesCount];
        public int[] reesesPeesesMap = new int[reesesCount];
        public int[] reesesPeesesX = new int[reesesCount];
        public int[] reesesPeesesY = new int[reesesCount];
        public int[] zoneMap = new int[40];
        public int[] zoneX = new int[40];
        public int[] zoneY = new int[40];

        public int[] pieceLocations = [0,0,0];
        private readonly Random random = new();
        public static int reesesCount = 10;
        public Label energyDisplay;
        public Label reesesDisplay;
        public Label[] zones = new Label[40];
        private Movement movement;
        public int currentScreen;
        public Form game;
        public int energy;
        public int reeses;
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
                Location = new Point(140,167),
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
            SpawnPhonePieces(3);
            SpawnReeses();
            SpawnZones();
            ChangeBackground();
            movement.ShipAnimation();
        }
        public void ChangeScene(int sideHit){
            HideElements();
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
            if(!movement.inPit){
                for(int i = 0; i < reesesCount; i++){
                    if(currentScreen == reesesPeesesMap[i]){
                        reesesPeeses[i] = new Label{
                            Size = new Size(5, 5),
                            Location = new Point(reesesPeesesX[i], reesesPeesesY[i]),
                            Visible = true,
                            Parent = background,
                            BackColor = Color.DarkGreen,
                        };
                    }
                }
                for(int i = 0; i < zoneMap.Length; i++){
                    if(currentScreen == zoneMap[i]){
                        zones[i] = new Label{
                            Size = new Size(20, 20),
                            Location = new Point(zoneX[i], zoneY[i]),
                            Visible = false,
                            Parent = background,
                            BackColor = Color.DarkRed,
                        };
                    }
                }
            }
            if(movement.inPit){
                background.Image = insidePit;
                HideElements();
            }
        }
        public void HideElements(){
            for(int i = 0; i < reesesCount; i++){
                if(currentScreen == reesesPeesesMap[i]) reesesPeeses[i].Visible = false;
            }
            for(int i = 0; i < zoneX.Length; i++){
                if(currentScreen == zoneMap[i]) zones[i].Visible = false;
            }
        }
        public void SpawnPhonePieces(int amountToSpawn){
            for(int i = 0; i < amountToSpawn; i++){
                int randomNumber;
                while(true){
                    randomNumber = random.Next(20);
                    randomNumber += 1;
                    if(pieceLocations[1] != randomNumber) break;
                    if(pieceLocations[2] != randomNumber) break;
                }
                if(pieceLocations[i] != 999) pieceLocations[i] = randomNumber;
                else if(pieceLocations[i + 1] != 999) pieceLocations[i] = randomNumber;
                else if(pieceLocations[i + 2] != 999) pieceLocations[i] = randomNumber;
                //Console.WriteLine(pieceLocations[i]);
            }
            
        }
        public void SpawnReeses(){
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
                //Console.WriteLine(reesesPeesesMap[i] + " : [ " + reesesPeesesX[i] + "," + reesesPeesesY[i] + " ]");
            }
        }
        public void SpawnZones(){
            //call eliot zone = 0 - 5
            for(int i = 0; i < 6; i++){
                int x = random.Next(49,253);
                int y = random.Next(29,135);
                x += 1;
                y += 1;
                zoneX[i] = x;
                zoneY[i] = y;
                zoneMap[i] = i + 1;
                //Console.WriteLine("i : " + i + "\nEliot " + (i + 1));
                //Console.WriteLine(zoneMap[i] + " : [ " + zoneX[i] + "," + zoneY[i] + " ]");
            }
            //eat candy zone = 6 - 11
            for(int i = 0; i < 6; i++){
                int x = random.Next(49,253);
                int y = random.Next(29,135);
                x += 1;
                y += 1;
                zoneX[i + 6] = x;
                zoneY[i + 6] = y;
                zoneMap[i + 6] = i + 1;
                //Console.WriteLine("i : " + (i + 6) + "\nCandie " + (i + 1));
                //Console.WriteLine(zoneMap[i + 6] + " : [ " + zoneX[i + 6] + "," + zoneY[i + 6] + " ]");
            }
            //send humans back zone = 12 - 17
            for(int i = 0; i < 6; i++){
                int x = random.Next(49,253);
                int y = random.Next(29,135);
                x += 1;
                y += 1;
                zoneX[i + 12] = x;
                zoneY[i + 12] = y;
                zoneMap[i + 12] = i + 1;
                //Console.WriteLine("i : " + (i + 12) + "\nHuman " + (i + 1));
                //Console.WriteLine(zoneMap[i + 12] + " : [ " + zoneX[i + 12] + "," + zoneY[i + 12] + " ]");
            }
            //telliport zones = 18 - 33
            for(int i = 0; i < 16; i++){
                int x = random.Next(49,253);
                int y = random.Next(29,135);
                int map = i + 1;
                if(i >= 6) map = i % 6;
                if(map == 0) map = 6;
                x += 1;
                y += 1;
                zoneX[i + 18] = x;
                zoneY[i + 18] = y;
                zoneMap[i + 18] = map;
                //Console.WriteLine("i : " + (i + 18) + "\nTP " + (i + 1));
                //Console.WriteLine(zoneMap[i + 18] + " : [ " + zoneX[i + 18] + "," + zoneY[i + 18] + " ]");
            }
            //Phone Location Zones 34 - 37
            zoneMap[34] = 1;
            zoneX[34] = 151;
            zoneY[34] = 83;
            zoneMap[35] = 2;
            zoneX[35] = 153;
            zoneY[35] = 72;
            zoneMap[36] = 4;
            zoneX[36] = 153;
            zoneY[36] = 76;
            zoneMap[37] = 6;
            zoneX[37] = 153;
            zoneY[37] = 92;
            //Ship Call Location 38
            zoneMap[38] = 5;
            zoneX[38] = 223;
            zoneY[38] = 93;
            //Ship Land Location 39
            zoneMap[39] = 3;
            zoneX[39] = 153;
            zoneY[39] = 93;
        }
        public void LowerEnergy(int amount){
            energy -= amount;
            if(energy < 0) energy = 0;
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
    }
}