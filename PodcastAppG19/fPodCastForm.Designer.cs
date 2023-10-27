namespace PodcastAppG19
{
    partial class fPodCast
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
            lblRubrik = new Label();
            lblNamn = new Label();
            txtbNamn = new TextBox();
            cbBFrekvens = new ComboBox();
            cbBKategori = new ComboBox();
            cbBFilter = new ComboBox();
            btnLaggTill = new Button();
            btnAndra = new Button();
            btnTaBort = new Button();
            btnAterstall = new Button();
            lblURL = new Label();
            lblAvsnitt = new Label();
            lblKategori = new Label();
            Catagory = new Button();
            btnTaBort1 = new Button();
            btnAndra1 = new Button();
            dataGridView1 = new DataGridView();
            AntalAvsnitt = new DataGridViewTextBoxColumn();
            FlodesNamn = new DataGridViewTextBoxColumn();
            FlodesTitel = new DataGridViewTextBoxColumn();
            FlodesFrekvens = new DataGridViewTextBoxColumn();
            FlodesKategori = new DataGridViewTextBoxColumn();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            txtbINFO = new TextBox();
            fontDialog1 = new FontDialog();
            dataGridView2 = new DataGridView();
            AvsnittC = new DataGridViewTextBoxColumn();
            dataGridView3 = new DataGridView();
            kategori = new DataGridViewTextBoxColumn();
            kategoritxtb = new TextBox();
            txtbURL = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // lblRubrik
            // 
            lblRubrik.AutoSize = true;
            lblRubrik.Font = new Font("SimSun", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblRubrik.Location = new Point(666, 29);
            lblRubrik.Name = "lblRubrik";
            lblRubrik.Size = new Size(195, 47);
            lblRubrik.TabIndex = 0;
            lblRubrik.Text = "PODCAST";
            lblRubrik.Click += lblRubrik_Click;
            // 
            // lblNamn
            // 
            lblNamn.AutoSize = true;
            lblNamn.Location = new Point(70, 111);
            lblNamn.Name = "lblNamn";
            lblNamn.Size = new Size(115, 20);
            lblNamn.TabIndex = 1;
            lblNamn.Text = "NAMN (Valfritt):";
            // 
            // txtbNamn
            // 
            txtbNamn.ForeColor = SystemColors.ControlText;
            txtbNamn.Location = new Point(70, 133);
            txtbNamn.Name = "txtbNamn";
            txtbNamn.Size = new Size(318, 27);
            txtbNamn.TabIndex = 2;
            txtbNamn.Text = "ex...Namn";
            txtbNamn.TextChanged += txtbNamn_TextChanged;
            // 
            // cbBFrekvens
            // 
            cbBFrekvens.ForeColor = SystemColors.WindowText;
            cbBFrekvens.FormattingEnabled = true;
            cbBFrekvens.Items.AddRange(new object[] { "1 min", "5 min ", "10 min" });
            cbBFrekvens.Location = new Point(70, 167);
            cbBFrekvens.Name = "cbBFrekvens";
            cbBFrekvens.Size = new Size(115, 28);
            cbBFrekvens.TabIndex = 3;
            cbBFrekvens.Text = "1 min ";
            cbBFrekvens.SelectedIndexChanged += cbBFrekvens_SelectedIndexChanged;
            // 
            // cbBKategori
            // 
            cbBKategori.FormattingEnabled = true;
            cbBKategori.Items.AddRange(new object[] { "Dokumentär", "Historia", "Karriär ", "Humor", "Kriminal" });
            cbBKategori.Location = new Point(189, 167);
            cbBKategori.Name = "cbBKategori";
            cbBKategori.Size = new Size(199, 28);
            cbBKategori.TabIndex = 4;
            cbBKategori.Text = "Dokumentär";
            cbBKategori.SelectedIndexChanged += cbBKategori_SelectedIndexChanged;
            // 
            // cbBFilter
            // 
            cbBFilter.FormattingEnabled = true;
            cbBFilter.Location = new Point(447, 91);
            cbBFilter.Name = "cbBFilter";
            cbBFilter.Size = new Size(227, 28);
            cbBFilter.TabIndex = 5;
            cbBFilter.Text = "Filtrera...";
            cbBFilter.SelectedIndexChanged += cbBFilter_SelectedIndexChanged_1;
            // 
            // btnLaggTill
            // 
            btnLaggTill.Location = new Point(466, 137);
            btnLaggTill.Name = "btnLaggTill";
            btnLaggTill.Size = new Size(94, 29);
            btnLaggTill.TabIndex = 7;
            btnLaggTill.Text = "Lägg till";
            btnLaggTill.UseVisualStyleBackColor = true;
            btnLaggTill.Click += btnLaggTill_Click;
            // 
            // btnAndra
            // 
            btnAndra.Location = new Point(566, 137);
            btnAndra.Name = "btnAndra";
            btnAndra.Size = new Size(94, 29);
            btnAndra.TabIndex = 8;
            btnAndra.Text = "Ändra";
            btnAndra.UseVisualStyleBackColor = true;
            btnAndra.Click += btnAndra_Click;
            // 
            // btnTaBort
            // 
            btnTaBort.Location = new Point(666, 137);
            btnTaBort.Name = "btnTaBort";
            btnTaBort.Size = new Size(141, 29);
            btnTaBort.TabIndex = 9;
            btnTaBort.Text = "Ta bort";
            btnTaBort.UseVisualStyleBackColor = true;
            btnTaBort.Click += btnTaBort_Click;
            // 
            // btnAterstall
            // 
            btnAterstall.Location = new Point(699, 101);
            btnAterstall.Name = "btnAterstall";
            btnAterstall.Size = new Size(107, 29);
            btnAterstall.TabIndex = 10;
            btnAterstall.Text = "Återställ";
            btnAterstall.UseVisualStyleBackColor = true;
            btnAterstall.Click += btnAterstall_Click;
            // 
            // lblURL
            // 
            lblURL.AutoSize = true;
            lblURL.Location = new Point(403, 175);
            lblURL.Name = "lblURL";
            lblURL.Size = new Size(38, 20);
            lblURL.TabIndex = 11;
            lblURL.Text = "URL:";
            // 
            // lblAvsnitt
            // 
            lblAvsnitt.AutoSize = true;
            lblAvsnitt.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblAvsnitt.Location = new Point(935, 164);
            lblAvsnitt.Name = "lblAvsnitt";
            lblAvsnitt.Size = new Size(90, 35);
            lblAvsnitt.TabIndex = 13;
            lblAvsnitt.Text = "Avsnitt";
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.Location = new Point(1161, 147);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(80, 20);
            lblKategori.TabIndex = 15;
            lblKategori.Text = "KATEGORI:";
            // 
            // Catagory
            // 
            Catagory.Location = new Point(1161, 204);
            Catagory.Name = "Catagory";
            Catagory.Size = new Size(94, 29);
            Catagory.TabIndex = 16;
            Catagory.Text = "Lägg till";
            Catagory.UseVisualStyleBackColor = true;
            Catagory.Click += Catagory_Click;
            // 
            // btnTaBort1
            // 
            btnTaBort1.Location = new Point(1376, 204);
            btnTaBort1.Name = "btnTaBort1";
            btnTaBort1.Size = new Size(94, 29);
            btnTaBort1.TabIndex = 17;
            btnTaBort1.Text = "Ta bort";
            btnTaBort1.UseVisualStyleBackColor = true;
            btnTaBort1.Click += btnTaBort1_Click;
            // 
            // btnAndra1
            // 
            btnAndra1.Location = new Point(1261, 204);
            btnAndra1.Name = "btnAndra1";
            btnAndra1.Size = new Size(109, 29);
            btnAndra1.TabIndex = 18;
            btnAndra1.Text = "Ändra";
            btnAndra1.UseVisualStyleBackColor = true;
            btnAndra1.Click += btnAndra1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ButtonShadow;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { AntalAvsnitt, FlodesNamn, FlodesTitel, FlodesFrekvens, FlodesKategori });
            dataGridView1.Location = new Point(70, 204);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.ShowCellToolTips = false;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.Size = new Size(737, 541);
            dataGridView1.TabIndex = 19;
            dataGridView1.CellStateChanged += dataGridView1_CellStateChanged;
            dataGridView1.RowStateChanged += dataGridView1_RowStateChanged;
            // 
            // AntalAvsnitt
            // 
            AntalAvsnitt.FillWeight = 103.857552F;
            AntalAvsnitt.HeaderText = "Antal avsnitt";
            AntalAvsnitt.MinimumWidth = 6;
            AntalAvsnitt.Name = "AntalAvsnitt";
            AntalAvsnitt.Width = 139;
            // 
            // FlodesNamn
            // 
            FlodesNamn.FillWeight = 90.50349F;
            FlodesNamn.HeaderText = "Namn";
            FlodesNamn.MinimumWidth = 6;
            FlodesNamn.Name = "FlodesNamn";
            FlodesNamn.Width = 125;
            // 
            // FlodesTitel
            // 
            FlodesTitel.FillWeight = 90.75368F;
            FlodesTitel.HeaderText = "Titel";
            FlodesTitel.MinimumWidth = 6;
            FlodesTitel.Name = "FlodesTitel";
            FlodesTitel.Width = 125;
            // 
            // FlodesFrekvens
            // 
            FlodesFrekvens.FillWeight = 90.9574356F;
            FlodesFrekvens.HeaderText = "Frekvens";
            FlodesFrekvens.MinimumWidth = 6;
            FlodesFrekvens.Name = "FlodesFrekvens";
            FlodesFrekvens.Width = 125;
            // 
            // FlodesKategori
            // 
            FlodesKategori.FillWeight = 123.927841F;
            FlodesKategori.HeaderText = "Kategori";
            FlodesKategori.MinimumWidth = 6;
            FlodesKategori.Name = "FlodesKategori";
            FlodesKategori.Width = 170;
            // 
            // txtbINFO
            // 
            txtbINFO.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtbINFO.Location = new Point(1161, 492);
            txtbINFO.Multiline = true;
            txtbINFO.Name = "txtbINFO";
            txtbINFO.ScrollBars = ScrollBars.Vertical;
            txtbINFO.Size = new Size(309, 253);
            txtbINFO.TabIndex = 22;
            txtbINFO.TextChanged += txtbINFO_TextChanged;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { AvsnittC });
            dataGridView2.Location = new Point(810, 204);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.ShowCellToolTips = false;
            dataGridView2.Size = new Size(345, 541);
            dataGridView2.TabIndex = 23;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick_1;
            dataGridView2.RowStateChanged += dataGridView2_RowStateChanged;
            // 
            // AvsnittC
            // 
            AvsnittC.HeaderText = "Avsnitt";
            AvsnittC.MinimumWidth = 6;
            AvsnittC.Name = "AvsnittC";
            AvsnittC.ReadOnly = true;
            AvsnittC.Width = 292;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.AllowUserToResizeColumns = false;
            dataGridView3.AllowUserToResizeRows = false;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { kategori });
            dataGridView3.Location = new Point(1161, 239);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.RowTemplate.Height = 29;
            dataGridView3.Size = new Size(309, 247);
            dataGridView3.TabIndex = 24;
            dataGridView3.CellContentClick += dataGridView3_CellContentClick;
            // 
            // kategori
            // 
            kategori.HeaderText = "Kategori";
            kategori.MinimumWidth = 6;
            kategori.Name = "kategori";
            kategori.Width = 255;
            // 
            // kategoritxtb
            // 
            kategoritxtb.Location = new Point(1161, 175);
            kategoritxtb.Name = "kategoritxtb";
            kategoritxtb.Size = new Size(309, 27);
            kategoritxtb.TabIndex = 26;
            kategoritxtb.TextChanged += kategoritxtb_TextChanged;
            // 
            // txtbURL
            // 
            txtbURL.Location = new Point(447, 172);
            txtbURL.Name = "txtbURL";
            txtbURL.Size = new Size(359, 27);
            txtbURL.TabIndex = 27;
            // 
            // fPodCast
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1482, 753);
            Controls.Add(txtbURL);
            Controls.Add(kategoritxtb);
            Controls.Add(Catagory);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(txtbINFO);
            Controls.Add(dataGridView1);
            Controls.Add(btnAndra1);
            Controls.Add(btnTaBort1);
            Controls.Add(lblKategori);
            Controls.Add(lblAvsnitt);
            Controls.Add(lblURL);
            Controls.Add(btnAterstall);
            Controls.Add(btnAndra);
            Controls.Add(btnLaggTill);
            Controls.Add(cbBFilter);
            Controls.Add(cbBKategori);
            Controls.Add(cbBFrekvens);
            Controls.Add(txtbNamn);
            Controls.Add(lblNamn);
            Controls.Add(lblRubrik);
            Controls.Add(btnTaBort);
            Name = "fPodCast";
            Text = "PODCAST";
            Load += fPodCast_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRubrik;
        private Label lblNamn;
        private TextBox txtbNamn;
        private ComboBox cbBFrekvens;
        private ComboBox cbBKategori;
        private ComboBox cbBFilter;
        private Button btnLaggTill;
        private Button btnAndra;
        private Button btnTaBort;
        private Button btnAterstall;
        private Label lblURL;
        private Label lblAvsnitt;
        private TextBox txtbKategori;
        private Label lblKategori;
        private Button Catagory;
        private Button btnTaBort1;
        private Button btnAndra1;
        private DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox txtbINFO;
        private FontDialog fontDialog1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn AvsnittC;
        private DataGridViewTextBoxColumn AntalAvsnitt;
        private DataGridViewTextBoxColumn FlodesNamn;
        private DataGridViewTextBoxColumn FlodesTitel;
        private DataGridViewTextBoxColumn FlodesFrekvens;
        private DataGridViewTextBoxColumn FlodesKategori;
        private DataGridView dataGridView3;
        private TextBox kategoritxtb;
        private DataGridViewTextBoxColumn kategori;
        private TextBox txtbURL;
    }
}