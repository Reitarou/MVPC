namespace MVPClocker
{
    partial class MainDlg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dgvMobs = new System.Windows.Forms.DataGridView();
            this.dgvcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcRespIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcKillCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcRespCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkTimer = new System.Windows.Forms.Timer(this.components);
            this.btnKilled = new System.Windows.Forms.Button();
            this.cbUseNameFilter = new System.Windows.Forms.CheckBox();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbNextMVP = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(155, 405);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(236, 405);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(317, 405);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Visible = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgvMobs
            // 
            this.dgvMobs.AllowUserToAddRows = false;
            this.dgvMobs.AllowUserToDeleteRows = false;
            this.dgvMobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcID,
            this.dgvcName,
            this.dgvcStatus,
            this.dgvcRespIn,
            this.dgvcKillCount,
            this.dgvcRespCD});
            this.dgvMobs.Location = new System.Drawing.Point(12, 12);
            this.dgvMobs.MultiSelect = false;
            this.dgvMobs.Name = "dgvMobs";
            this.dgvMobs.ReadOnly = true;
            this.dgvMobs.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvMobs.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMobs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMobs.Size = new System.Drawing.Size(380, 276);
            this.dgvMobs.TabIndex = 0;
            // 
            // dgvcID
            // 
            this.dgvcID.HeaderText = "ID";
            this.dgvcID.Name = "dgvcID";
            this.dgvcID.ReadOnly = true;
            this.dgvcID.Visible = false;
            this.dgvcID.Width = 60;
            // 
            // dgvcName
            // 
            this.dgvcName.HeaderText = "Имя";
            this.dgvcName.Name = "dgvcName";
            this.dgvcName.ReadOnly = true;
            this.dgvcName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcName.Width = 240;
            // 
            // dgvcStatus
            // 
            this.dgvcStatus.HeaderText = "Статус";
            this.dgvcStatus.Name = "dgvcStatus";
            this.dgvcStatus.ReadOnly = true;
            this.dgvcStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcStatus.Width = 60;
            // 
            // dgvcRespIn
            // 
            this.dgvcRespIn.HeaderText = "Респ";
            this.dgvcRespIn.Name = "dgvcRespIn";
            this.dgvcRespIn.ReadOnly = true;
            this.dgvcRespIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcRespIn.Width = 60;
            // 
            // dgvcKillCount
            // 
            this.dgvcKillCount.HeaderText = "Убито";
            this.dgvcKillCount.Name = "dgvcKillCount";
            this.dgvcKillCount.ReadOnly = true;
            this.dgvcKillCount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcKillCount.Visible = false;
            // 
            // dgvcRespCD
            // 
            this.dgvcRespCD.HeaderText = "Респ КД";
            this.dgvcRespCD.Name = "dgvcRespCD";
            this.dgvcRespCD.ReadOnly = true;
            this.dgvcRespCD.Visible = false;
            // 
            // checkTimer
            // 
            this.checkTimer.Enabled = true;
            this.checkTimer.Interval = 1000;
            this.checkTimer.Tick += new System.EventHandler(this.checkTimer_Tick);
            // 
            // btnKilled
            // 
            this.btnKilled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKilled.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKilled.Location = new System.Drawing.Point(12, 294);
            this.btnKilled.Name = "btnKilled";
            this.btnKilled.Size = new System.Drawing.Size(380, 53);
            this.btnKilled.TabIndex = 1;
            this.btnKilled.Text = "УБИТ";
            this.btnKilled.UseVisualStyleBackColor = true;
            this.btnKilled.Click += new System.EventHandler(this.btnKilled_Click);
            // 
            // cbUseNameFilter
            // 
            this.cbUseNameFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbUseNameFilter.AutoSize = true;
            this.cbUseNameFilter.Checked = true;
            this.cbUseNameFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseNameFilter.Location = new System.Drawing.Point(12, 366);
            this.cbUseNameFilter.Name = "cbUseNameFilter";
            this.cbUseNameFilter.Size = new System.Drawing.Size(63, 17);
            this.cbUseNameFilter.TabIndex = 2;
            this.cbUseNameFilter.Text = "фильтр";
            this.cbUseNameFilter.UseVisualStyleBackColor = true;
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.Location = new System.Drawing.Point(81, 364);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(68, 20);
            this.tbFilter.TabIndex = 3;
            this.tbFilter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "Убит в...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnKilledAt_Click);
            // 
            // lbNextMVP
            // 
            this.lbNextMVP.Location = new System.Drawing.Point(160, 389);
            this.lbNextMVP.Name = "lbNextMVP";
            this.lbNextMVP.Size = new System.Drawing.Size(232, 39);
            this.lbNextMVP.TabIndex = 8;
            this.lbNextMVP.Text = "label1";
            this.lbNextMVP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(316, 365);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "мин.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Предупреждать за";
            // 
            // MainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 440);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lbNextMVP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.cbUseNameFilter);
            this.Controls.Add(this.btnKilled);
            this.Controls.Add(this.dgvMobs);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Name = "MainDlg";
            this.Text = "MVPC v.1.2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgvMobs;
        private System.Windows.Forms.Timer checkTimer;
        private System.Windows.Forms.Button btnKilled;
        private System.Windows.Forms.CheckBox cbUseNameFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcRespIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcKillCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcRespCD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbNextMVP;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}