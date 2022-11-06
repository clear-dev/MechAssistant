namespace MechAssistant
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isMech = new System.Windows.Forms.CheckBox();
            this.plateBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vehBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpgradeFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.isMech);
            this.groupBox1.Controls.Add(this.plateBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.vehBox);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Info";
            // 
            // isMech
            // 
            this.isMech.AutoSize = true;
            this.isMech.Location = new System.Drawing.Point(12, 66);
            this.isMech.Name = "isMech";
            this.isMech.Size = new System.Drawing.Size(56, 19);
            this.isMech.TabIndex = 6;
            this.isMech.Text = "Mech";
            this.isMech.UseVisualStyleBackColor = true;
            // 
            // plateBox
            // 
            this.plateBox.Location = new System.Drawing.Point(245, 37);
            this.plateBox.Name = "plateBox";
            this.plateBox.PlaceholderText = "ABCD123";
            this.plateBox.Size = new System.Drawing.Size(100, 23);
            this.plateBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Plate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Make / Model";
            // 
            // vehBox
            // 
            this.vehBox.Location = new System.Drawing.Point(118, 37);
            this.vehBox.Name = "vehBox";
            this.vehBox.PlaceholderText = "Honda Integra";
            this.vehBox.Size = new System.Drawing.Size(121, 23);
            this.vehBox.TabIndex = 2;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(12, 37);
            this.nameBox.Name = "nameBox";
            this.nameBox.PlaceholderText = "Tony Demarcus";
            this.nameBox.Size = new System.Drawing.Size(100, 23);
            this.nameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // UpgradeFlow
            // 
            this.UpgradeFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpgradeFlow.Location = new System.Drawing.Point(12, 97);
            this.UpgradeFlow.Name = "UpgradeFlow";
            this.UpgradeFlow.Size = new System.Drawing.Size(776, 204);
            this.UpgradeFlow.TabIndex = 7;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(359, 342);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.UpgradeFlow);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MechAssistant";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox nameBox;
        private Label label1;
        private TextBox vehBox;
        private TextBox plateBox;
        private Label label3;
        private Label label2;
        private CheckBox isMech;
        private FlowLayoutPanel UpgradeFlow;
        private RichTextBox richTextBox1;
    }
}