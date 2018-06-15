namespace UnitTests.Forms
{
    partial class UnitTestManager
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
            VisualPlus.Structure.TextStyle textStyle1 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.TextStyle textStyle2 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.TextStyle textStyle3 = new VisualPlus.Structure.TextStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitTestManager));
            VisualPlus.Structure.TextStyle textStyle4 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.TextStyle textStyle5 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.TextStyle textStyle6 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.TextStyle textStyle7 = new VisualPlus.Structure.TextStyle();
            VisualPlus.Structure.Border border1 = new VisualPlus.Structure.Border();
            this.BtnRunTest = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.visualListBoxTests = new VisualPlus.Toolkit.Controls.DataManagement.VisualListBox();
            this.visualLabelTestsCount = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.SuspendLayout();
            // 
            // BtnRunTest
            // 
            this.BtnRunTest.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnRunTest.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.BtnRunTest.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnRunTest.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnRunTest.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.BtnRunTest.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.BtnRunTest.Border.HoverVisible = true;
            this.BtnRunTest.Border.Rounding = 6;
            this.BtnRunTest.Border.Thickness = 1;
            this.BtnRunTest.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.BtnRunTest.Border.Visible = true;
            this.BtnRunTest.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.BtnRunTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnRunTest.Image = null;
            this.BtnRunTest.Location = new System.Drawing.Point(12, 42);
            this.BtnRunTest.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.BtnRunTest.Name = "BtnRunTest";
            this.BtnRunTest.Size = new System.Drawing.Size(88, 38);
            this.BtnRunTest.TabIndex = 2;
            this.BtnRunTest.Text = "Run Test";
            this.BtnRunTest.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnRunTest.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.BtnRunTest.TextLineAlignment = System.Drawing.StringAlignment.Center;
            textStyle1.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            textStyle1.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            textStyle1.Hover = System.Drawing.Color.Empty;
            textStyle1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.BtnRunTest.TextStyle = textStyle1;
            this.BtnRunTest.Click += new System.EventHandler(this.BtnRunTest_Click);
            // 
            // visualListBoxTests
            // 
            this.visualListBoxTests.AlternateColors = false;
            this.visualListBoxTests.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.visualListBoxTests.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.visualListBoxTests.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.visualListBoxTests.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.visualListBoxTests.Border.HoverVisible = true;
            this.visualListBoxTests.Border.Rounding = 6;
            this.visualListBoxTests.Border.Thickness = 1;
            this.visualListBoxTests.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.visualListBoxTests.Border.Visible = true;
            this.visualListBoxTests.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualListBoxTests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualListBoxTests.ItemAlternate = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(13)))));
            this.visualListBoxTests.ItemHeight = 18;
            this.visualListBoxTests.ItemLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualListBoxTests.ItemNormal = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.visualListBoxTests.ItemSelected = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.visualListBoxTests.Location = new System.Drawing.Point(12, 86);
            this.visualListBoxTests.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualListBoxTests.Name = "visualListBoxTests";
            this.visualListBoxTests.Size = new System.Drawing.Size(308, 150);
            this.visualListBoxTests.TabIndex = 3;
            this.visualListBoxTests.Text = "visualListBox1";
            textStyle2.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            textStyle2.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            textStyle2.Hover = System.Drawing.Color.Empty;
            textStyle2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.visualListBoxTests.TextStyle = textStyle2;
            this.visualListBoxTests.SelectedIndexChanged += new System.EventHandler(this.ListBoxTests_SelectedIndexChanged);
            // 
            // visualLabelTestsCount
            // 
            this.visualLabelTestsCount.BackColor = System.Drawing.Color.White;
            this.visualLabelTestsCount.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualLabelTestsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabelTestsCount.Location = new System.Drawing.Point(220, 49);
            this.visualLabelTestsCount.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualLabelTestsCount.Name = "visualLabelTestsCount";
            this.visualLabelTestsCount.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.visualLabelTestsCount.Outline = false;
            this.visualLabelTestsCount.OutlineColor = System.Drawing.Color.Red;
            this.visualLabelTestsCount.OutlineLocation = new System.Drawing.Point(0, 0);
            this.visualLabelTestsCount.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabelTestsCount.ReflectionSpacing = 0;
            this.visualLabelTestsCount.ShadowColor = System.Drawing.Color.Black;
            this.visualLabelTestsCount.ShadowDirection = 315;
            this.visualLabelTestsCount.ShadowLocation = new System.Drawing.Point(0, 0);
            this.visualLabelTestsCount.ShadowOpacity = 100;
            this.visualLabelTestsCount.Size = new System.Drawing.Size(100, 23);
            this.visualLabelTestsCount.TabIndex = 4;
            this.visualLabelTestsCount.Text = "Tests Count: 0";
            this.visualLabelTestsCount.TextAlignment = System.Drawing.StringAlignment.Far;
            this.visualLabelTestsCount.TextLineAlignment = System.Drawing.StringAlignment.Center;
            textStyle3.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            textStyle3.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            textStyle3.Hover = System.Drawing.Color.Empty;
            textStyle3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.visualLabelTestsCount.TextStyle = textStyle3;
            // 
            // UnitTestManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Background = System.Drawing.Color.White;
            this.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.Border.HoverVisible = true;
            this.Border.Rounding = 6;
            this.Border.Thickness = 3;
            this.Border.Type = VisualPlus.Enumerators.ShapeType.Rectangle;
            this.Border.Visible = true;
            this.ClientSize = new System.Drawing.Size(333, 251);
            // 
            // 
            // 
            this.ControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlBox.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ControlBox.HelpButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.HelpButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.HelpButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.HelpButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.HelpButton.BoxType = VisualPlus.Structure.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.HelpButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.HelpButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.HelpButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.HelpButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.HelpButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.ControlBox.HelpButton.Location = new System.Drawing.Point(0, 0);
            this.ControlBox.HelpButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.HelpButton.Name = "";
            this.ControlBox.HelpButton.OffsetLocation = new System.Drawing.Point(0, 1);
            this.ControlBox.HelpButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.HelpButton.TabIndex = 0;
            this.ControlBox.HelpButton.Text = "s";
            textStyle4.Disabled = System.Drawing.Color.Empty;
            textStyle4.Enabled = System.Drawing.Color.Empty;
            textStyle4.Hover = System.Drawing.Color.Empty;
            textStyle4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.HelpButton.TextStyle = textStyle4;
            this.ControlBox.Location = new System.Drawing.Point(257, 4);
            // 
            // 
            // 
            this.ControlBox.MaximizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.MaximizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MaximizeButton.BoxType = VisualPlus.Structure.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.MaximizeButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MaximizeButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.ControlBox.MaximizeButton.Location = new System.Drawing.Point(48, 0);
            this.ControlBox.MaximizeButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.MaximizeButton.Name = "";
            this.ControlBox.MaximizeButton.OffsetLocation = new System.Drawing.Point(1, 1);
            this.ControlBox.MaximizeButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.MaximizeButton.TabIndex = 2;
            this.ControlBox.MaximizeButton.Text = "1";
            textStyle5.Disabled = System.Drawing.Color.Empty;
            textStyle5.Enabled = System.Drawing.Color.Empty;
            textStyle5.Hover = System.Drawing.Color.Empty;
            textStyle5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.MaximizeButton.TextStyle = textStyle5;
            this.ControlBox.MaximizeButton.Visible = false;
            // 
            // 
            // 
            this.ControlBox.MinimizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.MinimizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.MinimizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.MinimizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MinimizeButton.BoxType = VisualPlus.Structure.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.MinimizeButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MinimizeButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.ControlBox.MinimizeButton.Location = new System.Drawing.Point(24, 0);
            this.ControlBox.MinimizeButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.MinimizeButton.Name = "";
            this.ControlBox.MinimizeButton.OffsetLocation = new System.Drawing.Point(2, 0);
            this.ControlBox.MinimizeButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.MinimizeButton.TabIndex = 1;
            this.ControlBox.MinimizeButton.Text = "0";
            textStyle6.Disabled = System.Drawing.Color.Empty;
            textStyle6.Enabled = System.Drawing.Color.Empty;
            textStyle6.Hover = System.Drawing.Color.Empty;
            textStyle6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.MinimizeButton.TextStyle = textStyle6;
            this.ControlBox.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.Name = "";
            this.ControlBox.Size = new System.Drawing.Size(72, 25);
            this.ControlBox.TabIndex = 0;
            textStyle7.Disabled = System.Drawing.Color.Empty;
            textStyle7.Enabled = System.Drawing.Color.Empty;
            textStyle7.Hover = System.Drawing.Color.Empty;
            textStyle7.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.TextStyle = textStyle7;
            this.Controls.Add(this.visualLabelTestsCount);
            this.Controls.Add(this.visualListBoxTests);
            this.Controls.Add(this.BtnRunTest);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.MinimizeBox = true;
            this.Name = "UnitTestManager";
            this.Sizable = false;
            this.Text = "VisualPlus - UnitTest Manager";
            this.TextRectangle = new System.Drawing.Rectangle(87, 7, 159, 14);
            this.Load += new System.EventHandler(this.TestManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton BtnRunTest;
        private VisualPlus.Toolkit.Controls.DataManagement.VisualListBox visualListBoxTests;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel visualLabelTestsCount;
    }
}