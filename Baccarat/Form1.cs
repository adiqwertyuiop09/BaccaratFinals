using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Baccarat
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private List<string> deck = new List<string>();


        private int playerBalance = 1000;
        private int currentBetAmount = 0;
        private string currentBetType = "";

        private Image backCardImage;
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
            BackOfCards();
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

        private void BackOfCards()
        {
            string backCardPath = @"C:\BaccaratCards\BackOfCard.jpg";

            if (File.Exists(backCardPath))
            {
                backCardImage = Image.FromFile(backCardPath);

                pbPlayerCard1.Image = backCardImage;
                pbPlayerCard2.Image = backCardImage;
                pbPlayerCard3.Image = backCardImage;
                pbBankerCard1.Image = backCardImage;
                pbBankerCard2.Image = backCardImage;
                pbBankerCard3.Image = backCardImage;

                pbPlayerCard1.SizeMode = PictureBoxSizeMode.StretchImage;
                pbPlayerCard2.SizeMode = PictureBoxSizeMode.StretchImage;
                pbPlayerCard3.SizeMode = PictureBoxSizeMode.StretchImage;
                pbBankerCard1.SizeMode = PictureBoxSizeMode.StretchImage;
                pbBankerCard2.SizeMode = PictureBoxSizeMode.StretchImage;
                pbBankerCard3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                MessageBox.Show("Back of card image not found.");
            }
        }


        private void InitializeDeck()
        {
            deck.Clear();

            string[] cardFiles = new string[]
            {
                    "2OfSpades.jpg", "3OfSpades.jpg", "4OfSpades.jpg", "5OfSpades.jpg",
                    "6OfSpades.jpg", "7OfSpades.jpg", "8OfSpades.jpg", "9OfSpades.jpg",
                    "10OfSpades.jpg", "AceOfSpades.jpg", "JackOfSpades.jpg", "QueenOfSpades.jpg", "KingOfSpades.jpg",

                    "AceOfHearts.png", "2OfHearts.png", "3OfHearts.jpg", "4OfHearts.jpg",
                    "5OfHearts.jpg", "6OfHearts.jpg", "7OfHearts.jpg", "8OfHearts.jpg",
                    "9OfHearts.jpg", "10OfHearts.jpg", "JackOfHearts.jpg", "QueenOfHearts.jpg", "KingOfHearts.jpg"
            };

            deck.AddRange(cardFiles);

          
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }


        private Image DrawCard(out string cardFileName)
        {
            if (deck.Count == 0)
            {
                MessageBox.Show("No more cards in deck!");
                cardFileName = null;
                return null;
            }

            cardFileName = deck[0];
            deck.RemoveAt(0);

            string imageDirectory = @"C:\BaccaratCards\";
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

        private async Task DealCards()
        {
            InitializeDeck();

            pbPlayerCard3.Image = backCardImage;
            pbBankerCard3.Image = backCardImage;


            txtPlayerScore.Text = "";
            txtBankerScore.Text = "";

            string playerCard1File, playerCard2File, bankerCard1File, bankerCard2File;

          
            await Task.Delay(1000);
            pbPlayerCard1.Image = DrawCard(out playerCard1File);
            await Task.Delay(1000);

            pbPlayerCard2.Image = DrawCard(out playerCard2File);
            await Task.Delay(1000);

            pbBankerCard1.Image = DrawCard(out bankerCard1File);
            await Task.Delay(1000);

            pbBankerCard2.Image = DrawCard(out bankerCard2File);
            await Task.Delay(1000);

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
                    pbPlayerCard3.Image = DrawCard(out playerThirdFile);
                    playerThirdValue = GetCardValue(playerThirdFile);
                    playerTotal = (playerTotal + playerThirdValue) % 10;
                    await Task.Delay(1000);
                }
                else
                {
                    pbPlayerCard3.Image = backCardImage;
                    playerThirdValue = -1;
                }

                if (ShouldBankerDraw(bankerTotal, playerThirdValue))
                {
                    pbBankerCard3.Image = DrawCard(out bankerThirdFile);
                    bankerThirdValue = GetCardValue(bankerThirdFile);
                    bankerTotal = (bankerTotal + bankerThirdValue) % 10;
                    await Task.Delay(1000);
                }
            }

            txtPlayerScore.Text = playerTotal.ToString();
            txtBankerScore.Text = bankerTotal.ToString();

            string winner = DetermineWinner(playerTotal, bankerTotal);
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
            BackOfCards();

            txtPlayerScore.Text = string.Empty;
            txtBankerScore.Text = string.Empty;
            lblWinner.Text = string.Empty;

            playerBalance = 1000;
            lblPlayerBalance.Text = $"Player Balance: {playerBalance}";
            txtBetAmount.Text = string.Empty;
        }

        private async void btnDeal_Click(object sender, EventArgs e)
        {
            if (currentBetAmount == 0 || string.IsNullOrEmpty(currentBetType))
            {
                MessageBox.Show("Please place a bet before dealing.");
                return;
            }
            BackOfCards(); 
            await Task.Delay(1500); 
            await DealCards();
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

            BackOfCards();
            txtPlayerScore.Text = string.Empty;
            txtBankerScore.Text = string.Empty;

            lblPlayerBalance.Text = string.Empty;
            txtBetAmount.Text = string.Empty;
        }
     
    }
}
