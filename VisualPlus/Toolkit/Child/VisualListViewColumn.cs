#region Namespace

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using VisualPlus.Delegates;
using VisualPlus.Enumerators;
using VisualPlus.Events;
using VisualPlus.Localization;
using VisualPlus.Toolkit.Controls.DataManagement;
using VisualPlus.Toolkit.Controls.DataManagement.ListViewComponents.EmbeddedControls;
using VisualPlus.TypeConverters;

#endregion

namespace VisualPlus.Toolkit.Child
{
    [DesignTimeVisible(true)]
    [TypeConverter(typeof(VisualListViewColumnConverter))]
    public class VisualListViewColumn : ICloneable
    {
        #region Variables

        private ArrayList _activeControlItems;
        private bool _checkBox;
        private bool _checkBoxes;
        private bool _checked;
        private ColumnStates _columnState;
        private Control _embeddedControlTemplate;
        private LVActivatedEmbeddedTypes _embeddedType;
        private int _imageIndex;
        private SortDirections _lastSortDirection;
        private VisualListViewEx _listView;
        private string _name;
        private bool _numericSort;
        private object _tag;
        private string _text;
        private ContentAlignment _textAlignment;
        private int _width;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualListViewColumn" /> class.</summary>
        public VisualListViewColumn()
        {
            _embeddedControlTemplate = null;
            _embeddedType = LVActivatedEmbeddedTypes.None;
            _activeControlItems = new ArrayList();
            _columnState = ColumnStates.None;
            _imageIndex = -1;
            _lastSortDirection = SortDirections.Descending;
            _textAlignment = ContentAlignment.MiddleLeft;
            _width = 150;
            _tag = null;
            _listView = null;
            _numericSort = false;
            _checked = false;
            _checkBoxes = false;
            _checkBox = false;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualListViewColumn" /> class.</summary>
        /// <param name="key">The key of the column header.</param>
        public VisualListViewColumn(string key) : this()
        {
            _name = key;
            _text = key;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualListViewColumn" /> class.</summary>
        /// <param name="key">The key of the column header.</param>
        /// <param name="text">The text to display in the column header.</param>
        public VisualListViewColumn(string key, string text) : this()
        {
            _name = key;
            _text = text;
        }

        #endregion

        #region Events

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event ListViewChangedEventHandler ChangedEvent;

        #endregion

        #region Properties

        [Browsable(false)]
        [Description("Array of items that have live controls.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ArrayList ActiveControlItems
        {
            get
            {
                return _activeControlItems;
            }

            set
            {
                _activeControlItems = value;
            }
        }

        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.CheckBoxes)]
        public bool CheckBox
        {
            get
            {
                return _checkBox;
            }

            set
            {
                _checkBox = value;
            }
        }

        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.CheckBoxes)]
        public bool CheckBoxes
        {
            get
            {
                return _checkBoxes;
            }

            set
            {
                _checkBoxes = value;
            }
        }

        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.CheckBoxes)]
        public bool Checked
        {
            get
            {
                return _checked;
            }

            set
            {
                _checked = value;
            }
        }

        [Browsable(false)]
        [Description("Activated embedded control types available.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control EmbeddedControlTemplate
        {
            get
            {
                return _embeddedControlTemplate;
            }

            set
            {
                _embeddedControlTemplate = value;
            }
        }

        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description("Type of system embedded control you would like activated in place here.")]
        public LVActivatedEmbeddedTypes EmbeddedType
        {
            get
            {
                return _embeddedType;
            }

            set
            {
                // set the activated embedded control template here
                _embeddedType = value;

                // only handle system types
                if (value == LVActivatedEmbeddedTypes.TextBox)
                {
                    _embeddedControlTemplate = new LVTextBox();
                }
                else if (value == LVActivatedEmbeddedTypes.ComboBox)
                {
                    _embeddedControlTemplate = new LVComboBox();
                }
                else if (value == LVActivatedEmbeddedTypes.DateTimePicker)
                {
                    _embeddedControlTemplate = new LVDateTimePicker();
                }
                else if (value == LVActivatedEmbeddedTypes.None)
                {
                    EmbeddedControlTemplate = null;
                }

                // if its none or user control them leave it alone
            }
        }

        [Category(EventCategory.Behavior)]
        [Description(PropertyDescription.ImageIndex)]
        [TypeConverter(typeof(ImageIndexConverter))]
        public int ImageIndex
        {
            get
            {
                return _imageIndex;
            }

            set
            {
                _imageIndex = value;
            }
        }

        [Browsable(false)]
        [Description(PropertyDescription.SortDirection)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SortDirections LastSortState
        {
            get
            {
                return _lastSortDirection;
            }

            set
            {
                _lastSortDirection = value;
            }
        }

        [Browsable(false)]
        [Description(PropertyDescription.Parent)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VisualListViewEx ListView
        {
            get
            {
                return _listView;
            }

            set
            {
                _listView = value;
            }
        }

        [Browsable(true)]
        [Category(PropertyCategory.Design)]
        [Description(PropertyDescription.Name)]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    ChangedEvent?.Invoke(this, new ListViewChangedEventArgs(ListViewChangedTypes.ColumnChanged, this, null, null));
                }
            }
        }

        [Browsable(true)]
        [Category(EventCategory.Behavior)]
        [Description(PropertyDescription.NumericSort)]
        public bool NumericSort
        {
            get
            {
                return _numericSort;
            }

            set
            {
                _numericSort = value;
            }
        }

        [Browsable(false)]
        [Description(PropertyDescription.ColumnStates)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ColumnStates State
        {
            get
            {
                return _columnState;
            }

            set
            {
                if (_columnState != value)
                {
                    _columnState = value;
                    ChangedEvent?.Invoke(this, new ListViewChangedEventArgs(ListViewChangedTypes.ColumnStateChanged, this, null, null));
                }
            }
        }

        [Browsable(false)]
        [Category(PropertyCategory.Data)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Tag
        {
            get
            {
                return _tag;
            }

            set
            {
                _tag = value;
            }
        }

        [Browsable(true)]
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Text)]
        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                if (_text != value)
                {
                    _text = value;
                    ChangedEvent?.Invoke(this, new ListViewChangedEventArgs(ListViewChangedTypes.ColumnChanged, this, null, null));
                }
            }
        }

        [Browsable(true)]
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.TextAlign)]
        public ContentAlignment TextAlignment
        {
            get
            {
                return _textAlignment;
            }

            set
            {
                _textAlignment = value;
            }
        }

        [Browsable(true)]
        [Category(PropertyCategory.Design)]
        [Description(PropertyDescription.Size)]
        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                if (_width != value)
                {
                    _width = value;
                    ChangedEvent?.Invoke(this, new ListViewChangedEventArgs(ListViewChangedTypes.ColumnChanged, this, null, null));
                }
            }
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return GetType().Name + ": {" + _text + "}";
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Creates an identical copy of the current <see cref="VisualListViewColumn" /> that is not attached to any list
        ///     view control.
        /// </summary>
        /// <returns>The <see cref="Object" />.</returns>
        public object Clone()
        {
            Type _clonedType = GetType();
            VisualListViewColumn _column;

            if (_clonedType == typeof(VisualListViewColumn))
            {
                _column = new VisualListViewColumn();
            }
            else
            {
                _column = (VisualListViewColumn)Activator.CreateInstance(_clonedType);
            }

            _column.Text = Text;
            _column.Width = Width;
            _column.TextAlignment = TextAlignment;
            return _column;
        }

        #endregion
    }
}