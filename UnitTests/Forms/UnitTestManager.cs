namespace UnitTests.Forms
{
    #region Namespace

    using System;
    using System.Windows.Forms;

    using UnitTests.Tests;

    #endregion

    /// <summary>The test manager.</summary>
    public partial class UnitTestManager : Form
    {
        #region Variables

        private UnitTests _unitTest;

        #endregion

        #region Constructors

        public UnitTestManager()
        {
            InitializeComponent();
        }

        #endregion

        #region Enumerators

        /// <summary>The different kind of unit tests.</summary>
        private enum UnitTests
        {
            /// <summary>The list view advanced.</summary>
            VisualListViewAdvanced = 0,

            /// <summary>The none.</summary>
            None = 1
        }

        #endregion

        #region Methods

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            Form _formToOpen;

            switch (_unitTest)
            {
                case UnitTests.VisualListViewAdvanced:
                    {
                        _formToOpen = new VisualListViewTest();
                        break;
                    }

                case UnitTests.None:
                    {
                        _formToOpen = null;
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            _formToOpen?.ShowDialog();
        }

        private void ListBoxTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            _unitTest = (UnitTests)listBoxTests.SelectedIndex;
        }

        private void TestManager_Load(object sender, EventArgs e)
        {
            _unitTest = UnitTests.VisualListViewAdvanced;

            Array _tests = typeof(UnitTests).GetEnumValues();
            foreach (object obj in _tests)
            {
                listBoxTests.Items.Add(obj);
            }

            listBoxTests.SelectedIndex = 0;
        }

        #endregion
    }
}