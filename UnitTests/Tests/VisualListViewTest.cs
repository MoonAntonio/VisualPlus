namespace UnitTests.Tests
{
    #region Namespace

    using System;
    using System.Text;
    using System.Windows.Forms;

    using VisualPlus.EventArgs;
    using VisualPlus.Toolkit.Child;
    using VisualPlus.Toolkit.Controls.DataVisualization;

    #endregion

    /// <summary>The visual list view test.</summary>
    public partial class VisualListViewTest : Form
    {
        #region Constructors

        public VisualListViewTest()
        {
            InitializeComponent();

            visualListViewAdvanced1.DisplayText = "No tasks in the current view." + Environment.NewLine + Environment.NewLine + "Click 'Add' to create a new task.";
            
            visualListViewAdvanced1.SelectedIndexChanged += VisualListViewAdvanced1_SelectedIndexChanged;
        }

        #endregion

        #region Methods

        /// <summary>Generate the <see cref="VisualListViewItem" /> for this test.</summary>
        /// <returns>The <see cref="VisualListViewItem" />.</returns>
        private static VisualListViewItem GenerateItem()
        {
            VisualListViewItem _item = new VisualListViewItem(@"Item: " + new Random().Next(0, 1000));
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
            visualListViewAdvanced1.Items.Add(_listViewItem);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            foreach (VisualListViewItem _selectedItem in visualListViewAdvanced1.SelectedItems)
            {
                visualListViewAdvanced1.Items.Remove(_selectedItem);
            }
        }

        private void VisualListViewAdvanced1_SelectedIndexChanged(object source, ListViewClickEventArgs e)
        {
            // Test index content
            int _rowIndex = e.ItemIndex;
            string _row = visualListViewAdvanced1.Items[_rowIndex].SubItems[1].Text;

            StringBuilder _selectedIndex = new StringBuilder();
            _selectedIndex.AppendLine("Row: " + _rowIndex);
            _selectedIndex.AppendLine("Content: " + _row);

            MessageBox.Show(_selectedIndex.ToString(), Application.ProductName);
        }

        private void VisualListViewTest_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < 0; i++)
            {
                VisualListViewItem _listViewItem = GenerateItem();
                visualListViewAdvanced1.Items.Add(_listViewItem);
            }
        }

        #endregion
    }
}