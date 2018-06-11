namespace VisualPlus.Toolkit.Controls.DataManagement
{
    #region Namespace

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using VisualPlus.Collections.CollectionBase;
    using VisualPlus.Collections.CollectionsEditor;
    using VisualPlus.Constants;
    using VisualPlus.Delegates;
    using VisualPlus.Enumerators;
    using VisualPlus.EventArgs;
    using VisualPlus.Localization;
    using VisualPlus.Managers;
    using VisualPlus.Native;
    using VisualPlus.Renders;
    using VisualPlus.Toolkit.Child;
    using VisualPlus.Toolkit.Controls.DataManagement.ListViewComponents;
    using VisualPlus.Toolkit.VisualBase;

    #endregion

    /// <summary>The visual list view.</summary>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("SelectedIndexChanged")]
    [DefaultProperty("Items")]
    [Description("The Visual ListView")]

    // [Designer(typeof(VisualListViewAdvDesigner))]
    [ToolboxBitmap(typeof(VisualListViewEx), "VisualListView.bmp")]
    [ToolboxItem(true)]
    public partial class VisualListViewEx : VisualControlBase
    {
        #region Variables

        private Control _activatedEmbeddedControl;
        private bool _allowColumnResize;
        private bool _alternatingColors;
        private bool _autoHeight;
        private bool _backgroundStretchToFit;
        private bool _borderVisible;
        private Color _colorAlternateBackground;
        private Color _colorGridColor;
        private Color _colorSelectionColor;
        private Color _colorSuperFlatHeaderColor;
        private int _columnIndex;
        private VisualListViewColumnCollection _columns;
        private IContainer _components;
        private LVControlStyles _controlStyle;
        private BorderStrip _cornerBox;
        private string _displayText;
        private Color _displayTextColor;
        private Font _displayTextFont;
        private bool _displayTextOnEmpty;
        private VisualListViewItem _focusedItem;
        private bool _fullRowSelect;
        private GridLines _gridLines;
        private GridLineStyle _gridLineStyle;
        private GridTypes _gridType;
        private int _headerHeight;
        private bool _headerVisible;
        private bool _headerWordWrap;
        private BorderStrip _horizontalBottomBorderStrip;
        private ManagedHScrollBar _horizontalScrollBar;
        private BorderStrip _horizontalTopBorderStrip;
        private int _hotColumnIndex;
        private bool _hotColumnTracking;
        private int _hotItemIndex;
        private bool _hotItemTracking;
        private Color _hotTrackingColor;
        private bool _hoverEvents;
        private bool _hoverLive;
        private int _hoverTime;
        private ImageList _imageListColumns;
        private ImageList _imageListItems;
        private int _itemHeight;
        private VisualListViewItemCollection _items;
        private bool _itemWordWrap;
        private Point _lastHoverSpot;
        private int _lastSelectionIndex;
        private int _lastSubSelectionIndex;
        private ArrayList _liveControls;
        private int _maxHeight;
        private bool _multiSelect;
        private ArrayList _newLiveControls;
        private Point _pointColumnResizeAnchor;
        private int _resizeColumnNumber;
        private bool _selectable;
        private Color _selectedTextColor;
        private bool _showFocusRect;
        private SortTypes _sortType;
        private ListStates _state;
        private IntPtr _theme;
        private bool _themesAvailable;
        private Timer _timer;
        private bool _updating;
        private BorderStrip _verticalLeftBorderStrip;
        private BorderStrip _verticalRightBorderStrip;
        private ManagedVScrollBar _verticalScrollBar;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualListViewEx" /> class.</summary>
        public VisualListViewEx()
        {
            DebugTraceManager.WriteDebug("VisualListView::Constructor", DebugTraceManager.DebugOutput.TraceListener);

            _liveControls = new ArrayList();
            _allowColumnResize = true;
            _autoHeight = true;
            _backgroundStretchToFit = true;
            _fullRowSelect = true;
            _headerVisible = true;
            _selectable = true;
            _borderVisible = false;
            _colorAlternateBackground = Color.DarkGreen;
            _colorGridColor = Color.LightGray;
            _colorSelectionColor = Color.DarkBlue;
            _colorSuperFlatHeaderColor = Color.White;
            _newLiveControls = new ArrayList();
            _sortType = SortTypes.InsertionSort;
            _selectedTextColor = Color.White;
            _lastHoverSpot = new Point(0, 0);
            _state = ListStates.None;
            _itemHeight = 18;
            _hoverTime = 1;
            _hotItemIndex = -1;
            _hotColumnIndex = -1;
            _columnIndex = 0;
            _headerHeight = 22;
            _theme = IntPtr.Zero;
            _hotTrackingColor = Color.LightGray;
            _gridType = GridTypes.Normal;
            _gridLineStyle = GridLineStyle.Solid;
            _gridLines = GridLines.Both;
            _controlStyle = LVControlStyles.SuperFlat;
            _multiSelect = false;
            _hotItemTracking = true;
            _hotColumnTracking = true;

            _displayTextOnEmpty = true;
            _displayTextColor = Color.DimGray;
            _displayText = "The list is empty.";
            _displayTextFont = DefaultFont;

            _columns = new VisualListViewColumnCollection(this);
            _columns.ChangedEvent += Columns_Changed;

            _items = new VisualListViewItemCollection(this);
            _items.ChangedEvent += Items_Changed;

            InitializeComponent();

            if (!DesignMode)
            {
                if (AreThemesAvailable())
                {
                    _themesAvailable = true;
                }
                else
                {
                    _themesAvailable = false;
                }
            }

            TabStop = true;

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.Opaque |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.Selectable |
                ControlStyles.UserMouse,
                true);

            BackColor = SystemColors.ControlLightLight;

            SuspendLayout();

            _horizontalScrollBar = new ManagedHScrollBar
                {
                    Anchor = AnchorStyles.None,
                    CausesValidation = false,
                    Location = new Point(24, 0),
                    MHeight = 16,
                    MWidth = 120,
                    Name = "hPanelScrollBar",
                    Size = new Size(120, 16),
                    Parent = this
                };
            _horizontalScrollBar.Scroll += OnScroll;
            _horizontalScrollBar.Scroll += HorizontalPanelScrollBar_Scroll;
            Controls.Add(_horizontalScrollBar);

            _verticalScrollBar = new ManagedVScrollBar
                {
                    Anchor = AnchorStyles.None,
                    CausesValidation = false,
                    Location = new Point(0, 12),
                    MHeight = 120,
                    MWidth = 16,
                    Name = "vPanelScrollBar",
                    Size = new Size(16, 120),
                    Parent = this
                };
            _verticalScrollBar.Scroll += OnScroll;
            _verticalScrollBar.Scroll += VerticalPanelScrollBar_Scroll;
            Controls.Add(_verticalScrollBar);

            _horizontalTopBorderStrip = new BorderStrip
                {
                    Parent = this,
                    BorderType = BorderStrip.BorderTypes.Top,
                    Visible = false
                };
            _horizontalTopBorderStrip.BringToFront();

            _horizontalBottomBorderStrip = new BorderStrip
                {
                    Parent = this,
                    BorderType = BorderStrip.BorderTypes.Bottom,
                    Visible = true
                };
            _horizontalBottomBorderStrip.BringToFront();

            _verticalLeftBorderStrip = new BorderStrip
                {
                    BorderType = BorderStrip.BorderTypes.Left,
                    Parent = this,
                    Visible = true
                };
            _verticalLeftBorderStrip.BringToFront();

            _verticalRightBorderStrip = new BorderStrip
                {
                    BorderType = BorderStrip.BorderTypes.Right,
                    Parent = this,
                    Visible = true
                };
            _verticalRightBorderStrip.BringToFront();

            _cornerBox = new BorderStrip
                {
                    BackColor = SystemColors.Control,
                    BorderType = BorderStrip.BorderTypes.Square,
                    Visible = false,
                    Parent = this
                };
            _cornerBox.BringToFront();

            Size = new Size(121, 97);
            ResumeLayout(false);
        }

        #endregion

        #region Delegates

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public delegate void ClickedEventHandler(object source, ListViewClickEventArgs e);

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public delegate void HoverEventDelegate(object source, ListViewHoverEventArgs e);

        #endregion

        #region Events

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event ListViewChangedEventHandler ColumnChangedEvent;

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event ClickedEventHandler ColumnClickedEvent;

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event HoverEventDelegate HoverEvent;

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event ListViewChangedEventHandler ItemChangedEvent;

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event ClickedEventHandler SelectedIndexChanged;

        #endregion

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Control ActivatedEmbeddedControl
        {
            get
            {
                return _activatedEmbeddedControl;
            }

            set
            {
                _activatedEmbeddedControl = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Toggle)]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public bool AllowColumnResize
        {
            get
            {
                return _allowColumnResize;
            }

            set
            {
                _allowColumnResize = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public Color AlternateBackground
        {
            get
            {
                return _colorAlternateBackground;
            }

            set
            {
                _colorAlternateBackground = value;

                if (DesignMode && (Parent != null))
                {
                    Parent.Invalidate(true);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Toggle)]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public bool AlternatingColors
        {
            get
            {
                return _alternatingColors;
            }

            set
            {
                _alternatingColors = value;

                if (DesignMode && (Parent != null))
                {
                    Parent.Invalidate(true);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Toggle)]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public bool AutoHeight
        {
            get
            {
                return _autoHeight;
            }

            set
            {
                _autoHeight = value;
                if (DesignMode && (Parent != null))
                {
                    Parent.Invalidate(true);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Toggle)]
        [Category(EventCategory.Behavior)]
        [Browsable(true)]
        public bool BackgroundStretchToFit
        {
            get
            {
                return _backgroundStretchToFit;
            }

            set
            {
                _backgroundStretchToFit = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Size)]
        [Category(EventCategory.Appearance)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderPadding
        {
            get
            {
                if (BorderVisible)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Description(PropertyDescription.Toggle)]
        [Category(EventCategory.Appearance)]
        [Browsable(true)]
        public bool BorderVisible
        {
            get
            {
                return _borderVisible;
            }

            set
            {
                _borderVisible = value;

                if (DesignMode && (Parent != null))
                {
                    Parent.Invalidate(true);
                }
            }
        }

        [Description(PropertyDescription.Size)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int CellPaddingSize
        {
            get
            {
                return 2;
            }
        }

        /// <summary>Gets the indexes of the currently checked items in the control.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<int> CheckedIndicies
        {
            get
            {
                var _checkedItems = new List<int>();

                for (var i = 0; i < _items.Count; i++)
                {
                    if (_items[i].SubItems[0].Checked)
                    {
                        _checkedItems.Add(i);
                    }
                }

                return _checkedItems;
            }
        }

        /// <summary>Gets the currently checked items in the control.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<VisualListViewItem> CheckedItems
        {
            get
            {
                var _checkedItems = new List<VisualListViewItem>();

                foreach (VisualListViewItem _item in _items)
                {
                    if (_item.SubItems[0].Checked)
                    {
                        _checkedItems.Add(_item);
                    }
                }

                return _checkedItems;
            }
        }

        /// <summary>Gets the current column index.</summary>
        [Browsable(false)]
        public int ColumnIndex
        {
            get
            {
                return _columnIndex;
            }
        }

        [Category(PropertyCategory.Behavior)]
        [Description("The columns shown in Details view.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(VisualListViewColumnCollectionEditor), typeof(UITypeEditor))]
        [Browsable(true)]
        public VisualListViewColumnCollection Columns
        {
            get
            {
                return _columns;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("The control theme.")]
        [Category(EventCategory.Behavior)]
        [Browsable(true)]
        public LVControlStyles ControlStyle
        {
            get
            {
                return _controlStyle;
            }

            set
            {
                _controlStyle = value;

                if (DesignMode && (Parent != null))
                {
                    DebugTraceManager.WriteDebug("Calling Invalidate from ControlStyle Property", DebugTraceManager.DebugOutput.TraceListener);
                    Parent.Invalidate(true);
                }
            }
        }

        [Description("Number of items/rows.")]
        [Category(EventCategory.Behavior)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [DefaultValue(0)]
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        [Description(PropertyDescription.Text)]
        [Category(PropertyCategory.Appearance)]
        [Browsable(true)]
        public string DisplayText
        {
            get
            {
                return _displayText;
            }

            set
            {
                _displayText = value;
                Invalidate();
            }
        }

        [Description(PropertyDescription.Color)]
        [Category(PropertyCategory.Appearance)]
        [Browsable(true)]
        public Color DisplayTextColor
        {
            get
            {
                return _displayTextColor;
            }

            set
            {
                _displayTextColor = value;
                Invalidate();
            }
        }

        [Description(PropertyDescription.Font)]
        [Category(PropertyCategory.Appearance)]
        [Browsable(true)]
        public Font DisplayTextFont
        {
            get
            {
                return _displayTextFont;
            }

            set
            {
                _displayTextFont = value;
                Invalidate();
            }
        }

        [Description(PropertyDescription.Toggle)]
        [Category(PropertyCategory.Appearance)]
        [Browsable(true)]
        public bool DisplayTextOnEmpty
        {
            get
            {
                return _displayTextOnEmpty;
            }

            set
            {
                _displayTextOnEmpty = value;
                Invalidate();
            }
        }

        [Description("Currently focused item.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public VisualListViewItem FocusedItem
        {
            get
            {
                // need to make sure focused item actually exists
                if ((_focusedItem != null) && (_items.FindItemIndex(_focusedItem) < 0))
                {
                    _focusedItem = null; // even though there is a focused item, it doesn't actually exist anymore
                }

                return _focusedItem;
            }

            set
            {
                if (_focusedItem != value)
                {
                    _focusedItem = value;
                    if (!DesignMode)
                    {
                        DebugTraceManager.WriteDebug("Calling Invalidate From FocusedItem", DebugTraceManager.DebugOutput.TraceListener);
                        Invalidate(true);
                    }

                    SelectedIndexChanged?.Invoke(this, new ListViewClickEventArgs(_items.FindItemIndex(value), -1)); // never a column sent with selection index change
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Toggle)]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public bool FullRowSelect
        {
            get
            {
                return _fullRowSelect;
            }

            set
            {
                _fullRowSelect = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        [Category(PropertyCategory.Appearance)]
        [Browsable(true)]
        public Color GridColor
        {
            get
            {
                return _colorGridColor;
            }

            set
            {
                _colorGridColor = value;

                if (DesignMode && (Parent != null))
                {
                    DebugTraceManager.WriteDebug("Calling Invalidate From GridColor", DebugTraceManager.DebugOutput.TraceListener);
                    Parent.Invalidate(true);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Whether or not to draw gridlines.")]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public GridLines GridLines
        {
            get
            {
                return _gridLines;
            }

            set
            {
                _gridLines = value;

                if (DesignMode && (Parent != null))
                {
                    DebugTraceManager.WriteDebug("Calling Invalidate From GLGridLines", DebugTraceManager.DebugOutput.TraceListener);
                    Parent.Invalidate(true);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Whether or not to draw gridlines style.")]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public GridLineStyle GridLineStyle
        {
            get
            {
                return _gridLineStyle;
            }

            set
            {
                _gridLineStyle = value;

                if (DesignMode && (Parent != null))
                {
                    // Invalidate();
                    Parent.Invalidate(true);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Whether or not to draw grid types.")]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public GridTypes GridTypes
        {
            get
            {
                return _gridType;
            }

            set
            {
                _gridType = value;

                if (DesignMode && (Parent != null))
                {
                    DebugTraceManager.WriteDebug("Calling Invalidate From GLGridTypes", DebugTraceManager.DebugOutput.TraceListener);
                    Parent.Invalidate(true);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Size)]
        [Category(PropertyCategory.Appearance)]
        [Browsable(true)]
        public int HeaderHeight
        {
            get
            {
                if (HeaderVisible)
                {
                    return _headerHeight;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                _headerHeight = value;
                if (DesignMode && (Parent != null))
                {
                    DebugTraceManager.WriteDebug("Calling Invalidate From HeaderHeight", DebugTraceManager.DebugOutput.TraceListener);
                    Parent.Invalidate(true);
                }
            }
        }

        [Description(PropertyDescription.Rectangle)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Rectangle HeaderRect
        {
            get
            {
                return new Rectangle(BorderPadding, BorderPadding, Width - (BorderPadding * 2), HeaderHeight);
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Toggle)]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public bool HeaderVisible
        {
            get
            {
                return _headerVisible;
            }

            set
            {
                _headerVisible = value;
                if (DesignMode && (Parent != null))
                {
                    Parent.Invalidate(true);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Toggle)]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public bool HeaderWordWrap
        {
            get
            {
                return _headerWordWrap;
            }

            set
            {
                _headerWordWrap = value;

                if (DesignMode && (Parent != null))
                {
                    Parent.Invalidate(true);
                }
            }
        }

        [Browsable(false)]
        public ManagedHScrollBar HorizontalScrollBar
        {
            get
            {
                return _horizontalScrollBar;
            }

            set
            {
                _horizontalScrollBar = value;
            }
        }

        [Description("Currently Focused Column")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int HotColumnIndex
        {
            get
            {
                return _hotColumnIndex;
            }

            set
            {
                if (_hotColumnTracking)
                {
                    if (_hotColumnIndex != value)
                    {
                        _hotItemIndex = -1;
                        _hotColumnIndex = value;

                        if (!DesignMode)
                        {
                            DebugTraceManager.WriteDebug("Calling Invalidate From HotColumnIndex", DebugTraceManager.DebugOutput.TraceListener);
                            Invalidate(true);
                        }
                    }
                }
            }
        }

        [Description(PropertyDescription.Toggle)]
        [Category(EventCategory.Behavior)]
        [Browsable(true)]
        public bool HotColumnTracking
        {
            get
            {
                return _hotColumnTracking;
            }

            set
            {
                _hotColumnTracking = value;
            }
        }

        [Description("Currently Focused Item")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int HotItemIndex
        {
            get
            {
                return _hotItemIndex;
            }

            set
            {
                if (_hotItemTracking)
                {
                    if (_hotItemIndex != value)
                    {
                        _hotColumnIndex = -1;
                        _hotItemIndex = value;

                        if (_hotItemIndex > 0)
                        {
                            HoveredItem = _items[_hotItemIndex];
                        }

                        DebugTraceManager.WriteDebug("Calling Invalidate From HotItemIndex", DebugTraceManager.DebugOutput.TraceListener);
                        Invalidate(true);
                    }
                }
            }
        }

        [Description(PropertyDescription.Toggle)]
        [Category(EventCategory.Behavior)]
        [Browsable(true)]
        public bool HotItemTracking
        {
            get
            {
                return _hotItemTracking;
            }

            set
            {
                _hotItemTracking = value;
            }
        }

        [Description(PropertyDescription.Color)]
        [Category(EventCategory.Appearance)]
        [Browsable(true)]
        public Color HotTrackingColor
        {
            get
            {
                return _hotTrackingColor;
            }

            set
            {
                _hotTrackingColor = value;
            }
        }

        [Browsable(false)]
        public VisualListViewItem HoveredItem { get; private set; }

        [Description("Enabling hover events slows the control some but allows you to be informed when a user has hovered over an item.")]
        [Category(EventCategory.Behavior)]
        [Browsable(true)]
        public bool HoverEvents
        {
            get
            {
                return _hoverEvents;
            }

            set
            {
                _hoverEvents = value;

                if (!DesignMode)
                {
                    if (_hoverEvents)
                    {
                        // turn the events off, so we need to add the events
                        _timer = new Timer();
                        _timer.Interval = _hoverTime * 1000; // convert to seconds
                        _timer.Tick += HoverTimer_TimerTick;
                        _timer.Start();
                    }
                    else if (_timer != null)
                    {
                        // turn the events off
                        _timer.Stop();
                        _timer = null;
                    }
                }
            }
        }

        [Description("Amount of time in seconds a user hovers before hover event is fired. Can NOT be zero.")]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public int HoverTime
        {
            get
            {
                return _hoverTime;
            }

            set
            {
                if (_hoverTime < 1)
                {
                    _hoverTime = 1;
                }
                else
                {
                    _hoverTime = value;
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("ImageList to be used in listview.")]
        [Category(EventCategory.Behavior)]
        [Browsable(true)]
        public ImageList ImageListColumns
        {
            get
            {
                return _imageListColumns;
            }

            set
            {
                _imageListColumns = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("ImageList to be used in listview.")]
        [Category(EventCategory.Behavior)]
        [Browsable(true)]
        public ImageList ImageListItems
        {
            get
            {
                return _imageListItems;
            }

            set
            {
                _imageListItems = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Size)]
        [Category(PropertyCategory.Appearance)]
        [Browsable(true)]
        public int ItemHeight
        {
            get
            {
                return _itemHeight;
            }

            set
            {
                _itemHeight = value;
                if (DesignMode && (Parent != null))
                {
                    DebugTraceManager.WriteDebug("Calling Invalidate From ItemHeight", DebugTraceManager.DebugOutput.TraceListener);
                    Parent.Invalidate(true);
                }
            }
        }

        [Category(PropertyCategory.Data)]
        [Description("The items in the collection.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(VisualListViewItemCollectionEditor), typeof(UITypeEditor))]
        [Browsable(true)]
        public VisualListViewItemCollection Items
        {
            get
            {
                return _items;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Toggle)]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public bool ItemWordWrap
        {
            get
            {
                return _itemWordWrap;
            }

            set
            {
                _itemWordWrap = value;

                if (DesignMode && (Parent != null))
                {
                    Parent.Invalidate(true);
                }
            }
        }

        [Description(PropertyDescription.Size)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int MaxHeight
        {
            get
            {
                return _maxHeight;
            }

            set
            {
                if (value > _maxHeight)
                {
                    _maxHeight = value;
                    if (AutoHeight)
                    {
                        ItemHeight = MaxHeight;

                        if (!DesignMode)
                        {
                            DebugTraceManager.WriteDebug("Calling Invalidate From MaxHeight", DebugTraceManager.DebugOutput.TraceListener);
                            Invalidate(true);
                        }

                        DebugTraceManager.WriteDebug("Item height set bigger", DebugTraceManager.DebugOutput.TraceListener);
                    }
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Toggle)]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public bool MultiSelect
        {
            get
            {
                return _multiSelect;
            }

            set
            {
                _multiSelect = value;
            }
        }

        [Description("The rectangle of the client inside parent control")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Rectangle RowsClientRect
        {
            get
            {
                int tmpY = HeaderHeight + BorderPadding; // size of the header and the top border

                int tmpHeight = Height - HeaderHeight - (BorderPadding * 2);

                return new Rectangle(BorderPadding, tmpY, Width - (BorderPadding * 2), tmpHeight);
            }
        }

        [Description("The inner rectangle of the client inside parent control taking scroll bars into account.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Rectangle RowsInnerClientRect
        {
            get
            {
                Rectangle innerRect = RowsClientRect;

                innerRect.Width -= _verticalScrollBar.MWidth; // horizontal bar crosses vertical plane and vice versa
                innerRect.Height -= _horizontalScrollBar.MHeight;

                if (innerRect.Width < 0)
                {
                    innerRect.Width = 0;
                }

                if (innerRect.Height < 0)
                {
                    innerRect.Height = 0;
                }

                return innerRect;
            }
        }

        [Description("Full Sized rectangle of all columns total width.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Rectangle RowsRect
        {
            get
            {
                Rectangle rect = new Rectangle();

                rect.X = -_horizontalScrollBar.Value + BorderPadding;
                rect.Y = HeaderHeight + BorderPadding;
                rect.Width = Columns.Width;
                rect.Height = VisibleRowsCount * ItemHeight;

                return rect;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Toggle)]
        [Category(EventCategory.Behavior)]
        [Browsable(true)]
        public bool Selectable
        {
            get
            {
                return _selectable;
            }

            set
            {
                _selectable = value;
            }
        }

        /// <summary>Gets the currently selected indicies in the control.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<int> SelectedIndicies
        {
            get
            {
                return _items.SelectedIndicies;
            }
        }

        /// <summary>Gets the currently selected items in the control.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<VisualListViewItem> SelectedItems
        {
            get
            {
                return _items.SelectedItems;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        [Category(PropertyCategory.Appearance)]
        [Browsable(true)]
        public Color SelectedTextColor
        {
            get
            {
                return _selectedTextColor;
            }

            set
            {
                _selectedTextColor = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        [Category(PropertyCategory.Appearance)]
        [Browsable(true)]
        public Color SelectionColor
        {
            get
            {
                return _colorSelectionColor;
            }

            set
            {
                _colorSelectionColor = value;
            }
        }

        [Description(PropertyDescription.Toggle)]
        [Category(PropertyCategory.Behavior)]
        [Browsable(true)]
        public bool ShowFocusRect
        {
            get
            {
                return _showFocusRect;
            }

            set
            {
                _showFocusRect = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Type of sorting algorithm used.")]
        [Category(EventCategory.Behavior)]
        [Browsable(true)]
        public SortTypes SortType
        {
            get
            {
                return _sortType;
            }

            set
            {
                _sortType = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        [Category(PropertyCategory.Appearance)]
        [Browsable(true)]
        public Color SuperFlatHeaderColor
        {
            get
            {
                return _colorSuperFlatHeaderColor;
            }

            set
            {
                _colorSuperFlatHeaderColor = value;

                if (DesignMode && (Parent != null))
                {
                    Parent.Invalidate(true);
                }
            }
        }

        [Description(PropertyDescription.Toggle)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool ThemesAvailable
        {
            get
            {
                return _themesAvailable;
            }
        }

        [Browsable(false)]
        [Description("Gets or sets the first visible item in the control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VisualListViewItem TopItem
        {
            get
            {
                if (_items.Count <= 0)
                {
                    return null;
                }
                else
                {
                    return _items[0];
                }
            }

            set
            {
                _items[0] = value;
            }
        }

        [Browsable(false)]
        public ManagedVScrollBar VerticalScrollBar
        {
            get
            {
                return _verticalScrollBar;
            }

            set
            {
                _verticalScrollBar = value;
            }
        }

        [Description("Number of rows currently visible in inner rect.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int VisibleRowsCount
        {
            get
            {
                return RowsInnerClientRect.Height / ItemHeight;
            }
        }

        [Description("Calculates total height of all rows combined.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        protected int TotalRowHeight
        {
            get
            {
                return ItemHeight * _items.Count;
            }
        }

        #endregion

        #region Overrides

        /// <summary>Cleanup any resources being used.</summary>
        /// <param name="disposing">Indicates whether the method call comes from a <see cref="Dispose" /> method or a finalizer.</param>
        protected override void Dispose(bool disposing)
        {
            DebugTraceManager.WriteDebug("Disposing VisualListViewAdvanced.", DebugTraceManager.DebugOutput.TraceListener);

            if (_theme != IntPtr.Zero)
            {
                Uxtheme.CloseThemeData(_theme);
            }

            if (disposing)
            {
                if (_components != null)
                {
                    _components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            DebugTraceManager.WriteDebug("VisualListView::OnDoubleClick", DebugTraceManager.DebugOutput.TraceListener);

            Point _pointerLocation = PointToClient(Cursor.Position);

            int _item;
            int _columnIndexer;
            int _cellX;
            int _cellY;
            ListStates _liveStates;
            ListViewRegion _listViewRegion;
            InterpretCoordinates(_pointerLocation.X, _pointerLocation.Y, out _listViewRegion, out _cellX, out _cellY, out _item, out _columnIndexer, out _liveStates);

            // Debug.WriteLine( "listRegion " + listRegion.ToString() );
            if ((_listViewRegion == ListViewRegion.Client) && (_columnIndexer < _columns.Count))
            {
                ActivateEmbeddedControl(_columnIndexer, _items[_item], _items[_item].SubItems[_columnIndexer]);
            }

            base.OnDoubleClick(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            DestroyActivatedEmbedded();
            base.OnGotFocus(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            DebugTraceManager.WriteDebug("OnMouseDown", DebugTraceManager.DebugOutput.TraceListener);

            // Debug.WriteLine( "Real " + e.X.ToString() + " " + e.Y.ToString() );
            int _item;
            int _column;
            int _cellX;
            int _cellY;
            ListStates _liveStates;
            ListViewRegion _listViewRegion;
            InterpretCoordinates(e.X, e.Y, out _listViewRegion, out _cellX, out _cellY, out _item, out _column, out _liveStates);

            if (e.Button == MouseButtons.Right)
            {
                base.OnMouseDown(e);
                return;
            }

            // -----------------------------------------------------------------------------------------
            if (_liveStates == ListStates.ColumnSelect)
            {
                // Column select
                _state = ListStates.None;

                if (SortType != SortTypes.None)
                {
                    _columns[_column].State = ColumnStates.Pressed;
                    SortColumn(_column);
                }

                ColumnClickedEvent?.Invoke(this, new ListViewClickEventArgs(_item, _column)); // fire the column clicked event

                // Invalidate();
                base.OnMouseDown(e);
                return;
            }

            // ---Resizing -----------------------------------------------------------------------------------
            if (_liveStates == ListStates.ColumnResizing)
            {
                // resizing
                Cursor.Current = Cursors.VSplit;
                _state = ListStates.ColumnResizing;

                _pointColumnResizeAnchor = new Point(GetColumnScreenX(_column), e.Y); // deal with moving column sizes
                _resizeColumnNumber = _column;

                base.OnMouseDown(e);
                return;
            }

            // ---Items --------------------------------------------------------------------------------------
            if (_liveStates == ListStates.Selecting)
            {
                // Control based multi select ------------------------------------------------------------

                // Whatever else this does, it needs to first check to see if the state of the checkbox is changing
                if ((_column < _columns.Count) && _columns[_column].CheckBoxes)
                {
                    // there is a checkbox on this control, lets see if the click came in the region
                    if ((_cellX > CellPaddingSize) &&
                        (_cellX < CellPaddingSize + ListViewConstants.CHECKBOX_SIZE) &&
                        (_cellY > CellPaddingSize) &&
                        (_cellY < CellPaddingSize + ListViewConstants.CHECKBOX_SIZE))
                    {
                        // toggle the checkbox
                        if (_items[_item].SubItems[_column].Checked)
                        {
                            _items[_item].SubItems[_column].Checked = false;
                        }
                        else
                        {
                            _items[_item].SubItems[_column].Checked = true;
                        }
                    }
                }

                _state = ListStates.Selecting;

                FocusedItem = Items[_item];

                if (((ModifierKeys & Keys.Control) == Keys.Control) && MultiSelect)
                {
                    _lastSelectionIndex = _item;

                    if (_items[_item].Selected)
                    {
                        _items[_item].Selected = false;
                    }
                    else
                    {
                        _items[_item].Selected = true;
                    }

                    base.OnMouseDown(e);
                    return;
                }

                // Shift based multi row select -------------------------------------------------------
                if (((ModifierKeys & Keys.Shift) == Keys.Shift) && MultiSelect)
                {
                    _items.ClearSelection();
                    if (_lastSelectionIndex >= 0)
                    {
                        // ie, non negative so that we have a starting point
                        int index = _lastSelectionIndex;
                        do
                        {
                            _items[index].Selected = true;
                            if (index > _item)
                            {
                                index--;
                            }

                            if (index < _item)
                            {
                                index++;
                            }
                        }
                        while (index != _item);

                        _items[index].Selected = true;
                    }

                    base.OnMouseDown(e);
                    return;
                }

                // Normal single select -----------------------------------------------------------
                _items.ClearSelection(_items[_item]);

                // Following two if statements deal ONLY with non multi=select where a single sub item is being selected
                if ((_lastSelectionIndex < Count) && (_lastSubSelectionIndex < _columns.Count))
                {
                    _items[_lastSelectionIndex].SubItems[_lastSubSelectionIndex].Selected = false;
                }

                if ((_fullRowSelect == false) && (_item < Count) && (_column < _columns.Count))
                {
                    _items[_item].SubItems[_column].Selected = true;
                }

                _lastSelectionIndex = _item;
                _lastSubSelectionIndex = _column;
                _items[_item].Selected = true;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _columns.ClearHotStates(); // this is the HEADER hot state
            HotItemIndex = -1;
            _hotColumnIndex = -1;

            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            DebugTraceManager.WriteDebug("VisualListView::MouseMove", DebugTraceManager.DebugOutput.TraceListener);

            try
            {
                if (_state == ListStates.ColumnResizing)
                {
                    Cursor.Current = Cursors.VSplit;
                    int _width = e.X - _pointColumnResizeAnchor.X;

                    if (_width <= ListViewConstants.MINIMUM_COLUMN_SIZE)
                    {
                        _width = ListViewConstants.MINIMUM_COLUMN_SIZE;
                    }

                    VisualListViewColumn _column = Columns[_resizeColumnNumber];
                    _column.Width = _width;

                    OnMove(e);
                    return;
                }

                var _item = 0;
                int _columnIndexer;
                var _cellX = 0;
                var _cellY = 0;
                ListStates _listStates;
                ListViewRegion _listRegion;
                InterpretCoordinates(e.X, e.Y, out _listRegion, out _cellX, out _cellY, out _item, out _columnIndexer, out _listStates);

                // Update the column index
                _columnIndex = _columnIndexer;

                if (_listStates == ListStates.ColumnResizing)
                {
                    Cursor.Current = Cursors.VSplit;

                    OnMove(e);
                    return;
                }

                Cursor.Current = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception throw in GlobalList_MouseMove with text : " + ex);
            }

            OnMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            DebugTraceManager.WriteDebug("MouseUp", DebugTraceManager.DebugOutput.TraceListener);

            Cursor.Current = Cursors.Arrow;
            Columns.ClearStates();

            var nItem = 0;
            var nColumn = 0;
            var nCellX = 0;
            var nCellY = 0;
            ListStates eState;
            ListViewRegion listRegion;
            InterpretCoordinates(e.X, e.Y, out listRegion, out nCellX, out nCellY, out nItem, out nColumn, out eState);

            _state = ListStates.None;

            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DebugTraceManager.WriteDebug("VisualListView::Paint", DebugTraceManager.DebugOutput.TraceListener);

            if (!DesignMode && _updating)
            {
                return;
            }

            RecalculateScroll(); // Doesn't really belong in paint.

            Graphics _graphics = e.Graphics;
            int _insideWidth = Columns.Width > HeaderRect.Width ? Columns.Width : HeaderRect.Width;

            if (HeaderVisible)
            {
                _graphics.SetClip(HeaderRect);
                ListViewRenderer.DrawColumnHeader(_graphics, new Size(HeaderRect.Width, HeaderRect.Height), this, _horizontalScrollBar, _theme);
            }

            _graphics.SetClip(RowsInnerClientRect);
            ListViewRenderer.DrawRows(_graphics, this, _verticalScrollBar, _horizontalScrollBar, _newLiveControls, _liveControls, ListViewConstants.CHECKBOX_SIZE);

            foreach (Control control in _liveControls)
            {
                control.Visible = false;
            }

            _liveControls = _newLiveControls;
            _newLiveControls = new ArrayList();

            DrawDisplayText(_graphics);
            _graphics.SetClip(ClientRectangle);

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            DebugTraceManager.WriteDebug("OnResize - Calling Invalidate From OnResize", DebugTraceManager.DebugOutput.TraceListener);
            Invalidate();
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            DebugTraceManager.WriteDebug("PreProcessMessage - Msg: " + msg, DebugTraceManager.DebugOutput.TraceListener);

            if (msg.Msg == ListViewConstants.WM_KEYDOWN)
            {
                Keys _keyCode = (Keys)(int)msg.WParam; // this should turn the key data off because it will match selected keys to ORA them off

                if (_keyCode == Keys.Return)
                {
                    DestroyActivatedEmbedded();
                    return true;
                }

                // Debug.WriteLine("---");
                // Debug.WriteLine( ModifierKeys.ToString() );
                Debug.WriteLine(_keyCode.ToString());

                if ((FocusedItem != null) && (Count > 0) && Selectable)
                {
                    int _itemIndex = _items.FindItemIndex(FocusedItem);
                    int _previousIndex = _itemIndex;

                    if (_itemIndex < 0)
                    {
                        return true; // this can't move
                    }

                    if ((_keyCode == Keys.A) && ((ModifierKeys & Keys.Control) == Keys.Control))
                    {
                        for (var index = 0; index < _items.Count; index++)
                        {
                            Items[index].Selected = true;
                        }

                        return base.PreProcessMessage(ref msg);
                    }

                    if (_keyCode == Keys.Escape)
                    {
                        _items.ClearSelection(); // clear selections
                        FocusedItem = null;

                        return base.PreProcessMessage(ref msg);
                    }

                    if (_keyCode == Keys.Down)
                    {
                        // Could be a switch
                        _itemIndex++;
                    }
                    else if (_keyCode == Keys.Up)
                    {
                        _itemIndex--;
                    }
                    else if (_keyCode == Keys.PageDown)
                    {
                        _itemIndex += VisibleRowsCount;
                    }
                    else if (_keyCode == Keys.PageUp)
                    {
                        _itemIndex -= VisibleRowsCount;
                    }
                    else if (_keyCode == Keys.Home)
                    {
                        _itemIndex = 0;
                    }
                    else if (_keyCode == Keys.End)
                    {
                        _itemIndex = Count - 1;
                    }
                    else if (_keyCode == Keys.Space)
                    {
                        if (!MultiSelect)
                        {
                            _items.ClearSelection(_items[_itemIndex]);
                        }

                        _items[_itemIndex].Selected = !_items[_itemIndex].Selected;

                        return base.PreProcessMessage(ref msg);
                    }
                    else
                    {
                        return base.PreProcessMessage(ref msg);
                    }

                    // Check the bounds.
                    if (_itemIndex > Count - 1)
                    {
                        _itemIndex = Count - 1;
                    }

                    if (_itemIndex < 0)
                    {
                        _itemIndex = 0;
                    }

                    // Move view - Need to move end -1 to take into account 0 based index.
                    if (_itemIndex < _verticalScrollBar.Value)
                    {
                        // Its out of viewable, move the surface
                        _verticalScrollBar.Value = _itemIndex;
                    }

                    if (_itemIndex > _verticalScrollBar.Value + (VisibleRowsCount - 1))
                    {
                        _verticalScrollBar.Value = _itemIndex - (VisibleRowsCount - 1);
                    }

                    if (_previousIndex != _itemIndex)
                    {
                        if (((ModifierKeys & Keys.Control) != Keys.Control) && ((ModifierKeys & Keys.Shift) != Keys.Shift))
                        {
                            // No control no shift
                            _lastSelectionIndex = _itemIndex;
                            Items[_itemIndex].Selected = true;
                            _items.ClearSelection(Items[_itemIndex]);
                        }
                        else if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                        {
                            // Shift only
                            _items.ClearSelection();

                            // Gotta catch when the multi select is NOT set
                            if (!MultiSelect)
                            {
                                Items[_itemIndex].Selected = !Items[_itemIndex].Selected;
                            }
                            else
                            {
                                if (_lastSelectionIndex >= 0)
                                {
                                    // ie, non negative so that we have a starting point
                                    int index = _lastSelectionIndex;
                                    do
                                    {
                                        Items[index].Selected = true;
                                        if (index > _itemIndex)
                                        {
                                            index--;
                                        }

                                        if (index < _itemIndex)
                                        {
                                            index++;
                                        }
                                    }
                                    while (index != _itemIndex);

                                    Items[index].Selected = true;
                                }
                            }
                        }
                        else
                        {
                            // Control only
                            _lastSelectionIndex = _itemIndex;
                        }

                        // Bypass FocusedItem property, we always want to invalidate from this point
                        FocusedItem = Items[_itemIndex];
                    }
                }
                else
                {
                    // Only if non selectable
                    int _moveIndex = _verticalScrollBar.Value;

                    if (_keyCode == Keys.Down)
                    {
                        // Could be a switch
                        _moveIndex++;
                    }
                    else if (_keyCode == Keys.Up)
                    {
                        _moveIndex--;
                    }
                    else if (_keyCode == Keys.PageDown)
                    {
                        _moveIndex += VisibleRowsCount;
                    }
                    else if (_keyCode == Keys.PageUp)
                    {
                        _moveIndex -= VisibleRowsCount;
                    }
                    else if (_keyCode == Keys.Home)
                    {
                        _moveIndex = 0;
                    }
                    else if (_keyCode == Keys.End)
                    {
                        _moveIndex = Count - VisibleRowsCount;
                    }
                    else
                    {
                        return base.PreProcessMessage(ref msg);
                    }

                    if (_moveIndex > Count - VisibleRowsCount)
                    {
                        _moveIndex = Count - VisibleRowsCount;
                    }

                    if (_moveIndex < 0)
                    {
                        _moveIndex = 0;
                    }

                    if (_verticalScrollBar.Value != _moveIndex)
                    {
                        _verticalScrollBar.Value = _moveIndex;

                        DebugTraceManager.WriteDebug("Calling Invalidate From PreProcessMessage", DebugTraceManager.DebugOutput.TraceListener);
                        Invalidate();
                    }
                }
            }
            else
            {
                return base.PreProcessMessage(ref msg);
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>Instance the activated embedded control for this item/column.</summary>
        /// <param name="columnIndex">The column index.</param>
        /// <param name="item">The item.</param>
        /// <param name="subItem">The sub item.</param>
        private void ActivateEmbeddedControl(int columnIndex, VisualListViewItem item, VisualListViewSubItem subItem)
        {
            if (_activatedEmbeddedControl != null)
            {
                _activatedEmbeddedControl.Dispose();
                _activatedEmbeddedControl = null;
            }

            if (_columns[columnIndex].EmbeddedControlTemplate == null)
            {
                return;
            }

            Type _type = _columns[columnIndex].EmbeddedControlTemplate.GetType();
            Control _control = (Control)Activator.CreateInstance(_type);
            ILVEmbeddedControl _iEmbeddedControl = (ILVEmbeddedControl)_control;

            if (_iEmbeddedControl == null)
            {
                throw new Exception(@"Control does not implement the GLEmbeddedControl interface, can't start");
            }

            _iEmbeddedControl.LVEmbeddedControlLoad(item, subItem, this);

            _control.KeyPress += TextBox_KeyPress;

            _control.Parent = this;
            ActivatedEmbeddedControl = _control;
            if (_activatedEmbeddedControl != null)
            {
                int _yOffset = (subItem.LastCellRect.Height - _activatedEmbeddedControl.Bounds.Height) / 2;
            }

            Rectangle _controlBounds;

            if (GridLineStyle == GridLineStyle.None)
            {
                // Add 1 to x to give border, add 2 to Y because to account for possible grid that you must cover up
                _controlBounds = new Rectangle(subItem.LastCellRect.X + 1, subItem.LastCellRect.Y + 1, subItem.LastCellRect.Width - 3, subItem.LastCellRect.Height - 2);
            }
            else
            {
                // Add 1 to x to give border, add 2 to Y because to account for possible grid that you must cover up
                _controlBounds = new Rectangle(subItem.LastCellRect.X + 1, subItem.LastCellRect.Y + 2, subItem.LastCellRect.Width - 3, subItem.LastCellRect.Height - 3);
            }

            // control.Bounds = subItem.LastCellRect; //new Rectangle( subItem.LastCellRect.X, subItem.LastCellRect.Y + nYOffset, subItem.LastCellRect.Width, subItem.LastCellRect.Height );
            _control.Bounds = _controlBounds;

            _control.Show();
            _control.Focus();
        }

        /// <summary>Determines if themes are available.</summary>
        /// <returns>The <see cref="bool" />.</returns>
        private bool AreThemesAvailable()
        {
            DebugTraceManager.WriteDebug("AreThemesAvailable", DebugTraceManager.DebugOutput.TraceListener);

            // IntPtr hTheme = IntPtr.Zero;
            try
            {
                if ((Uxtheme.IsThemeActive() == 1) && (_theme == IntPtr.Zero))
                {
                    _theme = Uxtheme.OpenThemeData(_theme, "HEADER");

                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return false;
        }

        private int CompensateColumnHeaderResize(int columnIndex, bool columnResizeCancelled)
        {
            if ((_controlStyle == LVControlStyles.Normal) && !columnResizeCancelled && (_items.Count > 0))
            {
                // The user resized the first column
                if (columnIndex == 0)
                {
                    VisualListViewColumn _column = (_columns != null) && (_columns.Count > 0) ? _columns[0] : null;

                    if (_column != null)
                    {
                        if (_imageListColumns == null)
                        {
                            return 2;
                        }
                        else
                        {
                            // If the list-view contains an item w/ a non-negative ImageIndex then we don't need to add extra padding.
                            bool _addPadding = true;

                            for (var i = 0; i < _items.Count; i++)
                            {
                                // TODO: Fix image indexer
                                // if (_items[i].ImageIndexer.ActualIndex > -1)
                                // {
                                // _addPadding = false;
                                // }
                            }

                            if (_addPadding)
                            {
                                // 18 = 16 + 2;
                                // 16 = size of small image list.
                                // 2 is the padding we add when there is no small image list.
                                return 18;
                            }
                        }
                    }
                }
            }

            return 0;
        }

        /// <summary>
        ///     If an activated embedded control exists, remove and unload it
        /// </summary>
        private void DestroyActivatedEmbedded()
        {
            if (_activatedEmbeddedControl != null)
            {
                ILVEmbeddedControl control = (ILVEmbeddedControl)_activatedEmbeddedControl;
                control.LVEmbeddedControlUnload();

                // must do this because the unload may call the changed callback from the items which would call this routine a second time
                if (_activatedEmbeddedControl != null)
                {
                    _activatedEmbeddedControl.Dispose();
                    _activatedEmbeddedControl = null;
                }
            }
        }

        /// <summary>Draws the display text.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        private void DrawDisplayText(Graphics graphics)
        {
            if ((_items.Count <= 0) && _displayTextOnEmpty)
            {
                Rectangle _layoutRectangle = new Rectangle(0, 0, RowsClientRect.Width, RowsClientRect.Height);
                GraphicsManager.DrawText(graphics, _displayText, _displayTextFont, _displayTextColor, _layoutRectangle);
            }
        }

        /// <summary>Handle horizontal scroll bar movement.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void HorizontalPanelScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            DebugTraceManager.WriteDebug("hPanelScrollBar_Scroll", DebugTraceManager.DebugOutput.TraceListener);

            // this.Focus();
            DebugTraceManager.WriteDebug("Calling Invalidate From hPanelScrollBar_Scroll", DebugTraceManager.DebugOutput.TraceListener);

            Invalidate();
        }

        /// <summary>Timer handler. This mostly deals with the hover technology with events firing.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void HoverTimer_TimerTick(object sender, EventArgs e)
        {
            Point _pointLocalMouse;
            if (Cursor != null)
            {
                _pointLocalMouse = PointToClient(Cursor.Position);
            }
            else
            {
                _pointLocalMouse = new Point(9999, 9999);
            }

            int nItem;
            int nColumn;
            var nCellX = 0;
            var nCellY = 0;
            ListStates eState;
            ListViewRegion listRegion;
            InterpretCoordinates(_pointLocalMouse.X, _pointLocalMouse.Y, out listRegion, out nCellX, out nCellY, out nItem, out nColumn, out eState);

            if ((_pointLocalMouse == _lastHoverSpot) && !_hoverLive && (listRegion != ListViewRegion.NonClient))
            {
                Debug.WriteLine("VisualListView::HoverTimer-Firing");
                HoverEvent?.Invoke(this, new ListViewHoverEventArgs(ListViewHoverTypes.HoverStart, nItem, nColumn, listRegion));
                _hoverLive = true;
            }
            else if (_hoverLive && (_pointLocalMouse != _lastHoverSpot))
            {
                Debug.WriteLine("VisualListView::HoverTimer-Canceling");
                HoverEvent?.Invoke(this, new ListViewHoverEventArgs(ListViewHoverTypes.HoverEnd, -1, -1, ListViewRegion.NonClient));
                _hoverLive = false;
            }

            _lastHoverSpot = _pointLocalMouse;
        }

        private void InitializeComponent()
        {
            if (ControlStyle == LVControlStyles.XP)
            {
                Application.EnableVisualStyles();
            }

            _components = new Container();
        }

        /// <summary>The item has changed event.</summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The event args.</param>
        private void Items_Changed(object source, ListViewChangedEventArgs e)
        {
            DebugTraceManager.WriteDebug("VisualListView::Items_Changed", DebugTraceManager.DebugOutput.TraceListener);

            DestroyActivatedEmbedded();

            ItemChangedEvent?.Invoke(this, e);

            // Invalidate if an item that is within the visible area has changed
            if (e.Item != null)
            {
                if (IsItemVisible(e.Item))
                {
                    DebugTraceManager.WriteDebug("Calling Invalidate From Items_Changed", DebugTraceManager.DebugOutput.TraceListener);
                    Invalidate();
                }
            }

            // FIX: Invalidates list view on items changed.
            Invalidate();
        }

        private void OnMouseDownFromSubItem(object sender, MouseEventArgs e)
        {
            DebugTraceManager.WriteDebug("OnMouseDownFromSubItem", DebugTraceManager.DebugOutput.TraceListener);

            // Debug.WriteLine( "OnMouseDownFromSubItem called " + e.X.ToString() + " " + e.Y.ToString() );
            Point cp = PointToClient(new Point(MousePosition.X, MousePosition.Y));
            e = new MouseEventArgs(e.Button, e.Clicks, cp.X, cp.Y, e.Delta);

            // Debug.WriteLine( "after " + cp.X.ToString() + " " + cp.Y.ToString() );
            OnMouseDown(e);
        }

        private void OnScroll(object sender, ScrollEventArgs e)
        {
            DebugTraceManager.WriteDebug("Calling Invalidate From OnScroll", DebugTraceManager.DebugOutput.TraceListener);

            DestroyActivatedEmbedded();

            Invalidate();
        }

        /// <summary>Recalculate scroll bars and control size.</summary>
        private void RecalculateScroll()
        {
            DebugTraceManager.WriteDebug("VisualListView::RecalculateScroll", DebugTraceManager.DebugOutput.TraceListener);

            var _exitCode = 0;
            bool _bSbChanged;
            do
            {
                // this loop is to handle changes and re-changes that happen when one or the other changes
                DebugTraceManager.WriteDebug("Begin scrollbar updates loop", DebugTraceManager.DebugOutput.TraceListener);
                _bSbChanged = false;

                if ((_columns.Width > RowsInnerClientRect.Width) && (_horizontalScrollBar.Visible == false))
                {
                    // total width of all the rows is less than the visible rect
                    _horizontalScrollBar.MVisible = true;
                    _horizontalScrollBar.Value = 0;
                    _bSbChanged = true;

                    DebugTraceManager.WriteDebug("Calling Invalidate From RecalculateScroll", DebugTraceManager.DebugOutput.TraceListener);
                    Invalidate();
                    DebugTraceManager.WriteDebug("showing hScrollbar", DebugTraceManager.DebugOutput.TraceListener);
                }

                if ((_columns.Width <= RowsInnerClientRect.Width) && _horizontalScrollBar.Visible)
                {
                    // total width of all the rows is less than the visible rect
                    _horizontalScrollBar.MVisible = false;
                    _horizontalScrollBar.Value = 0;
                    _bSbChanged = true;
                    DebugTraceManager.WriteDebug("Calling Invalidate From RecalculateScroll", DebugTraceManager.DebugOutput.TraceListener);
                    Invalidate();
                    DebugTraceManager.WriteDebug("hiding hScrollbar", DebugTraceManager.DebugOutput.TraceListener);
                }

                if ((TotalRowHeight > RowsInnerClientRect.Height) && (_verticalScrollBar.Visible == false))
                {
                    // total height of all the rows is greater than the visible rect
                    _verticalScrollBar.MVisible = true;
                    _horizontalScrollBar.Value = 0;
                    _bSbChanged = true;
                    DebugTraceManager.WriteDebug("Calling Invalidate From RecalculateScroll", DebugTraceManager.DebugOutput.TraceListener);
                    Invalidate();
                    DebugTraceManager.WriteDebug("showing vScrollbar", DebugTraceManager.DebugOutput.TraceListener);
                }

                if ((TotalRowHeight <= RowsInnerClientRect.Height) && _verticalScrollBar.Visible)
                {
                    // total height of all rows is less than the visible rect
                    _verticalScrollBar.MVisible = false;
                    _verticalScrollBar.Value = 0;
                    _bSbChanged = true;
                    DebugTraceManager.WriteDebug("Calling Invalidate From RecalculateScroll", DebugTraceManager.DebugOutput.TraceListener);
                    Invalidate();
                    DebugTraceManager.WriteDebug("hiding vScrollbar", DebugTraceManager.DebugOutput.TraceListener);
                }

                DebugTraceManager.WriteDebug("End scrollbar updates loop", DebugTraceManager.DebugOutput.TraceListener);

                if (++_exitCode > 4)
                {
                    break;
                }
            }
            while (_bSbChanged);

            Rectangle _rectangleClient = RowsInnerClientRect;

            if (_verticalScrollBar.Visible)
            {
                _verticalScrollBar.MTop = _rectangleClient.Y;
                _verticalScrollBar.MLeft = _rectangleClient.Right;
                _verticalScrollBar.MHeight = _rectangleClient.Height;
                _verticalScrollBar.MLargeChange = VisibleRowsCount;
                _verticalScrollBar.MMaximum = Count - 1;

                if (_verticalScrollBar.Value + VisibleRowsCount > Count)
                {
                    // catch all to make sure the scrollbar isn't going farther than visible items
                    DebugTraceManager.WriteDebug("Changing vPanel value", DebugTraceManager.DebugOutput.TraceListener);
                    _verticalScrollBar.Value = Count - VisibleRowsCount; // an item got deleted underneath somehow and scroll value is larger than can be displayed
                }
            }

            if (_horizontalScrollBar.Visible)
            {
                _horizontalScrollBar.MLeft = _rectangleClient.Left;
                _horizontalScrollBar.MTop = _rectangleClient.Bottom;
                _horizontalScrollBar.MWidth = _rectangleClient.Width;

                _horizontalScrollBar.MLargeChange = _rectangleClient.Width; // this re-all is the size we want to move
                _horizontalScrollBar.MMaximum = Columns.Width;

                if (_horizontalScrollBar.Value + _horizontalScrollBar.LargeChange > _horizontalScrollBar.Maximum)
                {
                    DebugTraceManager.WriteDebug("Changing vPanel value", DebugTraceManager.DebugOutput.TraceListener);
                    _horizontalScrollBar.Value = _horizontalScrollBar.Maximum - _horizontalScrollBar.LargeChange;
                }
            }

            if (BorderPadding > 0)
            {
                _horizontalBottomBorderStrip.Bounds = new Rectangle(0, ClientRectangle.Bottom - BorderPadding, ClientRectangle.Width, BorderPadding); // horizontal bottom picture box
                _horizontalTopBorderStrip.Bounds = new Rectangle(0, ClientRectangle.Top, ClientRectangle.Width, BorderPadding); // horizontal bottom picture box
                _verticalLeftBorderStrip.Bounds = new Rectangle(0, 0, BorderPadding, ClientRectangle.Height); // horizontal bottom picture box
                _verticalRightBorderStrip.Bounds = new Rectangle(ClientRectangle.Right - BorderPadding, 0, BorderPadding, ClientRectangle.Height); // horizontal bottom picture box
            }
            else
            {
                if (_horizontalBottomBorderStrip.Visible)
                {
                    _horizontalBottomBorderStrip.Visible = false;
                }

                if (_horizontalTopBorderStrip.Visible)
                {
                    _horizontalTopBorderStrip.Visible = false;
                }

                if (_verticalLeftBorderStrip.Visible)
                {
                    _verticalLeftBorderStrip.Visible = false;
                }

                if (_verticalRightBorderStrip.Visible)
                {
                    _verticalRightBorderStrip.Visible = false;
                }
            }

            if (_horizontalScrollBar.Visible && _verticalScrollBar.Visible)
            {
                if (!_cornerBox.Visible)
                {
                    _cornerBox.Visible = true;
                }

                _cornerBox.Bounds = new Rectangle(_horizontalScrollBar.Right, _verticalScrollBar.Bottom, _verticalScrollBar.Width, _horizontalScrollBar.Height);
            }
            else
            {
                if (_cornerBox.Visible)
                {
                    _cornerBox.Visible = false;
                }
            }
        }

        /// <summary>Resizes the width of the given column as indicated by the resize style.</summary>
        /// <param name="columnIndex">The zero-based index of the column to resize.</param>
        /// <param name="width">The width of the column.</param>
        private void SetColumnWidth(int columnIndex, int width)
        {
            if (IsHandleCreated)
            {
                _columns[columnIndex].Width = width;
            }
        }

        /// <summary>Check for return (if we get it, deactivate).</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Return) || (e.KeyChar == (char)Keys.Escape))
            {
                DestroyActivatedEmbedded();
            }
        }

        /// <summary>Resizes the width of the given column as indicated by the resize style.</summary>
        /// <param name="headerAutoResize">One of the <see cref="ColumnHeaderAutoResizeStyle" /> values.</param>
        private void UpdateColumnWidths(ColumnHeaderAutoResizeStyle headerAutoResize)
        {
            if (_columns != null)
            {
                for (var i = 0; i < _columns.Count; i++)
                {
                    SetColumnWidth(i, headerAutoResize);
                }
            }
        }

        /// <summary>Handle vertical scroll bar movement.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void VerticalPanelScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            DebugTraceManager.WriteDebug("vPanelScrollBar_Scroll", DebugTraceManager.DebugOutput.TraceListener);

            // this.Focus();
            DebugTraceManager.WriteDebug("Calling Invalidate From vPanelScrollBar_Scroll", DebugTraceManager.DebugOutput.TraceListener);
            Invalidate();
        }

        /// <summary>Resizes the width of the given column as indicated by the resize style.</summary>
        /// <param name="columnIndex">The zero-based index of the column to resize.</param>
        /// <param name="headerAutoResize">One of the <see cref="ColumnHeaderAutoResizeStyle" /> values.</param>
        public void AutoResizeColumn(int columnIndex, ColumnHeaderAutoResizeStyle headerAutoResize)
        {
            if (!IsHandleCreated)
            {
                CreateHandle();
            }

            SetColumnWidth(columnIndex, headerAutoResize);
        }

        /// <summary>Resizes the width of the columns as indicated by the resize style.</summary>
        /// <param name="headerAutoResize">One of the <see cref="ColumnHeaderAutoResizeStyle" /> values.</param>
        public void AutoResizeColumns(ColumnHeaderAutoResizeStyle headerAutoResize)
        {
            if (!IsHandleCreated)
            {
                CreateHandle();
            }

            UpdateColumnWidths(headerAutoResize);
        }

        /// <summary>Ask paint to relax.</summary>
        public void BeginUpdate()
        {
            _updating = true;
        }

        /// <summary>Column has changed, fire event.</summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The event args.</param>
        public void Columns_Changed(object source, ListViewChangedEventArgs e)
        {
            DebugTraceManager.WriteDebug("Columns_Changed", DebugTraceManager.DebugOutput.TraceListener);

            if (e.ChangedType != ListViewChangedTypes.ColumnStateChanged)
            {
                DestroyActivatedEmbedded();
            }

            ColumnChangedEvent?.Invoke(this, e);

            DebugTraceManager.WriteDebug("Calling Invalidate From Columns_Changed", DebugTraceManager.DebugOutput.TraceListener);
            Invalidate();
        }

        /// <summary>Tell paint to start worrying about updates again and repaint while your at it.</summary>
        public void EndUpdate()
        {
            _updating = false;
            Invalidate();
        }

        /// <summary>Get return the X starting point of a particular column.</summary>
        /// <param name="column">The column.</param>
        /// <returns>The <see cref="int" />.</returns>
        public int GetColumnScreenX(int column)
        {
            DebugTraceManager.WriteDebug("Get Column Screen X", DebugTraceManager.DebugOutput.TraceListener);

            if (column >= Columns.Count)
            {
                return 0;
            }

            int nCurrentX = -_horizontalScrollBar.Value; // GetHScrollPoint();			// offset the starting point by the current scroll point
            int nColIndex = 0;
            foreach (VisualListViewColumn col in Columns)
            {
                if (nColIndex >= column)
                {
                    return nCurrentX;
                }

                nColIndex++;
                nCurrentX += col.Width;
            }

            return 0; // this should never happen;
        }

        /// <summary>
        ///     Interpret mouse coordinates, Do NOT put anything functional in this routine. It is ONLY for analyzing the
        ///     mouse coordinates.
        /// </summary>
        /// <param name="_screenX">The screen x.</param>
        /// <param name="_screenY">The screen y.</param>
        /// <param name="listRegion">The list region.</param>
        /// <param name="_cellX">The cell x.</param>
        /// <param name="_cellY">The cell y.</param>
        /// <param name="_itemIndex">The item.</param>
        /// <param name="columnIndex">The column.</param>
        /// <param name="nState">The state.</param>
        public void InterpretCoordinates(int _screenX, int _screenY, out ListViewRegion listRegion, out int _cellX, out int _cellY, out int _itemIndex, out int columnIndex, out ListStates nState)
        {
            DebugTraceManager.WriteDebug("VisualListView::Interpret Coordinates", DebugTraceManager.DebugOutput.TraceListener);

            nState = ListStates.None;
            columnIndex = 0;
            _itemIndex = 0;
            _cellX = 0;
            _cellY = 0;

            listRegion = ListViewRegion.NonClient;

            // Calculate horizontal subitem
            int _currentX = -_horizontalScrollBar.Value; // offset the starting point by the current scroll point

            for (columnIndex = 0; columnIndex < Columns.Count; columnIndex++)
            {
                VisualListViewColumn _column = Columns[columnIndex];

                // Find the inner X for the cell
                _cellX = _screenX - _currentX;

                if ((_screenX > _currentX) && (_screenX < (_currentX + _column.Width) - ListViewConstants.RESIZE_ARROW_PADDING))
                {
                    nState = ListStates.ColumnSelect;
                    break;
                }

                if ((_screenX >= (_currentX + _column.Width) - ListViewConstants.RESIZE_ARROW_PADDING) && (_screenX <= _currentX + _column.Width + ListViewConstants.RESIZE_ARROW_PADDING))
                {
                    // Check see if this is a 0 length column (which we skip to next on) or if this is the last column (which we can't skip)
                    if ((columnIndex + 1 == Columns.Count) || (Columns[columnIndex + 1].Width != 0))
                    {
                        if (AllowColumnResize)
                        {
                            nState = ListStates.ColumnResizing;
                        }

                        return;
                    }
                }

                _currentX += _column.Width;
            }

            if ((_screenY >= RowsInnerClientRect.Y) && (_screenY < RowsInnerClientRect.Bottom))
            {
                // We are in the client area
                listRegion = ListViewRegion.Client;

                _columns.ClearHotStates();
                _hotColumnIndex = -1;

                _itemIndex = ((_screenY - RowsInnerClientRect.Y) / ItemHeight) + _verticalScrollBar.Value;

                // get inner cell Y
                _cellY = (_screenY - RowsInnerClientRect.Y) % ItemHeight;

                HotItemIndex = _itemIndex;

                if ((_itemIndex >= _items.Count) || (_itemIndex > _verticalScrollBar.Value + VisibleRowsCount))
                {
                    nState = ListStates.None;
                    listRegion = ListViewRegion.NonClient;
                }
                else
                {
                    nState = ListStates.Selecting;

                    // Handle where FullRowSelect is OFF and we click on the second part of a spanned column
                    for (int nSubIndex = 0; nSubIndex < Columns.Count; nSubIndex++)
                    {
                        if (nSubIndex >= columnIndex)
                        {
                            columnIndex = nSubIndex;
                            return;
                        }
                    }
                }
            }
            else
            {
                if ((_screenY >= HeaderRect.Y) && (_screenY < HeaderRect.Bottom))
                {
                    listRegion = ListViewRegion.Header;

                    // In the header.
                    HotItemIndex = -1;
                    _hotColumnIndex = columnIndex;

                    if ((columnIndex > -1) && (columnIndex < Columns.Count) && !Columns.AnyPressed())
                    {
                        if (_columns[columnIndex].State == ColumnStates.None)
                        {
                            _columns.ClearHotStates();
                            _columns[columnIndex].State = ColumnStates.Hot;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     This is an OPTIMIZED routine to see if an item is visible.
        ///     The other method of just checking against the item index was slow because it had to walk the entire list, which
        ///     would massively slow down the control when large numbers of items were added.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public bool IsItemVisible(VisualListViewItem item)
        {
            // TODO: change this to only walk to visible items list
            int _itemIndex = _items.FindItemIndex(item);
            if ((_itemIndex >= _verticalScrollBar.Value) && (_itemIndex < _verticalScrollBar.Value + VisibleRowsCount))
            {
                return true;
            }

            return false;
        }

        /// <summary>Sort a column. Set to virtual so you can write your own sorting.</summary>
        /// <param name="column">The column.</param>
        public virtual void SortColumn(int column)
        {
            Debug.WriteLine("Column sorting called.");

            if (Count < 2)
            {
                // nothing to sort
                return;
            }

            if (SortType == SortTypes.InsertionSort)
            {
                LVQuickSort sorter = new LVQuickSort();

                sorter.NumericCompare = Columns[column].NumericSort;
                sorter.SortDirection = Columns[column].LastSortState;
                sorter.SortColumn = column;
                sorter.LVInsertionSort(Items, 0, _items.Count - 1);
            }
            else if (SortType == SortTypes.MergeSort)
            {
                // this.SortIndex = nColumn;
                LVMergeSort mergesort = new LVMergeSort();

                mergesort.NumericCompare = Columns[column].NumericSort;
                mergesort.SortDirection = Columns[column].LastSortState;
                mergesort.SortColumn = column;
                mergesort.Sort(Items, 0, _items.Count - 1);
            }
            else if (SortType == SortTypes.QuickSort)
            {
                LVQuickSort sorter = new LVQuickSort();

                sorter.NumericCompare = Columns[column].NumericSort;
                sorter.SortDirection = Columns[column].LastSortState;
                sorter.SortColumn = column;
                sorter.Sort(Items); // .QuickSort( Items, 0, Items.Count-1 );
            }

            if (Columns[column].LastSortState == SortDirections.Descending)
            {
                Columns[column].LastSortState = SortDirections.Ascending;
            }
            else
            {
                Columns[column].LastSortState = SortDirections.Descending;
            }

            // Items.Sort();
        }

        /// <summary>Resizes the width of the given column as indicated by the resize style.</summary>
        /// <param name="columnIndex">The zero-based index of the column to resize.</param>
        /// <param name="headerAutoResize">One of the <see cref="ColumnHeaderAutoResizeStyle" /> values.</param>
        internal void SetColumnWidth(int columnIndex, ColumnHeaderAutoResizeStyle headerAutoResize)
        {
            if ((columnIndex < 0) || ((columnIndex >= 0) && (_columns == null)) || (columnIndex >= _columns.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(columnIndex));
            }

            int _width = 0;
            int _compensate = 0;

            switch (headerAutoResize)
            {
                case ColumnHeaderAutoResizeStyle.None:
                    {
                        if (_width == -2)
                        {
                            headerAutoResize = ColumnHeaderAutoResizeStyle.HeaderSize;
                        }
                        else if (_width == -1)
                        {
                            headerAutoResize = ColumnHeaderAutoResizeStyle.ColumnContent;
                        }

                        break;
                    }

                case ColumnHeaderAutoResizeStyle.HeaderSize:
                    {
                        _compensate = CompensateColumnHeaderResize(columnIndex, false);
                        _width = -2;
                        break;
                    }

                case ColumnHeaderAutoResizeStyle.ColumnContent:
                    {
                        _compensate = CompensateColumnHeaderResize(columnIndex, false);
                        _width = -1;
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(headerAutoResize), headerAutoResize, null);
                    }
            }

            SetColumnWidth(columnIndex, _width);

            if ((IsHandleCreated && (headerAutoResize == ColumnHeaderAutoResizeStyle.ColumnContent)) || (headerAutoResize == ColumnHeaderAutoResizeStyle.HeaderSize))
            {
                if (_compensate != 0)
                {
                    int _newWidth = _columns[columnIndex].Width + _compensate;
                    _columns[columnIndex].Width = _newWidth;
                }
            }
        }

        #endregion
    }
}