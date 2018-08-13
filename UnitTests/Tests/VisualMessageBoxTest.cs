#region Namespace

using System;
using System.Drawing;
using System.Windows.Forms;

using VisualPlus.Events;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace UnitTests.Tests
{
    /// <summary>The message box creator test.</summary>
    public partial class VisualMessageBoxTest : VisualForm
    {
        #region Constructors

        public VisualMessageBoxTest()
        {
            InitializeComponent();

            cbButtons.DataSource = Enum.GetValues(typeof(MessageBoxButtons));
            cbType.DataSource = Enum.GetValues(typeof(MessageBoxType));

            cbIcons.Items.Add("None");
            cbIcons.Items.Add("Error");
            cbIcons.Items.Add("Information");
            cbIcons.Items.Add("Question");
            cbIcons.Items.Add("Warning");
            cbIcons.SelectedIndex = 0;

            tbTitle.Text = Application.ProductName;
            tbMessage.Text = "Hello world.";
        }

        #endregion

        #region Enumerators

        private enum MessageBoxType
        {
            /// <summary>The default.</summary>
            Default,

            /// <summary>The windows.</summary>
            Windows
        }

        #endregion

        #region Methods

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            string paragraphs =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus ex metus, blandit at justo porta, semper ullamcorper ante. Fusce ultricies lorem aliquam ipsum bibendum rutrum. Quisque sed tincidunt ligula. Etiam mollis turpis ut urna blandit, eget tempor nibh tempus. Vestibulum eget dolor efficitur, suscipit nulla sit amet, fermentum dolor. Donec metus turpis, dictum sed mollis ac, congue in mauris. Sed a tristique purus, ac venenatis purus. Fusce leo felis, luctus eget augue sit amet, hendrerit condimentum nibh. Morbi in diam posuere, volutpat erat luctus, iaculis ipsum. Nullam ut consequat lacus, bibendum tristique quam." +
                Environment.NewLine + Environment.NewLine +
                "Praesent vestibulum erat justo, eget posuere orci congue quis.Praesent dui nunc, lobortis id tortor sed, porta accumsan arcu.Cras malesuada dui a sagittis aliquet.Morbi eget lorem vel est congue blandit.Proin eu iaculis orci.Proin imperdiet consectetur commodo.Maecenas laoreet feugiat augue, eget consectetur enim dignissim in.Quisque mollis, sapien a cursus lobortis, sem ipsum dignissim nibh, a rhoncus eros ex a quam.Fusce posuere nisi id convallis pretium.Duis gravida rhoncus aliquam.Pellentesque lacinia venenatis lorem, ac accumsan arcu interdum tempor.Curabitur felis felis, luctus sed risus eget, congue eleifend lorem.Donec scelerisque venenatis sem, sed mattis ante rhoncus ac.Aenean consequat et felis quis ornare.Phasellus in tincidunt enim.Cras in dictum augue, nec blandit eros." +
                Environment.NewLine + Environment.NewLine +
                "Quisque vel vulputate urna.Nunc a turpis sit amet eros auctor maximus.Praesent quis ultrices diam.Pellentesque neque est, tristique id nulla vel, facilisis molestie lorem.Vivamus massa velit, eleifend sodales condimentum quis, lacinia tempus urna.Proin eget consequat sem.Etiam libero turpis, cursus vel nunc eget, dapibus placerat felis.Vivamus laoreet dolor purus, in iaculis nisl tincidunt eu.Vestibulum commodo urna libero, et sodales magna mollis eu.Nam at est eu ligula viverra mollis eget id arcu.Curabitur hendrerit quam diam, vel lacinia elit laoreet nec.Aenean ac ligula varius, sagittis augue sit amet, vulputate odio.Vivamus id molestie nulla.Ut tellus leo, congue sit amet tellus at, sodales tempor augue.Cras in feugiat magna, nec mollis est.Aliquam erat volutpat.";

            tbMessage.Text = paragraphs;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"Image Files|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png|All Files|*.*";
                openFileDialog.FileName = string.Empty;
                openFileDialog.Title = @"Open";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Image imageFile = System.Drawing.Image.FromFile(openFileDialog.FileName);
                pbImage.BackgroundImage = imageFile;
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messageBoxButtons = (MessageBoxButtons)cbButtons.SelectedValue;

            object boxIconObject = Enum.Parse(typeof(MessageBoxIcon), cbIcons.Text);
            MessageBoxIcon messageBoxIcons = (MessageBoxIcon)boxIconObject;

            MessageBoxType messageBoxType = (MessageBoxType)cbType.SelectedValue;

            DialogResult result;

            switch (messageBoxType)
            {
                case MessageBoxType.Default:
                    {
                        if (tImage.Toggled)
                        {
                            result = VisualMessageBox.Show(tbMessage.Text, tbTitle.Text, messageBoxButtons, pbImage.BackgroundImage);
                        }
                        else
                        {
                            result = VisualMessageBox.Show(tbMessage.Text, tbTitle.Text, messageBoxButtons, messageBoxIcons);
                        }

                        break;
                    }

                case MessageBoxType.Windows:
                    {
                        result = MessageBox.Show(tbMessage.Text, tbTitle.Text, messageBoxButtons, messageBoxIcons);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            lResult.Text = $@"Dialog Result: {result}";
        }

        private void TImage_ToggleChanged(ToggleEventArgs e)
        {
            if (e.State)
            {
                cbIcons.Enabled = false;
                btnLoad.Enabled = true;
            }
            else
            {
                cbIcons.Enabled = true;
                btnLoad.Enabled = false;
            }
        }

        #endregion
    }
}