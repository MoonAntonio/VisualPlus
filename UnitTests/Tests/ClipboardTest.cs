#region Namespace

using System;

using VisualPlus.Events;
using VisualPlus.Toolkit.Child;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace UnitTests.Tests
{
    /// <summary>The clipboard test.</summary>
    public partial class ClipboardTest : VisualForm
    {
        #region Constructors

        public ClipboardTest()
        {
            InitializeComponent();

            VisualListViewColumn timeColumn = new VisualListViewColumn("Time");

            VisualListViewColumn eventsColumn = new VisualListViewColumn("Events")
                    {
                       Width = 200 
                    };

            listViewEvents.Columns.Add(timeColumn);
            listViewEvents.Columns.Add(eventsColumn);

            textBox.ClipboardCopy += TextBox_ClipboardCopy;
            textBox.ClipboardCut += TextBox_ClipboardCut;
            textBox.ClipboardPaste += TextBox_ClipboardPaste;
        }

        #endregion

        #region Methods

        /// <summary>Generates an event item.</summary>
        /// <param name="text">The text.</param>
        private void GenerateEventItem(string text)
        {
            VisualListViewItem item = new VisualListViewItem(DateTime.Now.ToLongTimeString());
            item.SubItems.Add(text);

            listViewEvents.Items.Add(item);
        }

        private void TextBox_ClipboardCopy(object sender, ClipboardEventArgs e)
        {
            GenerateEventItem("Copied to clipboard.");
        }

        private void TextBox_ClipboardCut(object sender, ClipboardEventArgs e)
        {
            GenerateEventItem("Cut to clipboard.");
        }

        private void TextBox_ClipboardPaste(object sender, ClipboardEventArgs e)
        {
            GenerateEventItem("Pasted from clipboard.");
        }

        #endregion
    }
}