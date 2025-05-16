namespace Baccarat
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

        private void InitializeComponent()
        {
            lblPlayerHandTitle = new Label();
            lblBankerHandTitle = new Label();
            lblWinnerTitle = new Label();
            lblWinner = new Label();
            lblPlayerScore = new Label();
            lblBankerScore = new Label();
            btnDeal = new Button();
            btnReset = new Button();
            pbPlayerCard1 = new PictureBox();
            pbPlayerCard2 = new PictureBox();
            pbBankerCard1 = new PictureBox();
            pbBankerCard2 = new PictureBox();
            txtPlayerScore = new TextBox();
            txtBankerScore = new TextBox();
            btnQuit = new Button();
            txtBetAmount = new TextBox();
            lblBetAmount = new Label();
            lblPlayerBalance = new Label();
            btnPlayerBet = new Button();
            btnBankerBet = new Button();
            btnTieBet = new Button();
            pbPlayerCard3 = new PictureBox();
            pbBankerCard3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbPlayerCard1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPlayerCard2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBankerCard1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBankerCard2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPlayerCard3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBankerCard3).BeginInit();
            SuspendLayout();
            // 
            // lblPlayerHandTitle
            // 
            lblPlayerHandTitle.AutoSize = true;
            lblPlayerHandTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblPlayerHandTitle.Location = new Point(478, 70);
            lblPlayerHandTitle.Name = "lblPlayerHandTitle";
            lblPlayerHandTitle.Size = new Size(124, 24);
            lblPlayerHandTitle.TabIndex = 0;
            lblPlayerHandTitle.Text = "Player Hand";
            // 
            // lblBankerHandTitle
            // 
            lblBankerHandTitle.AutoSize = true;
            lblBankerHandTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblBankerHandTitle.Location = new Point(880, 70);
            lblBankerHandTitle.Name = "lblBankerHandTitle";
            lblBankerHandTitle.Size = new Size(132, 24);
            lblBankerHandTitle.TabIndex = 2;
            lblBankerHandTitle.Text = "Banker Hand";
            // 
            // lblWinnerTitle
            // 
            lblWinnerTitle.AutoSize = true;
            lblWinnerTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblWinnerTitle.Location = new Point(400, 464);
            lblWinnerTitle.Name = "lblWinnerTitle";
            lblWinnerTitle.Size = new Size(77, 24);
            lblWinnerTitle.TabIndex = 4;
            lblWinnerTitle.Text = "Winner";
            // 
            // lblWinner
            // 
            lblWinner.AutoSize = true;
            lblWinner.Font = new Font("Arial", 10F);
            lblWinner.Location = new Point(483, 468);
            lblWinner.Name = "lblWinner";
            lblWinner.Size = new Size(0, 19);
            lblWinner.TabIndex = 5;
            // 
            // lblPlayerScore
            // 
            lblPlayerScore.AutoSize = true;
            lblPlayerScore.Font = new Font("Arial", 10F);
            lblPlayerScore.Location = new Point(406, 375);
            lblPlayerScore.Name = "lblPlayerScore";
            lblPlayerScore.Size = new Size(105, 19);
            lblPlayerScore.TabIndex = 6;
            lblPlayerScore.Text = "Player Score";
            // 
            // lblBankerScore
            // 
            lblBankerScore.AutoSize = true;
            lblBankerScore.Font = new Font("Arial", 10F);
            lblBankerScore.Location = new Point(406, 421);
            lblBankerScore.Name = "lblBankerScore";
            lblBankerScore.Size = new Size(110, 19);
            lblBankerScore.TabIndex = 7;
            lblBankerScore.Text = "Banker Score";
            // 
            // btnDeal
            // 
            btnDeal.Location = new Point(637, 464);
            btnDeal.Name = "btnDeal";
            btnDeal.Size = new Size(94, 29);
            btnDeal.TabIndex = 8;
            btnDeal.Text = "Deal";
            btnDeal.UseVisualStyleBackColor = true;
            btnDeal.Click += btnDeal_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(820, 464);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // pbPlayerCard1
            // 
            pbPlayerCard1.Location = new Point(392, 118);
            pbPlayerCard1.Name = "pbPlayerCard1";
            pbPlayerCard1.Size = new Size(134, 177);
            pbPlayerCard1.SizeMode = PictureBoxSizeMode.Zoom;
            pbPlayerCard1.TabIndex = 10;
            pbPlayerCard1.TabStop = false;
            // 
            // pbPlayerCard2
            // 
            pbPlayerCard2.Location = new Point(553, 118);
            pbPlayerCard2.Name = "pbPlayerCard2";
            pbPlayerCard2.Size = new Size(134, 177);
            pbPlayerCard2.SizeMode = PictureBoxSizeMode.Zoom;
            pbPlayerCard2.TabIndex = 11;
            pbPlayerCard2.TabStop = false;
            // 
            // pbBankerCard1
            // 
            pbBankerCard1.Location = new Point(795, 118);
            pbBankerCard1.Name = "pbBankerCard1";
            pbBankerCard1.Size = new Size(134, 177);
            pbBankerCard1.SizeMode = PictureBoxSizeMode.Zoom;
            pbBankerCard1.TabIndex = 12;
            pbBankerCard1.TabStop = false;
            // 
            // pbBankerCard2
            // 
            pbBankerCard2.Location = new Point(961, 118);
            pbBankerCard2.Name = "pbBankerCard2";
            pbBankerCard2.Size = new Size(134, 177);
            pbBankerCard2.SizeMode = PictureBoxSizeMode.Zoom;
            pbBankerCard2.TabIndex = 13;
            pbBankerCard2.TabStop = false;
            // 
            // txtPlayerScore
            // 
            txtPlayerScore.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPlayerScore.Location = new Point(528, 368);
            txtPlayerScore.Name = "txtPlayerScore";
            txtPlayerScore.ReadOnly = true;
            txtPlayerScore.Size = new Size(125, 30);
            txtPlayerScore.TabIndex = 14;
            // 
            // txtBankerScore
            // 
            txtBankerScore.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBankerScore.Location = new Point(528, 414);
            txtBankerScore.Name = "txtBankerScore";
            txtBankerScore.ReadOnly = true;
            txtBankerScore.Size = new Size(125, 30);
            txtBankerScore.TabIndex = 15;
            // 
            // btnQuit
            // 
            btnQuit.Location = new Point(1022, 463);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(94, 29);
            btnQuit.TabIndex = 18;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // txtBetAmount
            // 
            txtBetAmount.Location = new Point(56, 112);
            txtBetAmount.Name = "txtBetAmount";
            txtBetAmount.Size = new Size(125, 27);
            txtBetAmount.TabIndex = 19;
            txtBetAmount.TextChanged += txtBetAmount_TextChanged_1;
            // 
            // lblBetAmount
            // 
            lblBetAmount.AutoSize = true;
            lblBetAmount.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBetAmount.Location = new Point(68, 89);
            lblBetAmount.Name = "lblBetAmount";
            lblBetAmount.Size = new Size(102, 23);
            lblBetAmount.TabIndex = 20;
            lblBetAmount.Text = "Bet Amount";
            // 
            // lblPlayerBalance
            // 
            lblPlayerBalance.AutoSize = true;
            lblPlayerBalance.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlayerBalance.Location = new Point(38, 22);
            lblPlayerBalance.Name = "lblPlayerBalance";
            lblPlayerBalance.Size = new Size(165, 23);
            lblPlayerBalance.TabIndex = 21;
            lblPlayerBalance.Text = "Player Balance: 1000";
            // 
            // btnPlayerBet
            // 
            btnPlayerBet.Location = new Point(73, 210);
            btnPlayerBet.Name = "btnPlayerBet";
            btnPlayerBet.Size = new Size(94, 29);
            btnPlayerBet.TabIndex = 22;
            btnPlayerBet.Text = "Player Bet";
            btnPlayerBet.UseVisualStyleBackColor = true;
            // 
            // btnBankerBet
            // 
            btnBankerBet.Location = new Point(73, 271);
            btnBankerBet.Name = "btnBankerBet";
            btnBankerBet.Size = new Size(94, 29);
            btnBankerBet.TabIndex = 23;
            btnBankerBet.Text = "Banker Bet";
            btnBankerBet.UseVisualStyleBackColor = true;
            // 
            // btnTieBet
            // 
            btnTieBet.Location = new Point(73, 336);
            btnTieBet.Name = "btnTieBet";
            btnTieBet.Size = new Size(94, 29);
            btnTieBet.TabIndex = 24;
            btnTieBet.Text = "Tie Bet";
            btnTieBet.UseVisualStyleBackColor = true;
            // 
            // pbPlayerCard3
            // 
            pbPlayerCard3.Location = new Point(231, 118);
            pbPlayerCard3.Name = "pbPlayerCard3";
            pbPlayerCard3.Size = new Size(134, 177);
            pbPlayerCard3.SizeMode = PictureBoxSizeMode.Zoom;
            pbPlayerCard3.TabIndex = 25;
            pbPlayerCard3.TabStop = false;
            // 
            // pbBankerCard3
            // 
            pbBankerCard3.Location = new Point(1123, 118);
            pbBankerCard3.Name = "pbBankerCard3";
            pbBankerCard3.Size = new Size(134, 177);
            pbBankerCard3.SizeMode = PictureBoxSizeMode.Zoom;
            pbBankerCard3.TabIndex = 26;
            pbBankerCard3.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 619);
            Controls.Add(pbBankerCard3);
            Controls.Add(pbPlayerCard3);
            Controls.Add(btnTieBet);
            Controls.Add(btnBankerBet);
            Controls.Add(btnPlayerBet);
            Controls.Add(lblPlayerBalance);
            Controls.Add(lblBetAmount);
            Controls.Add(txtBetAmount);
            Controls.Add(btnQuit);
            Controls.Add(txtBankerScore);
            Controls.Add(txtPlayerScore);
            Controls.Add(pbBankerCard2);
            Controls.Add(pbBankerCard1);
            Controls.Add(pbPlayerCard2);
            Controls.Add(pbPlayerCard1);
            Controls.Add(btnReset);
            Controls.Add(btnDeal);
            Controls.Add(lblBankerScore);
            Controls.Add(lblPlayerScore);
            Controls.Add(lblWinner);
            Controls.Add(lblWinnerTitle);
            Controls.Add(lblBankerHandTitle);
            Controls.Add(lblPlayerHandTitle);
            Name = "Form1";
            Text = "Baccarat Game";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)pbPlayerCard1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPlayerCard2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBankerCard1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBankerCard2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPlayerCard3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBankerCard3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlayerHandTitle;
        private Label lblBankerHandTitle;
        private Label lblWinnerTitle;
        private Label lblWinner;
        private Label lblPlayerScore;
        private Label lblBankerScore;
        private Button btnDeal;
        private Button btnReset;
        private PictureBox pbPlayerCard1;
        private PictureBox pbPlayerCard2;
        private PictureBox pbBankerCard1;
        private PictureBox pbBankerCard2;
        private TextBox txtPlayerScore;
        private TextBox txtBankerScore;
        private Button btnQuit;

        private TextBox txtBetAmount;   
        private Label lblBetAmount;
        private Label lblPlayerBalance;
        private Button btnPlayerBet;
        private Button btnBankerBet;
        private Button btnTieBet;
        private PictureBox pbPlayerCard3;
        private PictureBox pbBankerCard3;
    }
}

