namespace TSP_genetic
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
            start = new Button();
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonLoad = new Button();
            numericUpDown1 = new NumericUpDown();
            selectAll = new Button();
            deselectAll = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // start
            // 
            start.Location = new Point(777, 496);
            start.Name = "start";
            start.Size = new Size(75, 23);
            start.TabIndex = 1;
            start.Text = "start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 22);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(764, 440);
            textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(178, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(761, 468);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(160, 468);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(858, 497);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(178, 496);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // selectAll
            // 
            selectAll.BackgroundImageLayout = ImageLayout.None;
            selectAll.Location = new Point(12, 495);
            selectAll.Name = "selectAll";
            selectAll.Size = new Size(79, 23);
            selectAll.TabIndex = 6;
            selectAll.Text = "select all";
            selectAll.UseVisualStyleBackColor = true;
            selectAll.Click += selectAll_Click;
            // 
            // deselectAll
            // 
            deselectAll.BackgroundImageLayout = ImageLayout.None;
            deselectAll.Location = new Point(97, 495);
            deselectAll.Name = "deselectAll";
            deselectAll.Size = new Size(75, 23);
            deselectAll.TabIndex = 7;
            deselectAll.Text = "deselect all";
            deselectAll.UseVisualStyleBackColor = true;
            deselectAll.Click += deselectAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 532);
            Controls.Add(deselectAll);
            Controls.Add(selectAll);
            Controls.Add(numericUpDown1);
            Controls.Add(buttonLoad);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(groupBox1);
            Controls.Add(start);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button start;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonLoad;
        private NumericUpDown numericUpDown1;
        private Button selectAll;
        private Button deselectAll;
    }
}