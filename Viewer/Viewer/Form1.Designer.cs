namespace Viewer
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_load = new System.Windows.Forms.Button();
            this.button_browse = new System.Windows.Forms.Button();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_pause = new System.Windows.Forms.Button();
            this.button_play = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_first = new System.Windows.Forms.Button();
            this.button_prev_fast = new System.Windows.Forms.Button();
            this.button_prev = new System.Windows.Forms.Button();
            this.button_next_last = new System.Windows.Forms.Button();
            this.button_next_fast = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.label_itr = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Topic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Top1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Top2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Top3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button_load);
            this.groupBox1.Controls.Add(this.button_browse);
            this.groupBox1.Controls.Add(this.textBox_folder);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loader";
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(646, 16);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 2;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(565, 17);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(75, 23);
            this.button_browse.TabIndex = 1;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // textBox_folder
            // 
            this.textBox_folder.Location = new System.Drawing.Point(6, 19);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.ReadOnly = true;
            this.textBox_folder.Size = new System.Drawing.Size(553, 20);
            this.textBox_folder.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.button_pause);
            this.groupBox2.Controls.Add(this.button_play);
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.Controls.Add(this.button_first);
            this.groupBox2.Controls.Add(this.button_prev_fast);
            this.groupBox2.Controls.Add(this.button_prev);
            this.groupBox2.Controls.Add(this.button_next_last);
            this.groupBox2.Controls.Add(this.button_next_fast);
            this.groupBox2.Controls.Add(this.button_next);
            this.groupBox2.Controls.Add(this.label_itr);
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 717);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // button_pause
            // 
            this.button_pause.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_pause.Location = new System.Drawing.Point(295, 684);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(76, 23);
            this.button_pause.TabIndex = 9;
            this.button_pause.Text = "| |";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // button_play
            // 
            this.button_play.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_play.Location = new System.Drawing.Point(392, 684);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(76, 23);
            this.button_play.TabIndex = 8;
            this.button_play.Text = "|>";
            this.button_play.UseVisualStyleBackColor = true;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 34);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(715, 300);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // button_first
            // 
            this.button_first.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_first.Location = new System.Drawing.Point(99, 655);
            this.button_first.Name = "button_first";
            this.button_first.Size = new System.Drawing.Size(76, 23);
            this.button_first.TabIndex = 6;
            this.button_first.Text = "|<<<";
            this.button_first.UseVisualStyleBackColor = true;
            this.button_first.Click += new System.EventHandler(this.button_first_Click);
            // 
            // button_prev_fast
            // 
            this.button_prev_fast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_prev_fast.Location = new System.Drawing.Point(180, 655);
            this.button_prev_fast.Name = "button_prev_fast";
            this.button_prev_fast.Size = new System.Drawing.Size(76, 23);
            this.button_prev_fast.TabIndex = 5;
            this.button_prev_fast.Text = "<<";
            this.button_prev_fast.UseVisualStyleBackColor = true;
            this.button_prev_fast.Click += new System.EventHandler(this.button_prev_fast_Click);
            // 
            // button_prev
            // 
            this.button_prev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_prev.Location = new System.Drawing.Point(261, 655);
            this.button_prev.Name = "button_prev";
            this.button_prev.Size = new System.Drawing.Size(76, 23);
            this.button_prev.TabIndex = 4;
            this.button_prev.Text = "<";
            this.button_prev.UseVisualStyleBackColor = true;
            this.button_prev.Click += new System.EventHandler(this.button_prev_Click);
            // 
            // button_next_last
            // 
            this.button_next_last.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_next_last.Location = new System.Drawing.Point(564, 655);
            this.button_next_last.Name = "button_next_last";
            this.button_next_last.Size = new System.Drawing.Size(76, 23);
            this.button_next_last.TabIndex = 3;
            this.button_next_last.Text = ">>>|";
            this.button_next_last.UseVisualStyleBackColor = true;
            this.button_next_last.Click += new System.EventHandler(this.button_next_last_Click);
            // 
            // button_next_fast
            // 
            this.button_next_fast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_next_fast.Location = new System.Drawing.Point(483, 655);
            this.button_next_fast.Name = "button_next_fast";
            this.button_next_fast.Size = new System.Drawing.Size(76, 23);
            this.button_next_fast.TabIndex = 2;
            this.button_next_fast.Text = ">>";
            this.button_next_fast.UseVisualStyleBackColor = true;
            this.button_next_fast.Click += new System.EventHandler(this.button_next_fast_Click);
            // 
            // button_next
            // 
            this.button_next.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_next.Location = new System.Drawing.Point(404, 655);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(76, 23);
            this.button_next.TabIndex = 1;
            this.button_next.Text = ">";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // label_itr
            // 
            this.label_itr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_itr.AutoSize = true;
            this.label_itr.Location = new System.Drawing.Point(362, 660);
            this.label_itr.Name = "label_itr";
            this.label_itr.Size = new System.Drawing.Size(24, 13);
            this.label_itr.TabIndex = 0;
            this.label_itr.Text = "0/0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Topic,
            this.Top1,
            this.Top2,
            this.Top3});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 340);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(721, 309);
            this.dataGridView1.TabIndex = 10;
            // 
            // Topic
            // 
            this.Topic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Topic.HeaderText = "Topic";
            this.Topic.Name = "Topic";
            this.Topic.ReadOnly = true;
            // 
            // Top1
            // 
            this.Top1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Top1.HeaderText = "Top1";
            this.Top1.Name = "Top1";
            this.Top1.ReadOnly = true;
            // 
            // Top2
            // 
            this.Top2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Top2.HeaderText = "Top2";
            this.Top2.Name = "Top2";
            this.Top2.ReadOnly = true;
            // 
            // Top3
            // 
            this.Top3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Top3.HeaderText = "Top3";
            this.Top3.Name = "Top3";
            this.Top3.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 815);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SWE599 Topic Model Viewer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_first;
        private System.Windows.Forms.Button button_prev_fast;
        private System.Windows.Forms.Button button_prev;
        private System.Windows.Forms.Button button_next_last;
        private System.Windows.Forms.Button button_next_fast;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Label label_itr;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Topic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Top1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Top2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Top3;
    }
}

