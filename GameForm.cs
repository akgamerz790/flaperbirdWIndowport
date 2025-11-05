using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace FlappyBird
{
    public partial class GameForm : Form
    {
        private Game game;
        private Timer gameTimer;
        private bool gameStarted = false;
        private bool gameOver = false;
        
        // Game settings
        private const int GAME_SPEED = 20; // milliseconds
        private const int GRAVITY = 2;
        private const int JUMP_STRENGTH = -15;
        
        // UI Elements
        private Label scoreLabel;
        private Label gameOverLabel;
        private Label instructionLabel;
        private Button restartButton;
        
        public GameForm()
        {
            InitializeComponent();
            SetupGame();
        }
        
        private void InitializeComponent()
        {
            this.Text = "Flappy Bird - Windows Port";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.SkyBlue;
            this.DoubleBuffered = true;
            
            // Score label
            scoreLabel = new Label()
            {
                Text = "Score: 0",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(10, 10),
                Size = new Size(200, 30)
            };
            this.Controls.Add(scoreLabel);
            
            // Game over label
            gameOverLabel = new Label()
            {
                Text = "GAME OVER!",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.Red,
                BackColor = Color.Transparent,
                Location = new Point(300, 200),
                Size = new Size(200, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            this.Controls.Add(gameOverLabel);
            
            // Instruction label
            instructionLabel = new Label()
            {
                Text = "Press SPACE to start and jump!",
                Font = new Font("Arial", 14),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(250, 300),
                Size = new Size(300, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(instructionLabel);
            
            // Restart button
            restartButton = new Button()
            {
                Text = "Restart Game",
                Font = new Font("Arial", 12),
                Location = new Point(350, 350),
                Size = new Size(100, 30),
                Visible = false
            };
            restartButton.Click += RestartButton_Click;
            this.Controls.Add(restartButton);
            
            // Set up event handlers
            this.KeyDown += GameForm_KeyDown;
            this.Paint += GameForm_Paint;
            this.Focus();
        }
        
        private void SetupGame()
        {
            game = new Game(this.ClientSize.Width, this.ClientSize.Height);
            
            gameTimer = new Timer()
            {
                Interval = GAME_SPEED
            };
            gameTimer.Tick += GameTimer_Tick;
        }
        
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (!gameStarted && !gameOver)
                {
                    // Start the game
                    gameStarted = true;
                    instructionLabel.Visible = false;
                    gameTimer.Start();
                }
                else if (gameStarted && !gameOver)
                {
                    // Make bird jump
                    game.Bird.Jump(JUMP_STRENGTH);
                }
            }
        }
        
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                game.Update(GRAVITY);
                
                // Update score
                scoreLabel.Text = $"Score: {game.Score}";
                
                // Check for game over
                if (game.IsGameOver())
                {
                    GameOver();
                }
                
                // Refresh the form to trigger Paint event
                this.Invalidate();
            }
        }
        
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            if (game != null)
            {
                game.Draw(e.Graphics);
            }
        }
        
        private void GameOver()
        {
            gameOver = true;
            gameTimer.Stop();
            gameOverLabel.Visible = true;
            restartButton.Visible = true;
        }
        
        private void RestartButton_Click(object sender, EventArgs e)
        {
            // Reset game state
            gameStarted = false;
            gameOver = false;
            gameOverLabel.Visible = false;
            restartButton.Visible = false;
            instructionLabel.Visible = true;
            
            // Create new game instance
            SetupGame();
            scoreLabel.Text = "Score: 0";
            
            this.Invalidate();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Ensure the form can receive key events
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}