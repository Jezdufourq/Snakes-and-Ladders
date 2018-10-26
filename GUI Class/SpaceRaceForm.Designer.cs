namespace GUI_Class
{
    partial class SpaceRaceForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.GameResetButton = new System.Windows.Forms.Button();
            this.RollDiceButton = new System.Windows.Forms.Button();
            this.SingleStep = new System.Windows.Forms.GroupBox();
            this.NoRadioButton = new System.Windows.Forms.RadioButton();
            this.YesRadioButton = new System.Windows.Forms.RadioButton();
            this.playerDataGridView = new System.Windows.Forms.DataGridView();
            this.playerTokenImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rocketFuelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Players = new System.Windows.Forms.Label();
            this.NumberOfPlayersBox = new System.Windows.Forms.ComboBox();
            this.NumberOfPlayersLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SingleStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GameResetButton);
            this.splitContainer1.Panel2.Controls.Add(this.RollDiceButton);
            this.splitContainer1.Panel2.Controls.Add(this.SingleStep);
            this.splitContainer1.Panel2.Controls.Add(this.playerDataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.Players);
            this.splitContainer1.Panel2.Controls.Add(this.NumberOfPlayersBox);
            this.splitContainer1.Panel2.Controls.Add(this.NumberOfPlayersLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.exitButton);
            this.splitContainer1.Size = new System.Drawing.Size(884, 661);
            this.splitContainer1.SplitterDistance = 662;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 8;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(662, 661);
            this.tableLayoutPanel.TabIndex = 0;
            this.tableLayoutPanel.Tag = "";
            this.tableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_Paint);
            // 
            // GameResetButton
            // 
            this.GameResetButton.Enabled = false;
            this.GameResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameResetButton.Location = new System.Drawing.Point(14, 625);
            this.GameResetButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GameResetButton.Name = "GameResetButton";
            this.GameResetButton.Size = new System.Drawing.Size(104, 26);
            this.GameResetButton.TabIndex = 8;
            this.GameResetButton.Text = "Game Reset";
            this.GameResetButton.UseVisualStyleBackColor = true;
            this.GameResetButton.Click += new System.EventHandler(this.GameResetButton_Click);
            // 
            // RollDiceButton
            // 
            this.RollDiceButton.Enabled = false;
            this.RollDiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollDiceButton.Location = new System.Drawing.Point(76, 583);
            this.RollDiceButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RollDiceButton.Name = "RollDiceButton";
            this.RollDiceButton.Size = new System.Drawing.Size(74, 28);
            this.RollDiceButton.TabIndex = 7;
            this.RollDiceButton.Text = "Roll Dice";
            this.RollDiceButton.UseVisualStyleBackColor = true;
            this.RollDiceButton.Click += new System.EventHandler(this.RollDiceButton_Click);
            // 
            // SingleStep
            // 
            this.SingleStep.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SingleStep.Controls.Add(this.NoRadioButton);
            this.SingleStep.Controls.Add(this.YesRadioButton);
            this.SingleStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingleStep.Location = new System.Drawing.Point(58, 429);
            this.SingleStep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SingleStep.Name = "SingleStep";
            this.SingleStep.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SingleStep.Size = new System.Drawing.Size(105, 45);
            this.SingleStep.TabIndex = 6;
            this.SingleStep.TabStop = false;
            this.SingleStep.Text = "Single Step?";
            // 
            // NoRadioButton
            // 
            this.NoRadioButton.AutoSize = true;
            this.NoRadioButton.Location = new System.Drawing.Point(62, 17);
            this.NoRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NoRadioButton.Name = "NoRadioButton";
            this.NoRadioButton.Size = new System.Drawing.Size(41, 17);
            this.NoRadioButton.TabIndex = 0;
            this.NoRadioButton.TabStop = true;
            this.NoRadioButton.Text = "No";
            this.NoRadioButton.UseVisualStyleBackColor = true;
            this.NoRadioButton.CheckedChanged += new System.EventHandler(this.NoRadioButton_CheckedChanged);
            // 
            // YesRadioButton
            // 
            this.YesRadioButton.AutoSize = true;
            this.YesRadioButton.Location = new System.Drawing.Point(17, 17);
            this.YesRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.YesRadioButton.Name = "YesRadioButton";
            this.YesRadioButton.Size = new System.Drawing.Size(46, 17);
            this.YesRadioButton.TabIndex = 0;
            this.YesRadioButton.TabStop = true;
            this.YesRadioButton.Text = "Yes";
            this.YesRadioButton.UseVisualStyleBackColor = true;
            this.YesRadioButton.CheckedChanged += new System.EventHandler(this.YesRadioButton_CheckedChanged);
            // 
            // playerDataGridView
            // 
            this.playerDataGridView.AllowUserToAddRows = false;
            this.playerDataGridView.AllowUserToDeleteRows = false;
            this.playerDataGridView.AutoGenerateColumns = false;
            this.playerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerTokenImageDataGridViewImageColumn,
            this.nameDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn,
            this.rocketFuelDataGridViewTextBoxColumn});
            this.playerDataGridView.DataSource = this.playerBindingSource;
            this.playerDataGridView.Location = new System.Drawing.Point(5, 209);
            this.playerDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playerDataGridView.Name = "playerDataGridView";
            this.playerDataGridView.RowHeadersVisible = false;
            this.playerDataGridView.RowTemplate.Height = 24;
            this.playerDataGridView.Size = new System.Drawing.Size(210, 176);
            this.playerDataGridView.TabIndex = 5;
            this.playerDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.playerDataGridView_CellContentClick);
            // 
            // playerTokenImageDataGridViewImageColumn
            // 
            this.playerTokenImageDataGridViewImageColumn.DataPropertyName = "PlayerTokenImage";
            this.playerTokenImageDataGridViewImageColumn.Frozen = true;
            this.playerTokenImageDataGridViewImageColumn.HeaderText = "";
            this.playerTokenImageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.playerTokenImageDataGridViewImageColumn.MinimumWidth = 20;
            this.playerTokenImageDataGridViewImageColumn.Name = "playerTokenImageDataGridViewImageColumn";
            this.playerTokenImageDataGridViewImageColumn.ReadOnly = true;
            this.playerTokenImageDataGridViewImageColumn.Width = 20;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.Frozen = true;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 90;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.Frozen = true;
            this.positionDataGridViewTextBoxColumn.HeaderText = "Square";
            this.positionDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            this.positionDataGridViewTextBoxColumn.ReadOnly = true;
            this.positionDataGridViewTextBoxColumn.Width = 50;
            // 
            // rocketFuelDataGridViewTextBoxColumn
            // 
            this.rocketFuelDataGridViewTextBoxColumn.DataPropertyName = "RocketFuel";
            this.rocketFuelDataGridViewTextBoxColumn.HeaderText = "Fuel";
            this.rocketFuelDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.rocketFuelDataGridViewTextBoxColumn.Name = "rocketFuelDataGridViewTextBoxColumn";
            this.rocketFuelDataGridViewTextBoxColumn.ReadOnly = true;
            this.rocketFuelDataGridViewTextBoxColumn.Width = 50;
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(Object_Classes.Player);
            // 
            // Players
            // 
            this.Players.AutoSize = true;
            this.Players.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Players.Location = new System.Drawing.Point(62, 180);
            this.Players.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Players.Name = "Players";
            this.Players.Size = new System.Drawing.Size(92, 26);
            this.Players.TabIndex = 4;
            this.Players.Text = "Players";
            this.Players.Click += new System.EventHandler(this.Players_Click);
            // 
            // NumberOfPlayersBox
            // 
            this.NumberOfPlayersBox.FormattingEnabled = true;
            this.NumberOfPlayersBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.NumberOfPlayersBox.Location = new System.Drawing.Point(154, 93);
            this.NumberOfPlayersBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NumberOfPlayersBox.Name = "NumberOfPlayersBox";
            this.NumberOfPlayersBox.Size = new System.Drawing.Size(37, 21);
            this.NumberOfPlayersBox.TabIndex = 3;
            this.NumberOfPlayersBox.Text = "6";
            this.NumberOfPlayersBox.SelectedIndexChanged += new System.EventHandler(this.NumberOfPlayersBox_SelectedIndexChanged);
            // 
            // NumberOfPlayersLabel
            // 
            this.NumberOfPlayersLabel.AutoSize = true;
            this.NumberOfPlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfPlayersLabel.Location = new System.Drawing.Point(26, 96);
            this.NumberOfPlayersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NumberOfPlayersLabel.Name = "NumberOfPlayersLabel";
            this.NumberOfPlayersLabel.Size = new System.Drawing.Size(110, 13);
            this.NumberOfPlayersLabel.TabIndex = 2;
            this.NumberOfPlayersLabel.Text = "Number of Players";
            this.NumberOfPlayersLabel.Click += new System.EventHandler(this.NumberOfPlayersLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Space Race";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(125, 625);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 25);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // SpaceRaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SpaceRaceForm";
            this.Text = "Space Race";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.SingleStep.ResumeLayout(false);
            this.SingleStep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Players;
        private System.Windows.Forms.ComboBox NumberOfPlayersBox;
        private System.Windows.Forms.Label NumberOfPlayersLabel;
        private System.Windows.Forms.DataGridView playerDataGridView;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.Button GameResetButton;
        private System.Windows.Forms.Button RollDiceButton;
        private System.Windows.Forms.GroupBox SingleStep;
        private System.Windows.Forms.RadioButton NoRadioButton;
        private System.Windows.Forms.RadioButton YesRadioButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridViewImageColumn playerTokenImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rocketFuelDataGridViewTextBoxColumn;
    }
}

