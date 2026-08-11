using System;
using System.Windows.Forms;

namespace June2026.BookLendingSystem.WinForm
{
    public static class GridHelper
    {
        public static void EnsureSrColumn(DataGridView dgv, int currentPage, int pageSize)
        {
            if (dgv.Columns["SrCol"] == null)
            {
                var srCol = new DataGridViewTextBoxColumn
                {
                    Name = "SrCol",
                    HeaderText = "Sr.",
                    Width = 50,
                    ReadOnly = true
                };
                srCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                srCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns.Insert(0, srCol);
            }

            dgv.Columns["SrCol"].DisplayIndex = 0;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["SrCol"].Value = (currentPage - 1) * pageSize + i + 1;
            }
        }
    }
}
