using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;


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

            ImagesListView_ItemSelectionChanged(null, null);
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
                this.previewPictureBox.Image = null;
                return;
            }

            this.ImagesButtonEnabled(true);
            int index = this.imagesListView.SelectedItems[0].Index;
            if(index == 0)
                this.moveUpButton.Enabled = false;
            if(index == this.imagesListView.Items.Count - 1)
                this.moveDownButton.Enabled = false;

            string image = Path.Combine(this.imagesTextBox.Text, this.imagesListView.SelectedItems[0].Text);
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.saveButton.Enabled = false;

            var pageContent = new PageContent();
            
            pageContent.Model = modelNameTextBox.Text;
            pageContent.Scale = scaleComboBox.SelectedIndex;
            pageContent.Producer = producerTextBox.Text;
            pageContent.Description = descriptionRichTextBox.Text;
            pageContent.ImagesDirectory = imagesTextBox.Text;
            pageContent.AltDescription = altTextBox.Text;
            pageContent.WebsiteImageDir = imagesPathTextBox.Text;

            pageContent.ImagesList = new string[this.imagesListView.Items.Count];
            int i = 0;
            foreach (ListViewItem item in this.imagesListView.Items)
            {
                pageContent.ImagesList[i] = item.Text;
                i++;
            }

            var dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".gxml";
            dialog.Filter = "Gallery file (.gxml)|*.gxml";
            var result = dialog.ShowDialog(this);

            if (result != DialogResult.Yes && result != DialogResult.OK)
            {
                this.saveButton.Enabled = true;
                return;
            }

            string outputFile = dialog.FileName;

            XmlSerializer ser = new XmlSerializer(typeof(PageContent));
            TextWriter writer = new StreamWriter(outputFile);
            ser.Serialize(writer, pageContent);

            this.saveButton.Enabled = true;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "Czy na pewno załadować nowy plik? Niezapisane zmiany zostaną utracone.", "Nowy plik",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
                return;

            this.openButton.Enabled = false;

            var dialog = new OpenFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".gxml";
            dialog.Filter = "Gallery file (.gxml)|*.gxml";
            var result = dialog.ShowDialog(this);

            if (result != DialogResult.OK && result != DialogResult.Yes)
            {
                this.openButton.Enabled = true;
                return;
            }

            string inputFile = dialog.FileName;

            XmlSerializer ser = new XmlSerializer(typeof(PageContent));
            var fs = new FileStream(inputFile, FileMode.Open);
            PageContent pageContent = ser.Deserialize(fs) as PageContent;

            modelNameTextBox.Text = pageContent.Model;
            scaleComboBox.SelectedIndex = pageContent.Scale;
            producerTextBox.Text = pageContent.Producer;
            descriptionRichTextBox.Text = pageContent.Description;
            imagesTextBox.Text = pageContent.ImagesDirectory;
            altTextBox.Text = pageContent.AltDescription;
            imagesPathTextBox.Text = pageContent.WebsiteImageDir;

            foreach (string file in pageContent.ImagesList)
                this.imagesListView.Items.Add(file);

            if (this.loadMissingFilesCheckBox.Checked)
            {
                var di = new DirectoryInfo(pageContent.ImagesDirectory);
                var missingImages = di
                    .GetFiles("*.jpg", SearchOption.TopDirectoryOnly)
                    .Select(fi => fi.Name)
                    .Where(n => !pageContent.ImagesList.Contains(n));

                foreach (string image in missingImages)
                    this.imagesListView.Items.Add(image);
            }

            this.openButton.Enabled = true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Czy na pewno wyczyścić formularz? Niezapisane zmiany zostaną utracone.", "Nowy plik",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
                this.ClearForm();
        }

        private void ClearForm()
        {
            this.modelNameTextBox.Text = null;
            this.scaleComboBox.SelectedIndex = -1;
            this.producerTextBox.Text = null;
            this.descriptionRichTextBox.Text = null;
            this.imagesTextBox.Text = null;
            this.imagesListView.Items.Clear();
            this.altTextBox.Text = null;
            this.imagesPathTextBox.Text = null;
            this.previewPictureBox.Image = null;
        }
    }
}
