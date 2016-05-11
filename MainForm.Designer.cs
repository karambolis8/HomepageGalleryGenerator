namespace HomepageGalleryGenerator
{
    partial class MainForm
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.modelNameTextBox = new System.Windows.Forms.TextBox();
            this.producerTextBox = new System.Windows.Forms.TextBox();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.imagesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imagesBrowseButton = new System.Windows.Forms.Button();
            this.imagesPathTextBox = new System.Windows.Forms.TextBox();
            this.altTextBox = new System.Windows.Forms.TextBox();
            this.imagesTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scaleComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMissingFilesCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // modelNameTextBox
            // 
            this.modelNameTextBox.Location = new System.Drawing.Point(6, 32);
            this.modelNameTextBox.Name = "modelNameTextBox";
            this.modelNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.modelNameTextBox.TabIndex = 2;
            // 
            // producerTextBox
            // 
            this.producerTextBox.Location = new System.Drawing.Point(168, 32);
            this.producerTextBox.Name = "producerTextBox";
            this.producerTextBox.Size = new System.Drawing.Size(93, 20);
            this.producerTextBox.TabIndex = 4;
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Location = new System.Drawing.Point(6, 83);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(255, 199);
            this.descriptionRichTextBox.TabIndex = 5;
            this.descriptionRichTextBox.Text = "";
            // 
            // generateButton
            // 
            this.generateButton.Enabled = false;
            this.generateButton.Location = new System.Drawing.Point(665, 329);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 6;
            this.generateButton.Text = "Generuj";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BackColor = System.Drawing.Color.White;
            this.previewPictureBox.Location = new System.Drawing.Point(187, 83);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(258, 199);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPictureBox.TabIndex = 7;
            this.previewPictureBox.TabStop = false;
            // 
            // imagesListView
            // 
            this.imagesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.imagesListView.FullRowSelect = true;
            this.imagesListView.GridLines = true;
            this.imagesListView.HideSelection = false;
            this.imagesListView.Location = new System.Drawing.Point(6, 83);
            this.imagesListView.MultiSelect = false;
            this.imagesListView.Name = "imagesListView";
            this.imagesListView.Size = new System.Drawing.Size(161, 168);
            this.imagesListView.TabIndex = 8;
            this.imagesListView.UseCompatibleStateImageBehavior = false;
            this.imagesListView.View = System.Windows.Forms.View.Details;
            this.imagesListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ImagesListView_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nazwa pliku";
            this.columnHeader1.Width = 157;
            // 
            // imagesBrowseButton
            // 
            this.imagesBrowseButton.Location = new System.Drawing.Point(143, 31);
            this.imagesBrowseButton.Name = "imagesBrowseButton";
            this.imagesBrowseButton.Size = new System.Drawing.Size(24, 23);
            this.imagesBrowseButton.TabIndex = 9;
            this.imagesBrowseButton.Text = "...";
            this.imagesBrowseButton.UseVisualStyleBackColor = true;
            this.imagesBrowseButton.Click += new System.EventHandler(this.ImagesBrowseButton_Click);
            // 
            // imagesPathTextBox
            // 
            this.imagesPathTextBox.Location = new System.Drawing.Point(310, 31);
            this.imagesPathTextBox.Name = "imagesPathTextBox";
            this.imagesPathTextBox.Size = new System.Drawing.Size(135, 20);
            this.imagesPathTextBox.TabIndex = 11;
            // 
            // altTextBox
            // 
            this.altTextBox.Location = new System.Drawing.Point(187, 32);
            this.altTextBox.Name = "altTextBox";
            this.altTextBox.Size = new System.Drawing.Size(117, 20);
            this.altTextBox.TabIndex = 12;
            // 
            // imagesTextBox
            // 
            this.imagesTextBox.Location = new System.Drawing.Point(6, 33);
            this.imagesTextBox.Name = "imagesTextBox";
            this.imagesTextBox.Size = new System.Drawing.Size(131, 20);
            this.imagesTextBox.TabIndex = 13;
            this.imagesTextBox.TextChanged += new System.EventHandler(this.imagesTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Opis obrazków";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Folder img na WWW";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scaleComboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.modelNameTextBox);
            this.groupBox1.Controls.Add(this.descriptionRichTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.producerTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 295);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opis";
            // 
            // scaleComboBox
            // 
            this.scaleComboBox.FormattingEnabled = true;
            this.scaleComboBox.Location = new System.Drawing.Point(112, 31);
            this.scaleComboBox.Name = "scaleComboBox";
            this.scaleComboBox.Size = new System.Drawing.Size(50, 21);
            this.scaleComboBox.TabIndex = 18;
            this.scaleComboBox.SelectedIndexChanged += new System.EventHandler(this.scaleComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Opis";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Producent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Skala";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Model";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.moveDownButton);
            this.groupBox2.Controls.Add(this.moveUpButton);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.imagesPathTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.imagesListView);
            this.groupBox2.Controls.Add(this.previewPictureBox);
            this.groupBox2.Controls.Add(this.altTextBox);
            this.groupBox2.Controls.Add(this.imagesBrowseButton);
            this.groupBox2.Controls.Add(this.imagesTextBox);
            this.groupBox2.Location = new System.Drawing.Point(285, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 295);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Obrazki";
            // 
            // moveDownButton
            // 
            this.moveDownButton.Image = ((System.Drawing.Image)(resources.GetObject("moveDownButton.Image")));
            this.moveDownButton.Location = new System.Drawing.Point(142, 257);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(25, 25);
            this.moveDownButton.TabIndex = 26;
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Image = ((System.Drawing.Image)(resources.GetObject("moveUpButton.Image")));
            this.moveUpButton.Location = new System.Drawing.Point(111, 257);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(25, 25);
            this.moveUpButton.TabIndex = 25;
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(6, 257);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(25, 25);
            this.deleteButton.TabIndex = 24;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Pliki";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(184, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Podgląd";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.saveButton,
            this.openButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(749, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newButton
            // 
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(50, 20);
            this.newButton.Text = "Nowy";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(52, 20);
            this.saveButton.Text = "Zapisz";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(57, 20);
            this.openButton.Text = "Otwórz";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // loadMissingFilesCheckBox
            // 
            this.loadMissingFilesCheckBox.AutoSize = true;
            this.loadMissingFilesCheckBox.Checked = true;
            this.loadMissingFilesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loadMissingFilesCheckBox.Location = new System.Drawing.Point(12, 333);
            this.loadMissingFilesCheckBox.Name = "loadMissingFilesCheckBox";
            this.loadMissingFilesCheckBox.Size = new System.Drawing.Size(186, 17);
            this.loadMissingFilesCheckBox.TabIndex = 21;
            this.loadMissingFilesCheckBox.Text = "Załaduj nowe pliki przy otwieraniu";
            this.loadMissingFilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 362);
            this.Controls.Add(this.loadMissingFilesCheckBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Homepage Gallery Generator";
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox modelNameTextBox;
        private System.Windows.Forms.TextBox producerTextBox;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.ListView imagesListView;
        private System.Windows.Forms.Button imagesBrowseButton;
        private System.Windows.Forms.TextBox imagesPathTextBox;
        private System.Windows.Forms.TextBox altTextBox;
        private System.Windows.Forms.TextBox imagesTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ComboBox scaleComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newButton;
        private System.Windows.Forms.ToolStripMenuItem openButton;
        private System.Windows.Forms.ToolStripMenuItem saveButton;
        private System.Windows.Forms.CheckBox loadMissingFilesCheckBox;
    }
}

