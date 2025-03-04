using System;
using System.Drawing;
using System.Windows.Forms;

namespace CookieClicker
{
    public partial class MainForm : Form
    {
        private int cookies = 0;
        private int clickPower = 1;
        private int autoClickerCost = 15;
        private int autoClickers = 0;
        private int multiplierCost = 100;
        private int multiplierCount = 1;

        public MainForm()
        {
            InitializeComponent();
            LoadGame();
            gameTimer.Start();
        }

        // Initialisierung der Komponenten
        private void InitializeComponent()
        {
            // UI-Elemente
            pbCookie = new PictureBox();
            lblCookies = new Label();
            btnBuyAutoClicker = new Button();
            btnBuyMultiplier = new Button();
            gameTimer = new Timer();

            // PictureBox (Cookie)
            pbCookie.Image = WindowsFormsApp1.Properties.Resources.cookie; // Fügen Sie ein Cookie-Bild hinzu
            pbCookie.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCookie.Size = new Size(150, 150);
            pbCookie.Location = new Point(75, 50);
            pbCookie.MouseDown += PbCookie_MouseDown;

            // Labels
            lblCookies.Font = new Font("Arial", 14F);
            lblCookies.Location = new Point(50, 200);
            lblCookies.Size = new Size(200, 30);

            // Buttons
            btnBuyAutoClicker.Text = $"Autoklicker kaufen ({autoClickerCost})";
            btnBuyAutoClicker.Location = new Point(50, 250);
            btnBuyAutoClicker.Click += BtnBuyAutoClicker_Click;

            btnBuyMultiplier.Text = $"Multiplier x2 ({multiplierCost})";
            btnBuyMultiplier.Location = new Point(50, 300);
            btnBuyMultiplier.Click += BtnBuyMultiplier_Click;

            // Timer
            gameTimer.Interval = 1000;

            // Form
            ClientSize = new Size(300, 400);
            Controls.AddRange(new Control[] { pbCookie, lblCookies, btnBuyAutoClicker, btnBuyMultiplier });
            Text = "Cookie Clicker";
            DoubleBuffered = true;
        }

        private void PbCookie_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cookies += clickPower * multiplierCount;
                UpdateUI();
                CreateClickEffect();
            }
        }

        private void BtnBuyAutoClicker_Click(object sender, EventArgs e)
        {
            if (cookies >= autoClickerCost)
            {
                cookies -= autoClickerCost;
                autoClickers++;
                autoClickerCost = (int)(autoClickerCost * 1.15);
                UpdateUI();
            }
        }

        private void BtnBuyMultiplier_Click(object sender, EventArgs e)
        {
            if (cookies >= multiplierCost)
            {
                cookies -= multiplierCost;
                multiplierCount *= 2;
                multiplierCost *= 4;
                UpdateUI();
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            cookies += autoClickers * multiplierCount;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateUI));
                return;
            }

            lblCookies.Text = $"{cookies} Cookies";
            btnBuyAutoClicker.Text = $"Autoklicker ({autoClickerCost})";
            btnBuyMultiplier.Text = $"Multiplier x{multiplierCount * 2} ({multiplierCost})";
            btnBuyAutoClicker.Enabled = cookies >= autoClickerCost;
            btnBuyMultiplier.Enabled = cookies >= multiplierCost;
        }

        private void CreateClickEffect()
        {
            var effect = new Label
            {
                Text = $"+{clickPower * multiplierCount}",
                Location = new Point(pbCookie.Right + 10, pbCookie.Top + 50),
                ForeColor = Color.Green,
                BackColor = Color.Transparent,
                AutoSize = true
            };

            Controls.Add(effect);
            effect.BringToFront();

            var timer = new Timer { Interval = 20 };
            int y = effect.Top;
            timer.Tick += (s, args) =>
            {
                y -= 2;
                effect.Top = y;
                effect.ForeColor = Color.FromArgb(effect.ForeColor.A - 2, effect.ForeColor);

                if (effect.ForeColor.A <= 2)
                {
                    Controls.Remove(effect);
                    timer.Stop();
                }
            };
            timer.Start();
        }

        private void LoadGame()
        {
            cookies = WindowsFormsApp1.Properties.Settings.Default.Cookie;
            autoClickers = WindowsFormsApp1.Properties.Settings.Default.AutoClickers;
            multiplierCount = WindowsFormsApp1.Properties.Settings.Default.Multiplier;
            UpdateUI();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            WindowsFormsApp1.Properties.Settings.Default.Cookie = cookies;
            WindowsFormsApp1.Properties.Settings.Default.AutoClickers = autoClickers;
            WindowsFormsApp1.Properties.Settings.Default.Multiplier = multiplierCount;
            WindowsFormsApp1.Properties.Settings.Default.Save();
        }

        // UI Elemente
        private PictureBox pbCookie;
        private Label lblCookies;
        private Button btnBuyAutoClicker;
        private Button btnBuyMultiplier;
        private Timer gameTimer;
    }
}
