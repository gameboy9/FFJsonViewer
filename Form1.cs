using FFJsonViewer.Classes;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FFJsonViewer
{
	public partial class Form1 : Form
	{
		string directory = @"C:\Program Files (x86)\Steam\steamapps\common\FINAL FANTASY VI PR\FINAL FANTASY VI_Data\StreamingAssets\Assets\GameAssets\Serial\Res\Map";
		EventJSON jEvents;
		bool firstLoad = true;
		List<string> files = new List<string>();
		string file;
		bool fileChanged = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, 
				null, dataGridView1, new object[] { true });

			bool widthHeightSet = false;

			try
			{
				using (TextReader reader = File.OpenText("lastFFJSON.txt"))
				{
					Width = Convert.ToInt32(reader.ReadLine());
					Height = Convert.ToInt32(reader.ReadLine());
					widthHeightSet = true;
					if (Width < 1000) Width = 1000;
					if (Height < 700) Height = 700;
					Top = Convert.ToInt32(reader.ReadLine());
					Left = Convert.ToInt32(reader.ReadLine());
					if (Top < 0 || Top > 4000) Top = 100;
					if (Left < 0 || Left > 4000) Left = 100;
					for (int i = 0; i < 10; i++)
					{
						string file = reader.ReadLine();
						if (file != null)
							files.Add(file);
					}
				}
			}
			catch
			{
				if (!widthHeightSet)
				{
					Width = 1000;
					Height = 700;
				}
			}
			if (files.Count > 0)
			{
				loadFile(files[0]);
				refreshFileList();
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			using (StreamWriter writer = File.CreateText("lastFFJSON.txt"))
			{
				writer.WriteLine(Width);
				writer.WriteLine(Height);
				writer.WriteLine(Top);
				writer.WriteLine(Left);
				for (int i = 0; i < files.Count(); i++)
					writer.WriteLine(files[i]);
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "JSON files (*.json)|*.json";
			if (files.Count > 0)
				openFileDialog.InitialDirectory = Path.GetDirectoryName(files[0]);
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{  //Path.Combine(directory, "Map_30390", "Map_30390", "sc_e_0064_1.json");
				if (loadFile(openFileDialog.FileName))
				{
					files.Insert(0, openFileDialog.FileName);
					if (files.Count > 10)
						files.RemoveRange(10, files.Count - 10);

					refreshFileList();
				}
			}
		}

		private void refreshFileList()
		{
			cboFiles.Items.Clear();
			foreach (string file in files)
				cboFiles.Items.Add(file);
			cboFiles.SelectedIndex = 0;
		}

		private bool loadFile(string file)
		{
			if (file == null)
				return false;

			string json = File.ReadAllText(file);

			jEvents = JsonConvert.DeserializeObject<EventJSON>(json);
			if (jEvents.Animations == null)
			{
				MessageBox.Show("Invalid Final Fantasy Events JSON file.");
				return false;
			}

			dataGridView1.AutoSize = false;

			if (firstLoad)
			{
				DataGridViewColumn column = new DataGridViewTextBoxColumn();
				column = new DataGridViewTextBoxColumn();
				column.Name = "Label";
				dataGridView1.Columns.Add(column);

				column = new DataGridViewTextBoxColumn();
				column.Name = "Mnemonic";
				dataGridView1.Columns.Add(column);

				column = new DataGridViewTextBoxColumn();
				column.Name = "Type";
				dataGridView1.Columns.Add(column);

				for (int i = 0; i < 8; i++)
				{
					column = new DataGridViewTextBoxColumn();
					column.Name = (i == 0 ? "iVal" : "");
					column.Width = 50;
					dataGridView1.Columns.Add(column);
				}
				for (int i = 0; i < 8; i++)
				{
					column = new DataGridViewTextBoxColumn();
					column.Name = (i == 0 ? "rVal" : "");
					column.Width = 60;
					dataGridView1.Columns.Add(column);
				}
				for (int i = 0; i < 8; i++)
				{
					column = new DataGridViewTextBoxColumn();
					column.Name = (i == 0 ? "sVal" : "");
					dataGridView1.Columns.Add(column);
				}

				column = new DataGridViewTextBoxColumn();
				column.Name = "Comment";
				dataGridView1.Columns.Add(column);
				firstLoad = false;
			}

			dataGridView1.Rows.Clear();

			foreach (EventJSON.Mnemonic mnemonic in jEvents.Mnemonics)
			{
				dataGridView1.Rows.Add(mnemonic.label, mnemonic.mnemonic, mnemonic.type,
					mnemonic.operands.iValues.Length >= 1 ? mnemonic.operands.iValues[0] : 0,
					mnemonic.operands.iValues.Length >= 2 ? mnemonic.operands.iValues[1] : 0,
					mnemonic.operands.iValues.Length >= 3 ? mnemonic.operands.iValues[2] : 0,
					mnemonic.operands.iValues.Length >= 4 ? mnemonic.operands.iValues[3] : 0,
					mnemonic.operands.iValues.Length >= 5 ? mnemonic.operands.iValues[4] : 0,
					mnemonic.operands.iValues.Length >= 6 ? mnemonic.operands.iValues[5] : 0,
					mnemonic.operands.iValues.Length >= 7 ? mnemonic.operands.iValues[6] : 0,
					mnemonic.operands.iValues.Length >= 8 ? mnemonic.operands.iValues[7] : 0,
					mnemonic.operands.rValues.Length >= 1 ? mnemonic.operands.rValues[0] : 0,
					mnemonic.operands.rValues.Length >= 2 ? mnemonic.operands.rValues[1] : 0,
					mnemonic.operands.rValues.Length >= 3 ? mnemonic.operands.rValues[2] : 0,
					mnemonic.operands.rValues.Length >= 4 ? mnemonic.operands.rValues[3] : 0,
					mnemonic.operands.rValues.Length >= 5 ? mnemonic.operands.rValues[4] : 0,
					mnemonic.operands.rValues.Length >= 6 ? mnemonic.operands.rValues[5] : 0,
					mnemonic.operands.rValues.Length >= 7 ? mnemonic.operands.rValues[6] : 0,
					mnemonic.operands.rValues.Length >= 8 ? mnemonic.operands.rValues[7] : 0,
					mnemonic.operands.sValues.Length >= 1 ? mnemonic.operands.sValues[0] : "",
					mnemonic.operands.sValues.Length >= 2 ? mnemonic.operands.sValues[1] : "",
					mnemonic.operands.sValues.Length >= 3 ? mnemonic.operands.sValues[2] : "",
					mnemonic.operands.sValues.Length >= 4 ? mnemonic.operands.sValues[3] : "",
					mnemonic.operands.sValues.Length >= 5 ? mnemonic.operands.sValues[4] : "",
					mnemonic.operands.sValues.Length >= 6 ? mnemonic.operands.sValues[5] : "",
					mnemonic.operands.sValues.Length >= 7 ? mnemonic.operands.sValues[6] : "",
					mnemonic.operands.sValues.Length >= 8 ? mnemonic.operands.sValues[7] : "", mnemonic.comment);
			}

			dataGridView1.RowHeadersWidth = 80;

			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				row.HeaderCell.Value = string.Format("{0}", row.Index);
			}

			fileChanged = false;
			return true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			List<EventJSON.Mnemonic> m = new List<EventJSON.Mnemonic>();

			foreach(DataGridViewRow row in dataGridView1.Rows)
			{
				EventJSON.Mnemonic n = new EventJSON.Mnemonic();
				if (row.Cells[0].Value != null)
				{
					n.label = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
					n.mnemonic = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
					n.type = row.Cells[2].Value == null ? 0 : Convert.ToInt32(row.Cells[2].Value);
					n.operands = new EventJSON.Operands();
					n.operands.iValues = new int?[8];
					n.operands.rValues = new float?[8];
					n.operands.sValues = new string[8];
					for (int i = 0; i < 8; i++)
					{
						n.operands.iValues[i] = row.Cells[3 + i].Value == null ? 0 : Convert.ToInt32(row.Cells[3 + i].Value);
						n.operands.rValues[i] = row.Cells[11 + i].Value == null ? 0 : Convert.ToSingle(row.Cells[11 + i].Value);
						n.operands.sValues[i] = row.Cells[19 + i].Value == null ? "" : row.Cells[19 + i].Value.ToString();
					}
					n.comment = row.Cells[27].Value == null ? "" : row.Cells[27].Value.ToString();

					m.Add(n);
				}
			}

			jEvents.Mnemonics = m.ToArray();

			JsonSerializer serializer = new JsonSerializer();

			using (StreamWriter sw = new StreamWriter(files[0]))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				serializer.Serialize(writer, jEvents);
			}
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			fileChanged = true;
		}

		private void cmdInsertRow_Click(object sender, EventArgs e)
		{
			int deletedRow = dataGridView1.SelectedCells[0].RowIndex;

			for (int i = 0; i < txtInsertRows.Value; i++)
				dataGridView1.Rows.Insert(dataGridView1.SelectedCells[0].RowIndex, "", "", 1, 
					0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0,
					"", "", "", "", "", "", "", "",
					"");
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				row.HeaderCell.Value = string.Format("{0}", row.Index);

				if (row.Cells[1].Value != null)
				{
					if ((row.Cells[1].Value.ToString() == "Call" || row.Cells[1].Value.ToString() == "Jump") && Convert.ToInt32(row.Cells[3].Value) > deletedRow)
						row.Cells[3].Value = Convert.ToInt32(row.Cells[3].Value) + txtInsertRows.Value;
					if ((row.Cells[1].Value.ToString() == "Branch" || row.Cells[1].Value.ToString() == "SetPuppet") && Convert.ToInt32(row.Cells[5].Value) > deletedRow)
						row.Cells[5].Value = Convert.ToInt32(row.Cells[5].Value) + txtInsertRows.Value;
				}
			}

			fileChanged = true;
		}

		private void btnDeleteRow_Click(object sender, EventArgs e)
		{
			int deletedRow = dataGridView1.SelectedCells[0].RowIndex;
			dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				row.HeaderCell.Value = string.Format("{0}", row.Index);

				if (row.Cells[1].Value != null)
				{
					if ((row.Cells[1].Value.ToString() == "Call" || row.Cells[1].Value.ToString() == "Jump") && Convert.ToInt32(row.Cells[3].Value) > deletedRow)
						row.Cells[3].Value = Convert.ToInt32(row.Cells[3].Value) - 1;
					if ((row.Cells[1].Value.ToString() == "Branch" || row.Cells[1].Value.ToString() == "SetPuppet") && Convert.ToInt32(row.Cells[5].Value) > deletedRow)
						row.Cells[5].Value = Convert.ToInt32(row.Cells[5].Value) - 1;
				}
			}

			fileChanged = true;
		}

		public static void PasteTSV(DataGridView grid)
		{
			char[] rowSplitter = { '\r', '\n' };
			char[] columnSplitter = { '\t' };

			// Get the text from clipboard
			IDataObject dataInClipboard = Clipboard.GetDataObject();
			string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.UnicodeText);
			if (stringInClipboard == null) return;

			// Split it into lines
			string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

			// Get the row and column of selected cell in grid
			int r = grid.SelectedCells[0].RowIndex;
			int c = grid.SelectedCells[0].ColumnIndex;

			// Add rows into grid to fit clipboard lines
			if (grid.Rows.Count < (r + rowsInClipboard.Length))
			{
				grid.Rows.Add(r + rowsInClipboard.Length - grid.Rows.Count);
			}

			// Loop through the lines, split them into cells and place the values in the corresponding cell.
			for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
			{
				// Split row into cell values
				string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
				if (valuesInRow.Length == 28)
				{
					List<string> temp = valuesInRow.ToList();
					temp.RemoveAt(0);
					valuesInRow = temp.ToArray();
				}

				// Cycle through cell values
				for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
				{

					// Assign cell value, only if it within columns of the grid
					if (grid.ColumnCount - 1 >= c + iCol)
					{
						DataGridViewCell cell = grid.Rows[r + iRow].Cells[c + iCol];

						if (!cell.ReadOnly)
						{
							cell.Value = valuesInRow[iCol];
						}
					}
				}
			}

			foreach (DataGridViewRow row in grid.Rows)
			{
				row.HeaderCell.Value = string.Format("{0}", row.Index);
			}
		}

		private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
		{
			if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
			{
				PasteTSV(dataGridView1);
			}
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			dataGridView1.Width = this.Width - 42;
			dataGridView1.Height = this.Height - 128;
			btnLoad.Top = btnSave.Top = btnDeleteRow.Top = cmdInsertRow.Top = btnAdd.Top = this.Height - 88;
			txtInsertRows.Top = txtAdd.Top = cboFiles.Top = this.Height - 86;
			btnLoad.Left = this.Width - 262;
			btnSave.Left = this.Width - 124;
			cboFiles.Width = this.Width - 836;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (int.TryParse(dataGridView1.SelectedCells[0].Value.ToString(), out _))
				dataGridView1.SelectedCells[0].Value = Convert.ToInt32(dataGridView1.SelectedCells[0].Value) + txtAdd.Value;
		}

		private void cboFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			string file = files[cboFiles.SelectedIndex];
			loadFile(file);
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == 1 && e.Value != null)
			{
				if (e.Value.ToString() == "Call" || e.Value.ToString() == "SetPuppet")
					e.CellStyle.BackColor = Color.LightCyan;
				if (e.Value.ToString() == "Branch")
					e.CellStyle.BackColor = Color.LightGreen;
				if (e.Value.ToString() == "Encount" || e.Value.ToString() == "EncountBoss")
					e.CellStyle.BackColor = Color.LightPink;
				if (e.Value.ToString() == "ChangeMap")
					e.CellStyle.BackColor = Color.LightYellow;
			}
		}
	}
}