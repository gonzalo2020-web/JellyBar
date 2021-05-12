namespace JellyBar
{
    partial class frmJellyBar
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::JellyBar.FormasGlobales.Splash), true, true, true);
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            this.tileBar1 = new DevExpress.XtraBars.Navigation.TileBar();
            this.tbMenu = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup2 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tbiAgendar = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarGroup3 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tbiCatalogos = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.treeListPantallas = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.treeListPantallas)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // tileBar1
            // 
            this.tileBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar1.Location = new System.Drawing.Point(72, 104);
            this.tileBar1.Name = "tileBar1";
            this.tileBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar1.Size = new System.Drawing.Size(8, 8);
            this.tileBar1.TabIndex = 0;
            this.tileBar1.Text = "tileBar1";
            // 
            // tbMenu
            // 
            this.tbMenu.BackColor = System.Drawing.Color.Transparent;
            this.tbMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.tbMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbMenu.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tbMenu.Groups.Add(this.tileBarGroup2);
            this.tbMenu.Groups.Add(this.tileBarGroup3);
            this.tbMenu.Location = new System.Drawing.Point(0, 0);
            this.tbMenu.MaxId = 3;
            this.tbMenu.Name = "tbMenu";
            this.tbMenu.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbMenu.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tbMenu.Size = new System.Drawing.Size(197, 450);
            this.tbMenu.TabIndex = 1;
            this.tbMenu.Text = "tileBar2";
            // 
            // tileBarGroup2
            // 
            this.tileBarGroup2.Items.Add(this.tbiAgendar);
            this.tileBarGroup2.Name = "tileBarGroup2";
            // 
            // tbiAgendar
            // 
            this.tbiAgendar.AppearanceItem.Normal.BackColor = System.Drawing.Color.RosyBrown;
            this.tbiAgendar.AppearanceItem.Normal.Font = new System.Drawing.Font("Tw Cen MT", 13F);
            this.tbiAgendar.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tbiAgendar.AppearanceItem.Normal.Options.UseFont = true;
            this.tbiAgendar.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Text = "Agendar";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight;
            this.tbiAgendar.Elements.Add(tileItemElement1);
            this.tbiAgendar.Id = 0;
            this.tbiAgendar.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tbiAgendar.Name = "tbiAgendar";
            this.tbiAgendar.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tbiAgendar_ItemClick);
            // 
            // tileBarGroup3
            // 
            this.tileBarGroup3.Items.Add(this.tbiCatalogos);
            this.tileBarGroup3.Name = "tileBarGroup3";
            // 
            // tbiCatalogos
            // 
            this.tbiCatalogos.AppearanceItem.Normal.BackColor = System.Drawing.Color.Black;
            this.tbiCatalogos.AppearanceItem.Normal.Font = new System.Drawing.Font("Tw Cen MT", 13F);
            this.tbiCatalogos.AppearanceItem.Normal.ForeColor = System.Drawing.Color.RosyBrown;
            this.tbiCatalogos.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tbiCatalogos.AppearanceItem.Normal.Options.UseFont = true;
            this.tbiCatalogos.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tbiCatalogos.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.Text = "Catalogos";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight;
            this.tbiCatalogos.Elements.Add(tileItemElement2);
            this.tbiCatalogos.Id = 2;
            this.tbiCatalogos.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tbiCatalogos.Name = "tbiCatalogos";
            this.tbiCatalogos.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tbiCatalogos_ItemClick);
            // 
            // treeListPantallas
            // 
            this.treeListPantallas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListPantallas.Location = new System.Drawing.Point(197, 0);
            this.treeListPantallas.Name = "treeListPantallas";
            this.treeListPantallas.Size = new System.Drawing.Size(603, 450);
            this.treeListPantallas.TabIndex = 2;
            // 
            // frmJellyBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeListPantallas);
            this.Controls.Add(this.tbMenu);
            this.Controls.Add(this.tileBar1);
            this.IconOptions.Image = global::JellyBar.Properties.Resources.JellyBar_01;
            this.Name = "frmJellyBar";
            this.Text = "JellyBar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.treeListPantallas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileBar tileBar1;
        private DevExpress.XtraBars.Navigation.TileBar tbMenu;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup2;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiAgendar;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup3;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiCatalogos;
        private DevExpress.XtraTreeList.TreeList treeListPantallas;
    }
}

