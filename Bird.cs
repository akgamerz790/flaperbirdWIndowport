using System;
using System.Drawing;

namespace FlappyBird
{
    public class Bird
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int VelocityY { get; set; }
        
        private const int BIRD_SIZE = 30;
        
        public Bird(int startX, int startY)
        {
            X = startX;
            Y = startY;
            Width = BIRD_SIZE;
            Height = BIRD_SIZE;
            VelocityY = 0;
        }
        
        public void Update(int gravity)
        {
            // Apply gravity
            VelocityY += gravity;
            Y += VelocityY;
        }
        
        public void Jump(int jumpStrength)
        {
            VelocityY = jumpStrength;
        }
        
        public void Draw(Graphics g)
        {
            // Draw bird as a yellow circle
            using (Brush birdBrush = new SolidBrush(Color.Yellow))
            {
                g.FillEllipse(birdBrush, X, Y, Width, Height);
            }
            
            // Draw bird outline
            using (Pen birdPen = new Pen(Color.Orange, 2))
            {
                g.DrawEllipse(birdPen, X, Y, Width, Height);
            }
            
            // Draw simple eye
            using (Brush eyeBrush = new SolidBrush(Color.Black))
            {
                g.FillEllipse(eyeBrush, X + Width/2, Y + Height/4, 6, 6);
            }
            
            // Draw beak
            Point[] beakPoints = {
                new Point(X + Width, Y + Height/2),
                new Point(X + Width + 8, Y + Height/2 - 3),
                new Point(X + Width + 8, Y + Height/2 + 3)
            };
            
            using (Brush beakBrush = new SolidBrush(Color.Orange))
            {
                g.FillPolygon(beakBrush, beakPoints);
            }
        }
    }
}