using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;


namespace HomepageGalleryGenerator
{
    public partial class MainForm : Form
    {
        private bool unsavedChanges;

        private PageContent pageContent;

        public MainForm()
        {
            InitializeComponent();
            this.ImagesButtonEnabled(false);

            this.unsavedChanges = false;    
            this.scaleComboBox.Items.AddRange(new object[] { "1:144", "1:72", "1:48", "1:32", "1:35", "1:25", "1:24"} );

            this.pageContent = new PageContent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show(this, "Czy na pewno zamknąć aplikację? Niezapisane zmiany zostaną utracone.",
                    "Zamykanie programu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    e.Cancel = true;
            }

            base.OnClosing(e);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            string modelName = this.modelNameTextBox.Text;
            string scale = this.scaleComboBox.SelectedItem.ToString();
            string producer = this.producerTextBox.Text;
            string description = this.descriptionRichTextBox.Text;
            string imagesPath = this.imagesPathTextBox.Text.Replace("\\", "/");
            string alt = this.altTextBox.Text;

            SaveFileDialog dialog = new SaveFileDialog();

            if (!string.IsNullOrEmpty(pageContent.HtmlFile))
            {
                FileInfo fi = new FileInfo(pageContent.HtmlFile);
                dialog.FileName = fi.Name;
                dialog.InitialDirectory = fi.DirectoryName;
            }

            dialog.AddExtension = true;
            dialog.DefaultExt = ".html";
            dialog.Filter = "HTML file (.html)|*.html";
            dialog.ShowDialog(this);

            var outputFile = dialog.FileName;

            if (!string.IsNullOrEmpty(outputFile))
            {
                this.pageContent.HtmlFile = outputFile;

                IContentGenerator contentGenerator = new HTMLContentGenerator();
                List<string> filesList = new List<string>();
                foreach (ListViewItem item in this.imagesListView.Items)
                    filesList.Add(item.Text);
                string content = contentGenerator.GenerateContent(modelName, scale, producer, description, imagesPath, filesList.ToArray(), alt);

                using (StreamWriter file = new StreamWriter(outputFile, false))
                {
                    file.Write(content);
                }

                MessageBox.Show("Plik wygenerowany pomyślnie!", "Zapis pliku", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            foreach(string file in files.Where(f => !f.Contains("_small")))
                this.imagesListView.Items.Add(file);

            ImagesListView_ItemSelectionChanged(null, null);

            this.unsavedChanges = true;
        }

        private void ImagesButtonEnabled(bool enabled)
        {
            this.deleteButton.Enabled = enabled;
            this.moveDownButton.Enabled = enabled;
            this.moveUpButton.Enabled = enabled;
        }

        private void ImagesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(this.previewPictureBox.Image != null)
                this.previewPictureBox.Image.Dispose();

            if (this.imagesListView.SelectedItems.Count < 1)
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

            this.unsavedChanges = true;
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            this.MoveImage(true);
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            this.MoveImage(false);
        }

        private void MoveImage(bool moveUp)
        {
            int index = this.imagesListView.SelectedItems[0].Index;
            int order = moveUp ? -1 : 1;
            string text = this.imagesListView.Items[index].Text;
            this.imagesListView.Items.RemoveAt(index);
            this.imagesListView.Items.Insert(index + order, text);
            this.imagesListView.Items[index + order].Focused = true;
            this.imagesListView.Items[index + order].Selected = true;
            this.imagesListView.Select();

            this.unsavedChanges = true;
        }

        private void imagesTextBox_TextChanged(object sender, EventArgs e)
        {
            var imgIndex = this.imagesTextBox.Text.IndexOf("img");
            if(imgIndex > 0)
                this.imagesPathTextBox.Text = this.imagesTextBox.Text.Substring(imgIndex);
            this.unsavedChanges = true;
        }

        private void scaleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.generateButton.Enabled = this.scaleComboBox.SelectedItem != null;
            this.unsavedChanges = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.saveButton.Enabled = false;

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

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof (PageContent));
                using (TextWriter writer = new StreamWriter(outputFile))
                {
                    ser.Serialize(writer, pageContent);
                }
            }
            finally
            {
                this.saveButton.Enabled = true;
                this.unsavedChanges = false;
            }

        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (this.unsavedChanges)
            {
                var dialogResult = MessageBox.Show(this,
                    "Czy na pewno załadować nowy plik? Niezapisane zmiany zostaną utracone.", "Nowy plik",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                    return;
            }

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

            this.ClearForm();

            string inputFile = dialog.FileName;

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(PageContent));
                using (var fs = new FileStream(inputFile, FileMode.Open))
                {
                    pageContent = ser.Deserialize(fs) as PageContent;
                }
            }
            catch (Exception)
            {
                this.openButton.Enabled = true;
                this.unsavedChanges = false;
                throw;
            }

            if (pageContent == null)
            {
                this.openButton.Enabled = true;
                this.unsavedChanges = false;
                return;
            }

            modelNameTextBox.Text = pageContent.Model;
            scaleComboBox.SelectedIndex = pageContent.Scale;
            producerTextBox.Text = pageContent.Producer;
            descriptionRichTextBox.Text = pageContent.Description;
            imagesTextBox.Text = pageContent.ImagesDirectory;
            altTextBox.Text = pageContent.AltDescription;
            imagesPathTextBox.Text = pageContent.WebsiteImageDir;

            foreach (string file in pageContent.ImagesList)
            {
                if(File.Exists(Path.Combine(pageContent.ImagesDirectory, file)))
                    this.imagesListView.Items.Add(file);
            }

            this.unsavedChanges = false;

            if (this.loadMissingFilesCheckBox.Checked)
            {
                var di = new DirectoryInfo(pageContent.ImagesDirectory);
                var missingImages = di
                    .GetFiles("*.jpg", SearchOption.TopDirectoryOnly)
                    .Select(fi => fi.Name)
                    .Where(f => !f.Contains("_small"))
                    .Where(n => !pageContent.ImagesList.Contains(n))
                    .ToList();

                if (missingImages.Any())
                {
                    foreach (string image in missingImages)
                        this.imagesListView.Items.Add(image);

                    this.unsavedChanges = true;
                }
            }

            this.openButton.Enabled = true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            bool clear = false;

            if (this.unsavedChanges)
            {
                var result = MessageBox.Show(this,
                    "Czy na pewno wyczyścić formularz? Niezapisane zmiany zostaną utracone.", "Nowy plik",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                clear = result == DialogResult.Yes;
            }

            if (!this.unsavedChanges || clear)
            {
                this.ClearForm();
                this.unsavedChanges = false;
            }
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
            this.unsavedChanges = false;
            this.pageContent = new PageContent();

        }
    }
}
