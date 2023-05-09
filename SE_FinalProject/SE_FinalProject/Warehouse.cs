using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SE_FinalProject
{
    public partial class Warehouse : Form
    {
        public Warehouse()
        {
            InitializeComponent();
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            textBoxProductName.Focus();
        }

        public static string AddOrUpdateProduct(string productID, string productName, int productPrice, int productQuantity)
        {
            string sql = "SELECT * FROM Product WHERE ProductName = '" + productName + "'";
            DataTable dt = ConnectionString.SelectQuery(sql);
            if (dt != null)
            {
                int oldProductQuantity = int.Parse(dt.Rows[0][3].ToString());
                int newProductQuantity = oldProductQuantity + productQuantity;
                sql = "UPDATE Product SET ProductQuantity = " + newProductQuantity + " WHERE productID = '" + dt.Rows[0][0].ToString() + "'";
                ConnectionString.ActionQuery(sql);
                return dt.Rows[0][0].ToString();
            }
            else
            {
                sql = "INSERT INTO Product VALUES ('" + productID + "', '" + productName + "', " + productPrice + ", " + productQuantity + ")";
                ConnectionString.ActionQuery(sql);
                return "";
            }
        }

        public static string GetNewProductID()
        {
            string sql = "SELECT MAX(ProductID) FROM Product";
            DataTable dt = ConnectionString.SelectQuery(sql);
            string maxProductID = dt.Rows[0][0].ToString();
            int newProductID = int.Parse(maxProductID.Substring(1)) + 1;
            return "P" + newProductID.ToString("D3");
        }

        public static void CreateWareHouseReceipt(int totalProductQuantity, int totalProductPrice, string orderedDate)
        {
            string[] orderedDates = new string[100];
            string sql = "select * from WareHouseReceipt";
            DataTable dt = ConnectionString.SelectQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                orderedDates[i] = dt.Rows[i][3].ToString();
            }
            bool isExist = false;
            for (int i = 0; i < orderedDates.Length; i++)
            {
                if (orderedDates[i] == orderedDate)
                {
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                sql = "INSERT INTO WareHouseReceipt VALUES (" + totalProductQuantity + ", " + totalProductPrice + ", '" + orderedDate + "')";
                ConnectionString.ActionQuery(sql);

            }
            else
            {
                sql = "select * from WareHouseReceipt where CreatedDate = '" + orderedDate + "'";
                dt = ConnectionString.SelectQuery(sql);
                int oldTotalProductQuantity = int.Parse(dt.Rows[0][0].ToString());
                int oldTotalProductPrice = int.Parse(dt.Rows[0][1].ToString());
                int newTotalProductQuantity = oldTotalProductQuantity + totalProductQuantity;
                int newTotalProductPrice = oldTotalProductPrice + totalProductPrice;
                sql = "UPDATE WareHouseReceipt SET TotalProductQuantity = " + newTotalProductQuantity + ", TotalProductPrice = " + newTotalProductPrice + " WHERE CreatedDate = '" + orderedDate + "'";
                ConnectionString.ActionQuery(sql);
            }

        }

        public static string GetReceiptIDFromWareHouseReceipt(string orderedDate)
        {
            string sql = "SELECT ReceiptID FROM WareHouseReceipt WHERE CreatedDate = '" + orderedDate + "'";
            DataTable dt = ConnectionString.SelectQuery(sql);
            string ReceiptID = dt.Rows[0][0].ToString();
            return ReceiptID;
        }

        public static DataTable ShowAllProducts()
        {
            string sql = "SELECT * FROM Product";
            DataTable dt = ConnectionString.SelectQuery(sql);
            return dt;
        }

		public static void CreateIncludeImportedProducts(int totalProductQuantity, int totalProductPrice, string ReceiptID, string productID)
		{
			string sql = "SELECT * FROM IncludeImportedProducts WHERE ProductID = '" + productID + "'";
			DataTable dt = ConnectionString.SelectQuery(sql);
			if (dt != null)
			{
				int oldProductQuantity = int.Parse(dt.Rows[0][0].ToString());
				int oldProductPrice = int.Parse(dt.Rows[0][1].ToString());
				int newProductQuantity = oldProductQuantity + totalProductQuantity;
				int newProductPrice = oldProductPrice + totalProductPrice;
				sql = "UPDATE IncludeImportedProducts SET TotalProductQuantity = " + newProductQuantity + ", TotalProductPrice = " + newProductPrice + " WHERE ProductID = '" + productID + "'";
				ConnectionString.ActionQuery(sql);
			}
			else
			{
				sql = "INSERT INTO IncludeImportedProducts VALUES (" + totalProductQuantity + ", " + totalProductPrice + ", '" + ReceiptID + "', '" + productID + "')";
				ConnectionString.ActionQuery(sql);
			}
		}

		private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (textBoxProductName.Text == "" || textBoxProductPrice.Text == "" || textBoxProductQuantity.Text == "")
            {
                MessageBox.Show("Please enter all information!");
            }
            else
            {
				string newProductID = GetNewProductID();
				string check = AddOrUpdateProduct(newProductID, textBoxProductName.Text, int.Parse(textBoxProductPrice.Text), int.Parse(textBoxProductQuantity.Text));
				if (check != "")
				{
					newProductID = check;
				}
				CreateWareHouseReceipt(int.Parse(textBoxProductQuantity.Text), int.Parse(textBoxProductPrice.Text), DateTime.Now.ToString("yyyy-MM-dd"));
				string newReceiptID = GetReceiptIDFromWareHouseReceipt(DateTime.Now.ToString("yyyy-MM-dd"));
				CreateIncludeImportedProducts(int.Parse(textBoxProductQuantity.Text), int.Parse(textBoxProductPrice.Text), newReceiptID, newProductID);
				dataGridViewListProduct.DataSource = ShowAllProducts();
			}

            textBoxProductName.Clear();
            textBoxProductQuantity.Clear();
            textBoxProductPrice.Clear();
        }

        public static DataTable ShowWarehouseReceipt()
        {
            string sql = "SELECT * FROM WarehouseReceipt";
            DataTable dt = ConnectionString.SelectQuery(sql);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewWarehouseReceipt.DataSource = ShowWarehouseReceipt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            WarehouseStatistics ws = new WarehouseStatistics();
            ws.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            GoodsDeliveryNote gd = new GoodsDeliveryNote();
            gd.Show();
        }
    }
}
