namespace UnitTests.Tests
{
    #region Namespace

    using System;
    using System.Windows.Forms;

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

        #region Events

        private void VisualListViewTest_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < 25; i++)
            {
                ListViewItem _listViewItem = new ListViewItem
                        {
                           Text = @"Item " + i 
                        };

                visualListView1.Items.Add(_listViewItem);
            }
        }

        #endregion
    }
}