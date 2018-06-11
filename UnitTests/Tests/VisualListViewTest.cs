namespace UnitTests.Tests
{
    #region Namespace

    using System;
    using System.Text;
    using System.Windows.Forms;

    using VisualPlus.EventArgs;
    using VisualPlus.Toolkit.Child;
    using VisualPlus.Toolkit.Controls.DataVisualization;
    using VisualPlus.Toolkit.Dialogs;

    #endregion

    /// <summary>The visual list view test.</summary>
    public partial class VisualListViewTest : VisualForm
    {
        #region Constructors

        public VisualListViewTest()
        {
            InitializeComponent();

            visualListViewExTest.DisplayText = "No tasks in the current view." + Environment.NewLine + Environment.NewLine + "Click 'Add' to create a new task.";
            visualListViewExTest.SelectedIndexChanged += VisualListViewAdvanced1_SelectedIndexChanged;
        }

        #endregion

        #region Methods

        /// <summary>Generate the <see cref="VisualListViewItem" /> for this test.</summary>
        /// <returns>The <see cref="VisualListViewItem" />.</returns>
        private static VisualListViewItem GenerateItem()
        {
            Random _imageIndexRandomize = new Random();
            int _randomImageIndex = _imageIndexRandomize.Next(2);

            VisualListViewItem _item = new VisualListViewItem(@"Item: " + new Random().Next(0, 1000))
                {
                    CheckBox = true,
                    ImageIndex = _randomImageIndex
                };

            VisualListViewSubItem _content = new VisualListViewSubItem(@"Sub-Content: " + new Random().Next(0, 1000));
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
            visualListViewExTest.Items.Add(_listViewItem);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            foreach (VisualListViewItem _selectedItem in visualListViewExTest.SelectedItems)
            {
                visualListViewExTest.Items.Remove(_selectedItem);
            }
        }

        private void VisualListViewAdvanced1_SelectedIndexChanged(object source, ListViewClickEventArgs e)
        {
            int _columnIndex = visualListViewExTest.ColumnIndex;
            int _rowIndex = e.ItemIndex;
            string _column = visualListViewExTest.Columns[_columnIndex].Text;
            string _rowItem = visualListViewExTest.Items[_rowIndex].Text;
            string _rowSub = visualListViewExTest.Items[_rowIndex].SubItems[_columnIndex].Text;

            StringBuilder _selectedIndex = new StringBuilder();
            _selectedIndex.AppendLine($"Column: [{_columnIndex}] - Text: {_column}");
            _selectedIndex.AppendLine($"Row: [{_rowIndex}] - Text: {_rowItem}");
            _selectedIndex.AppendLine(Environment.NewLine);
            _selectedIndex.AppendLine($"Cell: Text: {_rowSub}");
            MessageBox.Show(_selectedIndex.ToString(), Application.ProductName);
        }

        private void VisualListViewTest_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < 5; i++)
            {
                VisualListViewItem _listViewItem = GenerateItem();
                visualListViewExTest.Items.Add(_listViewItem);
            }

            visualListViewExTest.Items[1].Selected = true;

            visualListViewExTest.Columns[0].ImageIndex = 0;
            visualListViewExTest.Columns[1].ImageIndex = 1;
            visualListViewExTest.Columns[2].ImageIndex = 2;
            visualListViewExTest.Columns[3].ImageIndex = 3;
        }

        #endregion
    }
}