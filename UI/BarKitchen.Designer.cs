namespace UI
{
    partial class BarKitchen
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
            pnlBar = new Panel();
            btnPreparingBar = new Button();
            pnlKitchen = new Panel();
            btnPreparingKitchen = new Button();
            btnReadyToServeKitchen = new Button();
            btnServedKitchen = new Button();
            kitchenTableComboBox = new ComboBox();
            sortKitchenComboBox = new ComboBox();
            label2 = new Label();
            listViewKitchen = new ListView();
            pictureBox2 = new PictureBox();
            btnReadyToServeBar = new Button();
            sortBarComboBox = new ComboBox();
            btnservedBar = new Button();
            barTableComboBox = new ComboBox();
            label1 = new Label();
            listViewBar = new ListView();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            barkitchenToolStripMenuItem = new ToolStripMenuItem();
            kitchenToolStripMenuItem = new ToolStripMenuItem();
            pnlBar.SuspendLayout();
            pnlKitchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBar
            // 
            pnlBar.Controls.Add(btnPreparingBar);
            pnlBar.Controls.Add(btnReadyToServeBar);
            pnlBar.Controls.Add(sortBarComboBox);
            pnlBar.Controls.Add(btnservedBar);
            pnlBar.Controls.Add(barTableComboBox);
            pnlBar.Controls.Add(label1);
            pnlBar.Controls.Add(listViewBar);
            pnlBar.Controls.Add(pictureBox1);
            pnlBar.Location = new Point(12, 61);
            pnlBar.Name = "pnlBar";
            pnlBar.Size = new Size(1109, 656);
            pnlBar.TabIndex = 0;
            // 
            // btnPreparingBar
            // 
            btnPreparingBar.Location = new Point(17, 568);
            btnPreparingBar.Name = "btnPreparingBar";
            btnPreparingBar.Size = new Size(130, 43);
            btnPreparingBar.TabIndex = 7;
            btnPreparingBar.Text = "Preparing";
            btnPreparingBar.UseVisualStyleBackColor = true;
            btnPreparingBar.Click += btnPreparingBar_Click;
            // 
            // pnlKitchen
            // 
            pnlKitchen.Controls.Add(btnPreparingKitchen);
            pnlKitchen.Controls.Add(btnReadyToServeKitchen);
            pnlKitchen.Controls.Add(btnServedKitchen);
            pnlKitchen.Controls.Add(kitchenTableComboBox);
            pnlKitchen.Controls.Add(sortKitchenComboBox);
            pnlKitchen.Controls.Add(label2);
            pnlKitchen.Controls.Add(listViewKitchen);
            pnlKitchen.Controls.Add(pictureBox2);
            pnlKitchen.Location = new Point(12, 61);
            pnlKitchen.Name = "pnlKitchen";
            pnlKitchen.Size = new Size(1109, 656);
            pnlKitchen.TabIndex = 3;
            // 
            // btnPreparingKitchen
            // 
            btnPreparingKitchen.Location = new Point(17, 568);
            btnPreparingKitchen.Name = "btnPreparingKitchen";
            btnPreparingKitchen.Size = new Size(130, 43);
            btnPreparingKitchen.TabIndex = 7;
            btnPreparingKitchen.Text = "Preparing";
            btnPreparingKitchen.UseVisualStyleBackColor = true;
            btnPreparingKitchen.Click += btnPreparingKitchen_Click;
            // 
            // btnReadyToServeKitchen
            // 
            btnReadyToServeKitchen.Location = new Point(455, 568);
            btnReadyToServeKitchen.Name = "btnReadyToServeKitchen";
            btnReadyToServeKitchen.Size = new Size(130, 43);
            btnReadyToServeKitchen.TabIndex = 6;
            btnReadyToServeKitchen.Text = "Ready To Serve";
            btnReadyToServeKitchen.UseVisualStyleBackColor = true;
            btnReadyToServeKitchen.Click += btnReadyToServeKitchen_Click;
            // 
            // btnServedKitchen
            // 
            btnServedKitchen.Location = new Point(919, 568);
            btnServedKitchen.Name = "btnServedKitchen";
            btnServedKitchen.Size = new Size(130, 43);
            btnServedKitchen.TabIndex = 5;
            btnServedKitchen.Text = "Served";
            btnServedKitchen.UseVisualStyleBackColor = true;
            btnServedKitchen.Click += btnServedKitchen_Click;
            // 
            // kitchenTableComboBox
            // 
            kitchenTableComboBox.FormattingEnabled = true;
            kitchenTableComboBox.Location = new Point(627, 115);
            kitchenTableComboBox.Name = "kitchenTableComboBox";
            kitchenTableComboBox.Size = new Size(151, 28);
            kitchenTableComboBox.TabIndex = 4;
            kitchenTableComboBox.Text = "Select Table";
            kitchenTableComboBox.SelectedIndexChanged += kitchenTableComboBox_SelectedIndexChanged;
            // 
            // sortKitchenComboBox
            // 
            sortKitchenComboBox.FormattingEnabled = true;
            sortKitchenComboBox.Location = new Point(408, 115);
            sortKitchenComboBox.Name = "sortKitchenComboBox";
            sortKitchenComboBox.Size = new Size(151, 28);
            sortKitchenComboBox.TabIndex = 3;
            sortKitchenComboBox.Text = "Sort";
            sortKitchenComboBox.SelectedIndexChanged += sortKitchenComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(17, 40);
            label2.Name = "label2";
            label2.Size = new Size(264, 78);
            label2.TabIndex = 2;
            label2.Text = "KITCHEN";
            // 
            // listViewKitchen
            // 
            listViewKitchen.Location = new Point(17, 158);
            listViewKitchen.Name = "listViewKitchen";
            listViewKitchen.Size = new Size(1032, 355);
            listViewKitchen.TabIndex = 1;
            listViewKitchen.UseCompatibleStateImageBehavior = false;
            listViewKitchen.View = View.Details;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Chapau_Logo;
            pictureBox2.Location = new Point(805, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(244, 127);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // btnReadyToServeBar
            // 
            btnReadyToServeBar.Location = new Point(455, 568);
            btnReadyToServeBar.Name = "btnReadyToServeBar";
            btnReadyToServeBar.Size = new Size(130, 43);
            btnReadyToServeBar.TabIndex = 6;
            btnReadyToServeBar.Text = "Ready To Serve";
            btnReadyToServeBar.UseVisualStyleBackColor = true;
            btnReadyToServeBar.Click += btnReadyToServeBar_Click;
            // 
            // sortBarComboBox
            // 
            sortBarComboBox.FormattingEnabled = true;
            sortBarComboBox.Location = new Point(408, 115);
            sortBarComboBox.Name = "sortBarComboBox";
            sortBarComboBox.Size = new Size(151, 28);
            sortBarComboBox.TabIndex = 5;
            sortBarComboBox.Text = "Sort";
            sortBarComboBox.SelectedIndexChanged += sortBarComboBox_SelectedIndexChanged;
            // 
            // btnservedBar
            // 
            btnservedBar.Location = new Point(919, 568);
            btnservedBar.Name = "btnservedBar";
            btnservedBar.Size = new Size(130, 43);
            btnservedBar.TabIndex = 4;
            btnservedBar.Text = "Served";
            btnservedBar.UseVisualStyleBackColor = true;
            btnservedBar.Click += btnservedBar_Click;
            // 
            // barTableComboBox
            // 
            barTableComboBox.FormattingEnabled = true;
            barTableComboBox.Location = new Point(627, 115);
            barTableComboBox.Name = "barTableComboBox";
            barTableComboBox.Size = new Size(151, 28);
            barTableComboBox.TabIndex = 3;
            barTableComboBox.Text = "Select Table";
            barTableComboBox.SelectedIndexChanged += barTableComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(17, 40);
            label1.Name = "label1";
            label1.Size = new Size(140, 78);
            label1.TabIndex = 2;
            label1.Text = "BAR";
            // 
            // listViewBar
            // 
            listViewBar.ImeMode = ImeMode.Disable;
            listViewBar.Location = new Point(17, 158);
            listViewBar.Name = "listViewBar";
            listViewBar.Size = new Size(1032, 355);
            listViewBar.TabIndex = 1;
            listViewBar.UseCompatibleStateImageBehavior = false;
            listViewBar.View = View.Details;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Chapau_Logo;
            pictureBox1.Location = new Point(805, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(244, 127);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { barkitchenToolStripMenuItem, kitchenToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1133, 43);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // barkitchenToolStripMenuItem
            // 
            barkitchenToolStripMenuItem.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            barkitchenToolStripMenuItem.Name = "barkitchenToolStripMenuItem";
            barkitchenToolStripMenuItem.Size = new Size(74, 39);
            barkitchenToolStripMenuItem.Text = "BAR";
            barkitchenToolStripMenuItem.Click += barkitchenToolStripMenuItem_Click;
            // 
            // kitchenToolStripMenuItem
            // 
            kitchenToolStripMenuItem.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            kitchenToolStripMenuItem.Name = "kitchenToolStripMenuItem";
            kitchenToolStripMenuItem.Size = new Size(128, 39);
            kitchenToolStripMenuItem.Text = "KITCHEN";
            kitchenToolStripMenuItem.Click += kitchenToolStripMenuItem_Click;
            // 
            // BarKitchen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 757);
            Controls.Add(menuStrip1);
            Controls.Add(pnlKitchen);
            Controls.Add(pnlBar);
            MainMenuStrip = menuStrip1;
            Name = "BarKitchen";
            Text = "BarKitchen";
            Load += BarKitchen_Load;
            pnlBar.ResumeLayout(false);
            pnlBar.PerformLayout();
            pnlKitchen.ResumeLayout(false);
            pnlKitchen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBar;
        private ListView listViewBar;
        private PictureBox pictureBox1;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem barkitchenToolStripMenuItem;
        private ToolStripMenuItem kitchenToolStripMenuItem;
        private Panel pnlKitchen;
        private Label label2;
        private ListView listViewKitchen;
        private PictureBox pictureBox2;
        private ComboBox barTableComboBox;
        private ComboBox sortBarComboBox;
        private Button btnservedBar;
        private Button btnPreparingBar;
        private Button btnReadyToServeBar;
        private ComboBox kitchenTableComboBox;
        private ComboBox sortKitchenComboBox;
        private Button btnPreparingKitchen;
        private Button btnReadyToServeKitchen;
        private Button btnServedKitchen;
    }
}