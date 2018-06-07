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
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn1 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn2 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn3 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn4 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Structure.TextStyle textStyle1 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.TextStyle textStyle2 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.TextStyle textStyle3 = new VisualPlus.Structure.TextStyle();
            this.visualListViewAdvanced1 = new VisualPlus.Toolkit.Controls.DataManagement.VisualListViewAdvanced();
            this.BtnRemove = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.BtnAdd = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.SuspendLayout();
            // 
            // visualListViewAdvanced1
            // 
            this.visualListViewAdvanced1.AllowColumnResize = true;
            this.visualListViewAdvanced1.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.visualListViewAdvanced1.AlternatingColors = false;
            this.visualListViewAdvanced1.AutoHeight = true;
            this.visualListViewAdvanced1.BackColor = System.Drawing.Color.White;
            this.visualListViewAdvanced1.BackgroundStretchToFit = true;
            this.visualListViewAdvanced1.BorderVisible = false;
            visualListViewColumn1.CheckBoxes = true;
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
            this.visualListViewAdvanced1.Columns.AddRange(new VisualPlus.Toolkit.Child.VisualListViewColumn[] {
            visualListViewColumn1,
            visualListViewColumn2,
            visualListViewColumn3,
            visualListViewColumn4});
            this.visualListViewAdvanced1.ControlStyle = VisualPlus.Enumerators.LVControlStyles.SuperFlat;
            this.visualListViewAdvanced1.DisplayText = "The list is empty.";
            this.visualListViewAdvanced1.DisplayTextColor = System.Drawing.Color.DimGray;
            this.visualListViewAdvanced1.DisplayTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visualListViewAdvanced1.DisplayTextOnEmpty = true;
            this.visualListViewAdvanced1.Dock = System.Windows.Forms.DockStyle.Bottom;
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
            this.visualListViewAdvanced1.ItemHeight = 17;
            this.visualListViewAdvanced1.ItemWordWrap = false;
            this.visualListViewAdvanced1.Location = new System.Drawing.Point(0, 80);
            this.visualListViewAdvanced1.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualListViewAdvanced1.MultiSelect = true;
            this.visualListViewAdvanced1.Name = "visualListViewAdvanced1";
            this.visualListViewAdvanced1.Selectable = true;
            this.visualListViewAdvanced1.SelectedTextColor = System.Drawing.Color.White;
            this.visualListViewAdvanced1.SelectionColor = System.Drawing.Color.CornflowerBlue;
            this.visualListViewAdvanced1.ShowFocusRect = false;
            this.visualListViewAdvanced1.Size = new System.Drawing.Size(482, 231);
            this.visualListViewAdvanced1.SortType = VisualPlus.Enumerators.SortTypes.InsertionSort;
            this.visualListViewAdvanced1.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.visualListViewAdvanced1.TabIndex = 0;
            this.visualListViewAdvanced1.Text = "visualListViewAdvanced1";
            textStyle1.Disabled = System.Drawing.Color.Empty;
            textStyle1.Enabled = System.Drawing.Color.Empty;
            textStyle1.Hover = System.Drawing.Color.Empty;
            textStyle1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.visualListViewAdvanced1.TextStyle = textStyle1;
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
            this.BtnRemove.Location = new System.Drawing.Point(158, 12);
            this.BtnRemove.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(140, 45);
            this.BtnRemove.TabIndex = 3;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.BtnRemove.TextLineAlignment = System.Drawing.StringAlignment.Center;
            textStyle2.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            textStyle2.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            textStyle2.Hover = System.Drawing.Color.Empty;
            textStyle2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.BtnRemove.TextStyle = textStyle2;
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
            this.BtnAdd.Location = new System.Drawing.Point(12, 12);
            this.BtnAdd.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(140, 45);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.BtnAdd.TextLineAlignment = System.Drawing.StringAlignment.Center;
            textStyle3.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            textStyle3.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            textStyle3.Hover = System.Drawing.Color.Empty;
            textStyle3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.BtnAdd.TextStyle = textStyle3;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // VisualListViewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 311);
            this.Controls.Add(this.visualListViewAdvanced1);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnAdd);
            this.Name = "VisualListViewTest";
            this.Text = "VisualListView Test";
            this.Load += new System.EventHandler(this.VisualListViewTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VisualListViewAdvanced visualListViewAdvanced1;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton BtnAdd;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton BtnRemove;
    }
}