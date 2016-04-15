
using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;


namespace HomepageGalleryGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.ImagesButtonEnabled(false);

            this.scaleComboBox.Items.AddRange(new object[] { "1:144", "1:72", "1:48", "1:32", "1:35", "1:25", "1:24"} );
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            //validateForm

            string modelName = this.modelNameTextBox.Text;
            string scale = this.scaleComboBox.SelectedItem.ToString();
            string producer = this.producerTextBox.Text;
            string description = this.descriptionRichTextBox.Text;
            string imagesPath = this.imagesPathTextBox.Text.Replace("\\", "/");
            string alt = this.altTextBox.Text;
            string outputFile;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".html";
            dialog.Filter = "HTML file (.html)|*.html";
            dialog.ShowDialog(this);
            outputFile = dialog.FileName;

            IContentGenerator contentGenerator = new HTMLContentGenerator();
            List<string> filesList = new List<string>();
            foreach(ListViewItem item in this.imagesListView.Items)
                filesList.Add(item.Text);
            string content = contentGenerator.GenerateContent(modelName, scale, producer, description, imagesPath, filesList.ToArray(), alt);

            StreamWriter file = new StreamWriter(outputFile, false);
            file.Write(content);
            file.Close();

            MessageBox.Show("Plik wygenerowany pomyślnie!", "Zapis pliku", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImagesBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.AddExtension = false;
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.Filter = "Pliki JPG (*.jpg)|*.jpg";
            dialog.ShowDialog(this);
            this.imagesTextBox.Text = Path.GetDirectoryName(dialog.FileNames[0]);
            string[] files = dialog.SafeFileNames;
            this.imagesListView.Items.Clear();
            foreach(string file in files)
            {
                if(file.Contains("_small"))
                    continue;
                this.imagesListView.Items.Add(file);
            }
        }

        private void ImagesButtonEnabled(bool enabled)
        {
            this.deleteButton.Enabled = enabled;
            this.moveDownButton.Enabled = enabled;
            this.moveUpButton.Enabled = enabled;
        }

        private void ImagesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(this.imagesListView.SelectedItems.Count < 1)
            {
                this.ImagesButtonEnabled(false);
                return;
            }

            this.ImagesButtonEnabled(true);
            int index = this.imagesListView.SelectedItems[0].Index;
            if(index == 0)
                this.moveUpButton.Enabled = false;
            if(index == this.imagesListView.Items.Count - 1)
                this.moveDownButton.Enabled = false;

            string image = this.imagesTextBox.Text + "/" + this.imagesListView.SelectedItems[0].Text;
            this.previewPictureBox.Image = Image.FromFile(image);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.imagesListView.Items.Remove(this.imagesListView.SelectedItems[0]);
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            int index = this.imagesListView.SelectedItems[0].Index;
            string text = this.imagesListView.Items[index].Text;
            this.imagesListView.Items.RemoveAt(index);
            this.imagesListView.Items.Insert(index - 1, text);
            this.imagesListView.Items[index - 1].Focused = true;
            this.imagesListView.Items[index - 1].Selected = true;
            this.imagesListView.Select();
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            int index = this.imagesListView.SelectedItems[0].Index;
            string text = this.imagesListView.Items[index].Text;
            this.imagesListView.Items.RemoveAt(index);
            this.imagesListView.Items.Insert(index + 1, text);
            this.imagesListView.Items[index + 1].Focused = true;
            this.imagesListView.Items[index + 1].Selected = true;
            this.imagesListView.Select();
        }

        private void imagesTextBox_TextChanged(object sender, EventArgs e)
        {
            var imgIndex = this.imagesTextBox.Text.IndexOf("img");
            if(imgIndex > 0)
                this.imagesPathTextBox.Text = this.imagesTextBox.Text.Substring(imgIndex);
        }

        private void scaleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.generateButton.Enabled = this.scaleComboBox.SelectedItem != null;
        }
    }
}
