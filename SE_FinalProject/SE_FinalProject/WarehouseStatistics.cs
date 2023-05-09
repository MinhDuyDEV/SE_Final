using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_FinalProject
{
    public partial class WarehouseStatistics : Form
    {
        public WarehouseStatistics()
        {
            InitializeComponent();
        }
        private bool check()
        {
            if (textBoxMonth.Text == "")
            {
                MessageBox.Show("Please enter month");
                return false;
            }
            return true;
        }

        private void buttonStockReport_Click(object sender, EventArgs e)
        {
            var month = textBoxMonth.Text;
            if (check())
            {
                string sql = "SELECT YEAR(CreatedDate) AS Year, MONTH(CreatedDate) AS Month, ProductID, SUM(TotalProductQuantity) AS TotalQuantityImported, 0 AS TotalQuantitySold FROM IncludeImportedProducts JOIN WarehouseReceipt ON IncludeImportedProducts.ReceiptID = WarehouseReceipt.ReceiptID WHERE MONTH(CreatedDate) = " + month + " GROUP BY YEAR(CreatedDate), MONTH(CreatedDate), ProductID UNION SELECT YEAR(OrderedDate) AS Year, MONTH(OrderedDate) AS Month, ProductID, 0 AS TotalQuantityImported, SUM(TotalProductQuantity) AS TotalQuantitySold FROM IncludeOrderProducts JOIN OrderReceipt ON IncludeOrderProducts.OrderID = OrderReceipt.OrderID WHERE MONTH(OrderedDate) = " + month + " GROUP BY YEAR(OrderedDate), MONTH(OrderedDate), ProductID; ";
                DataTable dt = ConnectionString.SelectQuery(sql);
                dataGridViewWarehouseStatistics.DataSource = dt;
            }
        }

        private void buttonBestSelling_Click(object sender, EventArgs e)
        {
            var month = textBoxMonth.Text;
            if (check())
            {
                string sql = "SELECT YEAR(OrderedDate) AS Year, MONTH(OrderedDate) AS Month, ProductID, SUM(TotalProductQuantity) AS TotalQuantitySold FROM IncludeOrderProducts JOIN OrderReceipt ON IncludeOrderProducts.OrderID = OrderReceipt.OrderID WHERE MONTH(OrderedDate) = " + month + " GROUP BY YEAR(OrderedDate), MONTH(OrderedDate), ProductID ORDER BY TotalQuantitySold DESC;";
                DataTable dt = ConnectionString.SelectQuery(sql);
                dataGridViewWarehouseStatistics.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Warehouse wh = new Warehouse();
            wh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GoodsDeliveryNote gd = new GoodsDeliveryNote();
            gd.Show();
        }
    }
}
