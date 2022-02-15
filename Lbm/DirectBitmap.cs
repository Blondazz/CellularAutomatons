using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using System.Runtime.InteropServices;

namespace LBM
{

    public class DirectBitmap : IDisposable
    {
        public Bitmap Bmp { get; private set; }
        public Int32[] Bits { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        private bool _disposed;

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bmp = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public DirectBitmap(Bitmap bmp)
        {
            Width = bmp.Width;
            Height = bmp.Height;
            Bits = new Int32[Width * Height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bmp = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    this.SetPixel(i, j, bmp.GetPixel(i, j));
                }
            }
        }

        public DirectBitmap(DirectBitmap directBmp) : this(directBmp.Bmp)
        {
        }

        public void SetPixel(int x, int y, Color color)
        {
            int index = x + (y * Width);
            int col = color.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            var result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            Bmp.Dispose();
            BitsHandle.Free();
        }
    }
}