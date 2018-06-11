namespace UnitTests.Forms
{
    #region Namespace

    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    using UnitTests.Tests;

    using VisualPlus.EventArgs;
    using VisualPlus.Toolkit.Dialogs;

    #endregion

    /// <summary>The test manager.</summary>
    public partial class UnitTestManager : VisualForm
    {
        #region Variables

        private UnitTests _unitTest;

        #endregion

        #region Constructors

        public UnitTestManager()
        {
            InitializeComponent();
            _visualControlBox.HelpClick += VisualControlBox_HelpClick;
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

        private void BtnRunTest_Click(object sender, EventArgs e)
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
            _unitTest = (UnitTests)visualListBoxTests.SelectedIndex;
        }

        private void TestManager_Load(object sender, EventArgs e)
        {
            _unitTest = UnitTests.VisualListViewAdvanced;

            Array _tests = typeof(UnitTests).GetEnumValues();
            visualLabelTestsCount.Text = $@"Tests Count: {_tests.Length}";

            foreach (object test in _tests)
            {
                visualListBoxTests.Items.Add(test);
            }

            visualListBoxTests.SelectedIndex = 0;
        }

        private void VisualControlBox_HelpClick(ControlBoxEventArgs e)
        {
            Process.Start("https://darkbyte7.github.io/VisualPlus/");
        }

        #endregion
    }
}