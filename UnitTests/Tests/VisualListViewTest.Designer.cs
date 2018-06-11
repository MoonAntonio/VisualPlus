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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualListViewTest));
            VisualPlus.Structure.TextStyle textStyle1 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.TextStyle textStyle2 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.TextStyle textStyle3 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn1 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn2 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn3 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn4 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Structure.TextStyle textStyle4 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.TextStyle textStyle5 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.Border border1 = new VisualPlus.Structure.Border();
            this.visualListViewExTest = new VisualPlus.Toolkit.Controls.DataManagement.VisualListViewEx();
            this.imageListColumns = new System.Windows.Forms.ImageList(this.components);
            this.imageListItems = new System.Windows.Forms.ImageList(this.components);
            this.BtnRemove = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.BtnAdd = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.SuspendLayout();
            // 
            // _visualControlBox
            // 
            // 
            // 
            // 
            this._visualControlBox.HelpButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this._visualControlBox.HelpButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this._visualControlBox.HelpButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this._visualControlBox.HelpButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this._visualControlBox.HelpButton.BoxType = VisualPlus.Structure.ControlBoxButton.ControlBoxType.Default;
            this._visualControlBox.HelpButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this._visualControlBox.HelpButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._visualControlBox.HelpButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._visualControlBox.HelpButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._visualControlBox.HelpButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this._visualControlBox.HelpButton.Location = new System.Drawing.Point(0, 0);
            this._visualControlBox.HelpButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this._visualControlBox.HelpButton.Name = "";
            this._visualControlBox.HelpButton.OffsetLocation = new System.Drawing.Point(0, 1);
            this._visualControlBox.HelpButton.Size = new System.Drawing.Size(24, 25);
            this._visualControlBox.HelpButton.TabIndex = 0;
            this._visualControlBox.HelpButton.Text = "s";
            textStyle1.Disabled = System.Drawing.Color.Empty;
            textStyle1.Enabled = System.Drawing.Color.Empty;
            textStyle1.Hover = System.Drawing.Color.Empty;
            textStyle1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this._visualControlBox.HelpButton.TextStyle = textStyle1;
            this._visualControlBox.HelpButton.Visible = false;
            this._visualControlBox.Location = new System.Drawing.Point(462, 4);
            // 
            // 
            // 
            this._visualControlBox.MaximizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this._visualControlBox.MaximizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this._visualControlBox.MaximizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this._visualControlBox.MaximizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this._visualControlBox.MaximizeButton.BoxType = VisualPlus.Structure.ControlBoxButton.ControlBoxType.Default;
            this._visualControlBox.MaximizeButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this._visualControlBox.MaximizeButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._visualControlBox.MaximizeButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._visualControlBox.MaximizeButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._visualControlBox.MaximizeButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this._visualControlBox.MaximizeButton.Location = new System.Drawing.Point(24, 0);
            this._visualControlBox.MaximizeButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this._visualControlBox.MaximizeButton.Name = "";
            this._visualControlBox.MaximizeButton.OffsetLocation = new System.Drawing.Point(1, 1);
            this._visualControlBox.MaximizeButton.Size = new System.Drawing.Size(24, 25);
            this._visualControlBox.MaximizeButton.TabIndex = 2;
            this._visualControlBox.MaximizeButton.Text = "1";
            textStyle2.Disabled = System.Drawing.Color.Empty;
            textStyle2.Enabled = System.Drawing.Color.Empty;
            textStyle2.Hover = System.Drawing.Color.Empty;
            textStyle2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this._visualControlBox.MaximizeButton.TextStyle = textStyle2;
            // 
            // 
            // 
            this._visualControlBox.MinimizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this._visualControlBox.MinimizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this._visualControlBox.MinimizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this._visualControlBox.MinimizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this._visualControlBox.MinimizeButton.BoxType = VisualPlus.Structure.ControlBoxButton.ControlBoxType.Default;
            this._visualControlBox.MinimizeButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this._visualControlBox.MinimizeButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._visualControlBox.MinimizeButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._visualControlBox.MinimizeButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._visualControlBox.MinimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this._visualControlBox.MinimizeButton.Location = new System.Drawing.Point(0, 0);
            this._visualControlBox.MinimizeButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this._visualControlBox.MinimizeButton.Name = "";
            this._visualControlBox.MinimizeButton.OffsetLocation = new System.Drawing.Point(2, 0);
            this._visualControlBox.MinimizeButton.Size = new System.Drawing.Size(24, 25);
            this._visualControlBox.MinimizeButton.TabIndex = 1;
            this._visualControlBox.MinimizeButton.Text = "0";
            textStyle3.Disabled = System.Drawing.Color.Empty;
            textStyle3.Enabled = System.Drawing.Color.Empty;
            textStyle3.Hover = System.Drawing.Color.Empty;
            textStyle3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this._visualControlBox.MinimizeButton.TextStyle = textStyle3;
            this._visualControlBox.Size = new System.Drawing.Size(72, 25);
            // 
            // visualListViewExTest
            // 
            this.visualListViewExTest.AllowColumnResize = true;
            this.visualListViewExTest.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.visualListViewExTest.AlternatingColors = false;
            this.visualListViewExTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visualListViewExTest.AutoHeight = true;
            this.visualListViewExTest.BackColor = System.Drawing.Color.White;
            this.visualListViewExTest.BackgroundStretchToFit = true;
            this.visualListViewExTest.BorderVisible = false;
            visualListViewColumn1.CheckBoxes = true;
            visualListViewColumn1.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.None;
            visualListViewColumn1.ImageIndex = -1;
            visualListViewColumn1.Name = "VisualListViewColumn1";
            visualListViewColumn1.NumericSort = false;
            visualListViewColumn1.Text = "Title";
            visualListViewColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            visualListViewColumn1.Width = 100;
            visualListViewColumn2.CheckBoxes = false;
            visualListViewColumn2.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.TextBox;
            visualListViewColumn2.ImageIndex = -1;
            visualListViewColumn2.Name = "VisualListViewColumn2";
            visualListViewColumn2.NumericSort = false;
            visualListViewColumn2.Text = "Content";
            visualListViewColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            visualListViewColumn2.Width = 100;
            visualListViewColumn3.CheckBoxes = false;
            visualListViewColumn3.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.DateTimePicker;
            visualListViewColumn3.ImageIndex = -1;
            visualListViewColumn3.Name = "VisualListViewColumn3";
            visualListViewColumn3.NumericSort = false;
            visualListViewColumn3.Text = "Date";
            visualListViewColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            visualListViewColumn3.Width = 100;
            visualListViewColumn4.CheckBoxes = false;
            visualListViewColumn4.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.None;
            visualListViewColumn4.ImageIndex = -1;
            visualListViewColumn4.Name = "VisualListViewColumn4";
            visualListViewColumn4.NumericSort = false;
            visualListViewColumn4.Text = "Progress";
            visualListViewColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            visualListViewColumn4.Width = 100;
            this.visualListViewExTest.Columns.AddRange(new VisualPlus.Toolkit.Child.VisualListViewColumn[] {
            visualListViewColumn1,
            visualListViewColumn2,
            visualListViewColumn3,
            visualListViewColumn4});
            this.visualListViewExTest.ControlStyle = VisualPlus.Enumerators.LVControlStyles.SuperFlat;
            this.visualListViewExTest.DisplayText = "The list is empty.";
            this.visualListViewExTest.DisplayTextColor = System.Drawing.Color.DimGray;
            this.visualListViewExTest.DisplayTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visualListViewExTest.DisplayTextOnEmpty = true;
            this.visualListViewExTest.FullRowSelect = true;
            this.visualListViewExTest.GridColor = System.Drawing.Color.LightGray;
            this.visualListViewExTest.GridLines = VisualPlus.Enumerators.GridLines.Both;
            this.visualListViewExTest.GridLineStyle = VisualPlus.Enumerators.GridLineStyle.Solid;
            this.visualListViewExTest.GridTypes = VisualPlus.Enumerators.GridTypes.Normal;
            this.visualListViewExTest.HeaderHeight = 22;
            this.visualListViewExTest.HeaderVisible = true;
            this.visualListViewExTest.HeaderWordWrap = false;
            this.visualListViewExTest.HotColumnTracking = true;
            this.visualListViewExTest.HotItemTracking = true;
            this.visualListViewExTest.HotTrackingColor = System.Drawing.Color.LightGray;
            this.visualListViewExTest.HoverEvents = false;
            this.visualListViewExTest.HoverTime = 1;
            this.visualListViewExTest.ImageListColumns = this.imageListColumns;
            this.visualListViewExTest.ImageListItems = this.imageListItems;
            this.visualListViewExTest.ItemHeight = 20;
            this.visualListViewExTest.ItemWordWrap = false;
            this.visualListViewExTest.Location = new System.Drawing.Point(13, 75);
            this.visualListViewExTest.MultiSelect = true;
            this.visualListViewExTest.Name = "visualListViewExTest";
            this.visualListViewExTest.Selectable = true;
            this.visualListViewExTest.SelectedTextColor = System.Drawing.Color.White;
            this.visualListViewExTest.SelectionColor = System.Drawing.Color.CornflowerBlue;
            this.visualListViewExTest.ShowFocusRect = false;
            this.visualListViewExTest.Size = new System.Drawing.Size(511, 259);
            this.visualListViewExTest.SortType = VisualPlus.Enumerators.SortTypes.InsertionSort;
            this.visualListViewExTest.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.visualListViewExTest.TabIndex = 0;
            this.visualListViewExTest.Text = "visualListViewAdvanced1";
            // 
            // imageListColumns
            // 
            this.imageListColumns.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListColumns.ImageStream")));
            this.imageListColumns.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListColumns.Images.SetKeyName(0, "title_window.png");
            this.imageListColumns.Images.SetKeyName(1, "layout_content.png");
            this.imageListColumns.Images.SetKeyName(2, "date.png");
            this.imageListColumns.Images.SetKeyName(3, "progressbar.png");
            // 
            // imageListItems
            // 
            this.imageListItems.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListItems.ImageStream")));
            this.imageListItems.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListItems.Images.SetKeyName(0, "tick_red.png");
            this.imageListItems.Images.SetKeyName(1, "tick_green.png");
            // 
            // BtnRemove
            // 
            this.BtnRemove.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnRemove.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.BtnRemove.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnRemove.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnRemove.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.BtnRemove.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.BtnRemove.Border.HoverVisible = true;
            this.BtnRemove.Border.Rounding = 6;
            this.BtnRemove.Border.Thickness = 1;
            this.BtnRemove.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.BtnRemove.Border.Visible = true;
            this.BtnRemove.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.BtnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnRemove.Image = null;
            this.BtnRemove.Location = new System.Drawing.Point(109, 38);
            this.BtnRemove.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(90, 31);
            this.BtnRemove.TabIndex = 3;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.BtnRemove.TextLineAlignment = System.Drawing.StringAlignment.Center;
            textStyle4.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            textStyle4.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            textStyle4.Hover = System.Drawing.Color.Empty;
            textStyle4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.BtnRemove.TextStyle = textStyle4;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnAdd.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.BtnAdd.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnAdd.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnAdd.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.BtnAdd.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.BtnAdd.Border.HoverVisible = true;
            this.BtnAdd.Border.Rounding = 6;
            this.BtnAdd.Border.Thickness = 1;
            this.BtnAdd.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.BtnAdd.Border.Visible = true;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.BtnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnAdd.Image = null;
            this.BtnAdd.Location = new System.Drawing.Point(13, 38);
            this.BtnAdd.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(90, 31);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.BtnAdd.TextLineAlignment = System.Drawing.StringAlignment.Center;
            textStyle5.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            textStyle5.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            textStyle5.Hover = System.Drawing.Color.Empty;
            textStyle5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.BtnAdd.TextStyle = textStyle5;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // VisualListViewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.Border.HoverVisible = true;
            this.Border.Rounding = 6;
            this.Border.Thickness = 3;
            this.Border.Type = VisualPlus.Enumerators.ShapeType.Rectangle;
            this.Border.Visible = true;
            this.ClientSize = new System.Drawing.Size(538, 348);
            this.Controls.Add(this.visualListViewExTest);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnAdd);
            border1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            border1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            border1.HoverVisible = false;
            border1.Rounding = 6;
            border1.Thickness = 1;
            border1.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            border1.Visible = false;
            this.Image.Border = border1;
            this.Image.Image = ((System.Drawing.Bitmap)(resources.GetObject("resource.Image3")));
            this.Image.Point = new System.Drawing.Point(5, 7);
            this.Image.Size = new System.Drawing.Size(16, 16);
            this.Image.Visible = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "VisualListViewTest";
            this.Text = "VisualListView Extended Test";
            this.TextRectangle = new System.Drawing.Rectangle(193, 7, 153, 13);
            this.Load += new System.EventHandler(this.VisualListViewTest_Load);
            this.Controls.SetChildIndex(this.BtnAdd, 0);
            this.Controls.SetChildIndex(this.BtnRemove, 0);
            this.Controls.SetChildIndex(this.visualListViewExTest, 0);
            this.Controls.SetChildIndex(this._visualControlBox, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private VisualListViewEx visualListViewExTest;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton BtnAdd;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton BtnRemove;
        private System.Windows.Forms.ImageList imageListColumns;
        private System.Windows.Forms.ImageList imageListItems;
    }
}