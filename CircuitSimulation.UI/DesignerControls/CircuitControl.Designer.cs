namespace CircuitSimulation.UI.DesignerControls
{
    partial class CircuitControl
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
            this.SuspendLayout();
            // 
            // CircuitControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Name = "CircuitControl";
            this.Size = new System.Drawing.Size(746, 487);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CircuitControl_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.CircuitControl_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CircuitControl_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
