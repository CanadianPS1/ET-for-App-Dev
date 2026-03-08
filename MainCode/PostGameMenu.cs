using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Windows.Forms;
using System.Drawing.Text;
using System;
using System.Media;
using MongoDB.Driver;
using MongoDB.Bson;
namespace MainCode{
    public class PostGameMenu{
        private Image backgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "seperated sprites", "Screens", "MainMenue.png"));        
        public PrivateFontCollection fonts = new PrivateFontCollection();
        private Form game;
        private int score;
        private PictureBox background;
        private Label cover, h1, topScoresLabel, highScore, scoreDisplay, errorMessage;
        private TextBox usernameTextBox;
        private Button submitScoreButton, exitButton;
        private SoundPlayer strSound;
        private bool submitedScore;
        public void FirstRun(Form g, int s, PictureBox b){
            fonts.AddFontFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "seperated sprites", "Pixel.ttf"));
            strSound = new SoundPlayer(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds", "MainMenu.wav"));
            strSound.PlayLooping();
            game = g;
            score = s;
            background = b;
            submitedScore = false;
            background.Image = backgroundImage;
            cover = new Label{
                BackColor = Color.DarkBlue,
                Location = new Point(30,30),
                Size = new Size(260, 130),
                Visible = true,
                Parent = background,
            };
            scoreDisplay = new Label{
                BackColor = Color.Transparent,
                ForeColor = Color.Yellow,
                Location = new Point(20,10),
                Size = new Size(160,10),
                Visible = true,
                Parent = background,
                Font = new Font(fonts.Families[0], 12, GraphicsUnit.Pixel),
                Text = "Score: " + score
            };
            background.Controls.Add(scoreDisplay);
            h1 = new Label{
                BackColor = Color.DarkBlue,
                ForeColor = Color.Yellow,
                Location = new Point(127,30),
                Size = new Size(100,30),
                Visible = true,
                Parent = background,
                Font = new Font(fonts.Families[0], 20, GraphicsUnit.Pixel),
                Text = "Score"
            };
            background.Controls.Add(h1);
            var client = new MongoClient("mongodb+srv://admit:passw0rd@schoolpilled.10u9kyg.mongodb.net/?appName=SchoolPilled");
            var database = client.GetDatabase("ET");
            var collection = database.GetCollection<BsonDocument>("ET");
            var top5Scores = collection.AsQueryable()
                .OrderByDescending(x => x["score"])
                .Take(5)
                .ToList();
            var topScores = top5Scores.ToDictionary(
                x => x["name"].AsString,
                x => x["score"].AsInt32
            );
            string scoresList = "";
            int topScore = 0;
            foreach(var player in topScores){
                string name = player.Key;
                int score = player.Value;
                if(score > topScore) topScore = score;
                scoresList += "~" + name + "~ : " + score + "\n";
            }
            topScoresLabel = new Label{
                BackColor = Color.DarkBlue,
                ForeColor = Color.Yellow,
                Location = new Point(50,60),
                Size = new Size(240,60),
                Visible = true,
                Parent = background,
                Font = new Font(fonts.Families[0], 12, GraphicsUnit.Pixel),
                Text = scoresList
            };
            background.Controls.Add(topScoresLabel);

            if(score > topScore){
                highScore = new Label{
                    BackColor = Color.DarkBlue,
                    ForeColor = Color.Yellow,
                    Location = new Point(80,120),
                    Size = new Size(160,10),
                    Visible = true,
                    Parent = background,
                    Font = new Font(fonts.Families[0], 12, GraphicsUnit.Pixel),
                    Text = "YOU GOT THE HIGH SCORE"
                };
                background.Controls.Add(highScore);
            }
            usernameTextBox = new TextBox{
                BackColor = Color.SteelBlue,
                ForeColor = Color.Yellow,
                Location = new Point(80,130),
                Size = new Size(160,10),
                Visible = true,
                Parent = background,
                Font = new Font(fonts.Families[0], 12, GraphicsUnit.Pixel),
                PlaceholderText = "Enter your Username",
            };
            submitScoreButton = new Button{
                BackColor = Color.SteelBlue,
                ForeColor = Color.Yellow,
                Location = new Point(240,120),
                Size = new Size(50, 35),
                Visible = true,
                Parent = background,
                Font = new Font(fonts.Families[0], 10, GraphicsUnit.Pixel),
                Text = "Submit Score"
            };
            submitScoreButton.Click += submitScore;
            background.Controls.Add(usernameTextBox);
            errorMessage = new Label{
                BackColor = Color.DarkBlue,
                ForeColor = Color.Red,
                Location = new Point(80,150),
                Size = new Size(160,10),
                Visible = true,
                Parent = background,
                Font = new Font(fonts.Families[0], 10, GraphicsUnit.Pixel),
            };
            background.Controls.Add(errorMessage);
            exitButton = new Button{
                BackColor = Color.Transparent,
                ForeColor = Color.Red,
                Location = new Point(270,5),
                Size = new Size(20, 20),
                Visible = true,
                Parent = background,
                Font = new Font(fonts.Families[0], 12, GraphicsUnit.Pixel),
                Text = "X"
            };
            exitButton.Click += Exit;
            background.Controls.Add(cover);
        }
        private void Exit(object sender, EventArgs e){
            Application.Exit();
        }
        public void submitScore(object sender, EventArgs e){
            if(!submitedScore){
                while(true){
                    if(usernameTextBox.TextLength > 15){
                        errorMessage.Text = "Name to Long!!!";
                        break;
                    }
                    if(usernameTextBox.TextLength == 0){
                        errorMessage.Text = "Name Empty!!!";
                        break;
                    }
                    if(usernameTextBox.Text == null){
                        errorMessage.Text = "Name Empty!!!";
                        break;
                    }
                    if(usernameTextBox.Text.ToLower().Contains("toe")){
                        errorMessage.Text = "Not rn Jacob >:(";
                        break;
                    }
                    var user = new BsonDocument{
                        { "name", usernameTextBox.Text},
                        { "score", score}
                    };
                    var client = new MongoClient("mongodb+srv://admit:passw0rd@schoolpilled.10u9kyg.mongodb.net/?appName=SchoolPilled");
                    var database = client.GetDatabase("ET");
                    var collection = database.GetCollection<BsonDocument>("ET");


                    if(collection.AsQueryable().Any(doc => doc["name"] == usernameTextBox.Text)){
                        string usersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "seperated sprites", "users.txt");
                        if (File.ReadAllText(usersFile).Contains(usernameTextBox.Text)){
                            var userToUpdate = collection.AsQueryable().FirstOrDefault(d => d["name"] == usernameTextBox.Text);
                            if(userToUpdate["score"] < score){
                                var filter = Builders<BsonDocument>.Filter.Eq("_id", userToUpdate["_id"]);
                                var update = Builders<BsonDocument>.Update.Set("score", score);
                                collection.UpdateOne(filter, update);
                                submitedScore = true;
                                errorMessage.Text = null;
                            }
                        }else{
                            errorMessage.Text = "Thats name isnt yours >:(";
                            break;
                        }
                    }else{
                        string usersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "seperated sprites", "users.txt");
                        if(!File.ReadAllText(usersFile).Contains(usernameTextBox.Text)){
                            File.AppendAllText(usersFile, usernameTextBox.Text + Environment.NewLine);
                        }
                        collection.InsertOne(user);
                        submitedScore = true;
                        errorMessage.Text = null;
                    }


                    
                    var top5Scores = collection.AsQueryable()
                    .OrderByDescending(x => x["score"])
                    .Take(5)
                    .ToList();
                    var topScores = top5Scores.ToDictionary(
                        x => x["name"].AsString,
                        x => x["score"].AsInt32
                    );
                    string scoresList = "";
                    foreach(var player in topScores){
                        string name = player.Key;
                        int score = player.Value;
                        scoresList += "~" + name + "~ : " + score + "\n";
                    }
                    topScoresLabel.Text = scoresList;
                    break;
                }
            }
        }
    }
}