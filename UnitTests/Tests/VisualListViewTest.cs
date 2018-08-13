#region Namespace

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using VisualPlus.Enumerators;
using VisualPlus.Events;
using VisualPlus.Structure;
using VisualPlus.Toolkit.Child;
using VisualPlus.Toolkit.Controls.DataVisualization;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace UnitTests.Tests
{
    /// <summary>The visual list view test.</summary>
    public partial class VisualListViewTest : VisualForm
    {
        #region Constructors

        public VisualListViewTest()
        {
            InitializeComponent();

            visualListView.DisplayText = "No tasks in the current view." + Environment.NewLine + Environment.NewLine + "Click 'Add' to create a new task.";
            visualListView.SelectedIndexChanged += VisualListViewSelection_SelectedIndexChanged;
            visualListView.ColumnClickedEvent += VisualListViewColumnClickedEvent;
        }

        #endregion

        #region Methods

        /// <summary>Generate the <see cref="VisualListViewItem" /> for this test.</summary>
        /// <returns>The <see cref="VisualListViewItem" />.</returns>
        private static VisualListViewItem GenerateItem()
        {
            Random _imageIndexRandomize = new Random();
            int _randomImageIndex = _imageIndexRandomize.Next(2);

            VisualListViewItem _item = new VisualListViewItem(@"Item-" + new Random().Next(0, 1000))
                {
                    CheckBox = true,
                    ImageIndex = _randomImageIndex
                };

            VisualListViewSubItem _content = new VisualListViewSubItem(@"Content:" + new Random().Next(0, 1000));
            VisualListViewSubItem _date = new VisualListViewSubItem(DateTime.Now.ToLongDateString());

            VisualProgressBar _progressBar = new VisualProgressBar
                    {
                       Value = new Random().Next(0, 100) 
                    };

            VisualListViewSubItem _progress = new VisualListViewSubItem
                    {
                       EmbeddedControl = _progressBar 
                    };

            _item.SubItems.Add(_content);
            _item.SubItems.Add(_date);
            _item.SubItems.Add(_progress);

            return _item;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            VisualListViewItem _listViewItem = GenerateItem();
            visualListView.Items.Add(_listViewItem);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            foreach (VisualListViewItem _selectedItem in visualListView.SelectedItems)
            {
                visualListView.Items.Remove(_selectedItem);
            }

            foreach (VisualListViewItem checkedItem in visualListView.CheckedItems)
            {
                visualListView.Items.Remove(checkedItem);
            }
        }

        /// <summary>Generate the column.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="imageIndex">The image index.</param>
        /// <param name="width">The width.</param>
        /// <returns>The <see cref="VisualListViewColumn" />.</returns>
        private VisualListViewColumn GenerateColumn(string text, int imageIndex, int width)
        {
            VisualListViewColumn _column = new VisualListViewColumn(text)
                {
                    TextAlignment = ContentAlignment.MiddleCenter,
                    ImageIndex = imageIndex,
                    Width = width
                };

            return _column;
        }

        private void VisualListViewColumnClickedEvent(object source, ListViewClickEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                foreach (VisualListViewItem _item in visualListView.Items)
                {
                    _item.Checked = visualListView.Columns[0].Checked;
                }
            }
        }

        private void VisualListViewSelection_SelectedIndexChanged(object source, ListViewClickEventArgs e)
        {
            int _columnIndex;

            if (visualListView.ColumnIndex == -1)
            {
                // Clicked outside of column bounds.
                return;
            }
            else
            {
                _columnIndex = visualListView.ColumnIndex;
            }

            int _rowIndex = e.ItemIndex;
            string _column = visualListView.Columns[_columnIndex].Text;
            string _rowItem = visualListView.Items[_rowIndex].Text;
            string _rowSub = visualListView.Items[_rowIndex].SubItems[_columnIndex].Text;
            bool _rowChecked = visualListView.Items[_rowIndex].Checked;
            bool _columnChecked = visualListView.Columns[_columnIndex].Checked;
            bool _cellChecked = visualListView.Items[_rowIndex].SubItems[_columnIndex].Checked;

            StringBuilder _selectedIndex = new StringBuilder();
            _selectedIndex.AppendLine($"Column: [{_columnIndex}] - Text: {_column}, - Checked: {_columnChecked}");
            _selectedIndex.AppendLine($"Row: [{_rowIndex}] - Text: {_rowItem}, - Checked: {_rowChecked}");
            _selectedIndex.AppendLine(Environment.NewLine);
            _selectedIndex.AppendLine($"Cell: Text: {_rowSub}, - Checked: {_cellChecked}");

            ConsoleEx.WriteDebug(_selectedIndex.ToString());
        }

        private void VisualListViewTest_Load(object sender, EventArgs e)
        {
            VisualListViewColumn _title = GenerateColumn("Title", 0, 50);
            _title.CheckBox = true;
            _title.CheckBoxes = true;

            VisualListViewColumn _content = GenerateColumn("Content", 1, 50);
            _content.EmbeddedType = LVActivatedEmbeddedTypes.TextBox;

            VisualListViewColumn _date = GenerateColumn("Date", 2, 50);
            _date.EmbeddedType = LVActivatedEmbeddedTypes.DateTimePicker;

            VisualListViewColumn _progress = GenerateColumn("Progress", 3, 50);

            visualListView.Columns.Add(_title);
            visualListView.Columns.Add(_content);
            visualListView.Columns.Add(_date);
            visualListView.Columns.Add(_progress);

            for (var i = 0; i < 15; i++)
            {
                VisualListViewItem _listViewItem = GenerateItem();
                visualListView.Items.Add(_listViewItem);
            }

            visualListView.Items[0].Selected = true;

            visualListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            visualListView.ControlStyle = LVControlStyles.SuperFlat;
        }

        #endregion
    }
}