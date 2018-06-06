namespace UnitTests.Tests
{
    using VisualPlus.Toolkit.Child;
    using VisualPlus.Toolkit.Controls.DataManagement;

    partial class VisualListViewTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn1 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn2 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn3 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn4 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            this.visualListViewAdvanced1 = new VisualPlus.Toolkit.Controls.DataManagement.VisualListViewAdvanced();
            this.SuspendLayout();
            // 
            // visualListViewAdvanced1
            // 
            this.visualListViewAdvanced1.AllowColumnResize = true;
            this.visualListViewAdvanced1.MultiSelect = false;
            this.visualListViewAdvanced1.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.visualListViewAdvanced1.AlternatingColors = false;
            this.visualListViewAdvanced1.AutoHeight = true;
            this.visualListViewAdvanced1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.visualListViewAdvanced1.BackgroundStretchToFit = true;
            visualListViewColumn1.CheckBoxes = false;
            visualListViewColumn1.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.None;
            visualListViewColumn1.ImageIndex = -1;
            visualListViewColumn1.Name = "VisualListViewColumn1";
            visualListViewColumn1.NumericSort = false;
            visualListViewColumn1.Text = "Title";
            visualListViewColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            visualListViewColumn1.Width = 100;
            visualListViewColumn2.CheckBoxes = false;
            visualListViewColumn2.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.TextBox;
            visualListViewColumn2.ImageIndex = -1;
            visualListViewColumn2.Name = "VisualListViewColumn2";
            visualListViewColumn2.NumericSort = false;
            visualListViewColumn2.Text = "Content";
            visualListViewColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            visualListViewColumn2.Width = 100;
            visualListViewColumn3.CheckBoxes = false;
            visualListViewColumn3.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.DateTimePicker;
            visualListViewColumn3.ImageIndex = -1;
            visualListViewColumn3.Name = "VisualListViewColumn3";
            visualListViewColumn3.NumericSort = false;
            visualListViewColumn3.Text = "Date";
            visualListViewColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            visualListViewColumn3.Width = 100;
            visualListViewColumn4.CheckBoxes = false;
            visualListViewColumn4.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.None;
            visualListViewColumn4.ImageIndex = -1;
            visualListViewColumn4.Name = "VisualListViewColumn4";
            visualListViewColumn4.NumericSort = false;
            visualListViewColumn4.Text = "Progress";
            visualListViewColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            visualListViewColumn4.Width = 100;
            this.visualListViewAdvanced1.Columns.AddRange(new VisualPlus.Toolkit.Child.VisualListViewColumn[] {
            visualListViewColumn1,
            visualListViewColumn2,
            visualListViewColumn3,
            visualListViewColumn4});
            this.visualListViewAdvanced1.ControlStyle = VisualPlus.Enumerators.LVControlStyles.XP;
            this.visualListViewAdvanced1.FullRowSelect = true;
            this.visualListViewAdvanced1.GridColor = System.Drawing.Color.LightGray;
            this.visualListViewAdvanced1.GridLines = VisualPlus.Enumerators.GridLines.Both;
            this.visualListViewAdvanced1.GridLineStyle = VisualPlus.Enumerators.GridLineStyle.Solid;
            this.visualListViewAdvanced1.GridTypes = VisualPlus.Enumerators.GridTypes.Normal;
            this.visualListViewAdvanced1.HeaderHeight = 22;
            this.visualListViewAdvanced1.HeaderVisible = true;
            this.visualListViewAdvanced1.HeaderWordWrap = false;
            this.visualListViewAdvanced1.HotColumnTracking = true;
            this.visualListViewAdvanced1.HotItemTracking = true;
            this.visualListViewAdvanced1.HotTrackingColor = System.Drawing.Color.LightGray;
            this.visualListViewAdvanced1.HoverEvents = false;
            this.visualListViewAdvanced1.HoverTime = 1;
            this.visualListViewAdvanced1.ImageList = null;
            this.visualListViewAdvanced1.ItemHeight = 17;
            this.visualListViewAdvanced1.ItemWordWrap = false;
            this.visualListViewAdvanced1.Location = new System.Drawing.Point(12, 12);
            this.visualListViewAdvanced1.Name = "visualListViewAdvanced1";
            this.visualListViewAdvanced1.Selectable = true;
            this.visualListViewAdvanced1.SelectedTextColor = System.Drawing.Color.White;
            this.visualListViewAdvanced1.SelectionColor = System.Drawing.Color.DarkBlue;
            this.visualListViewAdvanced1.ShowBorder = true;
            this.visualListViewAdvanced1.ShowFocusRect = false;
            this.visualListViewAdvanced1.Size = new System.Drawing.Size(457, 231);
            this.visualListViewAdvanced1.SortType = VisualPlus.Enumerators.SortTypes.InsertionSort;
            this.visualListViewAdvanced1.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.visualListViewAdvanced1.TabIndex = 0;
            this.visualListViewAdvanced1.Text = "visualListViewAdvanced1";
            // 
            // VisualListViewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 255);
            this.Controls.Add(this.visualListViewAdvanced1);
            this.Name = "VisualListViewTest";
            this.Text = "VisualListView Test";
            this.Load += new System.EventHandler(this.VisualListViewTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VisualListViewAdvanced visualListViewAdvanced1;
    }
}