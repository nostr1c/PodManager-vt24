namespace Gui
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            btnAddPod = new Button();
            tbUrl = new TextBox();
            dgPod = new DataGridView();
            btnRemovePod = new Button();
            lblUrl = new Label();
            btnSave = new Button();
            lbCategories = new ListBox();
            lblPodName = new Label();
            tbCategory = new TextBox();
            lblCategory = new Label();
            btnCategoryAdd = new Button();
            btnCategoryRemove = new Button();
            btnCategorySave = new Button();
            cbCategory = new ComboBox();
            lblSelectCategory = new Label();
            label2 = new Label();
            tbName = new TextBox();
            lbEpisodes = new ListBox();
            tbEpisodeDescription = new TextBox();
            cbFilter = new ComboBox();
            lbFilter = new Label();
            ((System.ComponentModel.ISupportInitialize)dgPod).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 57);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 1;
            // 
            // btnAddPod
            // 
            btnAddPod.Location = new Point(12, 105);
            btnAddPod.Name = "btnAddPod";
            btnAddPod.Size = new Size(54, 23);
            btnAddPod.TabIndex = 2;
            btnAddPod.Text = "Add";
            btnAddPod.UseVisualStyleBackColor = true;
            btnAddPod.Click += BtnAddPod_Click;
            // 
            // tbUrl
            // 
            tbUrl.Location = new Point(12, 31);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(363, 23);
            tbUrl.TabIndex = 3;
            tbUrl.Click += tbUrl_Click;
            // 
            // dgPod
            // 
            dgPod.AllowUserToAddRows = false;
            dgPod.AllowUserToDeleteRows = false;
            dgPod.AllowUserToOrderColumns = true;
            dgPod.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgPod.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgPod.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPod.GridColor = SystemColors.Control;
            dgPod.Location = new Point(12, 154);
            dgPod.Name = "dgPod";
            dgPod.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgPod.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgPod.RowHeadersVisible = false;
            dgPod.RowHeadersWidth = 82;
            dgPod.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPod.Size = new Size(512, 482);
            dgPod.TabIndex = 4;
            dgPod.SelectionChanged += dgPod_SelectionChanged;
            // 
            // btnRemovePod
            // 
            btnRemovePod.Location = new Point(139, 106);
            btnRemovePod.Name = "btnRemovePod";
            btnRemovePod.Size = new Size(61, 23);
            btnRemovePod.TabIndex = 5;
            btnRemovePod.Text = "Remove";
            btnRemovePod.UseVisualStyleBackColor = true;
            btnRemovePod.Click += BtnRemovePod_Click;
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new Point(12, 13);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(28, 15);
            lblUrl.TabIndex = 6;
            lblUrl.Text = "URL";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(71, 106);
            btnSave.Margin = new Padding(2, 1, 2, 1);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(63, 22);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // lbCategories
            // 
            lbCategories.FormattingEnabled = true;
            lbCategories.ItemHeight = 15;
            lbCategories.Location = new Point(795, 31);
            lbCategories.Name = "lbCategories";
            lbCategories.Size = new Size(120, 64);
            lbCategories.TabIndex = 9;
            lbCategories.SelectedIndexChanged += lbCategories_SelectedIndexChanged;
            // 
            // lblPodName
            // 
            lblPodName.AutoSize = true;
            lblPodName.Location = new Point(11, 59);
            lblPodName.Name = "lblPodName";
            lblPodName.Size = new Size(51, 15);
            lblPodName.TabIndex = 10;
            lblPodName.Text = "Pod title";
            // 
            // tbCategory
            // 
            tbCategory.Location = new Point(552, 31);
            tbCategory.Name = "tbCategory";
            tbCategory.Size = new Size(237, 23);
            tbCategory.TabIndex = 11;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(552, 13);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(55, 15);
            lblCategory.TabIndex = 12;
            lblCategory.Text = "Category";
            // 
            // btnCategoryAdd
            // 
            btnCategoryAdd.Location = new Point(552, 60);
            btnCategoryAdd.Name = "btnCategoryAdd";
            btnCategoryAdd.Size = new Size(75, 23);
            btnCategoryAdd.TabIndex = 13;
            btnCategoryAdd.Text = "Add";
            btnCategoryAdd.UseVisualStyleBackColor = true;
            btnCategoryAdd.Click += btnCategoryAdd_Click;
            // 
            // btnCategoryRemove
            // 
            btnCategoryRemove.Location = new Point(714, 60);
            btnCategoryRemove.Name = "btnCategoryRemove";
            btnCategoryRemove.Size = new Size(75, 23);
            btnCategoryRemove.TabIndex = 14;
            btnCategoryRemove.Text = "Remove";
            btnCategoryRemove.UseVisualStyleBackColor = true;
            btnCategoryRemove.Click += btnCategoryRemove_Click;
            // 
            // btnCategorySave
            // 
            btnCategorySave.Location = new Point(633, 60);
            btnCategorySave.Name = "btnCategorySave";
            btnCategorySave.Size = new Size(75, 23);
            btnCategorySave.TabIndex = 15;
            btnCategorySave.Text = "Save";
            btnCategorySave.UseVisualStyleBackColor = true;
            btnCategorySave.Click += btnCategorySave_Click;
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(254, 75);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(121, 23);
            cbCategory.TabIndex = 16;
            // 
            // lblSelectCategory
            // 
            lblSelectCategory.AutoSize = true;
            lblSelectCategory.Location = new Point(254, 57);
            lblSelectCategory.Name = "lblSelectCategory";
            lblSelectCategory.Size = new Size(58, 15);
            lblSelectCategory.TabIndex = 17;
            lblSelectCategory.Text = "Category:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 59);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 1;
            // 
            // tbName
            // 
            tbName.Location = new Point(11, 75);
            tbName.Margin = new Padding(2, 1, 2, 1);
            tbName.Name = "tbName";
            tbName.Size = new Size(238, 23);
            tbName.TabIndex = 7;
            // 
            // lbEpisodes
            // 
            lbEpisodes.FormattingEnabled = true;
            lbEpisodes.ItemHeight = 15;
            lbEpisodes.Location = new Point(552, 152);
            lbEpisodes.Name = "lbEpisodes";
            lbEpisodes.Size = new Size(284, 484);
            lbEpisodes.TabIndex = 18;
            lbEpisodes.SelectedValueChanged += lbEpisodes_SelectedValueChanged;
            // 
            // tbEpisodeDescription
            // 
            tbEpisodeDescription.BackColor = SystemColors.Window;
            tbEpisodeDescription.Location = new Point(859, 154);
            tbEpisodeDescription.Multiline = true;
            tbEpisodeDescription.Name = "tbEpisodeDescription";
            tbEpisodeDescription.ReadOnly = true;
            tbEpisodeDescription.Size = new Size(194, 276);
            tbEpisodeDescription.TabIndex = 19;
            // 
            // cbFilter
            // 
            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(403, 125);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(121, 23);
            cbFilter.TabIndex = 20;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            // 
            // lbFilter
            // 
            lbFilter.AutoSize = true;
            lbFilter.Location = new Point(403, 106);
            lbFilter.Name = "lbFilter";
            lbFilter.Size = new Size(33, 15);
            lbFilter.TabIndex = 21;
            lbFilter.Text = "Filter";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 648);
            Controls.Add(lbFilter);
            Controls.Add(cbFilter);
            Controls.Add(tbEpisodeDescription);
            Controls.Add(lbEpisodes);
            Controls.Add(lblSelectCategory);
            Controls.Add(cbCategory);
            Controls.Add(btnCategorySave);
            Controls.Add(btnCategoryRemove);
            Controls.Add(btnCategoryAdd);
            Controls.Add(lblCategory);
            Controls.Add(tbCategory);
            Controls.Add(lblPodName);
            Controls.Add(lbCategories);
            Controls.Add(btnSave);
            Controls.Add(tbName);
            Controls.Add(lblUrl);
            Controls.Add(btnRemovePod);
            Controls.Add(dgPod);
            Controls.Add(tbUrl);
            Controls.Add(label2);
            Controls.Add(btnAddPod);
            Controls.Add(label1);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)dgPod).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btnAddPod;
        private TextBox tbUrl;
        private DataGridView dgPod;
        private Button btnRemovePod;
        private Label lblUrl;
        private Button btnSave;
        private ListBox lbCategories;
        private Label lblPodName;
        private TextBox tbCategory;
        private Label lblCategory;
        private Button btnCategoryAdd;
        private Button btnCategoryRemove;
        private Button btnCategorySave;
        private ComboBox cbCategory;
        private Label lblSelectCategory;
        private Label label2;
        private TextBox tbName;
        private ListBox lbEpisodes;
        private TextBox tbEpisodeDescription;
        private ComboBox cbFilter;
        private Label lbFilter;
    }
}