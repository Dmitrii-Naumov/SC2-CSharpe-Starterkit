using System;
using System.Collections.Generic;
using SC2APIProtocol;

namespace SC2_Connector
{ 
    internal abstract class BoolGrid
    {
        protected bool Inverted = false;
        internal abstract bool GetInternal(int x, int y);
        public bool Get(Point2D pos)
        {
            if (pos.X < 0 || pos.Y < 0 || pos.X >= Width() || pos.Y >= Height())
                return false;
            return GetInternal((int)pos.X, (int)pos.Y) == (!Inverted);
        }
        public bool Get(float x, float y)
        {
            if (x < 0 || y < 0 || x >= Width() || y >= Height())
                return false;
            return GetInternal((int)x, (int)y) == (!Inverted);
        }

        public BoolGrid Invert()
        {
            BoolGrid result = Clone();
            result.Inverted = true;
            return result;
        }

        public abstract BoolGrid Clone();
        public abstract int Width();
        public abstract int Height();

        public bool this[Point2D pos]
        {
            get { return Get(pos); }
        }

        public bool this[int x, int y]
        {
            get { return Get(x, y); }
        }

        public int Count()
        {
            int result = 0;
            for (int x = 0; x < Width(); x++)
                for (int y = 0; y < Height(); y++)
                    if (this[x, y])
                        result++;
            return result;
        }
    }
}
