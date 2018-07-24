#region Namespace

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

#endregion

namespace VisualPlus.Toolkit.VisualBase
{
    [ToolboxItem(false)]
    public class ManagedHScrollBar : HScrollBar
    {
        #region Constructors

        public ManagedHScrollBar()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int MHeight
        {
            get
            {
                if (Visible != true)
                {
                    return 0;
                }
                else
                {
                    return Height;
                }
            }

            set
            {
                if (Height != value)
                {
                    Height = value;
                }
            }
        }

        public int MLargeChange
        {
            set
            {
                if (LargeChange != value)
                {
                    LargeChange = value;
                }
            }
        }

        public int MLeft
        {
            set
            {
                if (Left != value)
                {
                    Left = value;
                }
            }
        }

        public int MMaximum
        {
            set
            {
                if (Maximum != value)
                {
                    Maximum = value;
                }
            }
        }

        public int MSmallChange
        {
            set
            {
                if (SmallChange != value)
                {
                    SmallChange = value;
                }
            }
        }

        public int MTop
        {
            set
            {
                if (Top != value)
                {
                    Top = value;
                }
            }
        }

        public bool MVisible
        {
            set
            {
                if (Visible != value)
                {
                    Visible = value;
                }
            }
        }

        public int MWidth
        {
            get
            {
                if (Visible != true)
                {
                    return 0;
                }
                else
                {
                    return Width;
                }
            }

            set
            {
                if (Width != value)
                {
                    Width = value;
                }
            }
        }

        #endregion

        #region Methods

        public void ReflectFocus(object source, EventArgs e)
        {
            Debug.WriteLine("ManagedHScrollbar::Focus called");
            Parent.Focus();
        }

        private void InitializeComponent()
        {
            TabStop = false;
            GotFocus += ReflectFocus;
        }

        #endregion
    }
}