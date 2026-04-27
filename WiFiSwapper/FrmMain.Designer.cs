namespace WiFiSwapper
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gbInactive = new System.Windows.Forms.GroupBox();
            this.btnInactiveRemove = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lvInactive = new System.Windows.Forms.ListView();
            this.chInactiveName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInactiveAdd = new System.Windows.Forms.Button();
            this.bAgbctive = new System.Windows.Forms.GroupBox();
            this.btnActiveRemove = new System.Windows.Forms.Button();
            this.btnActiveAdd = new System.Windows.Forms.Button();
            this.lvActive = new System.Windows.Forms.ListView();
            this.chActiveName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pMiddle = new System.Windows.Forms.Panel();
            this.btnSwapProfiles = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buyMeCoffeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutWiFiSwapperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSeparator = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslBuyCoffeTo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.gbInactive.SuspendLayout();
            this.bAgbctive.SuspendLayout();
            this.pMiddle.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel.Controls.Add(this.gbInactive, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.bAgbctive, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.pMiddle, 1, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(780, 409);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // gbInactive
            // 
            this.gbInactive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInactive.Controls.Add(this.btnInactiveRemove);
            this.gbInactive.Controls.Add(this.lvInactive);
            this.gbInactive.Controls.Add(this.btnInactiveAdd);
            this.gbInactive.Location = new System.Drawing.Point(434, 5);
            this.gbInactive.Margin = new System.Windows.Forms.Padding(5);
            this.gbInactive.Name = "gbInactive";
            this.gbInactive.Padding = new System.Windows.Forms.Padding(10);
            this.gbInactive.Size = new System.Drawing.Size(341, 399);
            this.gbInactive.TabIndex = 1;
            this.gbInactive.TabStop = false;
            this.gbInactive.Text = "Alternate WiFi Profiles";
            // 
            // btnInactiveRemove
            // 
            this.btnInactiveRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInactiveRemove.Enabled = false;
            this.btnInactiveRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInactiveRemove.ImageKey = "delete-24";
            this.btnInactiveRemove.ImageList = this.imageList;
            this.btnInactiveRemove.Location = new System.Drawing.Point(249, 62);
            this.btnInactiveRemove.Name = "btnInactiveRemove";
            this.btnInactiveRemove.Size = new System.Drawing.Size(79, 30);
            this.btnInactiveRemove.TabIndex = 7;
            this.btnInactiveRemove.Text = "Remove";
            this.btnInactiveRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInactiveRemove.UseVisualStyleBackColor = true;
            this.btnInactiveRemove.Click += new System.EventHandler(this.btnInactiveRemove_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "lock");
            this.imageList.Images.SetKeyName(1, "unlock");
            this.imageList.Images.SetKeyName(2, "buycoffeto.ico");
            this.imageList.Images.SetKeyName(3, "swap-48.png");
            this.imageList.Images.SetKeyName(4, "add-24");
            this.imageList.Images.SetKeyName(5, "delete-24");
            this.imageList.Images.SetKeyName(6, "edit-24");
            // 
            // lvInactive
            // 
            this.lvInactive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvInactive.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chInactiveName});
            this.lvInactive.FullRowSelect = true;
            this.lvInactive.GridLines = true;
            this.lvInactive.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvInactive.HideSelection = false;
            this.lvInactive.Location = new System.Drawing.Point(13, 26);
            this.lvInactive.MultiSelect = false;
            this.lvInactive.Name = "lvInactive";
            this.lvInactive.Size = new System.Drawing.Size(230, 360);
            this.lvInactive.TabIndex = 4;
            this.lvInactive.UseCompatibleStateImageBehavior = false;
            this.lvInactive.View = System.Windows.Forms.View.Details;
            this.lvInactive.SelectedIndexChanged += new System.EventHandler(this.lvInactive_SelectedIndexChanged);
            this.lvInactive.Resize += new System.EventHandler(this.lvProfiles_Resize);
            // 
            // chInactiveName
            // 
            this.chInactiveName.Text = "Name";
            this.chInactiveName.Width = 220;
            // 
            // btnInactiveAdd
            // 
            this.btnInactiveAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInactiveAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInactiveAdd.ImageKey = "add-24";
            this.btnInactiveAdd.ImageList = this.imageList;
            this.btnInactiveAdd.Location = new System.Drawing.Point(249, 26);
            this.btnInactiveAdd.Name = "btnInactiveAdd";
            this.btnInactiveAdd.Size = new System.Drawing.Size(79, 30);
            this.btnInactiveAdd.TabIndex = 5;
            this.btnInactiveAdd.Text = "Add";
            this.btnInactiveAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInactiveAdd.UseVisualStyleBackColor = true;
            this.btnInactiveAdd.Click += new System.EventHandler(this.btnInactiveAdd_Click);
            // 
            // bAgbctive
            // 
            this.bAgbctive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bAgbctive.Controls.Add(this.btnActiveRemove);
            this.bAgbctive.Controls.Add(this.btnActiveAdd);
            this.bAgbctive.Controls.Add(this.lvActive);
            this.bAgbctive.Location = new System.Drawing.Point(5, 5);
            this.bAgbctive.Margin = new System.Windows.Forms.Padding(5);
            this.bAgbctive.Name = "bAgbctive";
            this.bAgbctive.Padding = new System.Windows.Forms.Padding(10);
            this.bAgbctive.Size = new System.Drawing.Size(341, 399);
            this.bAgbctive.TabIndex = 0;
            this.bAgbctive.TabStop = false;
            this.bAgbctive.Text = "Active WiFi Profiles";
            // 
            // btnActiveRemove
            // 
            this.btnActiveRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActiveRemove.Enabled = false;
            this.btnActiveRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActiveRemove.ImageKey = "delete-24";
            this.btnActiveRemove.ImageList = this.imageList;
            this.btnActiveRemove.Location = new System.Drawing.Point(249, 62);
            this.btnActiveRemove.Name = "btnActiveRemove";
            this.btnActiveRemove.Size = new System.Drawing.Size(79, 30);
            this.btnActiveRemove.TabIndex = 3;
            this.btnActiveRemove.Text = "Remove";
            this.btnActiveRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActiveRemove.UseVisualStyleBackColor = true;
            this.btnActiveRemove.Click += new System.EventHandler(this.btnActiveRemove_Click);
            // 
            // btnActiveAdd
            // 
            this.btnActiveAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActiveAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActiveAdd.ImageKey = "add-24";
            this.btnActiveAdd.ImageList = this.imageList;
            this.btnActiveAdd.Location = new System.Drawing.Point(249, 26);
            this.btnActiveAdd.Name = "btnActiveAdd";
            this.btnActiveAdd.Size = new System.Drawing.Size(79, 30);
            this.btnActiveAdd.TabIndex = 1;
            this.btnActiveAdd.Text = "Add";
            this.btnActiveAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActiveAdd.UseVisualStyleBackColor = true;
            this.btnActiveAdd.Click += new System.EventHandler(this.btnActiveAdd_Click);
            // 
            // lvActive
            // 
            this.lvActive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvActive.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chActiveName});
            this.lvActive.FullRowSelect = true;
            this.lvActive.GridLines = true;
            this.lvActive.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvActive.HideSelection = false;
            this.lvActive.Location = new System.Drawing.Point(13, 26);
            this.lvActive.MultiSelect = false;
            this.lvActive.Name = "lvActive";
            this.lvActive.Size = new System.Drawing.Size(230, 360);
            this.lvActive.TabIndex = 0;
            this.lvActive.UseCompatibleStateImageBehavior = false;
            this.lvActive.View = System.Windows.Forms.View.Details;
            this.lvActive.SelectedIndexChanged += new System.EventHandler(this.lvActive_SelectedIndexChanged);
            this.lvActive.Resize += new System.EventHandler(this.lvProfiles_Resize);
            // 
            // chActiveName
            // 
            this.chActiveName.Text = "Name";
            this.chActiveName.Width = 220;
            // 
            // pMiddle
            // 
            this.pMiddle.Controls.Add(this.btnSwapProfiles);
            this.pMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMiddle.Location = new System.Drawing.Point(354, 3);
            this.pMiddle.Name = "pMiddle";
            this.pMiddle.Size = new System.Drawing.Size(72, 403);
            this.pMiddle.TabIndex = 2;
            // 
            // btnSwapProfiles
            // 
            this.btnSwapProfiles.ImageKey = "swap-48.png";
            this.btnSwapProfiles.ImageList = this.imageList;
            this.btnSwapProfiles.Location = new System.Drawing.Point(3, 186);
            this.btnSwapProfiles.Name = "btnSwapProfiles";
            this.btnSwapProfiles.Padding = new System.Windows.Forms.Padding(5);
            this.btnSwapProfiles.Size = new System.Drawing.Size(65, 50);
            this.btnSwapProfiles.TabIndex = 3;
            this.btnSwapProfiles.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSwapProfiles.Click += new System.EventHandler(this.btnSwapProfiles_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accessToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accessToolStripMenuItem
            // 
            this.accessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lockToolStripMenuItem,
            this.unlockToolStripMenuItem});
            this.accessToolStripMenuItem.Name = "accessToolStripMenuItem";
            this.accessToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.accessToolStripMenuItem.Text = "Access";
            this.accessToolStripMenuItem.DropDownOpening += new System.EventHandler(this.accessToolStripMenuItem_DropDownOpening);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lockToolStripMenuItem.Image")));
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.lockToolStripMenuItem.Text = "Lock";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // unlockToolStripMenuItem
            // 
            this.unlockToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("unlockToolStripMenuItem.Image")));
            this.unlockToolStripMenuItem.Name = "unlockToolStripMenuItem";
            this.unlockToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.unlockToolStripMenuItem.Text = "Unlock";
            this.unlockToolStripMenuItem.Click += new System.EventHandler(this.unlockToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buyMeCoffeToolStripMenuItem,
            this.aboutWiFiSwapperToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // buyMeCoffeToolStripMenuItem
            // 
            this.buyMeCoffeToolStripMenuItem.Name = "buyMeCoffeToolStripMenuItem";
            this.buyMeCoffeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.buyMeCoffeToolStripMenuItem.Text = "Buy me coffe";
            this.buyMeCoffeToolStripMenuItem.Click += new System.EventHandler(this.buyMeCoffeToolStripMenuItem_Click);
            // 
            // aboutWiFiSwapperToolStripMenuItem
            // 
            this.aboutWiFiSwapperToolStripMenuItem.Name = "aboutWiFiSwapperToolStripMenuItem";
            this.aboutWiFiSwapperToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.aboutWiFiSwapperToolStripMenuItem.Text = "About WiFiSwapper";
            this.aboutWiFiSwapperToolStripMenuItem.Click += new System.EventHandler(this.aboutWiFiSwapperToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslVersion,
            this.tssSeparator,
            this.tsslBuyCoffeTo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 436);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(804, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "status";
            // 
            // tsslVersion
            // 
            this.tsslVersion.AutoSize = false;
            this.tsslVersion.Name = "tsslVersion";
            this.tsslVersion.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.tsslVersion.Size = new System.Drawing.Size(200, 20);
            this.tsslVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssSeparator
            // 
            this.tssSeparator.AutoSize = false;
            this.tssSeparator.Name = "tssSeparator";
            this.tssSeparator.Size = new System.Drawing.Size(464, 20);
            // 
            // tsslBuyCoffeTo
            // 
            this.tsslBuyCoffeTo.Image = ((System.Drawing.Image)(resources.GetObject("tsslBuyCoffeTo.Image")));
            this.tsslBuyCoffeTo.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.tsslBuyCoffeTo.IsLink = true;
            this.tsslBuyCoffeTo.Name = "tsslBuyCoffeTo";
            this.tsslBuyCoffeTo.Size = new System.Drawing.Size(102, 20);
            this.tsslBuyCoffeTo.Text = "Buy me a coffe";
            this.tsslBuyCoffeTo.Click += new System.EventHandler(this.tsslBuyCoffeTo_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(820, 250);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WiFi Swapper";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.tableLayoutPanel.ResumeLayout(false);
            this.gbInactive.ResumeLayout(false);
            this.bAgbctive.ResumeLayout(false);
            this.pMiddle.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox gbInactive;
        private System.Windows.Forms.GroupBox bAgbctive;
        private System.Windows.Forms.Button btnInactiveRemove;
        private System.Windows.Forms.ListView lvInactive;
        private System.Windows.Forms.Button btnInactiveAdd;
        private System.Windows.Forms.Button btnActiveRemove;
        private System.Windows.Forms.Button btnActiveAdd;
        private System.Windows.Forms.ListView lvActive;
        private System.Windows.Forms.Panel pMiddle;
        private System.Windows.Forms.Button btnSwapProfiles;
        private System.Windows.Forms.ColumnHeader chInactiveName;
        private System.Windows.Forms.ColumnHeader chActiveName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslVersion;
        private System.Windows.Forms.ToolStripStatusLabel tsslBuyCoffeTo;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutWiFiSwapperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buyMeCoffeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tssSeparator;
    }
}

