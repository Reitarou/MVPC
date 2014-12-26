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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dgvMobs = new System.Windows.Forms.DataGridView();
            this.checkTimer = new System.Windows.Forms.Timer(this.components);
            this.btnKilled = new System.Windows.Forms.Button();
            this.dgvcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcRespIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcKillCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcRespCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(86, 399);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(167, 399);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(248, 399);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgvMobs
            // 
            this.dgvMobs.AllowUserToAddRows = false;
            this.dgvMobs.AllowUserToDeleteRows = false;
            this.dgvMobs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvMobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMobs.Size = new System.Drawing.Size(311, 258);
            this.dgvMobs.TabIndex = 4;
            // 
            // checkTimer
            // 
            this.checkTimer.Enabled = true;
            this.checkTimer.Interval = 1000;
            this.checkTimer.Tick += new System.EventHandler(this.checkTimer_Tick);
            // 
            // btnKilled
            // 
            this.btnKilled.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKilled.Location = new System.Drawing.Point(12, 276);
            this.btnKilled.Name = "btnKilled";
            this.btnKilled.Size = new System.Drawing.Size(311, 53);
            this.btnKilled.TabIndex = 5;
            this.btnKilled.Text = "УБИТ";
            this.btnKilled.UseVisualStyleBackColor = true;
            this.btnKilled.Click += new System.EventHandler(this.btnKilled_Click);
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
            // 
            // dgvcStatus
            // 
            this.dgvcStatus.HeaderText = "Статус";
            this.dgvcStatus.Name = "dgvcStatus";
            this.dgvcStatus.ReadOnly = true;
            this.dgvcStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgvcRespIn
            // 
            this.dgvcRespIn.HeaderText = "Респ в:";
            this.dgvcRespIn.Name = "dgvcRespIn";
            this.dgvcRespIn.ReadOnly = true;
            this.dgvcRespIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.dgvcRespCD.HeaderText = "Респ";
            this.dgvcRespCD.Name = "dgvcRespTime";
            this.dgvcRespCD.ReadOnly = true;
            this.dgvcRespCD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcRespCD.Visible = false;
            // 
            // MainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 434);
            this.Controls.Add(this.btnKilled);
            this.Controls.Add(this.dgvMobs);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Name = "MainDlg";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgvMobs;
        private System.Windows.Forms.Timer checkTimer;
        private System.Windows.Forms.Button btnKilled;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcRespIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcKillCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcRespCD;
    }
}