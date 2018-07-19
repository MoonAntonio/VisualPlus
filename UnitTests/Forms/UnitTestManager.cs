#region Namespace

using System;
using System.Diagnostics;
using System.Windows.Forms;

using UnitTests.Tests;

using VisualPlus.Events;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace UnitTests.Forms
{
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
            HelpButtonClicked += VisualControlBox_HelpClick;
        }

        #endregion

        #region Enumerators

        /// <summary>The different kind of unit tests.</summary>
        private enum UnitTests
        {
            /// <summary>The VisualForm.</summary>
            VisualFormEmpty = 0,

            /// <summary>The VisualForm.</summary>
            VisualFormTest = 1,

            /// <summary>The list view.</summary>
            VisualListView = 2
        }

        #endregion

        #region Methods

        private void BtnRunTest_Click(object sender, EventArgs e)
        {
            VisualForm _formToOpen;
            
            switch (_unitTest)
            {
                case UnitTests.VisualFormEmpty:
                    {
                        _formToOpen = new VisualForm(Application.ProductName);
                        break;
                    }

                case UnitTests.VisualFormTest:
                    {
                        _formToOpen = new FormTest();
                        break;
                    }

                case UnitTests.VisualListView:
                    {
                        _formToOpen = new VisualListViewTest();
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            _formToOpen.ShowDialog();
        }

        private void ListBoxTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            _unitTest = (UnitTests)visualListBoxTests.SelectedIndex;
        }

        private void TestManager_Load(object sender, EventArgs e)
        {
            _unitTest = UnitTests.VisualListView;

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