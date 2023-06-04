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
            selectRandom = new Button();
            label1 = new Label();
            label2 = new Label();
            numericUpDown2 = new NumericUpDown();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // start
            // 
            start.Location = new Point(789, 496);
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
            textBox1.Size = new Size(770, 440);
            textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(178, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(782, 468);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Calculations:";
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
            buttonLoad.Location = new Point(879, 497);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(378, 499);
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
            // selectRandom
            // 
            selectRandom.BackgroundImageLayout = ImageLayout.None;
            selectRandom.Location = new Point(178, 495);
            selectRandom.Name = "selectRandom";
            selectRandom.Size = new Size(101, 23);
            selectRandom.TabIndex = 9;
            selectRandom.Text = "select random";
            selectRandom.UseVisualStyleBackColor = true;
            selectRandom.Click += selectRandom_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 501);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 10;
            label1.Text = "Population Size:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(504, 501);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 12;
            label2.Text = "Generations:";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(583, 499);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 11;
            numericUpDown2.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 532);
            Controls.Add(label2);
            Controls.Add(numericUpDown2);
            Controls.Add(label1);
            Controls.Add(selectRandom);
            Controls.Add(deselectAll);
            Controls.Add(selectAll);
            Controls.Add(numericUpDown1);
            Controls.Add(buttonLoad);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(groupBox1);
            Controls.Add(start);
            Name = "Form1";
            Text = "Traveling Inpost Genetic Algorithm Approach";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Button selectRandom;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown2;
    }
}