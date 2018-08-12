namespace VisualPlus.Toolkit.Dialogs
{
    partial class VisualColorDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualColorDialog));
            this.lR = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.lG = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.lB = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.lAlpha = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.nudAlpha = new VisualPlus.Toolkit.Controls.Interactivity.VisualNumericUpDown();
            this.nudRed = new VisualPlus.Toolkit.Controls.Interactivity.VisualNumericUpDown();
            this.nudGreen = new VisualPlus.Toolkit.Controls.Interactivity.VisualNumericUpDown();
            this.nudBlue = new VisualPlus.Toolkit.Controls.Interactivity.VisualNumericUpDown();
            this.tbHtml = new VisualPlus.Toolkit.Controls.Editors.VisualTextBox();
            this.btnOk = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.tilePreview = new VisualPlus.Toolkit.Controls.Layout.VisualTile();
            this.visualLabel1 = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.colorPicker = new VisualPlus.Toolkit.Controls.Editors.VisualColorPicker();
            this.SuspendLayout();
            // 
            // lR
            // 
            this.lR.BackColor = System.Drawing.Color.Transparent;
            this.lR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lR.Location = new System.Drawing.Point(146, 66);
            this.lR.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.lR.Name = "lR";
            this.lR.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.lR.Outline = false;
            this.lR.OutlineColor = System.Drawing.Color.Red;
            this.lR.OutlineLocation = new System.Drawing.Point(0, 0);
            this.lR.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lR.ReflectionSpacing = 0;
            this.lR.ShadowColor = System.Drawing.Color.Black;
            this.lR.ShadowDirection = 315;
            this.lR.ShadowLocation = new System.Drawing.Point(0, 0);
            this.lR.ShadowOpacity = 100;
            this.lR.Size = new System.Drawing.Size(41, 27);
            this.lR.TabIndex = 1;
            this.lR.Text = "Red:";
            this.lR.TextAlignment = System.Drawing.StringAlignment.Near;
            this.lR.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.lR.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.lR.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lR.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lR.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lR.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lR.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.lR.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // lG
            // 
            this.lG.BackColor = System.Drawing.Color.Transparent;
            this.lG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lG.Location = new System.Drawing.Point(146, 95);
            this.lG.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.lG.Name = "lG";
            this.lG.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.lG.Outline = false;
            this.lG.OutlineColor = System.Drawing.Color.Red;
            this.lG.OutlineLocation = new System.Drawing.Point(0, 0);
            this.lG.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lG.ReflectionSpacing = 0;
            this.lG.ShadowColor = System.Drawing.Color.Black;
            this.lG.ShadowDirection = 315;
            this.lG.ShadowLocation = new System.Drawing.Point(0, 0);
            this.lG.ShadowOpacity = 100;
            this.lG.Size = new System.Drawing.Size(41, 29);
            this.lG.TabIndex = 2;
            this.lG.Text = "Green:";
            this.lG.TextAlignment = System.Drawing.StringAlignment.Near;
            this.lG.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.lG.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.lG.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lG.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lG.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lG.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lG.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.lG.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // lB
            // 
            this.lB.BackColor = System.Drawing.Color.Transparent;
            this.lB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lB.Location = new System.Drawing.Point(146, 130);
            this.lB.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.lB.Name = "lB";
            this.lB.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.lB.Outline = false;
            this.lB.OutlineColor = System.Drawing.Color.Red;
            this.lB.OutlineLocation = new System.Drawing.Point(0, 0);
            this.lB.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lB.ReflectionSpacing = 0;
            this.lB.ShadowColor = System.Drawing.Color.Black;
            this.lB.ShadowDirection = 315;
            this.lB.ShadowLocation = new System.Drawing.Point(0, 0);
            this.lB.ShadowOpacity = 100;
            this.lB.Size = new System.Drawing.Size(41, 25);
            this.lB.TabIndex = 3;
            this.lB.Text = "Blue:";
            this.lB.TextAlignment = System.Drawing.StringAlignment.Near;
            this.lB.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.lB.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.lB.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lB.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lB.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lB.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lB.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.lB.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // lAlpha
            // 
            this.lAlpha.BackColor = System.Drawing.Color.Transparent;
            this.lAlpha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lAlpha.Location = new System.Drawing.Point(146, 37);
            this.lAlpha.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.lAlpha.Name = "lAlpha";
            this.lAlpha.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.lAlpha.Outline = false;
            this.lAlpha.OutlineColor = System.Drawing.Color.Red;
            this.lAlpha.OutlineLocation = new System.Drawing.Point(0, 0);
            this.lAlpha.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lAlpha.ReflectionSpacing = 0;
            this.lAlpha.ShadowColor = System.Drawing.Color.Black;
            this.lAlpha.ShadowDirection = 315;
            this.lAlpha.ShadowLocation = new System.Drawing.Point(0, 0);
            this.lAlpha.ShadowOpacity = 100;
            this.lAlpha.Size = new System.Drawing.Size(41, 25);
            this.lAlpha.TabIndex = 4;
            this.lAlpha.Text = "Alpha:";
            this.lAlpha.TextAlignment = System.Drawing.StringAlignment.Near;
            this.lAlpha.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.lAlpha.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.lAlpha.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lAlpha.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lAlpha.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lAlpha.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lAlpha.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.lAlpha.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // nudAlpha
            // 
            this.nudAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAlpha.BackColor = System.Drawing.Color.White;
            this.nudAlpha.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nudAlpha.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.nudAlpha.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.nudAlpha.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.nudAlpha.Border.HoverVisible = true;
            this.nudAlpha.Border.Rounding = 6;
            this.nudAlpha.Border.Thickness = 1;
            this.nudAlpha.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.nudAlpha.Border.Visible = true;
            this.nudAlpha.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.nudAlpha.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.nudAlpha.ButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.nudAlpha.ButtonOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.nudAlpha.ButtonWidth = 50;
            this.nudAlpha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudAlpha.Location = new System.Drawing.Point(193, 37);
            this.nudAlpha.MaximumValue = ((long)(255));
            this.nudAlpha.MinimumValue = ((long)(0));
            this.nudAlpha.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.nudAlpha.Name = "nudAlpha";
            this.nudAlpha.Separator = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.nudAlpha.Size = new System.Drawing.Size(121, 25);
            this.nudAlpha.TabIndex = 5;
            this.nudAlpha.Text = "visualNumericUpDown1";
            this.nudAlpha.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.nudAlpha.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudAlpha.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudAlpha.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudAlpha.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.nudAlpha.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.nudAlpha.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.nudAlpha.Value = ((long)(0));
            this.nudAlpha.ValueChanged += new VisualPlus.Delegates.ValueChangedEventHandler(this.NumericUpDownARGB_ValueChanged);
            // 
            // nudRed
            // 
            this.nudRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRed.BackColor = System.Drawing.Color.White;
            this.nudRed.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nudRed.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.nudRed.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.nudRed.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.nudRed.Border.HoverVisible = true;
            this.nudRed.Border.Rounding = 6;
            this.nudRed.Border.Thickness = 1;
            this.nudRed.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.nudRed.Border.Visible = true;
            this.nudRed.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.nudRed.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.nudRed.ButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.nudRed.ButtonOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.nudRed.ButtonWidth = 50;
            this.nudRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudRed.Location = new System.Drawing.Point(193, 68);
            this.nudRed.MaximumValue = ((long)(255));
            this.nudRed.MinimumValue = ((long)(0));
            this.nudRed.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.nudRed.Name = "nudRed";
            this.nudRed.Separator = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.nudRed.Size = new System.Drawing.Size(121, 25);
            this.nudRed.TabIndex = 6;
            this.nudRed.Text = "visualNumericUpDown2";
            this.nudRed.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.nudRed.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudRed.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudRed.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudRed.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.nudRed.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.nudRed.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.nudRed.Value = ((long)(0));
            this.nudRed.ValueChanged += new VisualPlus.Delegates.ValueChangedEventHandler(this.NumericUpDownARGB_ValueChanged);
            // 
            // nudGreen
            // 
            this.nudGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudGreen.BackColor = System.Drawing.Color.White;
            this.nudGreen.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nudGreen.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.nudGreen.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.nudGreen.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.nudGreen.Border.HoverVisible = true;
            this.nudGreen.Border.Rounding = 6;
            this.nudGreen.Border.Thickness = 1;
            this.nudGreen.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.nudGreen.Border.Visible = true;
            this.nudGreen.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.nudGreen.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.nudGreen.ButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.nudGreen.ButtonOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.nudGreen.ButtonWidth = 50;
            this.nudGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudGreen.Location = new System.Drawing.Point(193, 99);
            this.nudGreen.MaximumValue = ((long)(255));
            this.nudGreen.MinimumValue = ((long)(0));
            this.nudGreen.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.nudGreen.Name = "nudGreen";
            this.nudGreen.Separator = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.nudGreen.Size = new System.Drawing.Size(121, 25);
            this.nudGreen.TabIndex = 7;
            this.nudGreen.Text = "visualNumericUpDown3";
            this.nudGreen.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.nudGreen.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudGreen.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudGreen.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudGreen.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.nudGreen.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.nudGreen.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.nudGreen.Value = ((long)(0));
            this.nudGreen.ValueChanged += new VisualPlus.Delegates.ValueChangedEventHandler(this.NumericUpDownARGB_ValueChanged);
            // 
            // nudBlue
            // 
            this.nudBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBlue.BackColor = System.Drawing.Color.White;
            this.nudBlue.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nudBlue.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.nudBlue.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.nudBlue.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.nudBlue.Border.HoverVisible = true;
            this.nudBlue.Border.Rounding = 6;
            this.nudBlue.Border.Thickness = 1;
            this.nudBlue.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.nudBlue.Border.Visible = true;
            this.nudBlue.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.nudBlue.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.nudBlue.ButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.nudBlue.ButtonOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.nudBlue.ButtonWidth = 50;
            this.nudBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudBlue.Location = new System.Drawing.Point(193, 130);
            this.nudBlue.MaximumValue = ((long)(255));
            this.nudBlue.MinimumValue = ((long)(0));
            this.nudBlue.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.nudBlue.Name = "nudBlue";
            this.nudBlue.Separator = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.nudBlue.Size = new System.Drawing.Size(121, 25);
            this.nudBlue.TabIndex = 8;
            this.nudBlue.Text = "visualNumericUpDown4";
            this.nudBlue.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.nudBlue.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudBlue.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudBlue.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudBlue.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.nudBlue.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.nudBlue.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.nudBlue.Value = ((long)(0));
            this.nudBlue.ValueChanged += new VisualPlus.Delegates.ValueChangedEventHandler(this.NumericUpDownARGB_ValueChanged);
            // 
            // tbHtml
            // 
            this.tbHtml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHtml.BackColor = System.Drawing.Color.White;
            this.tbHtml.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tbHtml.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.tbHtml.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbHtml.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.tbHtml.Border.HoverVisible = true;
            this.tbHtml.Border.Rounding = 6;
            this.tbHtml.Border.Thickness = 1;
            this.tbHtml.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.tbHtml.Border.Visible = true;
            this.tbHtml.ButtonBorder.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbHtml.ButtonBorder.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.tbHtml.ButtonBorder.HoverVisible = true;
            this.tbHtml.ButtonBorder.Rounding = 6;
            this.tbHtml.ButtonBorder.Thickness = 1;
            this.tbHtml.ButtonBorder.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.tbHtml.ButtonBorder.Visible = true;
            this.tbHtml.ButtonColor.Disabled = System.Drawing.Color.Empty;
            this.tbHtml.ButtonColor.Enabled = System.Drawing.Color.Empty;
            this.tbHtml.ButtonColor.Hover = System.Drawing.Color.Empty;
            this.tbHtml.ButtonColor.Pressed = System.Drawing.Color.Empty;
            this.tbHtml.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHtml.ButtonIndent = 3;
            this.tbHtml.ButtonText = "visualButton";
            this.tbHtml.ButtonVisible = false;
            this.tbHtml.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbHtml.Image = null;
            this.tbHtml.ImageSize = new System.Drawing.Size(16, 16);
            this.tbHtml.ImageVisible = false;
            this.tbHtml.ImageWidth = 35;
            this.tbHtml.Location = new System.Drawing.Point(193, 161);
            this.tbHtml.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.tbHtml.Name = "tbHtml";
            this.tbHtml.PasswordChar = '\0';
            this.tbHtml.ReadOnly = true;
            this.tbHtml.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbHtml.Size = new System.Drawing.Size(121, 23);
            this.tbHtml.TabIndex = 9;
            this.tbHtml.TextBoxWidth = 111;
            this.tbHtml.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.tbHtml.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbHtml.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbHtml.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbHtml.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.tbHtml.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.tbHtml.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.tbHtml.Watermark.Active = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tbHtml.Watermark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHtml.Watermark.Inactive = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tbHtml.Watermark.Text = "Watermark text";
            this.tbHtml.Watermark.Visible = false;
            this.tbHtml.WordWrap = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOk.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnOk.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOk.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnOk.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnOk.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.btnOk.Border.HoverVisible = true;
            this.btnOk.Border.Rounding = 6;
            this.btnOk.Border.Thickness = 1;
            this.btnOk.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.btnOk.Border.Visible = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOk.Image = null;
            this.btnOk.Location = new System.Drawing.Point(239, 190);
            this.btnOk.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 24);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnOk.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.btnOk.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOk.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOk.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOk.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnOk.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.btnOk.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnOk.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // tilePreview
            // 
            this.tilePreview.BackColor = System.Drawing.Color.White;
            this.tilePreview.BackColorState.Disabled = System.Drawing.Color.White;
            this.tilePreview.BackColorState.Enabled = System.Drawing.Color.White;
            this.tilePreview.BackColorState.Hover = System.Drawing.Color.White;
            this.tilePreview.BackColorState.Pressed = System.Drawing.Color.White;
            this.tilePreview.BackgroundImageLayout = VisualPlus.Enumerators.BackgroundLayout.Stretch;
            this.tilePreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tilePreview.Image = ((System.Drawing.Image)(resources.GetObject("tilePreview.Image")));
            this.tilePreview.Location = new System.Drawing.Point(10, 190);
            this.tilePreview.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.tilePreview.Name = "tilePreview";
            this.tilePreview.Offset = new System.Drawing.Point(0, 0);
            this.tilePreview.Size = new System.Drawing.Size(24, 24);
            this.tilePreview.TabIndex = 11;
            this.tilePreview.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.tilePreview.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tilePreview.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tilePreview.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tilePreview.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.tilePreview.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.tilePreview.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.tilePreview.Type = VisualPlus.Toolkit.Controls.Layout.VisualTile.TileType.Text;
            // 
            // visualLabel1
            // 
            this.visualLabel1.BackColor = System.Drawing.Color.Transparent;
            this.visualLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.Location = new System.Drawing.Point(146, 161);
            this.visualLabel1.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualLabel1.Name = "visualLabel1";
            this.visualLabel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.visualLabel1.Outline = false;
            this.visualLabel1.OutlineColor = System.Drawing.Color.Red;
            this.visualLabel1.OutlineLocation = new System.Drawing.Point(0, 0);
            this.visualLabel1.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.ReflectionSpacing = 0;
            this.visualLabel1.ShadowColor = System.Drawing.Color.Black;
            this.visualLabel1.ShadowDirection = 315;
            this.visualLabel1.ShadowLocation = new System.Drawing.Point(0, 0);
            this.visualLabel1.ShadowOpacity = 100;
            this.visualLabel1.Size = new System.Drawing.Size(41, 23);
            this.visualLabel1.TabIndex = 12;
            this.visualLabel1.Text = "HEX:";
            this.visualLabel1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.visualLabel1.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel1.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualLabel1.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel1.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel1.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // colorPicker
            // 
            this.colorPicker.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.colorPicker.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.colorPicker.Border.HoverVisible = false;
            this.colorPicker.Border.Rounding = 6;
            this.colorPicker.Border.Thickness = 1;
            this.colorPicker.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.colorPicker.Border.Visible = true;
            this.colorPicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPicker.Location = new System.Drawing.Point(10, 48);
            this.colorPicker.MinimumSize = new System.Drawing.Size(130, 130);
            this.colorPicker.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Picker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.colorPicker.Picker.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.colorPicker.Picker.HoverVisible = false;
            this.colorPicker.Picker.Rounding = 6;
            this.colorPicker.Picker.Thickness = 1;
            this.colorPicker.Picker.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.colorPicker.Picker.Visible = true;
            this.colorPicker.PickerStyle = VisualPlus.Toolkit.Controls.Editors.VisualColorPicker.PickerType.Wheel;
            this.colorPicker.PickerVisible = true;
            this.colorPicker.Size = new System.Drawing.Size(130, 130);
            this.colorPicker.TabIndex = 13;
            this.colorPicker.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.colorPicker.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPicker.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPicker.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPicker.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.colorPicker.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.colorPicker.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.colorPicker.ColorChanged += new System.EventHandler(this.ColorPicker_ColorChanged);
            // 
            // VisualColorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.Border.HoverVisible = true;
            this.Border.Rounding = 6;
            this.Border.Thickness = 3;
            this.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rectangle;
            this.Border.Visible = true;
            this.ClientSize = new System.Drawing.Size(322, 221);
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
            this.ControlBox.HelpButton.BoxType = VisualPlus.Toolkit.VisualBase.ControlBoxButton.ControlBoxType.Default;
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
            this.ControlBox.HelpButton.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ControlBox.HelpButton.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.HelpButton.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.HelpButton.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.HelpButton.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.HelpButton.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.HelpButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.HelpButton.Visible = false;
            this.ControlBox.Location = new System.Drawing.Point(293, 4);
            // 
            // 
            // 
            this.ControlBox.MaximizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.MaximizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MaximizeButton.BoxType = VisualPlus.Toolkit.VisualBase.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.MaximizeButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MaximizeButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.ControlBox.MaximizeButton.Location = new System.Drawing.Point(0, 0);
            this.ControlBox.MaximizeButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.MaximizeButton.Name = "";
            this.ControlBox.MaximizeButton.OffsetLocation = new System.Drawing.Point(1, 1);
            this.ControlBox.MaximizeButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.MaximizeButton.TabIndex = 2;
            this.ControlBox.MaximizeButton.Text = "1";
            this.ControlBox.MaximizeButton.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ControlBox.MaximizeButton.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MaximizeButton.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MaximizeButton.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MaximizeButton.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.MaximizeButton.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.MaximizeButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.MaximizeButton.Visible = false;
            // 
            // 
            // 
            this.ControlBox.MinimizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.MinimizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.MinimizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.MinimizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MinimizeButton.BoxType = VisualPlus.Toolkit.VisualBase.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.MinimizeButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MinimizeButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.ControlBox.MinimizeButton.Location = new System.Drawing.Point(0, 0);
            this.ControlBox.MinimizeButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.MinimizeButton.Name = "";
            this.ControlBox.MinimizeButton.OffsetLocation = new System.Drawing.Point(2, 0);
            this.ControlBox.MinimizeButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.MinimizeButton.TabIndex = 1;
            this.ControlBox.MinimizeButton.Text = "0";
            this.ControlBox.MinimizeButton.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ControlBox.MinimizeButton.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MinimizeButton.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MinimizeButton.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MinimizeButton.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.MinimizeButton.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.MinimizeButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.MinimizeButton.Visible = false;
            this.ControlBox.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.Name = "";
            this.ControlBox.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.TabIndex = 0;
            this.ControlBox.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ControlBox.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.Controls.Add(this.colorPicker);
            this.Controls.Add(this.visualLabel1);
            this.Controls.Add(this.tilePreview);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbHtml);
            this.Controls.Add(this.nudBlue);
            this.Controls.Add(this.nudGreen);
            this.Controls.Add(this.nudRed);
            this.Controls.Add(this.nudAlpha);
            this.Controls.Add(this.lAlpha);
            this.Controls.Add(this.lB);
            this.Controls.Add(this.lG);
            this.Controls.Add(this.lR);
            this.Image.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Image.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.Image.Border.HoverVisible = false;
            this.Image.Border.Rounding = 6;
            this.Image.Border.Thickness = 1;
            this.Image.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.Image.Border.Visible = false;
            this.Image.Image = ((System.Drawing.Bitmap)(resources.GetObject("resource.Image3")));
            this.Image.Point = new System.Drawing.Point(5, 7);
            this.Image.Size = new System.Drawing.Size(16, 16);
            this.Image.Visible = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "VisualColorDialog";
            this.Text = "Color Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Interactivity.VisualLabel lR;
        private Controls.Interactivity.VisualLabel lG;
        private Controls.Interactivity.VisualLabel lB;
        private Controls.Interactivity.VisualLabel lAlpha;
        private Controls.Interactivity.VisualNumericUpDown nudAlpha;
        private Controls.Interactivity.VisualNumericUpDown nudRed;
        private Controls.Interactivity.VisualNumericUpDown nudGreen;
        private Controls.Interactivity.VisualNumericUpDown nudBlue;
        private Controls.Editors.VisualTextBox tbHtml;
        private Controls.Interactivity.VisualButton btnOk;
        private Controls.Layout.VisualTile tilePreview;
        private Controls.Interactivity.VisualLabel visualLabel1;
        private Controls.Editors.VisualColorPicker colorPicker;
    }
}