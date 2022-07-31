namespace FFJsonViewer
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.cmdInsertRow = new System.Windows.Forms.Button();
			this.btnDeleteRow = new System.Windows.Forms.Button();
			this.cboFiles = new System.Windows.Forms.ComboBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtAdd = new System.Windows.Forms.NumericUpDown();
			this.txtInsertRows = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAdd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInsertRows)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 29;
			this.dataGridView1.Size = new System.Drawing.Size(1548, 509);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
			this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(1328, 550);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(94, 29);
			this.btnLoad.TabIndex = 1;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(1466, 550);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(94, 29);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// cmdInsertRow
			// 
			this.cmdInsertRow.Location = new System.Drawing.Point(12, 550);
			this.cmdInsertRow.Name = "cmdInsertRow";
			this.cmdInsertRow.Size = new System.Drawing.Size(104, 29);
			this.cmdInsertRow.TabIndex = 3;
			this.cmdInsertRow.Text = "Insert Row...";
			this.cmdInsertRow.UseVisualStyleBackColor = true;
			this.cmdInsertRow.Click += new System.EventHandler(this.cmdInsertRow_Click);
			// 
			// btnDeleteRow
			// 
			this.btnDeleteRow.Location = new System.Drawing.Point(210, 550);
			this.btnDeleteRow.Name = "btnDeleteRow";
			this.btnDeleteRow.Size = new System.Drawing.Size(94, 29);
			this.btnDeleteRow.TabIndex = 4;
			this.btnDeleteRow.Text = "Delete Row";
			this.btnDeleteRow.UseVisualStyleBackColor = true;
			this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
			// 
			// cboFiles
			// 
			this.cboFiles.FormattingEnabled = true;
			this.cboFiles.Location = new System.Drawing.Point(530, 550);
			this.cboFiles.Name = "cboFiles";
			this.cboFiles.Size = new System.Drawing.Size(754, 28);
			this.cboFiles.TabIndex = 5;
			this.cboFiles.SelectedIndexChanged += new System.EventHandler(this.cboFiles_SelectedIndexChanged);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(315, 550);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(64, 29);
			this.btnAdd.TabIndex = 6;
			this.btnAdd.Text = "Add...";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtAdd
			// 
			this.txtAdd.Location = new System.Drawing.Point(385, 551);
			this.txtAdd.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.txtAdd.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
			this.txtAdd.Name = "txtAdd";
			this.txtAdd.Size = new System.Drawing.Size(90, 27);
			this.txtAdd.TabIndex = 7;
			this.txtAdd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// txtInsertRows
			// 
			this.txtInsertRows.Location = new System.Drawing.Point(131, 551);
			this.txtInsertRows.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
			this.txtInsertRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.txtInsertRows.Name = "txtInsertRows";
			this.txtInsertRows.Size = new System.Drawing.Size(64, 27);
			this.txtInsertRows.TabIndex = 8;
			this.txtInsertRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1572, 590);
			this.Controls.Add(this.txtInsertRows);
			this.Controls.Add(this.txtAdd);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.cboFiles);
			this.Controls.Add(this.btnDeleteRow);
			this.Controls.Add(this.cmdInsertRow);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form1";
			this.Text = "Final Fantasy PR JSON Viewer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAdd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInsertRows)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DataGridView dataGridView1;
		private Button btnLoad;
		private Button btnSave;
		private Button cmdInsertRow;
		private Button btnDeleteRow;
		private ComboBox cboFiles;
		private Button btnAdd;
		private NumericUpDown txtAdd;
		private NumericUpDown txtInsertRows;
	}
}