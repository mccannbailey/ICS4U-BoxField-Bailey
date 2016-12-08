using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoxField
{
    class Character
    {
        public int x, y, width, height;

        public Character(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }

        public bool collision(Character ch, Box b)
        {
            Rectangle chRec = new Rectangle(ch.x, ch.y, 30, 30);
            Rectangle cRec = new Rectangle(b.x, b.y, b.width, b.height);

            if (chRec.IntersectsWith(cRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}