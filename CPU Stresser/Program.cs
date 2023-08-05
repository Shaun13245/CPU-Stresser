using System;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace CPU_Stresser
{
    public partial class Program : Form
    {

        public Program()
        {
            InitializeComponent();
        }

        private NumericUpDown numericUpDown1;
        private Label Heading_lbl;
        private Label label1;
        private Button Go_btn;
        private Button Stop_btn;
        private static bool running = true;
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());
        }

        private static void burn()
        {
            while (true)
            {
                if (!running) break;
            }
        }

        private void InitializeComponent()
        {
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Heading_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Go_btn = new System.Windows.Forms.Button();
            this.Stop_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(95, 54);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 0;
            // 
            // Heading_lbl
            // 
            this.Heading_lbl.AutoSize = true;
            this.Heading_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heading_lbl.Location = new System.Drawing.Point(12, 9);
            this.Heading_lbl.Name = "Heading_lbl";
            this.Heading_lbl.Size = new System.Drawing.Size(233, 31);
            this.Heading_lbl.TabIndex = 2;
            this.Heading_lbl.Text = "CPU Stress tester";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CPU Threads:";
            // 
            // Go_btn
            // 
            this.Go_btn.Location = new System.Drawing.Point(18, 80);
            this.Go_btn.Name = "Go_btn";
            this.Go_btn.Size = new System.Drawing.Size(197, 35);
            this.Go_btn.TabIndex = 4;
            this.Go_btn.Text = "GO!";
            this.Go_btn.UseVisualStyleBackColor = true;
            this.Go_btn.Click += new System.EventHandler(this.Go_btn_Click);
            // 
            // Stop_btn
            // 
            this.Stop_btn.Location = new System.Drawing.Point(18, 121);
            this.Stop_btn.Name = "Stop_btn";
            this.Stop_btn.Size = new System.Drawing.Size(197, 35);
            this.Stop_btn.TabIndex = 5;
            this.Stop_btn.Text = "Stop";
            this.Stop_btn.UseVisualStyleBackColor = true;
            this.Stop_btn.Click += new System.EventHandler(this.Stop_btn_Click);
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(279, 180);
            this.Controls.Add(this.Stop_btn);
            this.Controls.Add(this.Go_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Heading_lbl);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "Program";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Stop_btn_Click(object sender, EventArgs e)
        {
            running = false;
            Console.WriteLine("Ending test");
        }

        private void Go_btn_Click(object sender, EventArgs e)
        {
            
            int n = (int)numericUpDown1.Value;
            ThreadStart ts = new ThreadStart(burn);
            Console.WriteLine("Starting test");
            for (int i = 0; i < n; i++)
            {
                Thread burnThread = new Thread(ts);
                burnThread.Start();
            }
        }
    }
}