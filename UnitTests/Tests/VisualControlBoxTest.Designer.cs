namespace UnitTests.Tests
{
    partial class VisualControlBoxTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualControlBoxTest));
            this.TControlBox = new VisualPlus.Toolkit.Controls.Interactivity.VisualToggle();
            this.LControlBoxToggle = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.LMinimzeBox = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.TMaximize = new VisualPlus.Toolkit.Controls.Interactivity.VisualToggle();
            this.SuspendLayout();
            // 
            // TControlBox
            // 
            this.TControlBox.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TControlBox.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.TControlBox.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TControlBox.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.TControlBox.Border.HoverVisible = true;
            this.TControlBox.Border.Rounding = 20;
            this.TControlBox.Border.Thickness = 1;
            this.TControlBox.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.TControlBox.Border.Visible = true;
            this.TControlBox.ButtonBorder.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TControlBox.ButtonBorder.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.TControlBox.ButtonBorder.HoverVisible = true;
            this.TControlBox.ButtonBorder.Rounding = 18;
            this.TControlBox.ButtonBorder.Thickness = 1;
            this.TControlBox.ButtonBorder.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.TControlBox.ButtonBorder.Visible = true;
            this.TControlBox.ButtonColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TControlBox.ButtonColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TControlBox.ButtonColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TControlBox.ButtonColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TControlBox.ButtonSize = new System.Drawing.Size(20, 20);
            this.TControlBox.FalseTextToggle = "No";
            this.TControlBox.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.TControlBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TControlBox.Location = new System.Drawing.Point(133, 45);
            this.TControlBox.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.TControlBox.Name = "TControlBox";
            this.TControlBox.ProgressImage = null;
            this.TControlBox.Size = new System.Drawing.Size(50, 25);
            this.TControlBox.TabIndex = 1;
            this.TControlBox.Text = "visualToggle1";
            this.TControlBox.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.TControlBox.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TControlBox.TextStyle.Hover = System.Drawing.Color.Empty;
            this.TControlBox.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.TControlBox.Toggled = true;
            this.TControlBox.TrueTextToggle = "Yes";
            this.TControlBox.Type = VisualPlus.Toolkit.Controls.Interactivity.VisualToggle.ToggleTypes.YesNo;
            this.TControlBox.ToggleChanged += new VisualPlus.Delegates.ToggleChangedEventHandler(this.TControlBox_ToggleChanged);
            // 
            // LControlBoxToggle
            // 
            this.LControlBoxToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.LControlBoxToggle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.LControlBoxToggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LControlBoxToggle.Location = new System.Drawing.Point(15, 45);
            this.LControlBoxToggle.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.LControlBoxToggle.Name = "LControlBoxToggle";
            this.LControlBoxToggle.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LControlBoxToggle.Outline = false;
            this.LControlBoxToggle.OutlineColor = System.Drawing.Color.Red;
            this.LControlBoxToggle.OutlineLocation = new System.Drawing.Point(0, 0);
            this.LControlBoxToggle.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LControlBoxToggle.ReflectionSpacing = 0;
            this.LControlBoxToggle.ShadowColor = System.Drawing.Color.Black;
            this.LControlBoxToggle.ShadowDirection = 315;
            this.LControlBoxToggle.ShadowLocation = new System.Drawing.Point(0, 0);
            this.LControlBoxToggle.ShadowOpacity = 100;
            this.LControlBoxToggle.Size = new System.Drawing.Size(112, 23);
            this.LControlBoxToggle.TabIndex = 2;
            this.LControlBoxToggle.Text = "Control Box Toggle:";
            this.LControlBoxToggle.TextAlignment = System.Drawing.StringAlignment.Near;
            this.LControlBoxToggle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.LControlBoxToggle.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.LControlBoxToggle.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LControlBoxToggle.TextStyle.Hover = System.Drawing.Color.Empty;
            this.LControlBoxToggle.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // LMinimzeBox
            // 
            this.LMinimzeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.LMinimzeBox.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.LMinimzeBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LMinimzeBox.Location = new System.Drawing.Point(15, 81);
            this.LMinimzeBox.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.LMinimzeBox.Name = "LMinimzeBox";
            this.LMinimzeBox.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LMinimzeBox.Outline = false;
            this.LMinimzeBox.OutlineColor = System.Drawing.Color.Red;
            this.LMinimzeBox.OutlineLocation = new System.Drawing.Point(0, 0);
            this.LMinimzeBox.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LMinimzeBox.ReflectionSpacing = 0;
            this.LMinimzeBox.ShadowColor = System.Drawing.Color.Black;
            this.LMinimzeBox.ShadowDirection = 315;
            this.LMinimzeBox.ShadowLocation = new System.Drawing.Point(0, 0);
            this.LMinimzeBox.ShadowOpacity = 100;
            this.LMinimzeBox.Size = new System.Drawing.Size(75, 23);
            this.LMinimzeBox.TabIndex = 3;
            this.LMinimzeBox.Text = "Maximize Box:";
            this.LMinimzeBox.TextAlignment = System.Drawing.StringAlignment.Near;
            this.LMinimzeBox.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.LMinimzeBox.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.LMinimzeBox.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LMinimzeBox.TextStyle.Hover = System.Drawing.Color.Empty;
            this.LMinimzeBox.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // TMaximize
            // 
            this.TMaximize.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TMaximize.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.TMaximize.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TMaximize.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.TMaximize.Border.HoverVisible = true;
            this.TMaximize.Border.Rounding = 20;
            this.TMaximize.Border.Thickness = 1;
            this.TMaximize.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.TMaximize.Border.Visible = true;
            this.TMaximize.ButtonBorder.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TMaximize.ButtonBorder.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.TMaximize.ButtonBorder.HoverVisible = true;
            this.TMaximize.ButtonBorder.Rounding = 18;
            this.TMaximize.ButtonBorder.Thickness = 1;
            this.TMaximize.ButtonBorder.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.TMaximize.ButtonBorder.Visible = true;
            this.TMaximize.ButtonColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TMaximize.ButtonColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TMaximize.ButtonColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TMaximize.ButtonColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TMaximize.ButtonSize = new System.Drawing.Size(20, 20);
            this.TMaximize.FalseTextToggle = "No";
            this.TMaximize.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.TMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TMaximize.Location = new System.Drawing.Point(133, 81);
            this.TMaximize.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.TMaximize.Name = "TMaximize";
            this.TMaximize.ProgressImage = null;
            this.TMaximize.Size = new System.Drawing.Size(50, 25);
            this.TMaximize.TabIndex = 4;
            this.TMaximize.Text = "visualToggle1";
            this.TMaximize.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.TMaximize.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TMaximize.TextStyle.Hover = System.Drawing.Color.Empty;
            this.TMaximize.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.TMaximize.Toggled = true;
            this.TMaximize.TrueTextToggle = "Yes";
            this.TMaximize.Type = VisualPlus.Toolkit.Controls.Interactivity.VisualToggle.ToggleTypes.YesNo;
            this.TMaximize.ToggleChanged += new VisualPlus.Delegates.ToggleChangedEventHandler(this.TMaximize_ToggleChanged);
            // 
            // VisualControlBoxTest
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
            this.ClientSize = new System.Drawing.Size(339, 248);
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
            this.ControlBox.HelpButton.TextStyle.Disabled = System.Drawing.Color.Empty;
            this.ControlBox.HelpButton.TextStyle.Enabled = System.Drawing.Color.Empty;
            this.ControlBox.HelpButton.TextStyle.Hover = System.Drawing.Color.Empty;
            this.ControlBox.HelpButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.Location = new System.Drawing.Point(239, 4);
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
            this.ControlBox.MaximizeButton.TextStyle.Disabled = System.Drawing.Color.Empty;
            this.ControlBox.MaximizeButton.TextStyle.Enabled = System.Drawing.Color.Empty;
            this.ControlBox.MaximizeButton.TextStyle.Hover = System.Drawing.Color.Empty;
            this.ControlBox.MaximizeButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
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
            this.ControlBox.MinimizeButton.TextStyle.Disabled = System.Drawing.Color.Empty;
            this.ControlBox.MinimizeButton.TextStyle.Enabled = System.Drawing.Color.Empty;
            this.ControlBox.MinimizeButton.TextStyle.Hover = System.Drawing.Color.Empty;
            this.ControlBox.MinimizeButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.Name = "";
            this.ControlBox.Size = new System.Drawing.Size(96, 25);
            this.ControlBox.TabIndex = 0;
            this.ControlBox.TextStyle.Disabled = System.Drawing.Color.Empty;
            this.ControlBox.TextStyle.Enabled = System.Drawing.Color.Empty;
            this.ControlBox.TextStyle.Hover = System.Drawing.Color.Empty;
            this.ControlBox.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.Controls.Add(this.TMaximize);
            this.Controls.Add(this.LMinimzeBox);
            this.Controls.Add(this.LControlBoxToggle);
            this.Controls.Add(this.TControlBox);
            this.HelpButton = true;
            this.Image.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Image.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.Image.Border.HoverVisible = false;
            this.Image.Border.Rounding = 6;
            this.Image.Border.Thickness = 1;
            this.Image.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.Image.Border.Visible = false;
            this.Image.Image = ((System.Drawing.Bitmap)(resources.GetObject("resource.Image3")));
            this.Image.Point = new System.Drawing.Point(5, 7);
            this.Image.Size = new System.Drawing.Size(16, 16);
            this.Image.Visible = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "VisualControlBoxTest";
            this.Text = "VisualControlBox Test";
            this.TextRectangle = new System.Drawing.Rectangle(110, 7, 118, 14);
            this.ResumeLayout(false);

        }

        #endregion

        private VisualPlus.Toolkit.Controls.Interactivity.VisualToggle TControlBox;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel LControlBoxToggle;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel LMinimzeBox;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualToggle TMaximize;
    }
}