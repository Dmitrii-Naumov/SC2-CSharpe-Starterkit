using SC2APIProtocol;

namespace SC2_Connector
{
    internal class ImageBoolGrid : BoolGrid
    {
        private ImageData data;
        private const int trueValue = 1;

        public ImageBoolGrid(ImageData data)
        {
            this.data = data;
        }

        public override BoolGrid Clone()
        {
            return new ImageBoolGrid(data);
        }

        internal override bool GetInternal(int x, int y)
        {
            return GetDataValue(data, x, y) == trueValue;
        }

        public override int Width()
        {
            return data.Size.X;
        }

        public override int Height()
        {
            return data.Size.Y;
        }
        public static int GetDataValue(ImageData data, int x, int y)
        {
            if (data.BitsPerPixel == 1)
                return GetDataValueBit(data, x, y);

            return GetDataValueByte(data, x, y);
        }
        public static int GetDataValueBit(ImageData data, int x, int y)
        {
            int pixelID = x + y * data.Size.X;
            int byteLocation = pixelID / 8;
            int bitLocation = pixelID % 8;
            return ((data.Data[byteLocation] & 1 << (7 - bitLocation)) == 0) ? 0 : 1;
        }
        public static int GetDataValueByte(ImageData data, int x, int y)
        {
            int pixelID = x + y * data.Size.X;
            return data.Data[pixelID];
        }
    }
}
