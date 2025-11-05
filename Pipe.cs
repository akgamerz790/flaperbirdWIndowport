using System;
using System.Drawing;

namespace FlappyBird
{
    public class Pipe
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Scored { get; set; }
        
        private const int PIPE_WIDTH = 60;
        private const int PIPE_SPEED = 3;
        
        public Pipe(int startX, int startY, int height)
        {
            X = startX;
            Y = startY;
            Width = PIPE_WIDTH;
            Height = height;
            Scored = false;
        }
        
        public void Update()
        {
            // Move pipe to the left
            X -= PIPE_SPEED;
        }
        
        public void Draw(Graphics g)
        {
            // Draw pipe body
            using (Brush pipeBrush = new SolidBrush(Color.Green))
            {
                g.FillRectangle(pipeBrush, X, Y, Width, Height);
            }
            
            // Draw pipe outline
            using (Pen pipePen = new Pen(Color.DarkGreen, 2))
            {
                g.DrawRectangle(pipePen, X, Y, Width, Height);
            }
            
            // Draw pipe cap (slightly wider)
            int capHeight = 20;
            int capWidth = Width + 8;
            int capX = X - 4;
            
            if (Y == 0) // Top pipe
            {
                // Cap at bottom of top pipe
                using (Brush capBrush = new SolidBrush(Color.DarkGreen))
                {
                    g.FillRectangle(capBrush, capX, Y + Height - capHeight, capWidth, capHeight);
                }
            }
            else // Bottom pipe
            {
                // Cap at top of bottom pipe
                using (Brush capBrush = new SolidBrush(Color.DarkGreen))
                {
                    g.FillRectangle(capBrush, capX, Y, capWidth, capHeight);
                }
            }
        }
    }
}