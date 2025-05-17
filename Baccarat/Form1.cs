using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Baccarat
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        private int playerBalance = 1000;
        private int currentBetAmount = 0;
        private string currentBetType = "";

        public Form1()
        {
            InitializeComponent();
            
           
            btnPlayerBet.Click += BtnPlayerBet_Click;
            btnBankerBet.Click += BtnBankerBet_Click;
            btnTieBet.Click += BtnTieBet_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblPlayerBalance.Text = $"Player Balance: {playerBalance}";
        }

        private void BtnPlayerBet_Click(object sender, EventArgs e)
        {
            PlaceBet("Player");
        }

        private void BtnBankerBet_Click(object sender, EventArgs e)
        {
            PlaceBet("Banker");
        }

        private void BtnTieBet_Click(object sender, EventArgs e)
        {
            PlaceBet("Tie");
        }

        private void PlaceBet(string betType)
        {
            if (!int.TryParse(txtBetAmount.Text, out int bet))
            {
                MessageBox.Show("Please enter a valid bet amount.");
                return;
            }

            if (bet > playerBalance)
            {
                MessageBox.Show("You don't have enough balance.");
                return;
            }

            currentBetAmount = bet;
            currentBetType = betType;
            MessageBox.Show($"Bet placed on {betType} for {bet}.");
        }

        private Image GetRandomCardImage(out string cardFileName)
        {
            string imageDirectory = @"C:\BaccaratCards\";

            string[] cardFiles = new string[]
            {
                "2OfSpades.jpg", "3OfSpades.jpg", "4OfSpades.jpg", "5OfSpades.jpg",
                "6OfSpades.jpg", "7OfSpades.jpg", "8OfSpades.jpg", "9OfSpades.jpg",
                "10OfSpades.jpg", "AceOfSpades.jpg", "JackOfSpades.jpg", "QueenOfSpades.jpg", "KingOfSpades.jpg",

                "AceOfHearts.png", "2OfHearts.png", "3OfHearts.jpg"
            };

            cardFileName = cardFiles[random.Next(cardFiles.Length)];
            string cardImagePath = Path.Combine(imageDirectory, cardFileName);

            if (!File.Exists(cardImagePath))
            {
                MessageBox.Show($"File not found: {cardImagePath}");
                return null;
            }

            try
            {
                return Image.FromFile(cardImagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
                return null;
            }
        }

        private bool ShouldPlayerDraw(int playerScore)
        {
            
            return playerScore <= 5;
        }

        private bool ShouldBankerDraw(int bankerScore, int playerThirdCard)
        {
            if (playerThirdCard == -1) 
                return bankerScore <= 5;

            if (bankerScore <= 2) return true;
            if (bankerScore == 3 && playerThirdCard != 8) return true;
            if (bankerScore == 4 && playerThirdCard >= 2 && playerThirdCard <= 7) return true;
            if (bankerScore == 5 && playerThirdCard >= 4 && playerThirdCard <= 7) return true;
            if (bankerScore == 6 && (playerThirdCard == 6 || playerThirdCard == 7)) return true;

            return false;
        }


        private void DealCards()
        {
            pbPlayerCard3.Image = null;
            pbBankerCard3.Image = null;

            txtPlayerScore.Text = "";
            txtBankerScore.Text = "";
            lblWinner.Text = "";

            string playerCard1File, playerCard2File, bankerCard1File, bankerCard2File;

           
            pbPlayerCard1.Image = GetRandomCardImage(out playerCard1File);
            pbPlayerCard2.Image = GetRandomCardImage(out playerCard2File);
            pbBankerCard1.Image = GetRandomCardImage(out bankerCard1File);
            pbBankerCard2.Image = GetRandomCardImage(out bankerCard2File);

            int playerCard1Value = GetCardValue(playerCard1File);
            int playerCard2Value = GetCardValue(playerCard2File);
            int bankerCard1Value = GetCardValue(bankerCard1File);
            int bankerCard2Value = GetCardValue(bankerCard2File);

            int playerTotal = (playerCard1Value + playerCard2Value) % 10;
            int bankerTotal = (bankerCard1Value + bankerCard2Value) % 10;

            int playerThirdValue = -1;
            int bankerThirdValue = -1;

            string playerThirdFile = "", bankerThirdFile = "";

           
            bool natural = playerTotal >= 8 || bankerTotal >= 8;

            if (!natural)
            {
               
                if (ShouldPlayerDraw(playerTotal))
                {
                    pbPlayerCard3.Image = GetRandomCardImage(out playerThirdFile);
                    playerThirdValue = GetCardValue(playerThirdFile);

                    MessageBox.Show($"Player drew: {playerThirdFile}\nValue: {playerThirdValue}\nPrevious total: {(playerCard1Value + playerCard2Value) % 10}\nNew total: {(playerCard1Value + playerCard2Value + playerThirdValue) % 10}");


                    playerTotal = (playerTotal + playerThirdValue) % 10;
                }
                else
                {
                    pbPlayerCard3.Image = null;
                    playerThirdValue = -1;
                }


               
                if (ShouldBankerDraw(bankerTotal, playerThirdValue))
                {
                    pbBankerCard3.Image = GetRandomCardImage(out bankerThirdFile);
                    bankerThirdValue = GetCardValue(bankerThirdFile);

                    MessageBox.Show($"Banker drew: {bankerThirdFile}\nValue: {bankerThirdValue}\nPrevious total: {(bankerCard1Value + bankerCard2Value) % 10}\nNew total: {(bankerCard1Value + bankerCard2Value + bankerThirdValue) % 10}");


                    bankerTotal = (bankerTotal + bankerThirdValue) % 10;
                }
            }

           
            txtPlayerScore.Text = playerTotal.ToString();
            txtBankerScore.Text = bankerTotal.ToString();

            string winner = DetermineWinner(playerTotal, bankerTotal);
            lblWinner.Text = winner;

            ApplyBettingResult(winner);
        }


        private int CalculateScore(string card1FileName, string card2FileName) // redundant code ayoko pa burahin pwede magamit if papalitan score calculation
        {
            int card1Value = GetCardValue(card1FileName);
            int card2Value = GetCardValue(card2FileName);
            return (card1Value + card2Value) % 10;
        }

        private int GetCardValue(string cardFileName)
        {
            if (string.IsNullOrEmpty(cardFileName))
                return 0;

            string cardName = Path.GetFileNameWithoutExtension(cardFileName);

            if (cardName.Contains("Ace"))
                return 1;
            else if (cardName.Contains("Jack") || cardName.Contains("Queen") || cardName.Contains("King") || cardName.Contains("10"))
                return 0;
            else
            {
                int index = cardName.IndexOf("Of");
                if (index > 0)
                {
                    string numberPart = cardName.Substring(0, index);
                    if (int.TryParse(numberPart, out int value))
                        return value;
                }
                return 0;
            }
        }


        private string DetermineWinner(int playerScore, int bankerScore)
        {
            string result;
            Color resultColor;

            if (playerScore > bankerScore)
            {
                result = "Player Wins!";
                resultColor = Color.Blue;
            }
            else if (playerScore < bankerScore)
            {
                result = "Banker Wins!";
                resultColor = Color.Green;
            }
            else
            {
                result = "It's a Tie!";
                resultColor = Color.Orange;
            }

            lblWinner.Text = result;
            lblWinner.ForeColor = resultColor;
            lblWinner.Font = new Font(lblWinner.Font.FontFamily, 9, FontStyle.Bold | FontStyle.Italic);
            lblWinner.TextAlign = ContentAlignment.MiddleCenter;

            return result;
        }


        private void ApplyBettingResult(string winnerText)
        {
            bool won = false;

            if (currentBetType == "Player" && winnerText.Contains("Player"))
                won = true;
            else if (currentBetType == "Banker" && winnerText.Contains("Banker"))
                won = true;
            else if (currentBetType == "Tie" && winnerText.Contains("Tie"))
                won = true;

            if (won)
            {
                int winnings = currentBetAmount;

                if (currentBetType == "Tie")
                    winnings *= 8;
                else if (currentBetType == "Banker")
                    winnings = (int)(winnings * 0.95);

                playerBalance += winnings;
                MessageBox.Show($"You won! +{winnings}");
            }
            else
            {
                playerBalance -= currentBetAmount;
                MessageBox.Show($"You lost! -{currentBetAmount}");
            }

            lblPlayerBalance.Text = $"Player Balance: {playerBalance}";

            currentBetAmount = 0;
            currentBetType = "";
        }

        private void ResetGame()
        {
            pbPlayerCard1.Image = null;
            pbPlayerCard2.Image = null;
            pbPlayerCard3.Image = null;
            pbBankerCard1.Image = null;
            pbBankerCard2.Image = null;            
            pbBankerCard3.Image = null;

            txtPlayerScore.Text = string.Empty;
            txtBankerScore.Text = string.Empty;
            lblWinner.Text = string.Empty;

            playerBalance = 1000;
            lblPlayerBalance.Text = $"Player Balance: {playerBalance}";
            txtBetAmount.Text = string.Empty;
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            if (currentBetAmount == 0 || string.IsNullOrEmpty(currentBetType))
            {
                MessageBox.Show("Please place a bet before dealing.");
                return;
            }

            DealCards();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            lblWinner.Text = "Developer Wins!"; // idk ilalagay pag nag quit
            lblWinner.ForeColor = Color.Red;
            lblWinner.Font = new Font(lblWinner.Font.FontFamily, 9, FontStyle.Bold | FontStyle.Italic);
            lblWinner.TextAlign = ContentAlignment.MiddleCenter;

            btnDeal.Enabled = false;
            btnReset.Enabled = false;
            btnQuit.Enabled = false;

            pbPlayerCard1.Image = null;
            pbPlayerCard2.Image = null;
            pbPlayerCard3.Image = null;
            pbBankerCard1.Image = null;
            pbBankerCard2.Image = null;
            pbBankerCard3.Image = null;
            txtPlayerScore.Text = string.Empty;
            txtBankerScore.Text = string.Empty;

            lblPlayerBalance.Text = string.Empty;
            txtBetAmount.Text = string.Empty;
        }

        private void lblPlayerBalance_Click(object sender, EventArgs e)
        {

        }

        private void txtBetAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void txtBetAmount_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
