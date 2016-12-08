using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        SolidBrush boxBrush = new SolidBrush(Color.White);
                
        List<Box> boxes = new List<Box>();
        List<Box> boxesRight = new List<Box>();

        Character player;
        int boxLeftX = 300, boxRightX = 500;
        int waitTime = 8;
        int x, y, width, height, boxStartL, boxStartR;
        bool gameOver, leftD = false;

        public GameScreen()
        {
            InitializeComponent();
            x = this.Width / 2; y = this.Height / 2;
            player = new Character(x, y, width, height);
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            boxStartL = 300; boxStartR = 500;
            Box b = new Box(300, 0, 30, 30);
            boxes.Add(b);

            b = new Box(500, 0, 30, 30);
            boxesRight.Add(b);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.B:
                    bDown = true;
                    break;
                case Keys.N:
                    nDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.B:
                    bDown = false;
                    break;
                case Keys.N:
                    nDown = false;
                    break;
                case Keys.M:
                    mDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                if (player.collision(player, boxes[i]) || player.collision(player, boxesRight[i]))
                {
                    gameLoop.Enabled = false;
                    gameOver = true;
                    this.Refresh();
                    #region Create Reset Button
                    Button resetButton = new Button();
                    resetButton.Location = new Point(this.Width - 100, this.Height / 2 + 100);
                    resetButton.Text = "Restart";
                    this.Controls.Add(resetButton);
                    resetButton.Click += delegate
                    {
                        Application.Restart();
                        //make reset method at some point, dont be lazy
                    };
                    #endregion
                }
            }
            waitTime--;

            #region create boxes
            if (waitTime == 0)
            {
                
                Box b = new Box(boxStartL, 0, 30, 30);
                boxes.Add(b);

                b = new Box(boxStartR, 0, 30, 30);
                boxesRight.Add(b);               

                waitTime = 8;
            }

            //moving rectangles for hardness
            for (int i = 0; i < boxes.Count; i++)
            {                     
                boxes[i].y += 6;                
                boxesRight[i].y += 6;

                #region box pattern
               
                if (boxesRight[i].x < 800 && leftD == false)
                {
                    boxes[i].x += 3;
                    boxesRight[i].x += 3;
                    boxStartL = boxes[i].x - 10;
                    boxStartR = boxesRight[i].x - 10;
                    if (boxesRight[i].x > 700) { leftD = true; }
                }
                else if (boxesRight[i].x > 800 || leftD)
                {
                    boxes[i].x -= 3;
                    boxesRight[i].x -= 3;
                    boxStartL = boxes[i].x + 10;
                    boxStartR = boxesRight[i].x + 10;
                    leftD = true;
                }
                else if (boxes[i].x <= 200)
                {              
                    leftD = false;
                }
                #endregion
            }
            if (boxes[0].y > this.Height)
            {
                boxes.RemoveAt(0);
                boxesRight.RemoveAt(0);
            }
            #endregion

            //check button presses
            if (leftArrowDown)
            {
                player.x -= 10;
                this.Refresh();
            }
            else if (rightArrowDown)
            {
                player.x += 10;
                this.Refresh();
            }                       
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            Brush solidBlack = new SolidBrush(Color.Black);
            Font black = new Font("Courier New", 16.0f, FontStyle.Bold);

            foreach(Box b in boxes)
            {
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, 30, 30);
            }

            foreach (Box b in boxesRight)
            {
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, 30, 30);
            }
            e.Graphics.FillRectangle(solidBlack, player.x, player.y, 30, 30);  
            
            if (gameOver)
            {
                e.Graphics.DrawString("Game Over", black, solidBlack, this.Width / 2 - 100, this.Height / 2);
            }          
        }
    }
}
