namespace RS2_Definition_Suite
{
    partial class MainApp
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("obj.dat");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("obj.idx");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Items", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("npc.dat");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("npc.idx");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("NPCs", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("loc.dat");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("loc.idx");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Objects", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("seq.dat");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Animation Sequence", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("flo.dat");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Floor", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("spotanim.dat");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("GFX", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("idk.dat");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Identity Kit", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("varp.dat");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Variable Parameters", new System.Windows.Forms.TreeNode[] {
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("varbit.dat");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Variable Bit Data", new System.Windows.Forms.TreeNode[] {
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Cache", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode9,
            treeNode11,
            treeNode13,
            treeNode15,
            treeNode17,
            treeNode19,
            treeNode21});
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openCache = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMain = new System.Windows.Forms.ToolStripMenuItem();
            this.credits = new System.Windows.Forms.ToolStripMenuItem();
            this.cacheSelectorBox = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadedLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadedLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.selectParentText = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.credits,
            this.cacheSelectorBox});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 27);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCache,
            this.toolStripSeparator1,
            this.exitMain});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 23);
            this.fileMenu.Text = "File";
            // 
            // openCache
            // 
            this.openCache.Name = "openCache";
            this.openCache.Size = new System.Drawing.Size(139, 22);
            this.openCache.Text = "Open Cache";
            this.openCache.Click += new System.EventHandler(this.openCache_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // exitMain
            // 
            this.exitMain.Name = "exitMain";
            this.exitMain.Size = new System.Drawing.Size(139, 22);
            this.exitMain.Text = "Exit";
            // 
            // credits
            // 
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(56, 23);
            this.credits.Text = "Credits";
            this.credits.Click += new System.EventHandler(this.credits_Click);
            // 
            // cacheSelectorBox
            // 
            this.cacheSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cacheSelectorBox.Enabled = false;
            this.cacheSelectorBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cacheSelectorBox.Items.AddRange(new object[] {
            "317/319",
            "377"});
            this.cacheSelectorBox.MaxDropDownItems = 2;
            this.cacheSelectorBox.Name = "cacheSelectorBox";
            this.cacheSelectorBox.Size = new System.Drawing.Size(121, 23);
            this.cacheSelectorBox.SelectedIndexChanged += new System.EventHandler(this.cacheSelectorBox_SelectedIndexChanged);
            this.cacheSelectorBox.EnabledChanged += new System.EventHandler(this.cacheSelectorBox_EnabledChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadedLabel1,
            this.loadedLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loadedLabel1
            // 
            this.loadedLabel1.Name = "loadedLabel1";
            this.loadedLabel1.Size = new System.Drawing.Size(101, 17);
            this.loadedLabel1.Text = "No Cache Loaded";
            this.loadedLabel1.Paint += new System.Windows.Forms.PaintEventHandler(this.loadedLabel1_Paint);
            // 
            // loadedLabel2
            // 
            this.loadedLabel2.Name = "loadedLabel2";
            this.loadedLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.selectParentText);
            this.splitContainer1.Size = new System.Drawing.Size(784, 512);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Enabled = false;
            this.treeView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "objdat";
            treeNode1.Text = "obj.dat";
            treeNode2.Name = "objidx";
            treeNode2.Text = "obj.idx";
            treeNode3.Name = "items";
            treeNode3.Text = "Items";
            treeNode4.Name = "npcdat";
            treeNode4.Text = "npc.dat";
            treeNode5.Name = "npcidx";
            treeNode5.Text = "npc.idx";
            treeNode6.Name = "npc";
            treeNode6.Text = "NPCs";
            treeNode7.Name = "locdat";
            treeNode7.Text = "loc.dat";
            treeNode8.Name = "locidx";
            treeNode8.Text = "loc.idx";
            treeNode9.Name = "objects";
            treeNode9.Text = "Objects";
            treeNode10.Name = "seq";
            treeNode10.Text = "seq.dat";
            treeNode11.Name = "seq";
            treeNode11.Text = "Animation Sequence";
            treeNode12.Name = "flo";
            treeNode12.Text = "flo.dat";
            treeNode13.Name = "floor";
            treeNode13.Text = "Floor";
            treeNode14.Name = "gfx";
            treeNode14.Text = "spotanim.dat";
            treeNode15.Name = "spotanim";
            treeNode15.Text = "GFX";
            treeNode16.Name = "idk";
            treeNode16.Text = "idk.dat";
            treeNode17.Name = "idk";
            treeNode17.Text = "Identity Kit";
            treeNode18.Name = "varp";
            treeNode18.Text = "varp.dat";
            treeNode19.Name = "varp";
            treeNode19.Text = "Variable Parameters";
            treeNode20.Name = "varbit";
            treeNode20.Text = "varbit.dat";
            treeNode21.Name = "varbit";
            treeNode21.Text = "Variable Bit Data";
            treeNode22.Name = "cache";
            treeNode22.Text = "Cache";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22});
            this.treeView1.Size = new System.Drawing.Size(217, 512);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // selectParentText
            // 
            this.selectParentText.AutoSize = true;
            this.selectParentText.Location = new System.Drawing.Point(3, 0);
            this.selectParentText.Name = "selectParentText";
            this.selectParentText.Size = new System.Drawing.Size(121, 13);
            this.selectParentText.TabIndex = 0;
            this.selectParentText.Text = "Nothing to display here..";
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "MainApp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RS2 Definition Suite";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel loadedLabel1;
        private System.Windows.Forms.ToolStripStatusLabel loadedLabel2;
        private System.Windows.Forms.ToolStripMenuItem credits;
        private System.Windows.Forms.ToolStripComboBox cacheSelectorBox;
        private System.Windows.Forms.ToolStripMenuItem openCache;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label selectParentText;
    }
}

