#region Namespace

using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

#endregion

namespace VisualPlus.Structure
{
    [StructLayout(LayoutKind.Explicit)]
    public struct RECT
    {
        [FieldOffset(0)]
        public int Left;

        [FieldOffset(4)]
        public int Top;

        [FieldOffset(8)]
        public int Right;

        [FieldOffset(12)]
        public int Bottom;

        /// <summary>Initializes a new instance of the <see cref="RECT" /> struct.</summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        public RECT(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>Initializes a new instance of the <see cref="RECT" /> struct.</summary>
        /// <param name="rectangle">The rectangle.</param>
        public RECT(Rectangle rectangle) : this(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom)
        {
        }

        /// <summary>Retrieves the <see cref="Rectangle" /> from the <see cref="RECT" />.</summary>
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(Left, Top, Right, Bottom - 1);
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="RECT" /> is empty.</summary>
        public bool IsEmpty
        {
            get
            {
                return (Left == 0) && (Top == 0) && (Right == 0) && (Bottom == 0);
            }
        }

        public int X
        {
            get
            {
                return Left;
            }

            set
            {
                Right -= Left - value;
                Left = value;
            }
        }

        public int Y
        {
            get
            {
                return Top;
            }

            set
            {
                Bottom -= Top - value;
                Top = value;
            }
        }

        public int Height
        {
            get
            {
                return Bottom - Top;
            }

            set
            {
                Bottom = value + Top;
            }
        }

        public int Width
        {
            get
            {
                return Right - Left;
            }

            set
            {
                Right = value + Left;
            }
        }

        public Point Location
        {
            get
            {
                return new Point(Left, Top);
            }

            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Size Size
        {
            get
            {
                return new Size(Width, Height);
            }

            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        public static implicit operator Rectangle(RECT rect)
        {
            return new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height);
        }

        public static implicit operator RECT(Rectangle rectangle)
        {
            return new RECT(rectangle);
        }

        public static bool operator ==(RECT rect1, RECT rect2)
        {
            return rect1.Equals(rect2);
        }

        public static bool operator !=(RECT rect1, RECT rect2)
        {
            return !rect1.Equals(rect2);
        }

        public bool Equals(RECT rect)
        {
            return (rect.Left == Left) && (rect.Top == Top) && (rect.Right == Right) && (rect.Bottom == Bottom);
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case RECT rect:
                    {
                        return Equals(rect);
                    }

                case Rectangle rectangle:
                    {
                        return Equals(new RECT(rectangle));
                    }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ((Rectangle)this).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
        }
    }
}