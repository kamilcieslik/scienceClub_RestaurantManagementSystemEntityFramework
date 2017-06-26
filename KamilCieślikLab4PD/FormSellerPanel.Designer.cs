namespace KamilCieślikLab4PD
{
    partial class FormSellerPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSellerPanel));
            this.buttonBuckets = new System.Windows.Forms.Button();
            this.buttonBigBoxes = new System.Windows.Forms.Button();
            this.buttonSets = new System.Windows.Forms.Button();
            this.buttonSandwiches = new System.Windows.Forms.Button();
            this.buttonSalads = new System.Windows.Forms.Button();
            this.buttonDrinks = new System.Windows.Forms.Button();
            this.dataGridViewListOfProducts = new System.Windows.Forms.DataGridView();
            this.dataGridViewNewOrderListOfProducts = new System.Windows.Forms.DataGridView();
            this.buttonAcceptNewOrder = new System.Windows.Forms.Button();
            this.buttonDeleteSelectedProductFromNewOrder = new System.Windows.Forms.Button();
            this.labelNewOrderListOfProducts = new System.Windows.Forms.Label();
            this.labelListOfProducts = new System.Windows.Forms.Label();
            this.labelSeller = new System.Windows.Forms.Label();
            this.labelCurrentSellerNameAndSurname = new System.Windows.Forms.Label();
            this.buttonLogoutFromSellerPanel = new System.Windows.Forms.Button();
            this.buttonAddProductToNewOrderListOfProducts = new System.Windows.Forms.Button();
            this.pictureBoxArrowFromProductsListToOrderProductsList = new System.Windows.Forms.PictureBox();
            this.labelActualPrice = new System.Windows.Forms.Label();
            this.labelActualAmountOfCalories = new System.Windows.Forms.Label();
            this.labelActualSumPrice = new System.Windows.Forms.Label();
            this.labelActualSumAmountOfCalories = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListOfProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNewOrderListOfProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowFromProductsListToOrderProductsList)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBuckets
            // 
            this.buttonBuckets.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBuckets.BackgroundImage")));
            this.buttonBuckets.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBuckets.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuckets.ForeColor = System.Drawing.Color.Black;
            this.buttonBuckets.Location = new System.Drawing.Point(39, 158);
            this.buttonBuckets.Name = "buttonBuckets";
            this.buttonBuckets.Size = new System.Drawing.Size(130, 130);
            this.buttonBuckets.TabIndex = 0;
            this.buttonBuckets.Text = "Kubełki";
            this.buttonBuckets.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonBuckets.UseVisualStyleBackColor = true;
            this.buttonBuckets.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // buttonBigBoxes
            // 
            this.buttonBigBoxes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBigBoxes.BackgroundImage")));
            this.buttonBigBoxes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBigBoxes.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBigBoxes.ForeColor = System.Drawing.Color.Black;
            this.buttonBigBoxes.Location = new System.Drawing.Point(175, 158);
            this.buttonBigBoxes.Name = "buttonBigBoxes";
            this.buttonBigBoxes.Size = new System.Drawing.Size(130, 130);
            this.buttonBigBoxes.TabIndex = 1;
            this.buttonBigBoxes.Text = "Big Boxy";
            this.buttonBigBoxes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonBigBoxes.UseVisualStyleBackColor = true;
            this.buttonBigBoxes.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // buttonSets
            // 
            this.buttonSets.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSets.BackgroundImage")));
            this.buttonSets.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSets.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSets.ForeColor = System.Drawing.Color.Black;
            this.buttonSets.Location = new System.Drawing.Point(311, 158);
            this.buttonSets.Name = "buttonSets";
            this.buttonSets.Size = new System.Drawing.Size(130, 130);
            this.buttonSets.TabIndex = 2;
            this.buttonSets.Text = "Zestawy";
            this.buttonSets.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSets.UseVisualStyleBackColor = true;
            this.buttonSets.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // buttonSandwiches
            // 
            this.buttonSandwiches.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSandwiches.BackgroundImage")));
            this.buttonSandwiches.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSandwiches.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSandwiches.ForeColor = System.Drawing.Color.Black;
            this.buttonSandwiches.Location = new System.Drawing.Point(39, 294);
            this.buttonSandwiches.Name = "buttonSandwiches";
            this.buttonSandwiches.Size = new System.Drawing.Size(130, 130);
            this.buttonSandwiches.TabIndex = 3;
            this.buttonSandwiches.Text = "Kanapki";
            this.buttonSandwiches.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSandwiches.UseVisualStyleBackColor = true;
            this.buttonSandwiches.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // buttonSalads
            // 
            this.buttonSalads.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSalads.BackgroundImage")));
            this.buttonSalads.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalads.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalads.ForeColor = System.Drawing.Color.Black;
            this.buttonSalads.Location = new System.Drawing.Point(175, 294);
            this.buttonSalads.Name = "buttonSalads";
            this.buttonSalads.Size = new System.Drawing.Size(130, 130);
            this.buttonSalads.TabIndex = 4;
            this.buttonSalads.Text = "Sałatki";
            this.buttonSalads.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSalads.UseVisualStyleBackColor = true;
            this.buttonSalads.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // buttonDrinks
            // 
            this.buttonDrinks.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDrinks.BackgroundImage")));
            this.buttonDrinks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDrinks.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDrinks.ForeColor = System.Drawing.Color.Black;
            this.buttonDrinks.Location = new System.Drawing.Point(311, 294);
            this.buttonDrinks.Name = "buttonDrinks";
            this.buttonDrinks.Size = new System.Drawing.Size(130, 130);
            this.buttonDrinks.TabIndex = 5;
            this.buttonDrinks.Text = "Napoje";
            this.buttonDrinks.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDrinks.UseVisualStyleBackColor = true;
            this.buttonDrinks.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // dataGridViewListOfProducts
            // 
            this.dataGridViewListOfProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListOfProducts.Location = new System.Drawing.Point(503, 158);
            this.dataGridViewListOfProducts.MultiSelect = false;
            this.dataGridViewListOfProducts.Name = "dataGridViewListOfProducts";
            this.dataGridViewListOfProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListOfProducts.Size = new System.Drawing.Size(490, 266);
            this.dataGridViewListOfProducts.TabIndex = 6;
            // 
            // dataGridViewNewOrderListOfProducts
            // 
            this.dataGridViewNewOrderListOfProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNewOrderListOfProducts.Location = new System.Drawing.Point(1110, 158);
            this.dataGridViewNewOrderListOfProducts.MultiSelect = false;
            this.dataGridViewNewOrderListOfProducts.Name = "dataGridViewNewOrderListOfProducts";
            this.dataGridViewNewOrderListOfProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewNewOrderListOfProducts.Size = new System.Drawing.Size(490, 266);
            this.dataGridViewNewOrderListOfProducts.TabIndex = 7;
            // 
            // buttonAcceptNewOrder
            // 
            this.buttonAcceptNewOrder.Location = new System.Drawing.Point(1360, 499);
            this.buttonAcceptNewOrder.Name = "buttonAcceptNewOrder";
            this.buttonAcceptNewOrder.Size = new System.Drawing.Size(240, 38);
            this.buttonAcceptNewOrder.TabIndex = 8;
            this.buttonAcceptNewOrder.Text = "Akceptuj zamówienie";
            this.buttonAcceptNewOrder.UseVisualStyleBackColor = true;
            this.buttonAcceptNewOrder.Click += new System.EventHandler(this.buttonAcceptNewOrder_Click);
            // 
            // buttonDeleteSelectedProductFromNewOrder
            // 
            this.buttonDeleteSelectedProductFromNewOrder.Location = new System.Drawing.Point(1110, 499);
            this.buttonDeleteSelectedProductFromNewOrder.Name = "buttonDeleteSelectedProductFromNewOrder";
            this.buttonDeleteSelectedProductFromNewOrder.Size = new System.Drawing.Size(240, 38);
            this.buttonDeleteSelectedProductFromNewOrder.TabIndex = 9;
            this.buttonDeleteSelectedProductFromNewOrder.Text = "Usuń zaznaczony produkt z zamówienia";
            this.buttonDeleteSelectedProductFromNewOrder.UseVisualStyleBackColor = true;
            this.buttonDeleteSelectedProductFromNewOrder.Click += new System.EventHandler(this.buttonDeleteSelectedProductFromNewOrder_Click);
            // 
            // labelNewOrderListOfProducts
            // 
            this.labelNewOrderListOfProducts.AutoSize = true;
            this.labelNewOrderListOfProducts.Location = new System.Drawing.Point(1107, 127);
            this.labelNewOrderListOfProducts.Name = "labelNewOrderListOfProducts";
            this.labelNewOrderListOfProducts.Size = new System.Drawing.Size(96, 13);
            this.labelNewOrderListOfProducts.TabIndex = 10;
            this.labelNewOrderListOfProducts.Text = "Nowe zamówienie:";
            // 
            // labelListOfProducts
            // 
            this.labelListOfProducts.AutoSize = true;
            this.labelListOfProducts.Location = new System.Drawing.Point(500, 127);
            this.labelListOfProducts.Name = "labelListOfProducts";
            this.labelListOfProducts.Size = new System.Drawing.Size(131, 13);
            this.labelListOfProducts.TabIndex = 11;
            this.labelListOfProducts.Text = "List produktów do wyboru:";
            // 
            // labelSeller
            // 
            this.labelSeller.AutoSize = true;
            this.labelSeller.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSeller.Location = new System.Drawing.Point(33, 54);
            this.labelSeller.Name = "labelSeller";
            this.labelSeller.Size = new System.Drawing.Size(172, 31);
            this.labelSeller.TabIndex = 12;
            this.labelSeller.Text = "Sprzedawca:";
            // 
            // labelCurrentSellerNameAndSurname
            // 
            this.labelCurrentSellerNameAndSurname.AutoSize = true;
            this.labelCurrentSellerNameAndSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCurrentSellerNameAndSurname.Location = new System.Drawing.Point(284, 54);
            this.labelCurrentSellerNameAndSurname.Name = "labelCurrentSellerNameAndSurname";
            this.labelCurrentSellerNameAndSurname.Size = new System.Drawing.Size(196, 31);
            this.labelCurrentSellerNameAndSurname.TabIndex = 13;
            this.labelCurrentSellerNameAndSurname.Text = "imię i nazwisko";
            // 
            // buttonLogoutFromSellerPanel
            // 
            this.buttonLogoutFromSellerPanel.Location = new System.Drawing.Point(39, 448);
            this.buttonLogoutFromSellerPanel.Name = "buttonLogoutFromSellerPanel";
            this.buttonLogoutFromSellerPanel.Size = new System.Drawing.Size(402, 38);
            this.buttonLogoutFromSellerPanel.TabIndex = 14;
            this.buttonLogoutFromSellerPanel.Text = "Wyloguj z kasy";
            this.buttonLogoutFromSellerPanel.UseVisualStyleBackColor = true;
            this.buttonLogoutFromSellerPanel.Click += new System.EventHandler(this.buttonLogoutFromSellerPanel_Click);
            // 
            // buttonAddProductToNewOrderListOfProducts
            // 
            this.buttonAddProductToNewOrderListOfProducts.Location = new System.Drawing.Point(503, 448);
            this.buttonAddProductToNewOrderListOfProducts.Name = "buttonAddProductToNewOrderListOfProducts";
            this.buttonAddProductToNewOrderListOfProducts.Size = new System.Drawing.Size(490, 38);
            this.buttonAddProductToNewOrderListOfProducts.TabIndex = 15;
            this.buttonAddProductToNewOrderListOfProducts.Text = "Dodaj zaznaczony produkt do zamówienia";
            this.buttonAddProductToNewOrderListOfProducts.UseVisualStyleBackColor = true;
            this.buttonAddProductToNewOrderListOfProducts.Click += new System.EventHandler(this.buttonAddProductToNewOrderListOfProducts_Click);
            // 
            // pictureBoxArrowFromProductsListToOrderProductsList
            // 
            this.pictureBoxArrowFromProductsListToOrderProductsList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxArrowFromProductsListToOrderProductsList.BackgroundImage")));
            this.pictureBoxArrowFromProductsListToOrderProductsList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxArrowFromProductsListToOrderProductsList.Location = new System.Drawing.Point(999, 264);
            this.pictureBoxArrowFromProductsListToOrderProductsList.Name = "pictureBoxArrowFromProductsListToOrderProductsList";
            this.pictureBoxArrowFromProductsListToOrderProductsList.Size = new System.Drawing.Size(105, 50);
            this.pictureBoxArrowFromProductsListToOrderProductsList.TabIndex = 16;
            this.pictureBoxArrowFromProductsListToOrderProductsList.TabStop = false;
            // 
            // labelActualPrice
            // 
            this.labelActualPrice.AutoSize = true;
            this.labelActualPrice.Location = new System.Drawing.Point(1107, 461);
            this.labelActualPrice.Name = "labelActualPrice";
            this.labelActualPrice.Size = new System.Drawing.Size(79, 13);
            this.labelActualPrice.TabIndex = 17;
            this.labelActualPrice.Text = "Aktualna cena:";
            // 
            // labelActualAmountOfCalories
            // 
            this.labelActualAmountOfCalories.AutoSize = true;
            this.labelActualAmountOfCalories.Location = new System.Drawing.Point(1357, 461);
            this.labelActualAmountOfCalories.Name = "labelActualAmountOfCalories";
            this.labelActualAmountOfCalories.Size = new System.Drawing.Size(106, 13);
            this.labelActualAmountOfCalories.TabIndex = 18;
            this.labelActualAmountOfCalories.Text = "Aktualna ilość kalorii:";
            // 
            // labelActualSumPrice
            // 
            this.labelActualSumPrice.AutoSize = true;
            this.labelActualSumPrice.Location = new System.Drawing.Point(1217, 461);
            this.labelActualSumPrice.Name = "labelActualSumPrice";
            this.labelActualSumPrice.Size = new System.Drawing.Size(13, 13);
            this.labelActualSumPrice.TabIndex = 19;
            this.labelActualSumPrice.Text = "0";
            // 
            // labelActualSumAmountOfCalories
            // 
            this.labelActualSumAmountOfCalories.AutoSize = true;
            this.labelActualSumAmountOfCalories.Location = new System.Drawing.Point(1499, 461);
            this.labelActualSumAmountOfCalories.Name = "labelActualSumAmountOfCalories";
            this.labelActualSumAmountOfCalories.Size = new System.Drawing.Size(13, 13);
            this.labelActualSumAmountOfCalories.TabIndex = 20;
            this.labelActualSumAmountOfCalories.Text = "0";
            // 
            // FormSellerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1639, 549);
            this.Controls.Add(this.labelActualSumAmountOfCalories);
            this.Controls.Add(this.labelActualSumPrice);
            this.Controls.Add(this.labelActualAmountOfCalories);
            this.Controls.Add(this.labelActualPrice);
            this.Controls.Add(this.pictureBoxArrowFromProductsListToOrderProductsList);
            this.Controls.Add(this.buttonAddProductToNewOrderListOfProducts);
            this.Controls.Add(this.buttonLogoutFromSellerPanel);
            this.Controls.Add(this.labelCurrentSellerNameAndSurname);
            this.Controls.Add(this.labelSeller);
            this.Controls.Add(this.labelListOfProducts);
            this.Controls.Add(this.labelNewOrderListOfProducts);
            this.Controls.Add(this.buttonDeleteSelectedProductFromNewOrder);
            this.Controls.Add(this.buttonAcceptNewOrder);
            this.Controls.Add(this.dataGridViewNewOrderListOfProducts);
            this.Controls.Add(this.dataGridViewListOfProducts);
            this.Controls.Add(this.buttonDrinks);
            this.Controls.Add(this.buttonSalads);
            this.Controls.Add(this.buttonSandwiches);
            this.Controls.Add(this.buttonSets);
            this.Controls.Add(this.buttonBigBoxes);
            this.Controls.Add(this.buttonBuckets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSellerPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seller Panel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListOfProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNewOrderListOfProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowFromProductsListToOrderProductsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBuckets;
        private System.Windows.Forms.Button buttonBigBoxes;
        private System.Windows.Forms.Button buttonSets;
        private System.Windows.Forms.Button buttonSandwiches;
        private System.Windows.Forms.Button buttonSalads;
        private System.Windows.Forms.Button buttonDrinks;
        private System.Windows.Forms.DataGridView dataGridViewListOfProducts;
        private System.Windows.Forms.DataGridView dataGridViewNewOrderListOfProducts;
        private System.Windows.Forms.Button buttonAcceptNewOrder;
        private System.Windows.Forms.Button buttonDeleteSelectedProductFromNewOrder;
        private System.Windows.Forms.Label labelNewOrderListOfProducts;
        private System.Windows.Forms.Label labelListOfProducts;
        private System.Windows.Forms.Label labelSeller;
        private System.Windows.Forms.Label labelCurrentSellerNameAndSurname;
        private System.Windows.Forms.Button buttonLogoutFromSellerPanel;
        private System.Windows.Forms.Button buttonAddProductToNewOrderListOfProducts;
        private System.Windows.Forms.PictureBox pictureBoxArrowFromProductsListToOrderProductsList;
        private System.Windows.Forms.Label labelActualPrice;
        private System.Windows.Forms.Label labelActualAmountOfCalories;
        private System.Windows.Forms.Label labelActualSumPrice;
        private System.Windows.Forms.Label labelActualSumAmountOfCalories;
    }
}