using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.Math
{
    class Vec2
    {
        public int X { get; }
        public int Y { get; }

        public Vec2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vec2 Add(Vec2 other)
        {
            return new Vec2(X + other.X, Y + other.Y);
        }

        public Vec2 AddX(int value)
        {
            return new Vec2(X + value, Y);
        }

        public Vec2 AddY(int value)
        {
            return new Vec2(X, Y + value);
        }
    }
}
