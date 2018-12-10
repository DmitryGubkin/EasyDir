using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace EasyDir
{
    class DataEditorHelper
    {
        private CheckBox topCheckBox = new CheckBox();
        private DataGridView dataGridView = new DataGridView();

        public CheckBox GetTopCheckBox { get => topCheckBox;}
        public DataGridView GetDataGridView { get => dataGridView;}

        private CheckBox ColumnCheckbox()
        {
            topCheckBox.Size = new Size(15, 15);
            topCheckBox.BackColor = Color.Transparent;

            // Reset properties
            topCheckBox.Padding = new Padding(0);
            topCheckBox.Margin = new Padding(0);
            topCheckBox.Text = "";


            // Add checkbox to datagrid cell
            dataGridView.Controls.Add(topCheckBox);

            DataGridViewHeaderCell header = dataGridView.Columns[0].HeaderCell;
            topCheckBox.Location = new Point(
                (header.ContentBounds.Left +
                 (header.ContentBounds.Right - header.ContentBounds.Left + topCheckBox.Size.Width)
                 / 2) + 13,
                (header.ContentBounds.Top +
                 (header.ContentBounds.Bottom - header.ContentBounds.Top + topCheckBox.Size.Height)
                 / 2) - 2);
            return topCheckBox;
        }

        public DataEditorHelper (ref DataGridView _dataGridView)
        {
            dataGridView = _dataGridView;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Turquoise;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43);
            dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 128);
            dataGridView.Columns[0].Width = 30;
            dataGridView.Columns[3].Width = 50;
            dataGridView.RowHeadersVisible = false;
            _dataGridView.DefaultCellStyle.Font = new Font("Tahoma", 12, GraphicsUnit.Pixel);
            ColumnCheckbox();
        }
    }
}
