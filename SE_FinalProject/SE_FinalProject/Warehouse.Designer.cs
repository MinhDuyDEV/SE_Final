namespace SE_FinalProject
{
    partial class Warehouse
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
            this.groupBoxProductInformation = new System.Windows.Forms.GroupBox();
            this.textBoxProductQuantity = new System.Windows.Forms.TextBox();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.textBoxProductPrice = new System.Windows.Forms.TextBox();
            this.labelProductQuantity = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelProductPrice = new System.Windows.Forms.Label();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.groupBoxListProduct = new System.Windows.Forms.GroupBox();
            this.dataGridViewListProduct = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewWarehouseReceipt = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBoxProductInformation.SuspendLayout();
            this.groupBoxListProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListProduct)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouseReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxProductInformation
            // 
            this.groupBoxProductInformation.Controls.Add(this.textBoxProductQuantity);
            this.groupBoxProductInformation.Controls.Add(this.textBoxProductName);
            this.groupBoxProductInformation.Controls.Add(this.textBoxProductPrice);
            this.groupBoxProductInformation.Controls.Add(this.labelProductQuantity);
            this.groupBoxProductInformation.Controls.Add(this.labelProductName);
            this.groupBoxProductInformation.Controls.Add(this.labelProductPrice);
            this.groupBoxProductInformation.Location = new System.Drawing.Point(329, 11);
            this.groupBoxProductInformation.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxProductInformation.Name = "groupBoxProductInformation";
            this.groupBoxProductInformation.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxProductInformation.Size = new System.Drawing.Size(577, 150);
            this.groupBoxProductInformation.TabIndex = 0;
            this.groupBoxProductInformation.TabStop = false;
            this.groupBoxProductInformation.Text = "Product Information";
            // 
            // textBoxProductQuantity
            // 
            this.textBoxProductQuantity.Location = new System.Drawing.Point(360, 84);
            this.textBoxProductQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProductQuantity.Name = "textBoxProductQuantity";
            this.textBoxProductQuantity.Size = new System.Drawing.Size(143, 20);
            this.textBoxProductQuantity.TabIndex = 12;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(235, 29);
            this.textBoxProductName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(143, 20);
            this.textBoxProductName.TabIndex = 11;
            // 
            // textBoxProductPrice
            // 
            this.textBoxProductPrice.Location = new System.Drawing.Point(90, 84);
            this.textBoxProductPrice.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProductPrice.Name = "textBoxProductPrice";
            this.textBoxProductPrice.Size = new System.Drawing.Size(116, 20);
            this.textBoxProductPrice.TabIndex = 10;
            // 
            // labelProductQuantity
            // 
            this.labelProductQuantity.AutoSize = true;
            this.labelProductQuantity.Location = new System.Drawing.Point(310, 87);
            this.labelProductQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProductQuantity.Name = "labelProductQuantity";
            this.labelProductQuantity.Size = new System.Drawing.Size(46, 13);
            this.labelProductQuantity.TabIndex = 3;
            this.labelProductQuantity.Text = "Quantity";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(158, 32);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(73, 13);
            this.labelProductName.TabIndex = 2;
            this.labelProductName.Text = "Product name";
            // 
            // labelProductPrice
            // 
            this.labelProductPrice.AutoSize = true;
            this.labelProductPrice.Location = new System.Drawing.Point(55, 87);
            this.labelProductPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProductPrice.Name = "labelProductPrice";
            this.labelProductPrice.Size = new System.Drawing.Size(31, 13);
            this.labelProductPrice.TabIndex = 1;
            this.labelProductPrice.Text = "Price";
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(329, 205);
            this.buttonAddProduct.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(106, 50);
            this.buttonAddProduct.TabIndex = 1;
            this.buttonAddProduct.Text = "Add Product";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // groupBoxListProduct
            // 
            this.groupBoxListProduct.Controls.Add(this.dataGridViewListProduct);
            this.groupBoxListProduct.Location = new System.Drawing.Point(22, 291);
            this.groupBoxListProduct.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxListProduct.Name = "groupBoxListProduct";
            this.groupBoxListProduct.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxListProduct.Size = new System.Drawing.Size(577, 384);
            this.groupBoxListProduct.TabIndex = 4;
            this.groupBoxListProduct.TabStop = false;
            this.groupBoxListProduct.Text = "List Product";
            // 
            // dataGridViewListProduct
            // 
            this.dataGridViewListProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListProduct.Location = new System.Drawing.Point(4, 27);
            this.dataGridViewListProduct.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewListProduct.Name = "dataGridViewListProduct";
            this.dataGridViewListProduct.RowHeadersWidth = 51;
            this.dataGridViewListProduct.RowTemplate.Height = 24;
            this.dataGridViewListProduct.Size = new System.Drawing.Size(555, 353);
            this.dataGridViewListProduct.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewWarehouseReceipt);
            this.groupBox1.Location = new System.Drawing.Point(663, 291);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(577, 384);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Warehouse Receipt";
            // 
            // dataGridViewWarehouseReceipt
            // 
            this.dataGridViewWarehouseReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouseReceipt.Location = new System.Drawing.Point(4, 27);
            this.dataGridViewWarehouseReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewWarehouseReceipt.Name = "dataGridViewWarehouseReceipt";
            this.dataGridViewWarehouseReceipt.RowHeadersWidth = 51;
            this.dataGridViewWarehouseReceipt.RowTemplate.Height = 24;
            this.dataGridViewWarehouseReceipt.Size = new System.Drawing.Size(555, 353);
            this.dataGridViewWarehouseReceipt.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(800, 205);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Warehouse Receipt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1144, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Statistics =>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1144, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "DeliveryNote =>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 702);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxListProduct);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.groupBoxProductInformation);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Warehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse";
            this.Load += new System.EventHandler(this.Warehouse_Load);
            this.groupBoxProductInformation.ResumeLayout(false);
            this.groupBoxProductInformation.PerformLayout();
            this.groupBoxListProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListProduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouseReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProductInformation;
        private System.Windows.Forms.TextBox textBoxProductQuantity;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.TextBox textBoxProductPrice;
        private System.Windows.Forms.Label labelProductQuantity;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelProductPrice;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.GroupBox groupBoxListProduct;
        private System.Windows.Forms.DataGridView dataGridViewListProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewWarehouseReceipt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}