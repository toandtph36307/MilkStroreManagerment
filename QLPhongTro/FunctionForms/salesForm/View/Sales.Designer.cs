namespace QLPhongTro.FunctionForms.salesForm.View
{
    partial class Sales
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
            this.tabControlOrders = new Guna.UI2.WinForms.Guna2TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstProductSuggestion = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbnDebt = new System.Windows.Forms.RadioButton();
            this.rbnReturnCus = new System.Windows.Forms.RadioButton();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblVND = new System.Windows.Forms.Label();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.btnPayPrinter = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBox3 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDiscount = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCusPay = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCashChange = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalAfterDiscount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TS_Discount = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstCustomerSuggestion = new System.Windows.Forms.ListBox();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomersSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlOrders
            // 
            this.tabControlOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOrders.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControlOrders.Location = new System.Drawing.Point(0, 0);
            this.tabControlOrders.Name = "tabControlOrders";
            this.tabControlOrders.SelectedIndex = 0;
            this.tabControlOrders.Size = new System.Drawing.Size(863, 631);
            this.tabControlOrders.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlOrders.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControlOrders.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlOrders.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabControlOrders.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControlOrders.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlOrders.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControlOrders.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlOrders.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabControlOrders.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControlOrders.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlOrders.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tabControlOrders.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlOrders.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabControlOrders.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tabControlOrders.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabControlOrders.TabIndex = 0;
            this.tabControlOrders.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControlOrders.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tabControlOrders.SelectedIndexChanged += new System.EventHandler(this.tabControlOrders_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.lstProductSuggestion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSearchProduct);
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 53);
            this.panel1.TabIndex = 1;
            // 
            // lstProductSuggestion
            // 
            this.lstProductSuggestion.FormattingEnabled = true;
            this.lstProductSuggestion.ItemHeight = 16;
            this.lstProductSuggestion.Location = new System.Drawing.Point(191, 46);
            this.lstProductSuggestion.Name = "lstProductSuggestion";
            this.lstProductSuggestion.Size = new System.Drawing.Size(662, 4);
            this.lstProductSuggestion.TabIndex = 3;
            this.lstProductSuggestion.Click += new System.EventHandler(this.lstProductSuggestion_Click);
            this.lstProductSuggestion.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstProductSuggestion_DrawItem);
            this.lstProductSuggestion.Leave += new System.EventHandler(this.lstProductSuggestion_Leave);
            this.lstProductSuggestion.MouseLeave += new System.EventHandler(this.lstProductSuggestion_MouseLeave);
            this.lstProductSuggestion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstProductSuggestion_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "SEARCH";
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.BorderRadius = 15;
            this.txtSearchProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchProduct.DefaultText = "";
            this.txtSearchProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchProduct.ForeColor = System.Drawing.Color.Black;
            this.txtSearchProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.Location = new System.Drawing.Point(191, 13);
            this.txtSearchProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PlaceholderText = "";
            this.txtSearchProduct.SelectedText = "";
            this.txtSearchProduct.Size = new System.Drawing.Size(662, 32);
            this.txtSearchProduct.TabIndex = 1;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(982, 13);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 32);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "Add New Ordertab";
            this.guna2Button1.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbnDebt);
            this.panel2.Controls.Add(this.rbnReturnCus);
            this.panel2.Controls.Add(this.lblPercent);
            this.panel2.Controls.Add(this.lblVND);
            this.panel2.Controls.Add(this.guna2Button3);
            this.panel2.Controls.Add(this.btnPayPrinter);
            this.panel2.Controls.Add(this.guna2TextBox3);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.txtDiscount);
            this.panel2.Controls.Add(this.txtCusPay);
            this.panel2.Controls.Add(this.lblCashChange);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblTotalAfterDiscount);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TS_Discount);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblTotalMoney);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lstCustomerSuggestion);
            this.panel2.Controls.Add(this.lblCustomers);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCustomersSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(863, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 631);
            this.panel2.TabIndex = 2;
            // 
            // rbnDebt
            // 
            this.rbnDebt.AutoSize = true;
            this.rbnDebt.FlatAppearance.BorderSize = 2;
            this.rbnDebt.Font = new System.Drawing.Font("Showcard Gothic", 9F);
            this.rbnDebt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.rbnDebt.Location = new System.Drawing.Point(21, 454);
            this.rbnDebt.Name = "rbnDebt";
            this.rbnDebt.Size = new System.Drawing.Size(68, 22);
            this.rbnDebt.TabIndex = 34;
            this.rbnDebt.Text = "Debt";
            this.rbnDebt.UseVisualStyleBackColor = true;
            // 
            // rbnReturnCus
            // 
            this.rbnReturnCus.AutoSize = true;
            this.rbnReturnCus.Checked = true;
            this.rbnReturnCus.FlatAppearance.BorderSize = 2;
            this.rbnReturnCus.Font = new System.Drawing.Font("Showcard Gothic", 9F);
            this.rbnReturnCus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.rbnReturnCus.Location = new System.Drawing.Point(21, 416);
            this.rbnReturnCus.Name = "rbnReturnCus";
            this.rbnReturnCus.Size = new System.Drawing.Size(194, 22);
            this.rbnReturnCus.TabIndex = 33;
            this.rbnReturnCus.TabStop = true;
            this.rbnReturnCus.Text = "Return to Customer";
            this.rbnReturnCus.UseVisualStyleBackColor = true;
            this.rbnReturnCus.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.lblPercent.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(116, 197);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(24, 21);
            this.lblPercent.TabIndex = 32;
            this.lblPercent.Text = "%";
            this.lblPercent.Visible = false;
            // 
            // lblVND
            // 
            this.lblVND.AutoSize = true;
            this.lblVND.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.lblVND.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVND.Location = new System.Drawing.Point(149, 200);
            this.lblVND.Name = "lblVND";
            this.lblVND.Size = new System.Drawing.Size(35, 17);
            this.lblVND.TabIndex = 0;
            this.lblVND.Text = "vnd";
            // 
            // guna2Button3
            // 
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(178, 574);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(130, 45);
            this.guna2Button3.TabIndex = 31;
            this.guna2Button3.Text = "guna2Button3";
            // 
            // btnPayPrinter
            // 
            this.btnPayPrinter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPayPrinter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPayPrinter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPayPrinter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPayPrinter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPayPrinter.ForeColor = System.Drawing.Color.White;
            this.btnPayPrinter.Location = new System.Drawing.Point(3, 574);
            this.btnPayPrinter.Name = "btnPayPrinter";
            this.btnPayPrinter.Size = new System.Drawing.Size(130, 45);
            this.btnPayPrinter.TabIndex = 30;
            this.btnPayPrinter.Text = "btnPayPrinter";
            this.btnPayPrinter.Click += new System.EventHandler(this.btnPayPrinter_Click);
            // 
            // guna2TextBox3
            // 
            this.guna2TextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox3.DefaultText = "";
            this.guna2TextBox3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox3.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox3.Location = new System.Drawing.Point(3, 496);
            this.guna2TextBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox3.Name = "guna2TextBox3";
            this.guna2TextBox3.PlaceholderText = "Remark";
            this.guna2TextBox3.SelectedText = "";
            this.guna2TextBox3.Size = new System.Drawing.Size(305, 57);
            this.guna2TextBox3.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Showcard Gothic", 9F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.label13.Location = new System.Drawing.Point(227, 420);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 18);
            this.label13.TabIndex = 28;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(3, 99);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(305, 1);
            this.panel6.TabIndex = 24;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(3, 236);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(305, 1);
            this.panel5.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(3, 390);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(305, 1);
            this.panel4.TabIndex = 22;
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderRadius = 15;
            this.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiscount.DefaultText = "";
            this.txtDiscount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscount.Font = new System.Drawing.Font("Showcard Gothic", 7.8F);
            this.txtDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.txtDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscount.Location = new System.Drawing.Point(192, 192);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.txtDiscount.PlaceholderText = "0";
            this.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiscount.SelectedText = "";
            this.txtDiscount.Size = new System.Drawing.Size(113, 32);
            this.txtDiscount.TabIndex = 21;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // txtCusPay
            // 
            this.txtCusPay.BorderRadius = 15;
            this.txtCusPay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCusPay.DefaultText = "";
            this.txtCusPay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCusPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCusPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusPay.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusPay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtCusPay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusPay.Font = new System.Drawing.Font("Showcard Gothic", 7.8F);
            this.txtCusPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.txtCusPay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusPay.Location = new System.Drawing.Point(76, 303);
            this.txtCusPay.Name = "txtCusPay";
            this.txtCusPay.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.txtCusPay.PlaceholderText = "0";
            this.txtCusPay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCusPay.SelectedText = "";
            this.txtCusPay.Size = new System.Drawing.Size(113, 32);
            this.txtCusPay.TabIndex = 20;
            this.txtCusPay.TextChanged += new System.EventHandler(this.txtCusPay_TextChanged);
            // 
            // lblCashChange
            // 
            this.lblCashChange.AutoSize = true;
            this.lblCashChange.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.lblCashChange.Location = new System.Drawing.Point(102, 352);
            this.lblCashChange.Name = "lblCashChange";
            this.lblCashChange.Size = new System.Drawing.Size(16, 17);
            this.lblCashChange.TabIndex = 19;
            this.lblCashChange.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.label11.Location = new System.Drawing.Point(18, 351);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 18);
            this.label11.TabIndex = 18;
            this.label11.Text = "Change : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.label9.Location = new System.Drawing.Point(18, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Paid :";
            // 
            // lblTotalAfterDiscount
            // 
            this.lblTotalAfterDiscount.AutoSize = true;
            this.lblTotalAfterDiscount.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAfterDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.lblTotalAfterDiscount.Location = new System.Drawing.Point(176, 267);
            this.lblTotalAfterDiscount.Name = "lblTotalAfterDiscount";
            this.lblTotalAfterDiscount.Size = new System.Drawing.Size(21, 23);
            this.lblTotalAfterDiscount.TabIndex = 15;
            this.lblTotalAfterDiscount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(6, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Paided Amount :";
            // 
            // TS_Discount
            // 
            this.TS_Discount.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.TS_Discount.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.TS_Discount.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.TS_Discount.CheckedState.InnerColor = System.Drawing.Color.White;
            this.TS_Discount.Location = new System.Drawing.Point(106, 186);
            this.TS_Discount.Name = "TS_Discount";
            this.TS_Discount.Size = new System.Drawing.Size(80, 44);
            this.TS_Discount.TabIndex = 11;
            this.TS_Discount.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.TS_Discount.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.TS_Discount.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.TS_Discount.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.TS_Discount.CheckedChanged += new System.EventHandler(this.TS_Discount_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.label8.Location = new System.Drawing.Point(130, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.label7.Location = new System.Drawing.Point(18, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Discount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(18, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Promotion: ";
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.lblTotalMoney.Location = new System.Drawing.Point(107, 122);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(21, 23);
            this.lblTotalMoney.TabIndex = 7;
            this.lblTotalMoney.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(6, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Amount :";
            // 
            // lstCustomerSuggestion
            // 
            this.lstCustomerSuggestion.FormattingEnabled = true;
            this.lstCustomerSuggestion.ItemHeight = 16;
            this.lstCustomerSuggestion.Location = new System.Drawing.Point(9, 44);
            this.lstCustomerSuggestion.Name = "lstCustomerSuggestion";
            this.lstCustomerSuggestion.Size = new System.Drawing.Size(290, 4);
            this.lstCustomerSuggestion.TabIndex = 5;
            this.lstCustomerSuggestion.Visible = false;
            this.lstCustomerSuggestion.Click += new System.EventHandler(this.lstCustomerSuggestion_Click);
            this.lstCustomerSuggestion.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstCustomerSuggestion_DrawItem);
            this.lstCustomerSuggestion.Leave += new System.EventHandler(this.lstCustomerSuggestion_Leave);
            this.lstCustomerSuggestion.MouseLeave += new System.EventHandler(this.lstCustomerSuggestion_MouseLeave);
            this.lstCustomerSuggestion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstCustomerSuggestion_MouseMove);
            // 
            // lblCustomers
            // 
            this.lblCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.lblCustomers.Location = new System.Drawing.Point(126, 60);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCustomers.Size = new System.Drawing.Size(67, 20);
            this.lblCustomers.TabIndex = 4;
            this.lblCustomers.Text = "Khách lẻ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer :";
            // 
            // txtCustomersSearch
            // 
            this.txtCustomersSearch.BorderRadius = 15;
            this.txtCustomersSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomersSearch.DefaultText = "";
            this.txtCustomersSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomersSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomersSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomersSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomersSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtCustomersSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomersSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomersSearch.ForeColor = System.Drawing.Color.Black;
            this.txtCustomersSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomersSearch.Location = new System.Drawing.Point(6, 7);
            this.txtCustomersSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomersSearch.Name = "txtCustomersSearch";
            this.txtCustomersSearch.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtCustomersSearch.PlaceholderText = "Search Customers";
            this.txtCustomersSearch.SelectedText = "";
            this.txtCustomersSearch.Size = new System.Drawing.Size(293, 32);
            this.txtCustomersSearch.TabIndex = 2;
            this.txtCustomersSearch.TextChanged += new System.EventHandler(this.txtCustomersSearch_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControlOrders);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(863, 631);
            this.panel3.TabIndex = 3;
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 684);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Sales";
            this.Text = "MilkStoreManagerment";
            this.Load += new System.EventHandler(this.Sales_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tabControlOrders;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lstProductSuggestion;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomersSearch;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstCustomerSuggestion;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ToggleSwitch TS_Discount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalAfterDiscount;
        private Guna.UI2.WinForms.Guna2TextBox txtCusPay;
        private System.Windows.Forms.Label lblCashChange;
        private Guna.UI2.WinForms.Guna2TextBox txtDiscount;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox3;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button btnPayPrinter;
        private System.Windows.Forms.Label lblVND;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.RadioButton rbnReturnCus;
        private System.Windows.Forms.RadioButton rbnDebt;
    }
}