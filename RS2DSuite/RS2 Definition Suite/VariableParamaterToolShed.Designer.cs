namespace RS2_Definition_Suite
{
    partial class VariableParamaterToolShed
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.indexTreeView = new System.Windows.Forms.TreeView();
            this.propertyEditor = new System.Windows.Forms.PropertyGrid();
            this.addParameter = new System.Windows.Forms.Button();
            this.removeParameter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exportVarp = new System.Windows.Forms.Button();
            this.addUpTo = new System.Windows.Forms.Button();
            this.upTo = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upTo)).BeginInit();
            this.SuspendLayout();
            // 
            // indexTreeView
            // 
            this.indexTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.indexTreeView.Location = new System.Drawing.Point(0, 0);
            this.indexTreeView.Name = "indexTreeView";
            this.indexTreeView.Size = new System.Drawing.Size(134, 401);
            this.indexTreeView.TabIndex = 0;
            // 
            // propertyEditor
            // 
            this.propertyEditor.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyEditor.Location = new System.Drawing.Point(285, 0);
            this.propertyEditor.Name = "propertyEditor";
            this.propertyEditor.Size = new System.Drawing.Size(176, 401);
            this.propertyEditor.TabIndex = 1;
            // 
            // addParameter
            // 
            this.addParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addParameter.Location = new System.Drawing.Point(140, 344);
            this.addParameter.Name = "addParameter";
            this.addParameter.Size = new System.Drawing.Size(139, 24);
            this.addParameter.TabIndex = 2;
            this.addParameter.Text = "Create Definition";
            this.addParameter.UseVisualStyleBackColor = true;
            // 
            // removeParameter
            // 
            this.removeParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeParameter.Location = new System.Drawing.Point(140, 374);
            this.removeParameter.Name = "removeParameter";
            this.removeParameter.Size = new System.Drawing.Size(139, 24);
            this.removeParameter.TabIndex = 3;
            this.removeParameter.Text = "Remove Last Definition";
            this.removeParameter.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(140, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 275);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Variable Parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.MaximumSize = new System.Drawing.Size(139, 0);
            this.label1.MinimumSize = new System.Drawing.Size(139, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 130);
            this.label1.TabIndex = 0;
            this.label1.Text = "What are Variable Parameters?\r\n\r\nVariable Parameters provide functionality for cl" +
    "ient\r\nrelated settings such as brightness, and volume.\r\n\r\nThese parameters are m" +
    "ainly used in interfaces.";
            // 
            // exportVarp
            // 
            this.exportVarp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportVarp.Location = new System.Drawing.Point(140, 314);
            this.exportVarp.Name = "exportVarp";
            this.exportVarp.Size = new System.Drawing.Size(139, 24);
            this.exportVarp.TabIndex = 2;
            this.exportVarp.Text = "Export Varp Definitions";
            this.exportVarp.UseVisualStyleBackColor = true;
            // 
            // addUpTo
            // 
            this.addUpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addUpTo.Location = new System.Drawing.Point(140, 284);
            this.addUpTo.Name = "addUpTo";
            this.addUpTo.Size = new System.Drawing.Size(64, 24);
            this.addUpTo.TabIndex = 2;
            this.addUpTo.Text = "Add up to:";
            this.addUpTo.UseVisualStyleBackColor = true;
            // 
            // upTo
            // 
            this.upTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.upTo.Location = new System.Drawing.Point(210, 288);
            this.upTo.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.upTo.Name = "upTo";
            this.upTo.Size = new System.Drawing.Size(69, 20);
            this.upTo.TabIndex = 1;
            // 
            // VariableParamaterToolShed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.upTo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.removeParameter);
            this.Controls.Add(this.addUpTo);
            this.Controls.Add(this.exportVarp);
            this.Controls.Add(this.addParameter);
            this.Controls.Add(this.propertyEditor);
            this.Controls.Add(this.indexTreeView);
            this.Name = "VariableParamaterToolShed";
            this.Size = new System.Drawing.Size(461, 401);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upTo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TreeView indexTreeView;
        public System.Windows.Forms.PropertyGrid propertyEditor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button addParameter;
        public System.Windows.Forms.Button removeParameter;
        public System.Windows.Forms.Button exportVarp;
        public System.Windows.Forms.Button addUpTo;
        public System.Windows.Forms.NumericUpDown upTo;
    }
}
