namespace UI
{
    partial class overview
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
            label1 = new Label();
            Tables = new ListView();
            ChangeStatus = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(501, 48);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(518, 62);
            label1.TabIndex = 0;
            label1.Text = "Restaurant Overview";
            // 
            // Tables
            // 
            Tables.Location = new Point(119, 153);
            Tables.Name = "Tables";
            Tables.Size = new Size(660, 424);
            Tables.TabIndex = 1;
            Tables.UseCompatibleStateImageBehavior = false;
            // 
            // ChangeStatus
            // 
            ChangeStatus.Location = new Point(119, 684);
            ChangeStatus.Name = "ChangeStatus";
            ChangeStatus.Size = new Size(308, 52);
            ChangeStatus.TabIndex = 2;
            ChangeStatus.Text = "Change status";
            ChangeStatus.UseVisualStyleBackColor = true;
            ChangeStatus.Click += ChangeStatus_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(812, 153);
            listView1.Name = "listView1";
            listView1.Size = new Size(652, 424);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // overview
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1516, 832);
            Controls.Add(listView1);
            Controls.Add(ChangeStatus);
            Controls.Add(Tables);
            Controls.Add(label1);
            Margin = new Padding(6);
            Name = "overview";
            Text = "overview";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView Tables;
        private Button ChangeStatus;
        private ListView listView1;
    }
}