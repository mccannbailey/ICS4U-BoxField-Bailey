using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxField
{
    class Box
    {
        public int x, y, width, height;

        /// <summary>
        /// Constructor method for a box
        /// </summary>
        /// <param name="_x">x postion on screen</param>
        /// <param name="_y">y position on screen</param>
        public Box (int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }
    }
}
