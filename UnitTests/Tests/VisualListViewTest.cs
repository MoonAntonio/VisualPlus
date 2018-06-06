namespace UnitTests.Tests
{
    #region Namespace

    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

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
        }

        #endregion

        #region Methods

        private void VisualListViewTest_Load(object sender, EventArgs e)
        {

            for (var i = 0; i < 25; i++)
            {
                VisualListViewItem _listViewItem = new VisualListViewItem(@"Item " + i);
                VisualListViewSubItem _content = new VisualListViewSubItem(@"SubItem" + i);
                VisualListViewSubItem _date = new VisualListViewSubItem(DateTime.Now.ToLongDateString());

                VisualProgressBar _progressBar = new VisualProgressBar
                {
                        Value = new Random().Next(0, 100)
                };

                VisualListViewSubItem _progress = new VisualListViewSubItem
                    {
                        EmbeddedControl = _progressBar
                    };

                _listViewItem.SubItems.Add(_content);
                _listViewItem.SubItems.Add(_date);
                _listViewItem.SubItems.Add(_progress);
                visualListViewAdvanced1.Items.Add(_listViewItem);
            }
        }

        #endregion
}
}