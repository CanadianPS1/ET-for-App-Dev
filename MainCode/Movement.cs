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
        private Image scientistWalk1 = Image.FromFile(@"seperated sprites\AI\HatGuy\HG1.png");
        private Image scientistWalk1Left = Image.FromFile(@"seperated sprites\AI\HatGuy\HG1.png");
        private Image scientistWalk2 = Image.FromFile(@"seperated sprites\AI\HatGuy\HG2.png");
        private Image scientistWalk2Left = Image.FromFile(@"seperated sprites\AI\HatGuy\HG2.png");
        private Image scientistWalk3 = Image.FromFile(@"seperated sprites\AI\HatGuy\HG3.png");
        private Image scientistWalk3Left = Image.FromFile(@"seperated sprites\AI\HatGuy\HG3.png");
        private Image scientistWalk4 = Image.FromFile(@"seperated sprites\AI\HatGuy\HG4.png");
        private Image scientistWalk4Left = Image.FromFile(@"seperated sprites\AI\HatGuy\HG4.png");
        private Image scientistWalk5 = Image.FromFile(@"seperated sprites\AI\HatGuy\HG5.png");
        private Image scientistWalk5Left = Image.FromFile(@"seperated sprites\AI\HatGuy\HG5.png");
        private Image ciaWalk1 = Image.FromFile(@"seperated sprites\AI\CIA\CIA1.png");
        private Image ciaWalk1Left = Image.FromFile(@"seperated sprites\AI\CIA\CIA1.png");
        private Image ciaWalk2 = Image.FromFile(@"seperated sprites\AI\CIA\CIA2.png");
        private Image ciaWalk2Left = Image.FromFile(@"seperated sprites\AI\CIA\CIA2.png");
        private Image ciaWalk3 = Image.FromFile(@"seperated sprites\AI\CIA\CIA3.png");
        private Image ciaWalk3Left = Image.FromFile(@"seperated sprites\AI\CIA\CIA3.png");
        private Image ciaWalk4 = Image.FromFile(@"seperated sprites\AI\CIA\CIA4.png");
        private Image ciaWalk4Left = Image.FromFile(@"seperated sprites\AI\CIA\CIA4.png");
        private Image eliotWalk1 = Image.FromFile(@"seperated sprites\AI\Kid\K1.png");
        private Image eliotWalk1Left = Image.FromFile(@"seperated sprites\AI\Kid\K1.png");
        private Image eliotWalk2 = Image.FromFile(@"seperated sprites\AI\Kid\K2.png");
        private Image eliotWalk2Left = Image.FromFile(@"seperated sprites\AI\Kid\K2.png");
        private Image eliotWalk3 = Image.FromFile(@"seperated sprites\AI\Kid\K3.png");
        private Image eliotWalk3Left = Image.FromFile(@"seperated sprites\AI\Kid\K3.png");
        private Image eliotWalk4 = Image.FromFile(@"seperated sprites\AI\Kid\K4.png");
        private Image eliotWalk4Left = Image.FromFile(@"seperated sprites\AI\Kid\K4.png");
        private Image etDead = Image.FromFile(@"seperated sprites\E.T\ETDeath01.png");
        private Image etFly1 = Image.FromFile(@"seperated sprites\E.T\ETStretch01.png");
        private Image etFlyLeft1 = Image.FromFile(@"seperated sprites\E.T\ETStretch01.png");
        private Image etFly2 = Image.FromFile(@"seperated sprites\E.T\ETStretch02.png");
        private Image etFlyLeft2 = Image.FromFile(@"seperated sprites\E.T\ETStretch02.png");
        private Image etFly3 = Image.FromFile(@"seperated sprites\E.T\ETStretch03.png");
        private Image etFlyLeft3 = Image.FromFile(@"seperated sprites\E.T\ETStretch03.png");
        private Image ship = Image.FromFile(@"seperated sprites\E.T\Ship\ETShip01.png");
        private Image ship2 = Image.FromFile(@"seperated sprites\E.T\Ship\ETShip02.png");
        private Image piece1 = Image.FromFile(@"seperated sprites\E.T\phonePieces\phonePiece01.png");
        private Image piece2 = Image.FromFile(@"seperated sprites\E.T\phonePieces\phonePiece02.png");
        private Image piece3 = Image.FromFile(@"seperated sprites\E.T\phonePieces\phonePiece03.png");
        private Image uiPiece1 = Image.FromFile(@"seperated sprites\UI\Symbols\Collected1.png");
        private Image uiPiece2 = Image.FromFile(@"seperated sprites\UI\Symbols\Collected2.png");
        private Image uiPiece3 = Image.FromFile(@"seperated sprites\UI\Symbols\Collected3.png");
        private Image uiCallElliott = Image.FromFile(@"seperated sprites\UI\Symbols\CallElliott.png");
        private Image uiCallShip = Image.FromFile(@"seperated sprites\UI\Symbols\CallShip.png");
        private Image uiEatCandy = Image.FromFile(@"seperated sprites\UI\Symbols\EatCandy.png");
        private Image uiFindPhonePiece = Image.FromFile(@"seperated sprites\UI\Symbols\FindPhonePiece.png");
        private Image uiLandingZone = Image.FromFile(@"seperated sprites\UI\Symbols\LandingZone.png");
        private Image uiSendHumanBack = Image.FromFile(@"seperated sprites\UI\Symbols\SendHumansBack.png");
        private Image uiArrowDown = Image.FromFile(@"seperated sprites\UI\Arrows\ArrowDown.png");
        private Image uiArrowGoUp = Image.FromFile(@"seperated sprites\UI\Arrows\ArrowGoUp.png");
        private Image uiArrowLeft = Image.FromFile(@"seperated sprites\UI\Arrows\ArrowLeft.png");
        private Image uiArrowRight = Image.FromFile(@"seperated sprites\UI\Arrows\ArrowRight.png");
        private Image uiArrowUp = Image.FromFile(@"seperated sprites\UI\Arrows\ArrowUp.png");
        private Image uiTimer1 = Image.FromFile(@"seperated sprites\UI\Timer\Timer1.png");
        private Image uiTimer2 = Image.FromFile(@"seperated sprites\UI\Timer\Timer2.png");
        private Image uiTimer3 = Image.FromFile(@"seperated sprites\UI\Timer\Timer3.png");
        private Image uiTimer4 = Image.FromFile(@"seperated sprites\UI\Timer\Timer4.png");
        private Image uiTimer5 = Image.FromFile(@"seperated sprites\UI\Timer\Timer5.png");
        private Image uiTimer6 = Image.FromFile(@"seperated sprites\UI\Timer\Timer6.png");
        private Image uiTimer7 = Image.FromFile(@"seperated sprites\UI\Timer\Timer7.png");
        private Image uiTimerFull = Image.FromFile(@"seperated sprites\UI\Timer\TimerFull.png");
        private SoundPlayer etWalkSound = new SoundPlayer(@"Sounds\ETWalkies.wav");
        private SoundPlayer eliotWalkSound = new SoundPlayer(@"Sounds\ETWalkies2.wav");
        private SoundPlayer scientistWalkSound = new SoundPlayer(@"Sounds\EnemyWalk2.wav");
        private SoundPlayer ciaWalkSound = new SoundPlayer(@"Sounds\EnemyWalk1.wav");
        private SoundPlayer shipSound = new SoundPlayer(@"Sounds\EnemyWalk2.wav");
        private readonly Random random = new();
        protected Label et, phonePiece;
        private Label phone, zone, shipLabel, shipLabelFake, correctHole, timer, scientist, cia, eliot;
        private readonly int speed = 2, energyDecretionAmount = 2;
        private int walkFrame, flyFrame, pitNumber, piecesCollected, scientistWalkFrame, ciaWalkFrame, eliotWalkFrame, lives;
        private string direction, scientistDirection, ciaDirection, eliotDirection;
        private SceneHandler scene;
        public bool inPit;
        private bool phonePieceInPit, dead, specialing, telliporting, firstMove, threading, findingET, scientistOnFrame, running, ciaOnFrame, takingPhone;
        private Thread animation, falling, timerAnimation, scientistAction, ciaAction, eliotAction;
        private readonly Form game;
        public Movement(Form g, PictureBox background, SceneHandler s){
            running = true;
            lives = 3;
            game = g;
            scene = s;
            inPit = false;
            firstMove = true;
            dead = false;
            specialing = false;
            telliporting = false;
            phonePieceInPit = false;
            findingET = true;
            pitNumber = 0;
            timer = new Label{
                Size = new Size(16, 8),
                Visible = true,
                Location = new Point(200,10),
                Parent = background,
                BackColor = Color.Transparent,
            };
            background.Controls.Add(timer);
            correctHole = new Label{
                Size = new Size(5, 5),
                Visible = false,
                Location = new Point(225,120),
                Parent = background,
                BackColor = Color.Yellow,
            };
            background.Controls.Add(correctHole);
            zone = new Label{
                Size = new Size(16, 8),
                Visible = true,
                Location = new Point(153,13),
                Parent = background,
                BackColor = Color.Transparent,
            };
            background.Controls.Add(zone);
            phone = new Label{
                Size = new Size(8, 5),
                Visible = true,
                Location = new Point(100,10),
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
            shipLabel = new Label{
                Size = new Size(32, 32),
                Visible = true,
                Image = ship,
                Location = new Point(145,30),
                Parent = background,
                BackColor = Color.Transparent,
            };
            background.Controls.Add(shipLabel);
            shipLabelFake = new Label{
                Size = new Size(32, 32),
                Visible = true,
                Image = ship2,
                Location = new Point(145,30),
                Parent = background,
                BackColor = Color.Transparent,
            };
            background.Controls.Add(shipLabelFake);
            eliot = new Label{
                Size = new Size(8, 19),
                Visible = true,
                Image = eliotWalk1,
                Location = new Point(330,95),
                Parent = background,
                BackColor = Color.Transparent,
            };
            background.Controls.Add(cia);
            cia = new Label{
                Size = new Size(16, 28),
                Visible = true,
                Image = ciaWalk1,
                Location = new Point(700,95),
                Parent = background,
                BackColor = Color.Transparent,
            };
            background.Controls.Add(cia);
            scientist = new Label{
                Size = new Size(16, 28),
                Visible = true,
                Image = scientistWalk1,
                Location = new Point(750,95),
                Parent = background,
                BackColor = Color.Transparent,
            };
            background.Controls.Add(scientist);
            et = new Label{
                Size = new Size(16, 23),
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
            game.FormClosing += GameClosed;
            direction = "r";
            etIdleLeft.RotateFlip(RotateFlipType.RotateNoneFlipX);
            etWalk1Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            etWalk2Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            etFlyLeft1.RotateFlip(RotateFlipType.RotateNoneFlipX);
            etFlyLeft2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            etFlyLeft3.RotateFlip(RotateFlipType.RotateNoneFlipX);
            scientistWalk1Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            scientistWalk2Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            scientistWalk3Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            scientistWalk4Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            scientistWalk5Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            ciaWalk1Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            ciaWalk2Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            ciaWalk3Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            ciaWalk4Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            eliotWalk1Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            eliotWalk2Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            eliotWalk3Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            eliotWalk4Left.RotateFlip(RotateFlipType.RotateNoneFlipX);
            walkFrame = 1;
            flyFrame = 1;
            piecesCollected = 0;
        }
        private void GameClosed(object sender, FormClosingEventArgs e){running = false;}
        public void WinAnimation(){
            threading = true;
            shipLabelFake.Visible = true;
            animation = new(() =>  {
                if(threading){
                    while(shipLabelFake.Location.Y < 95){
                        shipLabelFake.Top += 5;
                        Thread.Sleep(200);
                        shipSound.Play();
                    }
                    et.Visible = false;
                    shipLabel.Location = new Point(shipLabelFake.Location.X, shipLabelFake.Location.Y);
                    shipLabelFake.Visible = false;
                    shipLabel.Visible = true;
                    while(shipLabel.Location.Y > 0){
                        shipLabel.Top -= 5;
                        Thread.Sleep(200);
                        shipSound.Play();
                    }
                }
            });
            animation.Start();
        }
        public void ShipAnimation(){
            threading = true;
            et.Visible = false;
            shipLabelFake.Visible = false;
            animation = new(() =>  {
                if(threading){
                    while(shipLabel.Location.Y < 95){
                        shipLabel.Top += 5;
                        Thread.Sleep(100);
                        shipSound.Play();
                    }
                    threading = false;
                    shipSound.Play();
                    shipSound.Play();
                }
                shipLabel.Visible = false;
                et.Visible = true;
            });
            animation.Start();
        }
        public void Falling(){
            threading = true;
            falling = new(() =>  {
                if(threading){
                    et.Location = new Point(200, 40);
                    while(et.Location.Y < 129){
                        et.Top += 1;
                        Thread.Sleep(10);
                        shipSound.Play();
                    }
                    threading = false;
                }
            });
            falling.Start();
        }
        public void Timer(){
            timerAnimation = new(() =>  {
                for(int i = 0; i < 8; i++){
                    if(i == 0) timer.Image = uiTimer1;
                    else if(i == 1) timer.Image = uiTimer2;
                    else if(i == 2) timer.Image = uiTimer3;
                    else if(i == 3) timer.Image = uiTimer4;
                    else if(i == 4) timer.Image = uiTimer5;
                    else if(i == 5) timer.Image = uiTimer6;
                    else if(i == 8) timer.Image = uiTimer7;
                    else if(i == 7) timer.Image = uiTimerFull;
                    Thread.Sleep(1873);
                }
                timer.Image = null;
                BringShip();
            });
            timerAnimation.Start();
        }
        private void OnKeyDown(object sender, KeyEventArgs e){
            if(!threading && findingET){
                if(firstMove) AiStarter();
                firstMove = false;
                if(scene.energy <= 0) dead = true;
                if(!dead){
                    if(e.KeyCode == Keys.A) MoveLeft();
                    if(e.KeyCode == Keys.D) MoveRight();
                    if(e.KeyCode == Keys.S) MoveDown();
                    if(e.KeyCode == Keys.W) MoveUp();
                    if(e.KeyCode == Keys.Space){
                        MoveFly();
                        specialing = true;
                    }
                }
                else et.Image = etDead;
                
                if(scene.energy <= 0) dead = true;
            }
        }
        private void AiStarter(){
            ScientistStarter();
            CiaStarter();
            EliotStarter();
        }
        private void OnKeyUp(object sender, KeyEventArgs e){
            if(e.KeyCode == Keys.Space){
                flyFrame = 1;
                specialing = false;
                correctHole.Visible = false;
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
                scene.LowerEnergy(5);
                FlyAnimation();
            }
            else{
                FlyAnimation();
                if(!telliporting) Detecting();
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
            DetectZone();
        }
        public void DetectReeses(){
            for(int i = 0; i < SceneHandler.reesesCount; i++){
                if(scene.reesesPeesesMap[i] == scene.currentScreen){
                    if((et.Location.X <= scene.reesesPeesesX[i] + 10) && (et.Location.X >= scene.reesesPeesesX[i] - 10) 
                    && (et.Location.Y <= scene.reesesPeesesY[i] + 10) && (et.Location.Y >= scene.reesesPeesesY[i] - 10)) CollectReesesPiece(i);
                }
            }
        }
        public void DetectZone(){
            bool onOneFr = false;
            if(!inPit){
                for(int i = 0; i < scene.zoneMap.Length; i++){
                    if(scene.zoneMap[i] == scene.currentScreen){
                        if((et.Location.X <= scene.zoneX[i] + 20) && (et.Location.X >= scene.zoneX[i] - 10) 
                        && (et.Location.Y <= scene.zoneY[i] + 20) && (et.Location.Y >= scene.zoneY[i] - 10)){
                            if(i < 6){
                                //zone.Image = uiCallElliott;                        
                            }if(i > 5 && i < 12){
                                zone.Image = uiEatCandy;
                                EatCandy();
                            }
                            if(i > 11 && i < 18){
                                zone.Image = uiSendHumanBack;
                                SendHumansBack();
                            }
                            if(i > 17 && i < 33){
                                zone.Image = uiArrowGoUp;
                                Telliport();
                            }
                            if(i > 33 && i < 38) FindPhonePiece();
                            if(i == 38){
                                zone.Image = uiCallShip;
                                CallShip();
                            }
                            if(i == 39) zone.Image = uiLandingZone;
                        }
                    }
                }
            }
            for(int i = 0; i < scene.zoneMap.Length; i++){
                if(scene.zoneMap[i] == scene.currentScreen){
                    if((et.Location.X <= scene.zoneX[i] + 20) && (et.Location.X >= scene.zoneX[i] - 10) 
                    && (et.Location.Y <= scene.zoneY[i] + 20) && (et.Location.Y >= scene.zoneY[i] - 10)){
                        onOneFr = true;
                    }
                }
            }
            if(!onOneFr) zone.Image = null;
        }
        public void DetectPit(){
            if(!inPit && findingET){
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
            //Console.WriteLine("X : " + et.Location.X + "\nY : " + et.Location.Y);
        }
        private void SendHumansBack(){
            if(specialing){
                cia.Location = new Point(700,95);
                scientist.Location = new Point(750,95);
            }
        }
        private void BringShip(){
            if(zone.Image == uiLandingZone && !ciaOnFrame && !scientistOnFrame) WinAnimation();
        }
        private void CallShip(){if(specialing && piecesCollected == 3) Timer();}
        private void Telliport(){
            if(specialing && !telliporting && !inPit){
                specialing = false;
                telliporting = true;
                int tpZoneId = random.Next(16);
                tpZoneId += 18;
                scene.currentScreen = scene.zoneMap[tpZoneId];
                scene.ChangeBackground();
                et.Location = new Point(scene.zoneX[tpZoneId],scene.zoneY[tpZoneId]);
                telliporting = false;
            }
        }
        private void PutDotAbovePiece(int hole){
            correctHole.Visible = true;
            if(hole == 1) correctHole.Location = new Point(155,120);
            else if(hole == 2) correctHole.Location = new Point(230,100);
            else if(hole == 3) correctHole.Location = new Point(80,100);
            else if(hole == 4) correctHole.Location = new Point(155,70);
            else if(hole == 5) correctHole.Location = new Point(90,60);
            else if(hole == 6) correctHole.Location = new Point(90,125);
            else if(hole == 7) correctHole.Location = new Point(220,60);
            else if(hole == 8) correctHole.Location = new Point(220,125);
            else if(hole == 9) correctHole.Location = new Point(40,50);
            else if(hole == 10) correctHole.Location = new Point(153,50);
            else if(hole == 11) correctHole.Location = new Point(270,50);
            else if(hole == 12) correctHole.Location = new Point(90,95);
            else if(hole == 13) correctHole.Location = new Point(220,95);
            else if(hole == 14) correctHole.Location = new Point(40,135);
            else if(hole == 15) correctHole.Location = new Point(153,135);
            else if(hole == 16) correctHole.Location = new Point(270,135);
            else if(hole == 17) correctHole.Location = new Point(90,70);
            else if(hole == 18) correctHole.Location = new Point(220,70);
            else if(hole == 19) correctHole.Location = new Point(90,120);
            else if(hole == 20) correctHole.Location = new Point(225,120);
        }
        private void FindPhonePiece(){
            //sets the icon if your on the same screen as one
            for(int i = 0; i < scene.pieceLocations.Length; i++){
                if(scene.currentScreen == 1){
                    if(scene.pieceLocations[i] == 1 || scene.pieceLocations[i] == 2 || 
                        scene.pieceLocations[i] == 3 || scene.pieceLocations[i] == 4) zone.Image = uiFindPhonePiece;
                }else if(scene.currentScreen == 2){
                    if(scene.pieceLocations[i] == 5 || scene.pieceLocations[i] == 6 || 
                        scene.pieceLocations[i] == 7 || scene.pieceLocations[i] == 8) zone.Image = uiFindPhonePiece;
                }else if(scene.currentScreen == 4){
                    if(scene.pieceLocations[i] == 9 || scene.pieceLocations[i] == 10 || 
                        scene.pieceLocations[i] == 11 || scene.pieceLocations[i] == 12 ||
                        scene.pieceLocations[i] == 13 || scene.pieceLocations[i] == 14 || 
                        scene.pieceLocations[i] == 15 || scene.pieceLocations[i] == 16) zone.Image = uiFindPhonePiece;
                }else if(scene.currentScreen == 6){
                    if(scene.pieceLocations[i] == 17 || scene.pieceLocations[i] == 18 || 
                        scene.pieceLocations[i] == 19 || scene.pieceLocations[i] == 20) zone.Image = uiFindPhonePiece;
                }
            }
            //sets the icon if your on a diffrent screen as one
            if(zone.Image == null){
                for(int i = 0; i <scene.pieceLocations.Length; i++){
                    if(scene.currentScreen == 1){
                        if(scene.pieceLocations[i] == 5 || scene.pieceLocations[i] == 6 || 
                            scene.pieceLocations[i] == 7 || scene.pieceLocations[i] == 8) zone.Image = uiArrowLeft;
                        else if(scene.pieceLocations[i] == 9 || scene.pieceLocations[i] == 10 || 
                                scene.pieceLocations[i] == 11 || scene.pieceLocations[i] == 12 ||
                                scene.pieceLocations[i] == 13 || scene.pieceLocations[i] == 14 || 
                                scene.pieceLocations[i] == 15 || scene.pieceLocations[i] == 16) zone.Image = uiArrowRight;
                        else if(scene.pieceLocations[i] == 17 || scene.pieceLocations[i] == 18 || 
                                scene.pieceLocations[i] == 19 || scene.pieceLocations[i] == 20) zone.Image = uiArrowDown;
                    }else if(scene.currentScreen == 2){
                        if(scene.pieceLocations[i] == 1 || scene.pieceLocations[i] == 2 || 
                            scene.pieceLocations[i] == 3 || scene.pieceLocations[i] == 4) zone.Image = uiArrowUp;
                        else if(scene.pieceLocations[i] == 9 || scene.pieceLocations[i] == 10 || 
                                scene.pieceLocations[i] == 11 || scene.pieceLocations[i] == 12 ||
                                scene.pieceLocations[i] == 13 || scene.pieceLocations[i] == 14 || 
                                scene.pieceLocations[i] == 15 || scene.pieceLocations[i] == 16) zone.Image = uiArrowRight;
                        else if(scene.pieceLocations[i] == 17 || scene.pieceLocations[i] == 18 || 
                                scene.pieceLocations[i] == 19 || scene.pieceLocations[i] == 20) zone.Image = uiArrowDown;
                    }else if(scene.currentScreen == 4)                    {
                        if(scene.pieceLocations[i] == 1 || scene.pieceLocations[i] == 2 || 
                            scene.pieceLocations[i] == 3 || scene.pieceLocations[i] == 4) zone.Image = uiArrowUp;
                        else if(scene.pieceLocations[i] == 5 || scene.pieceLocations[i] == 6 || 
                                scene.pieceLocations[i] == 7 || scene.pieceLocations[i] == 8) zone.Image = uiArrowLeft;
                        else if(scene.pieceLocations[i] == 17 || scene.pieceLocations[i] == 18 || 
                                scene.pieceLocations[i] == 19 || scene.pieceLocations[i] == 20) zone.Image = uiArrowDown;
                    }else if(scene.currentScreen == 6){
                        if(scene.pieceLocations[i] == 1 || scene.pieceLocations[i] == 2 || 
                            scene.pieceLocations[i] == 3 || scene.pieceLocations[i] == 4) zone.Image = uiArrowDown;
                        else if(scene.pieceLocations[i] == 5 || scene.pieceLocations[i] == 6 || 
                            scene.pieceLocations[i] == 7 || scene.pieceLocations[i] == 8) zone.Image = uiArrowLeft;
                        else if(scene.pieceLocations[i] == 9 || scene.pieceLocations[i] == 10 || 
                                scene.pieceLocations[i] == 11 || scene.pieceLocations[i] == 12 ||
                                scene.pieceLocations[i] == 13 || scene.pieceLocations[i] == 14 || 
                                scene.pieceLocations[i] == 15 || scene.pieceLocations[i] == 16) zone.Image = uiArrowRight;
                    }
                }
            }
            if(specialing){
                scene.LowerEnergy(19);
                for(int i = 0; i < scene.pieceLocations.Length; i++){
                    specialing = false;
                    if(scene.currentScreen == 1){
                        if(scene.pieceLocations[i] == 1) PutDotAbovePiece(1);
                        else if(scene.pieceLocations[i] == 2) PutDotAbovePiece(2);
                        else if(scene.pieceLocations[i] == 3) PutDotAbovePiece(3);
                        else if(scene.pieceLocations[i] == 4) PutDotAbovePiece(4);
                    }else if(scene.currentScreen == 2){
                        if(scene.pieceLocations[i] == 4) PutDotAbovePiece(5);
                        else if(scene.pieceLocations[i] == 5) PutDotAbovePiece(6);
                        else if(scene.pieceLocations[i] == 7) PutDotAbovePiece(7);
                        else if(scene.pieceLocations[i] == 8) PutDotAbovePiece(8);
                    }else if(scene.currentScreen == 4){
                        if(scene.pieceLocations[i] == 9) PutDotAbovePiece(9);
                        else if(scene.pieceLocations[i] == 10) PutDotAbovePiece(10);
                        else if(scene.pieceLocations[i] == 11) PutDotAbovePiece(11);
                        else if(scene.pieceLocations[i] == 12) PutDotAbovePiece(12);
                        else if(scene.pieceLocations[i] == 13) PutDotAbovePiece(13);
                        else if(scene.pieceLocations[i] == 14) PutDotAbovePiece(14);
                        else if(scene.pieceLocations[i] == 15) PutDotAbovePiece(15);
                        else if(scene.pieceLocations[i] == 16) PutDotAbovePiece(16);
                    }else if(scene.currentScreen == 6){
                        if(scene.pieceLocations[i] == 17) PutDotAbovePiece(17);
                        else if(scene.pieceLocations[i] == 18) PutDotAbovePiece(18);
                        else if(scene.pieceLocations[i] == 19) PutDotAbovePiece(19);
                        else if(scene.pieceLocations[i] == 20) PutDotAbovePiece(20);
                    }
                }
            }
        }
        private void EatCandy(){
            if(specialing){
                if(scene.reeses > 0){
                    scene.LowerEnergy(19);
                    scene.LowerPieces(1);
                    scene.HeigherEnergy(341);
                    specialing = false;
                }
            }
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
            int pieceArrayId = 0;
            if(scene.pieceLocations[0] == pitNumber) pieceArrayId = 0;
            if(scene.pieceLocations[1] == pitNumber) pieceArrayId = 1; 
            if(scene.pieceLocations[2] == pitNumber) pieceArrayId = 2; 
            scene.pieceLocations[pieceArrayId] = 999;
            if(piecesCollected == 1) phone.Image = uiPiece1;
            else if(piecesCollected == 2) phone.Image = uiPiece2;
            else if(piecesCollected == 3) phone.Image = uiPiece3;
        }
        public void FallIntoPit(int pitId){
            inPit = true;
            pitNumber = pitId;
            scientist.Visible = false;
            cia.Visible = false;
            scene.LowerEnergy(269);
            scene.ChangeBackground();
            Falling();
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
                    if(scientist.Location.Y > et.Location.Y) scientist.Top -= 110;
                    else if(scientist.Location.Y < et.Location.Y) scientist.Top += 110;
                    else scientist.Location = new Point(scientist.Location.X, et.Location.Y);
                    if(cia.Location.Y > et.Location.Y) cia.Top -= 110;
                    else if(cia.Location.Y < et.Location.Y) cia.Top += 110;
                    else cia.Location = new Point(cia.Location.X, et.Location.Y);
                //detects the bottom edge
                }else if(et.Location.Y >= 140){
                    scene.ChangeScene(3);
                    et.Top -= 110;
                    if(scientist.Location.Y > et.Location.Y) scientist.Top -= 110;
                    else if(scientist.Location.Y < et.Location.Y) scientist.Top += 110;
                    else scientist.Location = new Point(scientist.Location.X, et.Location.Y);
                    if(cia.Location.Y > et.Location.Y) cia.Top -= 110;
                    else if(cia.Location.Y < et.Location.Y) cia.Top += 110;
                    else cia.Location = new Point(cia.Location.X, et.Location.Y);
                //detects the left edge
                }else if(et.Location.X <= 30){
                    scene.ChangeScene(4);
                    et.Left += 220;
                    if(scientist.Location.X > et.Location.X) scientist.Left -= 220;
                    else if(scientist.Location.X < et.Location.X) scientist.Left += 220;
                    else scientist.Location = new Point(et.Location.X, scientist.Location.Y);
                    if(cia.Location.X > et.Location.X) cia.Left -= 220;
                    else if(cia.Location.X < et.Location.X) cia.Left += 220;
                    else cia.Location = new Point(et.Location.X, cia.Location.Y);
                //detects the right edge
                }else if(et.Location.X >= 270){
                    scene.ChangeScene(2);
                    et.Left -= 220;
                    if(scientist.Location.X > et.Location.X) scientist.Left -= 220;
                    else if(scientist.Location.X < et.Location.X) scientist.Left += 220;
                    else scientist.Location = new Point(et.Location.X, scientist.Location.Y);
                    if(cia.Location.X > et.Location.X) cia.Left -= 220;
                    else if(cia.Location.X < et.Location.X) cia.Left += 220;
                    else cia.Location = new Point(et.Location.X, cia.Location.Y);
                }
            }
            else{
                //detects the top edge of the pit
                if(et.Location.Y <= 26){
                    inPit = false;
                    pitNumber = 0;
                    phonePiece.Visible = false;
                    scene.ChangeBackground();
                    et.Top += 110;
                    scientist.Visible = true;    
                    cia.Visible = true;     
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
        private void CheckOnScreen(){
            if(scientist.Location.X < 320 && scientist.Location.Y < 210 && !inPit) scientistOnFrame = true;
            else scientistOnFrame = false;
            if(cia.Location.X < 320 && cia.Location.Y < 210 && !inPit) ciaOnFrame = true;
            else ciaOnFrame = false;
        }
        private void ReviveET(){
            et.Image = etIdle;
            scene.HeigherEnergy(3333);
            lives -= 1;
            while(340 < eliot.Location.X){
                eliotDirection = "l";
                eliot.Left -= 1;
                if(eliotWalkFrame == 1){
                    eliot.Image = eliotWalk1Left;
                    eliotWalkFrame = 2;
                }else if(eliotWalkFrame == 2){
                    eliot.Image = eliotWalk2Left;
                    eliotWalkFrame = 3;
                }else if(eliotWalkFrame == 3){
                    eliot.Image = eliotWalk3Left;
                    eliotWalkFrame = 4;
                }else if(eliotWalkFrame == 4){
                    eliot.Image = eliotWalk4Left;
                    eliotWalkSound.Play();
                    eliotWalkFrame = 1;
                }
                Thread.Sleep(25);
            }
            while(340 > eliot.Location.X){
                eliotDirection = "r";
                eliot.Left += 1;
                if(eliotWalkFrame == 1){
                    eliot.Image = eliotWalk1;
                    eliotWalkFrame = 2;
                }else if(eliotWalkFrame == 2){
                    eliot.Image = eliotWalk2;
                    eliotWalkFrame = 3;
                }else if(eliotWalkFrame == 3){
                    eliot.Image = eliotWalk3;
                    eliotWalkFrame = 4;
                }else if(eliotWalkFrame == 4){
                    eliot.Image = eliotWalk4;
                    eliotWalkSound.Play();
                    eliotWalkFrame = 1;
                }
                Thread.Sleep(25);
            }
            while(95 > eliot.Location.Y) eliot.Top += 1;
            while(95 < eliot.Location.Y) eliot.Top -= 1;
            dead = false;
        }
        private void MoveEliot(){
            if(et.Location.X < eliot.Location.X){
                eliotDirection = "l";
                eliot.Left -= 1;
            }else if(et.Location.X > eliot.Location.X){
                eliotDirection = "r";
                eliot.Left += 1;
            }
            if(et.Location.Y > eliot.Location.Y) eliot.Top += 1;
            else if(et.Location.Y < eliot.Location.Y) eliot.Top -= 1;
            if(et.Location.X == eliot.Location.X && et.Location.Y == eliot.Location.Y) ReviveET();
            
        }
        public void EliotStarter(){
            eliotWalkFrame = 1;
            eliotAction = new(() =>  {
                while(running){
                    if(dead && lives > 0){
                        MoveEliot();
                        if(eliotWalkFrame == 1){
                            if(eliotDirection.Equals("r")) eliot.Image = eliotWalk1;
                            else if(eliotDirection.Equals("l")) eliot.Image = eliotWalk1Left;
                            eliotWalkFrame = 2;
                        }else if(eliotWalkFrame == 2){
                            if(eliotDirection.Equals("r")) eliot.Image = eliotWalk2;
                            else if(eliotDirection.Equals("l")) eliot.Image = eliotWalk2Left;
                            eliotWalkFrame = 3;
                        }else if(eliotWalkFrame == 3){
                            if(eliotDirection.Equals("r")) eliot.Image = eliotWalk3;
                            else if(eliotDirection.Equals("l")) eliot.Image = eliotWalk3Left;
                            eliotWalkFrame = 4;
                        }else if(eliotWalkFrame == 4){
                            if(eliotDirection.Equals("r")) eliot.Image = eliotWalk4;
                            else if(eliotDirection.Equals("l")) eliot.Image = eliotWalk4Left;
                            eliotWalkSound.Play();
                            eliotWalkFrame = 1;
                        }
                        Thread.Sleep(25);
                    }
                }
            });
            eliotAction.Start();
        }
        private void MoveCia(){
            if(takingPhone && findingET){
                if(et.Location.X < cia.Location.X){
                    ciaDirection = "l";
                    cia.Left -= 1;
                }else if(et.Location.X > cia.Location.X){
                    ciaDirection = "r";
                    cia.Left += 1;
                }
                if(et.Location.Y > cia.Location.Y) cia.Top += 1;
                else if(et.Location.Y < cia.Location.Y) cia.Top -= 1;
                if(et.Location.X == cia.Location.X && et.Location.Y == cia.Location.Y) takingPhone = false;
            }else if(!takingPhone){
                takingPhone = true;
                if(piecesCollected > 0) piecesCollected -= 1;
                if(piecesCollected == 0) phone.Image = null;
                else if(piecesCollected == 1) phone.Image = uiPiece1;
                else if(piecesCollected == 2) phone.Image = uiPiece2;
                else if(piecesCollected == 3) phone.Image = uiPiece3;
                scene.SpawnPhonePieces(1);
                cia.Location = new Point(700,95);
                Thread.Sleep(5000);
            }
            
        }
        public void CiaStarter(){
            ciaWalkFrame = 1;
            takingPhone = true;
            ciaAction = new(() =>  {
                while(running){
                    if(!firstMove && !inPit){
                        CheckOnScreen();
                        MoveCia();
                        if(ciaWalkFrame == 1){
                            if(ciaDirection.Equals("r")) cia.Image = ciaWalk1;
                            else if(ciaDirection.Equals("l")) cia.Image = ciaWalk1Left;
                            ciaWalkFrame = 2;
                        }else if(ciaWalkFrame == 2){
                            if(ciaDirection.Equals("r")) cia.Image = ciaWalk2;
                            else if(ciaDirection.Equals("l")) cia.Image = ciaWalk2Left;
                            ciaWalkFrame = 3;
                        }else if(ciaWalkFrame == 3){
                            if(ciaDirection.Equals("r")) cia.Image = ciaWalk3;
                            else if(ciaDirection.Equals("l")) cia.Image = ciaWalk3Left;
                            ciaWalkFrame = 4;
                        }else if(ciaWalkFrame == 4){
                            if(ciaDirection.Equals("r")) cia.Image = ciaWalk4;
                            else if(ciaDirection.Equals("l")) cia.Image = ciaWalk4Left;
                            if(ciaOnFrame) ciaWalkSound.Play();
                            ciaWalkFrame = 1;
                        }
                        Thread.Sleep(25);
                    }
                }
            });
            ciaAction.Start();
        }
        private void MoveScientist(){
            if(findingET){
                if(et.Location.X < scientist.Location.X){
                    scientistDirection = "l";
                    scientist.Left -= 1;
                }else if(et.Location.X > scientist.Location.X){
                    scientistDirection = "r";
                    scientist.Left += 1;
                }
                if(et.Location.Y > scientist.Location.Y) scientist.Top += 1;
                else if(et.Location.Y < scientist.Location.Y) scientist.Top -= 1;
                if(et.Location.X == scientist.Location.X && et.Location.Y == scientist.Location.Y) findingET = false;
                //Console.WriteLine("Scientist\nX : " + scientist.Location.X + "\nY : " + scientist.Location.Y);
            }else if(!findingET){
                if(scene.currentScreen != 5){
                    scientistDirection = "r";
                    game.Invoke(new Action(DetectEdge));
                    et.Left += 2;
                    scientist.Left += 2;
                    scene.LowerEnergy(1);
                    //if(!(et.Location.X == scientist.Location.X && et.Location.Y == scientist.Location.Y)) findingET = true;
                }else{
                    findingET = true;
                    Thread.Sleep(5000);
                }
            }
            
        }
        public void ScientistStarter(){
            scientistWalkFrame = 1;
            findingET = true;
            scientistAction = new(() =>  {
                while(running){
                    if(!firstMove && !inPit){
                        CheckOnScreen();
                        MoveScientist();
                        if(scientistWalkFrame == 1){
                            if(scientistDirection.Equals("r")) scientist.Image = scientistWalk1;
                            else if(scientistDirection.Equals("l")) scientist.Image = scientistWalk1Left;
                            scientistWalkFrame = 2;
                        }else if(scientistWalkFrame == 2){
                            if(scientistDirection.Equals("r")) scientist.Image = scientistWalk2;
                            else if(scientistDirection.Equals("l")) scientist.Image = scientistWalk2Left;
                            scientistWalkFrame = 3;
                        }else if(scientistWalkFrame == 3){
                            if(scientistDirection.Equals("r")) scientist.Image = scientistWalk3;
                            else if(scientistDirection.Equals("l")) scientist.Image = scientistWalk3Left;
                            scientistWalkFrame = 4;
                        }else if(scientistWalkFrame == 4){
                            if(scientistDirection.Equals("r")) scientist.Image = scientistWalk4;
                            else if(scientistDirection.Equals("l")) scientist.Image = scientistWalk4Left;
                            if(scientistOnFrame) scientistWalkSound.Play();
                            scientistWalkFrame = 5;
                        }else if(scientistWalkFrame == 5){
                            if(scientistDirection.Equals("r")) scientist.Image = scientistWalk5;
                            else if(scientistDirection.Equals("l")) scientist.Image = scientistWalk5Left;
                            scientistWalkFrame = 1;
                        }
                        Thread.Sleep(25);
                    }
                }
            });
            scientistAction.Start();
        }
    }
}