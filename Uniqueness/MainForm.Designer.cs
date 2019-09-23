namespace Similarity_Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RowCountLabel = new System.Windows.Forms.Label();
            this.FilteredRowCountLabel = new System.Windows.Forms.Label();
            this.pctMissingLabel = new System.Windows.Forms.Label();
            this.pctMissing = new System.Windows.Forms.NumericUpDown();
            this.requestedItems = new System.Windows.Forms.NumericUpDown();
            this.requestedItemsLabel = new System.Windows.Forms.Label();
            this.numberOfCores = new System.Windows.Forms.NumericUpDown();
            this.numberOfCoresLabel = new System.Windows.Forms.Label();
            this.searchTypeLabel = new System.Windows.Forms.Label();
            this.searchType = new System.Windows.Forms.ComboBox();
            this.ActionButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FilteredRowCount = new System.Windows.Forms.TextBox();
            this.datapoints = new System.Windows.Forms.TextBox();
            this.RowCount = new System.Windows.Forms.TextBox();
            this.datapointsLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.targetResult = new System.Windows.Forms.NumericUpDown();
            this.targetResultLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.BestResult = new System.Windows.Forms.TextBox();
            this.BestResultLabel = new System.Windows.Forms.Label();
            this.heatMap = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMissing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestedItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfCores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.targetResult)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(688, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "&Import";
            this.importToolStripMenuItem.ToolTipText = "Load data from file";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "&Export";
            this.exportToolStripMenuItem.ToolTipText = "Export best results";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.tutorialToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            this.tutorialToolStripMenuItem.Click += new System.EventHandler(this.tutorialToolStripMenuItem_Click);
            // 
            // RowCountLabel
            // 
            this.RowCountLabel.AutoSize = true;
            this.RowCountLabel.Location = new System.Drawing.Point(6, 25);
            this.RowCountLabel.Name = "RowCountLabel";
            this.RowCountLabel.Size = new System.Drawing.Size(152, 13);
            this.RowCountLabel.TabIndex = 1;
            this.RowCountLabel.Text = "Number of search items (rows):";
            // 
            // FilteredRowCountLabel
            // 
            this.FilteredRowCountLabel.AutoSize = true;
            this.FilteredRowCountLabel.Location = new System.Drawing.Point(6, 65);
            this.FilteredRowCountLabel.Name = "FilteredRowCountLabel";
            this.FilteredRowCountLabel.Size = new System.Drawing.Size(105, 13);
            this.FilteredRowCountLabel.TabIndex = 2;
            this.FilteredRowCountLabel.Text = "Search items filtered:";
            // 
            // pctMissingLabel
            // 
            this.pctMissingLabel.AutoSize = true;
            this.pctMissingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pctMissingLabel.Location = new System.Drawing.Point(6, 85);
            this.pctMissingLabel.Name = "pctMissingLabel";
            this.pctMissingLabel.Size = new System.Drawing.Size(147, 13);
            this.pctMissingLabel.TabIndex = 3;
            this.pctMissingLabel.Text = "Percent missing allowed:";
            // 
            // pctMissing
            // 
            this.pctMissing.Location = new System.Drawing.Point(184, 81);
            this.pctMissing.Name = "pctMissing";
            this.pctMissing.Size = new System.Drawing.Size(54, 20);
            this.pctMissing.TabIndex = 6;
            this.pctMissing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pctMissing.ValueChanged += new System.EventHandler(this.pctMissing_ValueChanged);
            // 
            // requestedItems
            // 
            this.requestedItems.Location = new System.Drawing.Point(184, 23);
            this.requestedItems.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.requestedItems.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.requestedItems.Name = "requestedItems";
            this.requestedItems.Size = new System.Drawing.Size(54, 20);
            this.requestedItems.TabIndex = 8;
            this.requestedItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.requestedItems.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.requestedItems.ValueChanged += new System.EventHandler(this.requestedItems_ValueChanged);
            // 
            // requestedItemsLabel
            // 
            this.requestedItemsLabel.AutoSize = true;
            this.requestedItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestedItemsLabel.Location = new System.Drawing.Point(6, 25);
            this.requestedItemsLabel.Name = "requestedItemsLabel";
            this.requestedItemsLabel.Size = new System.Drawing.Size(142, 13);
            this.requestedItemsLabel.TabIndex = 7;
            this.requestedItemsLabel.Text = "Requested target items:";
            // 
            // numberOfCores
            // 
            this.numberOfCores.Location = new System.Drawing.Point(184, 45);
            this.numberOfCores.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfCores.Name = "numberOfCores";
            this.numberOfCores.Size = new System.Drawing.Size(54, 20);
            this.numberOfCores.TabIndex = 10;
            this.numberOfCores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numberOfCores.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfCores.ValueChanged += new System.EventHandler(this.numberOfCores_ValueChanged);
            // 
            // numberOfCoresLabel
            // 
            this.numberOfCoresLabel.AutoSize = true;
            this.numberOfCoresLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfCoresLabel.Location = new System.Drawing.Point(6, 47);
            this.numberOfCoresLabel.Name = "numberOfCoresLabel";
            this.numberOfCoresLabel.Size = new System.Drawing.Size(172, 13);
            this.numberOfCoresLabel.TabIndex = 9;
            this.numberOfCoresLabel.Text = "Number of worker processes:";
            // 
            // searchTypeLabel
            // 
            this.searchTypeLabel.AutoSize = true;
            this.searchTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTypeLabel.Location = new System.Drawing.Point(6, 94);
            this.searchTypeLabel.Name = "searchTypeLabel";
            this.searchTypeLabel.Size = new System.Drawing.Size(96, 13);
            this.searchTypeLabel.TabIndex = 11;
            this.searchTypeLabel.Text = "Search method:";
            // 
            // searchType
            // 
            this.searchType.FormattingEnabled = true;
            this.searchType.Location = new System.Drawing.Point(107, 91);
            this.searchType.Name = "searchType";
            this.searchType.Size = new System.Drawing.Size(131, 21);
            this.searchType.TabIndex = 12;
            this.searchType.SelectedIndexChanged += new System.EventHandler(this.searchType_SelectedIndexChanged);
            this.searchType.SelectedValueChanged += new System.EventHandler(this.searchType_SelectedValueChanged);
            // 
            // ActionButton
            // 
            this.ActionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ActionButton.Location = new System.Drawing.Point(628, 385);
            this.ActionButton.Name = "ActionButton";
            this.ActionButton.Size = new System.Drawing.Size(54, 23);
            this.ActionButton.TabIndex = 13;
            this.ActionButton.Text = "Go";
            this.ActionButton.UseVisualStyleBackColor = true;
            this.ActionButton.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FilteredRowCount);
            this.groupBox1.Controls.Add(this.datapoints);
            this.groupBox1.Controls.Add(this.RowCount);
            this.groupBox1.Controls.Add(this.datapointsLabel);
            this.groupBox1.Controls.Add(this.RowCountLabel);
            this.groupBox1.Controls.Add(this.FilteredRowCountLabel);
            this.groupBox1.Controls.Add(this.pctMissingLabel);
            this.groupBox1.Controls.Add(this.pctMissing);
            this.groupBox1.Location = new System.Drawing.Point(16, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 108);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Input";
            // 
            // FilteredRowCount
            // 
            this.FilteredRowCount.BackColor = System.Drawing.SystemColors.Control;
            this.FilteredRowCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FilteredRowCount.Location = new System.Drawing.Point(174, 65);
            this.FilteredRowCount.Name = "FilteredRowCount";
            this.FilteredRowCount.ReadOnly = true;
            this.FilteredRowCount.Size = new System.Drawing.Size(61, 13);
            this.FilteredRowCount.TabIndex = 10;
            this.FilteredRowCount.TabStop = false;
            this.FilteredRowCount.Text = "0";
            this.FilteredRowCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // datapoints
            // 
            this.datapoints.BackColor = System.Drawing.SystemColors.Control;
            this.datapoints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datapoints.Location = new System.Drawing.Point(174, 45);
            this.datapoints.Name = "datapoints";
            this.datapoints.ReadOnly = true;
            this.datapoints.Size = new System.Drawing.Size(61, 13);
            this.datapoints.TabIndex = 9;
            this.datapoints.TabStop = false;
            this.datapoints.Text = "0";
            this.datapoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RowCount
            // 
            this.RowCount.BackColor = System.Drawing.SystemColors.Control;
            this.RowCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RowCount.Location = new System.Drawing.Point(174, 25);
            this.RowCount.Name = "RowCount";
            this.RowCount.ReadOnly = true;
            this.RowCount.Size = new System.Drawing.Size(61, 13);
            this.RowCount.TabIndex = 8;
            this.RowCount.TabStop = false;
            this.RowCount.Text = "0";
            this.RowCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // datapointsLabel
            // 
            this.datapointsLabel.AutoSize = true;
            this.datapointsLabel.Location = new System.Drawing.Point(6, 45);
            this.datapointsLabel.Name = "datapointsLabel";
            this.datapointsLabel.Size = new System.Drawing.Size(162, 13);
            this.datapointsLabel.TabIndex = 6;
            this.datapointsLabel.Text = "Number of data points (columns):";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.targetResult);
            this.groupBox2.Controls.Add(this.targetResultLabel);
            this.groupBox2.Controls.Add(this.searchTypeLabel);
            this.groupBox2.Controls.Add(this.searchType);
            this.groupBox2.Controls.Add(this.requestedItemsLabel);
            this.groupBox2.Controls.Add(this.numberOfCores);
            this.groupBox2.Controls.Add(this.requestedItems);
            this.groupBox2.Controls.Add(this.numberOfCoresLabel);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(16, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 230);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Criteria";
            // 
            // targetResult
            // 
            this.targetResult.Location = new System.Drawing.Point(184, 68);
            this.targetResult.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.targetResult.Name = "targetResult";
            this.targetResult.Size = new System.Drawing.Size(54, 20);
            this.targetResult.TabIndex = 14;
            this.targetResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.targetResult.ValueChanged += new System.EventHandler(this.targetResult_ValueChanged);
            // 
            // targetResultLabel
            // 
            this.targetResultLabel.AutoSize = true;
            this.targetResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetResultLabel.Location = new System.Drawing.Point(6, 70);
            this.targetResultLabel.Name = "targetResultLabel";
            this.targetResultLabel.Size = new System.Drawing.Size(83, 13);
            this.targetResultLabel.TabIndex = 13;
            this.targetResultLabel.Text = "Target result:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 411);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(688, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.resultsDataGridView);
            this.groupBox3.Controls.Add(this.BestResult);
            this.groupBox3.Controls.Add(this.BestResultLabel);
            this.groupBox3.Location = new System.Drawing.Point(269, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 344);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search Results";
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Location = new System.Drawing.Point(6, 45);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.RowHeadersVisible = false;
            this.resultsDataGridView.Size = new System.Drawing.Size(407, 293);
            this.resultsDataGridView.TabIndex = 13;
            // 
            // BestResult
            // 
            this.BestResult.BackColor = System.Drawing.SystemColors.Control;
            this.BestResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BestResult.Location = new System.Drawing.Point(84, 25);
            this.BestResult.Name = "BestResult";
            this.BestResult.ReadOnly = true;
            this.BestResult.Size = new System.Drawing.Size(41, 13);
            this.BestResult.TabIndex = 12;
            this.BestResult.Text = "0";
            this.BestResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BestResultLabel
            // 
            this.BestResultLabel.AutoSize = true;
            this.BestResultLabel.Location = new System.Drawing.Point(6, 25);
            this.BestResultLabel.Name = "BestResultLabel";
            this.BestResultLabel.Size = new System.Drawing.Size(59, 13);
            this.BestResultLabel.TabIndex = 11;
            this.BestResultLabel.Text = "Best result:";
            // 
            // heatMap
            // 
            this.heatMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.heatMap.Location = new System.Drawing.Point(535, 385);
            this.heatMap.Name = "heatMap";
            this.heatMap.Size = new System.Drawing.Size(87, 23);
            this.heatMap.TabIndex = 18;
            this.heatMap.Text = "View Heatmap";
            this.heatMap.UseVisualStyleBackColor = true;
            this.heatMap.Click += new System.EventHandler(this.heatMap_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 433);
            this.Controls.Add(this.heatMap);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ActionButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Uniqueness";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMissing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestedItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfCores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.targetResult)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label RowCountLabel;
        private System.Windows.Forms.Label FilteredRowCountLabel;
        private System.Windows.Forms.Label pctMissingLabel;
        private System.Windows.Forms.NumericUpDown pctMissing;
        private System.Windows.Forms.NumericUpDown requestedItems;
        private System.Windows.Forms.Label requestedItemsLabel;
        private System.Windows.Forms.NumericUpDown numberOfCores;
        private System.Windows.Forms.Label numberOfCoresLabel;
        private System.Windows.Forms.Label searchTypeLabel;
        private System.Windows.Forms.ComboBox searchType;
        private System.Windows.Forms.Button ActionButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label datapointsLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.NumericUpDown targetResult;
        private System.Windows.Forms.Label targetResultLabel;
        private System.Windows.Forms.TextBox RowCount;
        private System.Windows.Forms.TextBox FilteredRowCount;
        private System.Windows.Forms.TextBox datapoints;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.TextBox BestResult;
        private System.Windows.Forms.Label BestResultLabel;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Button heatMap;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;
    }
}

