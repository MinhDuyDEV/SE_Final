using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SE_FinalProject
{
    public partial class GoodsDeliveryNote : Form
    {
        public GoodsDeliveryNote()
        {
            InitializeComponent();
        }

		public static DataTable ShowIncludeOrderProducts()
		{
			string sql = "SELECT * FROM IncludeOrderProducts";
			DataTable dt = ConnectionString.SelectQuery(sql);
			return dt;
		}

		private void GoodsDeliveryNote_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM OrderReceipt";
            DataTable dt = ConnectionString.SelectQuery(sql);
            dataGridView1.DataSource = dt;
        }

        private void buttonPrintInvoices_Click(object sender, EventArgs e)
        {
			string sql = "SELECT * FROM OrderReceipt WHERE status = 'confirmed'";
			DataTable data = ConnectionString.SelectQuery(sql);
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
			saveFileDialog.FileName = "Result.pdf";

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Document document = new Document();
				PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
				document.Open();
				PdfPTable table = new PdfPTable(data.Columns.Count);
				foreach (DataColumn column in data.Columns)
				{
					table.AddCell(new Phrase(column.ColumnName));
				}
				foreach (DataRow row in data.Rows)
				{
					foreach (object cell in row.ItemArray)
					{
						table.AddCell(new Phrase(cell.ToString()));
					}
				}
				document.Add(table);
				document.Close();
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            WarehouseStatistics ws = new WarehouseStatistics();
            ws.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Warehouse wh = new Warehouse();
            wh.Show();
        }

        private void buttonBeingTransported_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != dataGridView1.RowCount - 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string sql = "UPDATE OrderReceipt SET OrderStatus = 'being transferred' WHERE OrderID = " + id;
                ConnectionString.ActionQuery(sql);
                string sqlstr = "SELECT * FROM OrderReceipt";
                DataTable dt = ConnectionString.SelectQuery(sqlstr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please choose an Order");
            }
            
        }

        private void buttonUpdatePayment_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != dataGridView1.RowCount - 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string sql = "UPDATE OrderReceipt SET Status = 'confirmed' WHERE OrderID = " + id;
                ConnectionString.ActionQuery(sql);
                string sqlstr = "SELECT * FROM OrderReceipt";
                DataTable dt = ConnectionString.SelectQuery(sqlstr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please choose an Order");
            }

        }

		private void buttonShowAllOrderProduct_Click(object sender, EventArgs e)
		{
			DataTable dt = ShowIncludeOrderProducts();
			dataGridView1.DataSource = dt;
		}
	}
}
