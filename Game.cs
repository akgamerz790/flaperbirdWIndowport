using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FlappyBird
{
    public class Game
    {
        public Bird Bird { get; private set; }
        public List<Pipe> Pipes { get; private set; }
        public int Score { get; private set; }
        
        private int screenWidth;
        private int screenHeight;
        private int pipeSpawnTimer;
        private const int PIPE_SPAWN_INTERVAL = 120; // frames
        private const int PIPE_GAP = 150;
        
        public Game(int width, int height)
        {
            screenWidth = width;
            screenHeight = height;
            
            Bird = new Bird(100, height / 2);
            Pipes = new List<Pipe>();
            Score = 0;
            pipeSpawnTimer = 0;
        }
        
        public void Update(int gravity)
        {
            // Update bird
            Bird.Update(gravity);
            
            // Spawn pipes
            pipeSpawnTimer++;
            if (pipeSpawnTimer >= PIPE_SPAWN_INTERVAL)
            {
                SpawnPipe();
                pipeSpawnTimer = 0;
            }
            
            // Update pipes
            for (int i = Pipes.Count - 1; i >= 0; i--)
            {
                Pipes[i].Update();
                
                // Check if pipe passed the bird (scoring)
                if (!Pipes[i].Scored && Pipes[i].X + Pipes[i].Width < Bird.X)
                {
                    Pipes[i].Scored = true;
                    Score++;
                }
                
                // Remove pipes that are off-screen
                if (Pipes[i].X + Pipes[i].Width < 0)
                {
                    Pipes.RemoveAt(i);
                }
            }
        }
        
        private void SpawnPipe()
        {
            Random rand = new Random();
            int gapY = rand.Next(100, screenHeight - PIPE_GAP - 100);
            
            // Top pipe
            Pipes.Add(new Pipe(screenWidth, 0, gapY));
            
            // Bottom pipe
            Pipes.Add(new Pipe(screenWidth, gapY + PIPE_GAP, screenHeight - (gapY + PIPE_GAP)));
        }
        
        public bool IsGameOver()
        {
            // Check if bird hit the ground or ceiling
            if (Bird.Y <= 0 || Bird.Y + Bird.Height >= screenHeight)
            {
                return true;
            }
            
            // Check collision with pipes
            Rectangle birdRect = new Rectangle(Bird.X, Bird.Y, Bird.Width, Bird.Height);
            
            foreach (var pipe in Pipes)
            {
                Rectangle pipeRect = new Rectangle(pipe.X, pipe.Y, pipe.Width, pipe.Height);
                if (birdRect.IntersectsWith(pipeRect))
                {
                    return true;
                }
            }
            
            return false;
        }
        
        public void Draw(Graphics g)
        {
            // Draw bird
            Bird.Draw(g);
            
            // Draw pipes
            foreach (var pipe in Pipes)
            {
                pipe.Draw(g);
            }
            
            // Draw ground
            using (Brush groundBrush = new SolidBrush(Color.Green))
            {
                g.FillRectangle(groundBrush, 0, screenHeight - 50, screenWidth, 50);
            }
        }
    }
}