using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Windows.Forms;
using System.Threading;
using System;
using System.Media;
namespace MainCode{
    public class Movement : SceneHandler{
        private Image etIdle = Image.FromFile(@"seperated sprites\E.T\ETIdle.png");
        private Image etIdleLeft = Image.FromFile(@"seperated sprites\E.T\ETIdle.png");
        private Image etWalk1 = Image.FromFile(@"seperated sprites\E.T\ETWalk01.png");
        private Image etWalk1Left = Image.FromFile(@"seperated sprites\E.T\ETWalk01.png");
        private Image etWalk2 = Image.FromFile(@"seperated sprites\E.T\ETWalk02.png");
        private Image etWalk2Left = Image.FromFile(@"seperated sprites\E.T\ETWalk02.png");
        private Image etDead = Image.FromFile(@"seperated sprites\E.T\ETDeath01.png");
        private Image etFly1 = Image.FromFile(@"seperated sprites\E.T\ETStretch01.png");
        private Image etFlyLeft1 = Image.FromFile(@"seperated sprites\E.T\ETStretch01.png");
        private Image etFly2 = Image.FromFile(@"seperated sprites\E.T\ETStretch02.png");
        private Image etFlyLeft2 = Image.FromFile(@"seperated sprites\E.T\ETStretch02.png");
        private Image etFly3 = Image.FromFile(@"seperated sprites\E.T\ETStretch03.png");
        private Image etFlyLeft3 = Image.FromFile(@"seperated sprites\E.T\ETStretch03.png");
        private Image piece1 = Image.FromFile(@"seperated sprites\E.T\phonePieces\phonePiece01.png");
        private Image piece2 = Image.FromFile(@"seperated sprites\E.T\phonePieces\phonePiece02.png");
        private Image piece3 = Image.FromFile(@"seperated sprites\E.T\phonePieces\phonePiece03.png");
        private Image uiPiece1 = Image.FromFile(@"seperated sprites\UI\Symbols\Collected1.png");
        private Image uiPiece2 = Image.FromFile(@"seperated sprites\UI\Symbols\Collected2.png");
        private Image uiPiece3 = Image.FromFile(@"seperated sprites\UI\Symbols\Collected3.png");
        private SoundPlayer etWalkSound = new SoundPlayer(@"Sounds\ETWalkies.wav");
        protected Label et;
        protected Label phonePiece;
        private Label phone;
        private readonly int speed = 2;
        private readonly int energyDecretionAmount = 2;
        private int walkFrame;
        private int flyFrame;
        private string direction;
        private SceneHandler scene;
        public bool inPit;
        private bool phonePieceInPit;
        private bool dead;
        private int piecesCollected;
        public Movement(Form game,PictureBox background, SceneHandler s){
            scene = s;
            inPit = false;
            dead = false;
            phonePieceInPit = false;
            phone = new Label{
                Size = new Size(8, 5),
                Visible = true,
                Location = new Point(155,13),
                Parent = background,
                BackColor = Color.Transparent,
            };
            background.Controls.Add(phone);
            phonePiece = new Label{
                Size = new Size(16, 10),
                Visible = false,
                Location = new Point(153,127),
                Parent = background,
                BackColor = Color.Transparent,
            };
            background.Controls.Add(phonePiece);
            et = new Label{
                Size = new Size(16, 17),
                Visible = true,
                Image = etIdle,
                Location = new Point(153,95),
                Parent = background,
                BackColor = Color.Transparent,
            };
            background.Controls.Add(et);
            game.Refresh();
            game.KeyPreview = true;
            game.KeyDown += new KeyEventHandler(OnKeyDown);
            game.KeyUp += OnKeyUp;
            direction = "r";
            etIdleLeft.RotateFlip(RotateFlipType.RotateNoneFlipX);
            etWalk1Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            etWalk2Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            etFlyLeft1.RotateFlip(RotateFlipType.RotateNoneFlipX);
            etFlyLeft2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            etFlyLeft3.RotateFlip(RotateFlipType.RotateNoneFlipX);
            walkFrame = 1;
            flyFrame = 1;
            piecesCollected = 0;
        }
        private void OnKeyDown(object sender, KeyEventArgs e){
            if(scene.energy <= 0) dead = true;
            if(!dead){
                if(e.KeyCode == Keys.A) MoveLeft();
                if(e.KeyCode == Keys.D) MoveRight();
                if(e.KeyCode == Keys.S) MoveDown();
                if(e.KeyCode == Keys.W) MoveUp();
                if(e.KeyCode == Keys.Space) MoveFly();
            }
            else{
                et.Image = etDead;
            }
            if(scene.energy <= 0) dead = true;
        }
        private void OnKeyUp(object sender, KeyEventArgs e){
            if(e.KeyCode == Keys.Space){
                flyFrame = 1;
                if(direction.Equals("l")) et.Image = etIdleLeft;
                else if(direction.Equals("r"))et.Image = etIdle;
                if(inPit) et.Location = new Point(et.Location.X,130);
            }
        }
        private void MoveUp(){
            if(!inPit){
                et.Top -= speed;
                Detecting();
                scene.LowerEnergy(energyDecretionAmount);
                WalkAnimation();
            }
        }
        private void MoveDown(){
            if(!inPit){
                et.Top += speed;
                Detecting();
                scene.LowerEnergy(energyDecretionAmount);
                WalkAnimation();
            }
        }
        private void MoveFly(){
            if(inPit){
                et.Top -= speed;
                Detecting();
                scene.LowerEnergy(10);
                FlyAnimation();
            }
            else{
                scene.LowerEnergy(10);
                FlyAnimation();
            }
        }
        private void MoveLeft(){
            et.Left -= speed;
            if(inPit && et.Location.X <= 79) et.Left += speed;
            Detecting();
            scene.LowerEnergy(energyDecretionAmount);
            WalkAnimation();
            if(direction.Equals("r")) direction = "l";
        }
        private void MoveRight(){
            et.Left += speed;                    
            if(inPit && et.Location.X >= 219) et.Left -= speed;
            Detecting();
            scene.LowerEnergy(energyDecretionAmount);
            WalkAnimation();
            if(direction.Equals("l")) direction = "r";
        }
        private void Detecting(){
            DetectReeses();
            DetectEdge();
            DetectPit();
        }
        public void DetectReeses(){
            for(int i = 0; i < SceneHandler.reesesCount; i++){
                if(scene.reesesPeesesMap[i] == scene.currentScreen){
                    if((et.Location.X <= scene.reesesPeesesX[i] + 10) && (et.Location.X >= scene.reesesPeesesX[i] - 10) 
                    && (et.Location.Y <= scene.reesesPeesesY[i] + 10) && (et.Location.Y >= scene.reesesPeesesY[i] - 10)) CollectReesesPiece(i);
                }
            }
        }
        public void DetectPit(){
            if(!inPit){
                int sceneId = scene.currentScreen;
                if(sceneId == 1){
                    if((et.Location.X >= 125) && (et.Location.X <= 173) && (et.Location.Y <= 113) && (et.Location.Y >= 101)) FallIntoPit(1);
                    if((et.Location.X >= 211) && (et.Location.X <= 243) && (et.Location.Y <= 117) && (et.Location.Y >= 45)) FallIntoPit(2);
                    if((et.Location.X >= 59) && (et.Location.X <= 87) && (et.Location.Y <= 117) && (et.Location.Y >= 45)) FallIntoPit(3);
                    if((et.Location.X >= 125) && (et.Location.X <= 173) && (et.Location.Y <= 61) && (et.Location.Y >= 49)) FallIntoPit(4);
                }else if(sceneId == 2){
                    if((et.Location.X >= 53) && (et.Location.X <= 127) && (et.Location.Y <= 57) && (et.Location.Y >= 39)) FallIntoPit(5);
                    if((et.Location.X >= 53) && (et.Location.X <= 127) && (et.Location.Y <= 121) && (et.Location.Y >= 103)) FallIntoPit(6);
                    if((et.Location.X >= 183) && (et.Location.X <= 249) && (et.Location.Y <= 57) && (et.Location.Y >= 39)) FallIntoPit(7);
                    if((et.Location.X >= 183) && (et.Location.X <= 249) && (et.Location.Y <= 121) && (et.Location.Y >= 103)) FallIntoPit(8);
                }else if(sceneId == 4){
                    if((et.Location.X >= 33) && (et.Location.X <= 57) && (et.Location.Y <= 45) && (et.Location.Y >= 33)) FallIntoPit(9);
                    if((et.Location.X >= 115) && (et.Location.X <= 186) && (et.Location.Y <= 45) && (et.Location.Y >= 33)) FallIntoPit(10);
                    if((et.Location.X >= 246) && (et.Location.X <= 269) && (et.Location.Y <= 45) && (et.Location.Y >= 33)) FallIntoPit(11);
                    if((et.Location.X >= 57) && (et.Location.X <= 115) && (et.Location.Y <= 87) && (et.Location.Y >= 73)) FallIntoPit(12);
                    if((et.Location.X >= 183) && (et.Location.X <= 241) && (et.Location.Y <= 87) && (et.Location.Y >= 73)) FallIntoPit(13);
                    if((et.Location.X >= 33) && (et.Location.X <= 57) && (et.Location.Y <= 127) && (et.Location.Y >= 117)) FallIntoPit(14);
                    if((et.Location.X >= 115) && (et.Location.X <= 186) && (et.Location.Y <= 127) && (et.Location.Y >= 117)) FallIntoPit(15);
                    if((et.Location.X >= 246) && (et.Location.X <= 269) && (et.Location.Y <= 127) && (et.Location.Y >= 117)) FallIntoPit(16);
                }else if(sceneId == 6){
                    if((et.Location.X >= 73) && (et.Location.X <= 115) && (et.Location.Y <= 69) && (et.Location.Y >= 49)) FallIntoPit(17);
                    if((et.Location.X >= 189) && (et.Location.X <= 231) && (et.Location.Y <= 69) && (et.Location.Y >= 49)) FallIntoPit(18);
                    if((et.Location.X >= 63) && (et.Location.X <= 103) && (et.Location.Y <= 111) && (et.Location.Y >= 105)) FallIntoPit(19);
                    if((et.Location.X >= 199) && (et.Location.X <= 241) && (et.Location.Y <= 111) && (et.Location.Y >= 105)) FallIntoPit(20);
                }
            }else if(phonePieceInPit){
                if((et.Location.X >= 147) && (et.Location.X <= 161)) CollectPhonePiece();
            }
            System.Console.WriteLine("X : " + et.Location.X + "\nY : " + et.Location.Y);
        }
        private void CollectReesesPiece(int i){
            scene.reesesPeeses[i].Visible = false;
            SceneHandler.reesesCount -= 1;
            scene.reesesPeesesMap[i] = 10;
            scene.HeigherPieces(1);
        }
        private void CollectPhonePiece(){
            phonePiece.Visible = false;
            phonePieceInPit = false;
            piecesCollected += 1;
            if(piecesCollected == 1) phone.Image = uiPiece1;
            else if(piecesCollected == 2) phone.Image = uiPiece2;
            else if(piecesCollected == 3) phone.Image = uiPiece3;
        }
        public void FallIntoPit(int pitId){
            inPit = true;
            scene.ChangeBackground();
            et.Location = new Point(et.Location.X,130);
            if(scene.pieceLocations[0] == pitId){
                phonePiece.Visible = true;
                phonePiece.Image = piece1;
                phonePieceInPit = true;
            }else if(scene.pieceLocations[1] == pitId){
                phonePiece.Visible = true;
                phonePiece.Image = piece2;
                phonePieceInPit = true;
            }else if(scene.pieceLocations[2] == pitId){
                phonePiece.Visible = true;
                phonePiece.Image = piece3;
                phonePieceInPit = true;
            }
        }
        public void DetectEdge(){
            if(!inPit){
                //detects the top edge
                if(et.Location.Y <= 25){
                    scene.ChangeScene(1);
                    et.Top += 110;
                //detects the bottom edge
                }else if(et.Location.Y >= 140){
                    scene.ChangeScene(3);
                    et.Top -= 110;
                //detects the left edge
                }else if(et.Location.X <= 30){
                    scene.ChangeScene(4);
                    et.Left += 220;
                //detects the right edge
                }else if(et.Location.X >= 270){
                    scene.ChangeScene(2);
                    et.Left -= 220;
                }
            }
            else{
                //detects the top edge of the pit
                if(et.Location.Y <= 26){
                    inPit = false;
                    phonePiece.Visible = false;
                    scene.ChangeBackground();
                    et.Top += 110;                
                }
            }
        }
        private void WalkAnimation(){
            if(walkFrame == 1){ 
                if(direction.Equals("l")) et.Image = etWalk1Left;
                else if(direction.Equals("r"))et.Image = etWalk1;
                walkFrame = 2;
            }else if(walkFrame == 2){
                if(direction.Equals("l")) et.Image = etWalk2Left;
                else if(direction.Equals("r"))et.Image = etWalk2;
                walkFrame = 1;
                etWalkSound.Play();
            }else if(walkFrame == 0){ 
                if(direction.Equals("l")) et.Image = etIdleLeft;
                else if(direction.Equals("r"))et.Image = etIdle;
            }
        }
        private void FlyAnimation(){
            if(flyFrame == 1){
                if(direction.Equals("l")) et.Image = etFlyLeft1;
                else if(direction.Equals("r"))et.Image = etFly1;
                flyFrame = 2;
            }else if(flyFrame == 2){
                if(direction.Equals("l")) et.Image = etFlyLeft2;
                else if(direction.Equals("r"))et.Image = etFly2;
                flyFrame = 3;
            }else if(flyFrame == 3){
                if(direction.Equals("l")) et.Image = etFlyLeft3;
                else if(direction.Equals("r"))et.Image = etFly3;
            }
        }
    }
}