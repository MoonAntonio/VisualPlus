#region Namespace

using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using VisualPlus;
using VisualPlus.Constants;
using VisualPlus.Enumerators;
using VisualPlus.Events;
using VisualPlus.Managers;
using VisualPlus.Structure;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace VisualThemeBuilder.Forms
{
    /// <summary>The main.</summary>
    public partial class Main : VisualForm
    {
        #region Variables

        private readonly Theme _theme;
        private bool _saved;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="Main" /> class.</summary>
        public Main()
        {
            InitializeComponent();

            _theme = new Theme(Settings.DefaultValue.DefaultStyle);
            LoadTheme(_theme);

            tbName.Text = "UnnamedTheme";
            tbAuthor.Text = "Unknown";

            _saved = true;

            UpdateSelection();
        }

        #endregion

        #region Properties

        /// <summary>Retrieves the selected property color.</summary>
        [Browsable(false)]
        public Color SelectedColor
        {
            get
            {
                Color selectedItemColor = (Color)palettePropertyGrid.SelectedGridItem.Value;
                return selectedItemColor;
            }
        }

        #endregion

        #region Methods

        /// <summary>Occurs when the exit button has been clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>Loads the theme settings.</summary>
        /// <param name="theme">The theme to update with.</param>
        private void LoadTheme(Theme theme)
        {
            if (theme == null)
            {
                throw new NoNullAllowedException(nameof(theme));
            }

            _theme.UpdateTheme(theme.Information, theme.ColorPalette);
            rawText.Text = _theme.RawTheme;

            palettePropertyGrid.SelectedObject = _theme.ColorPalette;
        }

        /// <summary>Occurs when the help button has been clicked.</summary>
        /// <param name="e">The event args.</param>
        private void Main_HelpButtonClicked(ControlBoxEventArgs e)
        {
            DialogResult dialogResult = VisualMessageBox.Show("Would you like to visit the website?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("https://darkbyte7.github.io/VisualPlus/");
            }
        }

        /// <summary>Occurs when the form loads.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void Main_Load(object sender, EventArgs e)
        {
        }

        /// <summary>Create new theme.</summary>
        private void NewTheme()
        {
            tbPath.Text = string.Empty;

            Theme theme = new Theme(Themes.Visual)
                {
                    Information =
                        {
                            Author = "Unknown",
                            Name = "UnnamedTheme"
                        }
                };

            LoadTheme(theme);
            _saved = false;
        }

        /// <summary>Occurs when the new button has been clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_saved)
            {
                DialogResult result = MessageBox.Show(@"Would you like to save the unsaved changed?", Application.ProductName, MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem.PerformClick();
                }
                else if (result == DialogResult.No)
                {
                    NewTheme();
                    return;
                }
                else
                {
                    // Cancel
                }
            }

            NewTheme();
        }

        /// <summary>Occurs when the open directory button has been clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void OpenDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbPath.TextLength > 0)
            {
                if (File.Exists(tbPath.Text))
                {
                    string directory = Path.GetDirectoryName(tbPath.Text);
                    Process.Start(directory);
                }
            }
        }

        /// <summary>Occurs when the open templates button has been clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void OpenTemplatesDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = SettingConstants.TemplatesFolder;

            if (path.Length <= 0)
            {
                return;
            }

            if (Directory.Exists(path))
            {
                Process.Start(path);
            }
        }

        /// <summary>Occurs when the open button has been clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"Theme File|*.xml";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Theme theme = new Theme(openFileDialog.FileName);

                    if (theme.Information.IsNull)
                    {
                        // Unable to read theme information maybe corrupted.
                        MessageBox.Show($@"Unable to load the theme file.{Environment.NewLine}Detected invalid header.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        tbPath.Text = openFileDialog.FileName;
                    }

                    LoadTheme(theme);
                }
            }
        }

        /// <summary>Occurs when the palette property value changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void PalettePropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            Color changedItemValue = (Color)e.ChangedItem.Value;

            if (changedItemValue == Color.Empty)
            {
                return;
            }

            UpdateThemeContents();
            UpdateSelection();
        }

        /// <summary>Occurs when the palette selected item changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void PalettePropertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            UpdateSelection();
        }

        /// <summary>Saves the theme to file.</summary>
        private void Save()
        {
            using (StreamWriter _streamWriter = new StreamWriter(tbPath.Text, false))
            {
                _streamWriter.WriteLine(rawText.Text);
                _saved = false;
            }
        }

        /// <summary>Occurs when the save as button has been clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = @"Theme File|*.xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbPath.Text = saveFileDialog.FileName;
                    Save();
                }
            }
        }

        /// <summary>Occurs when the save button has been clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_saved)
            {
                return;
            }

            if (string.IsNullOrEmpty(tbPath.Text))
            {
                saveAsToolStripMenuItem.PerformClick();
            }
            else
            {
                Save();
            }
        }

        /// <summary>Occurs when the theme information text was changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void TbThemeInformation_TextChanged(object sender, EventArgs e)
        {
            UpdateThemeContents();
        }

        /// <summary>Update the color information based on the selection in the properties dialog.</summary>
        private void UpdateSelection()
        {
            if (palettePropertyGrid.SelectedGridItem != null)
            {
                object selectedGridItem = palettePropertyGrid.SelectedGridItem.Value;

                if (selectedGridItem is Color)
                {
                    tbSelectedColor.Image = ImageManager.CreateBitmap(SelectedColor, tbSelectedColor.ImageSize);
                    tbSelectedColor.ForeColor = ((ColorPalette)palettePropertyGrid.SelectedObject).TextEnabled;
                    tbSelectedColor.Text = palettePropertyGrid.SelectedGridItem.Label;
                }
            }
        }

        /// <summary>Update the theme contents.</summary>
        private void UpdateThemeContents()
        {
            ThemeInformation themeInformation = new ThemeInformation
                {
                    Author = tbAuthor.Text,
                    Name = tbName.Text
                };

            rawText.Text = new Theme(themeInformation, _theme.ColorPalette).RawTheme;
            _saved = false;
        }

        #endregion
    }
}