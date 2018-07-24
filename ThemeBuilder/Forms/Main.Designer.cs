using VisualPlus.Toolkit.VisualBase;

namespace ThemeBuilder.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.rawText = new VisualPlus.Toolkit.Controls.Editors.VisualRichTextBox();
            this.tbName = new VisualPlus.Toolkit.Controls.Editors.VisualTextBox();
            this.tbAuthor = new VisualPlus.Toolkit.Controls.Editors.VisualTextBox();
            this.visualLabel1 = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.visualLabel2 = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTemplatesDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.palettePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tbPath = new VisualPlus.Toolkit.Controls.Editors.VisualTextBox();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rawText
            // 
            this.rawText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawText.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.rawText.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.rawText.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.rawText.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.rawText.Border.HoverVisible = true;
            this.rawText.Border.Rounding = 6;
            this.rawText.Border.Thickness = 1;
            this.rawText.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.rawText.Border.Visible = true;
            this.rawText.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rawText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rawText.Location = new System.Drawing.Point(14, 120);
            this.rawText.MaxLength = 2147483647;
            this.rawText.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.rawText.Name = "rawText";
            this.rawText.ReadOnly = true;
            this.rawText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rawText.ShowSelectionMargin = false;
            this.rawText.Size = new System.Drawing.Size(438, 370);
            this.rawText.TabIndex = 2;
            this.rawText.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.rawText.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rawText.TextStyle.Hover = System.Drawing.Color.Empty;
            this.rawText.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // tbName
            // 
            this.tbName.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tbName.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.tbName.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbName.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.tbName.Border.HoverVisible = true;
            this.tbName.Border.Rounding = 6;
            this.tbName.Border.Thickness = 1;
            this.tbName.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.tbName.Border.Visible = true;
            this.tbName.ButtonBorder.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbName.ButtonBorder.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.tbName.ButtonBorder.HoverVisible = true;
            this.tbName.ButtonBorder.Rounding = 6;
            this.tbName.ButtonBorder.Thickness = 1;
            this.tbName.ButtonBorder.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.tbName.ButtonBorder.Visible = true;
            this.tbName.ButtonColor.Disabled = System.Drawing.Color.Empty;
            this.tbName.ButtonColor.Enabled = System.Drawing.Color.Empty;
            this.tbName.ButtonColor.Hover = System.Drawing.Color.Empty;
            this.tbName.ButtonColor.Pressed = System.Drawing.Color.Empty;
            this.tbName.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.ButtonIndent = 3;
            this.tbName.ButtonText = "visualButton";
            this.tbName.ButtonVisible = false;
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbName.ImageSize = new System.Drawing.Size(16, 16);
            this.tbName.ImageVisible = false;
            this.tbName.ImageWidth = 35;
            this.tbName.Location = new System.Drawing.Point(61, 60);
            this.tbName.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.tbName.Name = "tbName";
            this.tbName.PasswordChar = '\0';
            this.tbName.ReadOnly = false;
            this.tbName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbName.Size = new System.Drawing.Size(169, 25);
            this.tbName.TabIndex = 3;
            this.tbName.TextBoxWidth = 159;
            this.tbName.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.tbName.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbName.TextStyle.Hover = System.Drawing.Color.Empty;
            this.tbName.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.tbName.Watermark.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tbName.Watermark.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tbName.Watermark.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tbName.Watermark.Text = "The theme name...";
            this.tbName.Watermark.Visible = true;
            this.tbName.TextChanged += new System.EventHandler(this.TbThemeInformation_TextChanged);
            // 
            // tbAuthor
            // 
            this.tbAuthor.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tbAuthor.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.tbAuthor.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbAuthor.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.tbAuthor.Border.HoverVisible = true;
            this.tbAuthor.Border.Rounding = 6;
            this.tbAuthor.Border.Thickness = 1;
            this.tbAuthor.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.tbAuthor.Border.Visible = true;
            this.tbAuthor.ButtonBorder.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbAuthor.ButtonBorder.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.tbAuthor.ButtonBorder.HoverVisible = true;
            this.tbAuthor.ButtonBorder.Rounding = 6;
            this.tbAuthor.ButtonBorder.Thickness = 1;
            this.tbAuthor.ButtonBorder.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.tbAuthor.ButtonBorder.Visible = true;
            this.tbAuthor.ButtonColor.Disabled = System.Drawing.Color.Empty;
            this.tbAuthor.ButtonColor.Enabled = System.Drawing.Color.Empty;
            this.tbAuthor.ButtonColor.Hover = System.Drawing.Color.Empty;
            this.tbAuthor.ButtonColor.Pressed = System.Drawing.Color.Empty;
            this.tbAuthor.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAuthor.ButtonIndent = 3;
            this.tbAuthor.ButtonText = "visualButton";
            this.tbAuthor.ButtonVisible = false;
            this.tbAuthor.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tbAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbAuthor.ImageSize = new System.Drawing.Size(16, 16);
            this.tbAuthor.ImageVisible = false;
            this.tbAuthor.ImageWidth = 35;
            this.tbAuthor.Location = new System.Drawing.Point(288, 60);
            this.tbAuthor.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.PasswordChar = '\0';
            this.tbAuthor.ReadOnly = false;
            this.tbAuthor.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbAuthor.Size = new System.Drawing.Size(164, 25);
            this.tbAuthor.TabIndex = 4;
            this.tbAuthor.TextBoxWidth = 154;
            this.tbAuthor.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.tbAuthor.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbAuthor.TextStyle.Hover = System.Drawing.Color.Empty;
            this.tbAuthor.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.tbAuthor.Watermark.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tbAuthor.Watermark.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tbAuthor.Watermark.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tbAuthor.Watermark.Text = "The authors name...";
            this.tbAuthor.Watermark.Visible = true;
            this.tbAuthor.TextChanged += new System.EventHandler(this.TbThemeInformation_TextChanged);
            // 
            // visualLabel1
            // 
            this.visualLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.visualLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.Location = new System.Drawing.Point(14, 60);
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
            this.visualLabel1.TabIndex = 5;
            this.visualLabel1.Text = "Name:";
            this.visualLabel1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.visualLabel1.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel1.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualLabel1.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.TextStyle.Hover = System.Drawing.Color.Empty;
            this.visualLabel1.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // visualLabel2
            // 
            this.visualLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.visualLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel2.Location = new System.Drawing.Point(236, 60);
            this.visualLabel2.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualLabel2.Name = "visualLabel2";
            this.visualLabel2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.visualLabel2.Outline = false;
            this.visualLabel2.OutlineColor = System.Drawing.Color.Red;
            this.visualLabel2.OutlineLocation = new System.Drawing.Point(0, 0);
            this.visualLabel2.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel2.ReflectionSpacing = 0;
            this.visualLabel2.ShadowColor = System.Drawing.Color.Black;
            this.visualLabel2.ShadowDirection = 315;
            this.visualLabel2.ShadowLocation = new System.Drawing.Point(0, 0);
            this.visualLabel2.ShadowOpacity = 100;
            this.visualLabel2.Size = new System.Drawing.Size(46, 23);
            this.visualLabel2.TabIndex = 6;
            this.visualLabel2.Text = "Author:";
            this.visualLabel2.TextAlignment = System.Drawing.StringAlignment.Near;
            this.visualLabel2.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel2.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualLabel2.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel2.TextStyle.Hover = System.Drawing.Color.Empty;
            this.visualLabel2.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainMenuStrip.AutoSize = false;
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(4, 30);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.mainMenuStrip.Size = new System.Drawing.Size(720, 23);
            this.mainMenuStrip.TabIndex = 8;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.openDirectoryToolStripMenuItem,
            this.openTemplatesDirectoryToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 17);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(208, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // openDirectoryToolStripMenuItem
            // 
            this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            this.openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.openDirectoryToolStripMenuItem.Text = "Open Directory";
            this.openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.OpenDirectoryToolStripMenuItem_Click);
            // 
            // openTemplatesDirectoryToolStripMenuItem
            // 
            this.openTemplatesDirectoryToolStripMenuItem.Name = "openTemplatesDirectoryToolStripMenuItem";
            this.openTemplatesDirectoryToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.openTemplatesDirectoryToolStripMenuItem.Text = "Open Templates Directory";
            this.openTemplatesDirectoryToolStripMenuItem.Click += new System.EventHandler(this.OpenTemplatesDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(208, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // palettePropertyGrid
            // 
            this.palettePropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.palettePropertyGrid.Location = new System.Drawing.Point(465, 60);
            this.palettePropertyGrid.Name = "palettePropertyGrid";
            this.palettePropertyGrid.Size = new System.Drawing.Size(252, 430);
            this.palettePropertyGrid.TabIndex = 9;
            this.palettePropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PalettePropertyGrid_PropertyValueChanged);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tbPath.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.tbPath.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbPath.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.tbPath.Border.HoverVisible = true;
            this.tbPath.Border.Rounding = 6;
            this.tbPath.Border.Thickness = 1;
            this.tbPath.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.tbPath.Border.Visible = true;
            this.tbPath.ButtonBorder.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbPath.ButtonBorder.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.tbPath.ButtonBorder.HoverVisible = true;
            this.tbPath.ButtonBorder.Rounding = 6;
            this.tbPath.ButtonBorder.Thickness = 1;
            this.tbPath.ButtonBorder.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.tbPath.ButtonBorder.Visible = true;
            this.tbPath.ButtonColor.Disabled = System.Drawing.Color.Empty;
            this.tbPath.ButtonColor.Enabled = System.Drawing.Color.Empty;
            this.tbPath.ButtonColor.Hover = System.Drawing.Color.Empty;
            this.tbPath.ButtonColor.Pressed = System.Drawing.Color.Empty;
            this.tbPath.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPath.ButtonIndent = 3;
            this.tbPath.ButtonText = "visualButton";
            this.tbPath.ButtonVisible = false;
            this.tbPath.ForeColor = System.Drawing.Color.Silver;
            this.tbPath.ImageSize = new System.Drawing.Size(16, 16);
            this.tbPath.ImageVisible = false;
            this.tbPath.ImageWidth = 35;
            this.tbPath.Location = new System.Drawing.Point(14, 91);
            this.tbPath.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.tbPath.Name = "tbPath";
            this.tbPath.PasswordChar = '\0';
            this.tbPath.ReadOnly = true;
            this.tbPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbPath.Size = new System.Drawing.Size(438, 23);
            this.tbPath.TabIndex = 10;
            this.tbPath.TextBoxWidth = 428;
            this.tbPath.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.tbPath.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbPath.TextStyle.Hover = System.Drawing.Color.Empty;
            this.tbPath.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.tbPath.Watermark.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tbPath.Watermark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPath.Watermark.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tbPath.Watermark.Text = "Path to theme...";
            this.tbPath.Watermark.Visible = true;
            // 
            // Main
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
            this.ClientSize = new System.Drawing.Size(730, 500);
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
            this.ControlBox.HelpButton.BoxType = ControlBoxButton.ControlBoxType.Default;
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
            this.ControlBox.Location = new System.Drawing.Point(630, 4);
            // 
            // 
            // 
            this.ControlBox.MaximizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.MaximizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MaximizeButton.BoxType = ControlBoxButton.ControlBoxType.Default;
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
            this.ControlBox.MinimizeButton.BoxType = ControlBoxButton.ControlBoxType.Default;
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
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.palettePropertyGrid);
            this.Controls.Add(this.visualLabel2);
            this.Controls.Add(this.visualLabel1);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.rawText);
            this.Controls.Add(this.mainMenuStrip);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.MinimumSize = new System.Drawing.Size(730, 500);
            this.Name = "Main";
            this.Text = "Theme Builder";
            this.HelpButtonClicked += new VisualPlus.Delegates.ControlBoxEventHandler(this.Main_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Main_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private VisualPlus.Toolkit.Controls.Editors.VisualRichTextBox rawText;
        private VisualPlus.Toolkit.Controls.Editors.VisualTextBox tbName;
        private VisualPlus.Toolkit.Controls.Editors.VisualTextBox tbAuthor;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel visualLabel1;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel visualLabel2;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid palettePropertyGrid;
        private VisualPlus.Toolkit.Controls.Editors.VisualTextBox tbPath;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openTemplatesDirectoryToolStripMenuItem;
    }
}

