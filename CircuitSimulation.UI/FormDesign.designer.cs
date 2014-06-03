using CircuitSimulation.UI.DesignerControls;

namespace CircuitSimulation.UI
{
    partial class FormDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDesign));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Default", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Basic", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Gates", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Flip Flops", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Generators", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Integrated Circuit", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Diode", "diode.png");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Switch", "switchOFF.png");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Buffer", "buffer.png");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Input", "input.png");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Output", "output.png");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Not", "not.png");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("And", "and.png");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Or", "or.png");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Xor", "xor.png");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Nand", "nand.png");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("Nor", "nor.png");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Xnor", "xnor.png");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("SR Latch", "srLatch.png");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("Generator", "generator.png");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("Integrated Circuit", "integratedCircuit.png");
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSimulate = new CircuitSimulation.UI.ButtonWithImage();
            this.listViewElements = new System.Windows.Forms.ListView();
            this.circuitControl1 = new CircuitSimulation.UI.DesignerControls.CircuitControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "buffer.png");
            this.imageList.Images.SetKeyName(1, "and.png");
            this.imageList.Images.SetKeyName(2, "nand.png");
            this.imageList.Images.SetKeyName(3, "nor.png");
            this.imageList.Images.SetKeyName(4, "not.png");
            this.imageList.Images.SetKeyName(5, "or.png");
            this.imageList.Images.SetKeyName(6, "srLatch.png");
            this.imageList.Images.SetKeyName(7, "xnor.png");
            this.imageList.Images.SetKeyName(8, "xor.png");
            this.imageList.Images.SetKeyName(9, "arrow.png");
            this.imageList.Images.SetKeyName(10, "diode.png");
            this.imageList.Images.SetKeyName(11, "swtichON.png");
            this.imageList.Images.SetKeyName(12, "switchOFF.png");
            this.imageList.Images.SetKeyName(13, "generator.png");
            this.imageList.Images.SetKeyName(14, "integratedCircuit.png");
            this.imageList.Images.SetKeyName(15, "socket.png");
            this.imageList.Images.SetKeyName(16, "socketTrans.png");
            this.imageList.Images.SetKeyName(17, "input.png");
            this.imageList.Images.SetKeyName(18, "inputTrans.png");
            this.imageList.Images.SetKeyName(19, "output.png");
            this.imageList.Images.SetKeyName(20, "outputTrans.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.listViewElements);
            this.splitContainer1.Panel1MinSize = 120;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.circuitControl1);
            this.splitContainer1.Size = new System.Drawing.Size(865, 527);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.buttonSimulate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 29);
            this.panel1.TabIndex = 2;
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSimulate.Image = ((System.Drawing.Image)(resources.GetObject("buttonSimulate.Image")));
            this.buttonSimulate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSimulate.Location = new System.Drawing.Point(3, 3);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(95, 23);
            this.buttonSimulate.TabIndex = 1;
            this.buttonSimulate.Text = "Simulate";
            this.buttonSimulate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSimulate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSimulate.UseVisualStyleBackColor = true;
            // 
            // listViewElements
            // 
            this.listViewElements.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            listViewGroup1.Header = "Default";
            listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup1.Name = "listViewGroupDefault";
            listViewGroup2.Header = "Basic";
            listViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup2.Name = "listViewGroupBasic";
            listViewGroup3.Header = "Gates";
            listViewGroup3.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup3.Name = "listViewGroupGates";
            listViewGroup4.Header = "Flip Flops";
            listViewGroup4.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup4.Name = "listViewGroupFlipFlops";
            listViewGroup5.Header = "Generators";
            listViewGroup5.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup5.Name = "listViewGroupGenerators";
            listViewGroup6.Header = "Integrated Circuit";
            listViewGroup6.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup6.Name = "listViewGroupIntegratedCircuit";
            this.listViewElements.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6});
            listViewItem1.Group = listViewGroup2;
            listViewItem1.Tag = "Diode";
            listViewItem2.Group = listViewGroup2;
            listViewItem2.Tag = "Switch";
            listViewItem3.Group = listViewGroup2;
            listViewItem3.Tag = "Buffer";
            listViewItem4.Group = listViewGroup2;
            listViewItem4.Tag = "Input";
            listViewItem5.Group = listViewGroup2;
            listViewItem5.Tag = "Output";
            listViewItem6.Group = listViewGroup3;
            listViewItem6.Tag = "Not";
            listViewItem7.Group = listViewGroup3;
            listViewItem7.Tag = "And";
            listViewItem8.Group = listViewGroup3;
            listViewItem8.Tag = "Or";
            listViewItem9.Group = listViewGroup3;
            listViewItem9.Tag = "Xor";
            listViewItem10.Group = listViewGroup3;
            listViewItem10.Tag = "Nand";
            listViewItem11.Group = listViewGroup3;
            listViewItem11.Tag = "Nor";
            listViewItem12.Group = listViewGroup3;
            listViewItem12.Tag = "Xnor";
            listViewItem13.Group = listViewGroup4;
            listViewItem13.Tag = "SrLatch";
            listViewItem14.Group = listViewGroup5;
            listViewItem14.Tag = "Generator";
            listViewItem15.Group = listViewGroup6;
            listViewItem15.Tag = "IntegratedCircuit";
            this.listViewElements.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15});
            this.listViewElements.LargeImageList = this.imageList;
            this.listViewElements.Location = new System.Drawing.Point(0, 29);
            this.listViewElements.MultiSelect = false;
            this.listViewElements.Name = "listViewElements";
            this.listViewElements.Size = new System.Drawing.Size(231, 494);
            this.listViewElements.TabIndex = 0;
            this.listViewElements.UseCompatibleStateImageBehavior = false;
            this.listViewElements.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            // 
            // circuitControl1
            // 
            this.circuitControl1.AllowDrop = true;
            this.circuitControl1.AutoScroll = true;
            this.circuitControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circuitControl1.IsModified = false;
            this.circuitControl1.Location = new System.Drawing.Point(0, 0);
            this.circuitControl1.Name = "circuitControl1";
            this.circuitControl1.OutputToConnect = null;
            this.circuitControl1.SelectedElement = null;
            this.circuitControl1.Size = new System.Drawing.Size(623, 523);
            this.circuitControl1.TabIndex = 0;
            // 
            // FormDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 527);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = true;
            this.Name = "FormDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Design";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewElements;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ButtonWithImage buttonSimulate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList;
        private CircuitControl circuitControl1;


    }
}

