using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AnglickaGramatika
{
    public partial class Form1 : Form
    {
        private List<string> sentences;
        private Dictionary<string, string> sentenceDictionary;
        private string currentSlovakSentence;
        private string importedFilePath = string.Empty;
        private int correctAnswers = 0;
        private int wrongAnswers = 0;
        private List<(string Slovak, string UserAnswer, string CorrectAnswer)> incorrectAnswers;

        public Form1()
        {
            InitializeComponent();
            InitializeSentences();
            incorrectAnswers = new List<(string Slovak, string UserAnswer, string CorrectAnswer)>();
        }

        private string GetLastImportedFilePath()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appDirectory = Path.Combine(appDataPath, "AnglickaGramatika");
            if (!Directory.Exists(appDirectory))
            {
                Directory.CreateDirectory(appDirectory);
            }
            return Path.Combine(appDirectory, "last_imported.txt");
        }

        private void InitializeSentences()
        {
            sentences = new List<string>();
            sentenceDictionary = new Dictionary<string, string>();

            string lastImportedFilePath = GetLastImportedFilePath();
            if (File.Exists(lastImportedFilePath))
            {
                importedFilePath = File.ReadAllText(lastImportedFilePath);
                if (File.Exists(importedFilePath))
                {
                    LoadSentencesFromFile(importedFilePath);
                    string importedFileName = Path.GetFileNameWithoutExtension(importedFilePath);
                    lblSentenceCount.Text = $"Naimportovaná databáza: {importedFileName}";
                }
                else
                {
                    lblSentenceCount.Text = "Nebola naimportovaná žiadna databáza.";
                }
            }
            else
            {
                lblSentenceCount.Text = "Nebola naimportovaná žiadna databáza.";
            }
        }

        private void LoadSentencesFromFile(string filePath)
        {
            sentences = File.ReadAllLines(filePath).ToList();
            sentenceDictionary.Clear();

            foreach (var line in sentences)
            {
                if (line.StartsWith("-"))
                {
                    var parts = line.Substring(1).Split(new[] { "->" }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        sentenceDictionary[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
        }

        private void BtnStartTest_Click(object sender, EventArgs e)
        {
            correctAnswers = 0;
            wrongAnswers = 0;
            incorrectAnswers.Clear();
            lblUserAnswer.Text = "";
            lblResult.Text = "";
            ShowRandomSentence();
        }

        private void ShowRandomSentence()
        {
            var rand = new Random();
            var validSentences = sentenceDictionary.Keys.ToList();

            if (validSentences.Count > 0)
            {
                currentSlovakSentence = validSentences[rand.Next(validSentences.Count)];
                textBoxSentence.Text = currentSlovakSentence;
                textBoxAnswer.Clear();
                lblResult.Text = "";
                lblUserAnswer.Text = "";
                textBoxAnswer.Focus();
            }
            else
            {
                MessageBox.Show("V databáze nie sú dostupné žiadne vety.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TextBoxAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SubmitAnswer();
            }
        }

        private void SubmitAnswer()
        {
            string userAnswer = textBoxAnswer.Text.Trim();
            string correctAnswer = sentenceDictionary[currentSlovakSentence];

            if (correctAnswer.Equals(userAnswer, StringComparison.OrdinalIgnoreCase))
            {
                lblResult.Text = "Správne!";
                lblResult.ForeColor = Color.Green;
                lblUserAnswer.Text = "";
                correctAnswers++;
            }
            else
            {
                lblResult.Text = "Nesprávne!";
                lblResult.ForeColor = Color.Red;
                lblUserAnswer.Text = $"Správna odpoveď: {correctAnswer}";
                incorrectAnswers.Add((currentSlovakSentence, userAnswer, correctAnswer));
                wrongAnswers++;
            }

            var timer = new Timer { Interval = 3000 };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                lblResult.Text = "";
                lblUserAnswer.Text = "";
                ShowRandomSentence();
            };
            timer.Start();
        }

        private void BtnShowStatistics_Click(object sender, EventArgs e)
        {
            int total = correctAnswers + wrongAnswers;

            var statsForm = new Form
            {
                Text = "Štatistika",
                Size = new Size(500, 600),
                StartPosition = FormStartPosition.CenterScreen
            };

            var statsTextBox = new RichTextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill
            };

            statsTextBox.SelectionFont = new Font("Segoe UI", 14, FontStyle.Bold);
            statsTextBox.SelectionColor = Color.Blue;
            statsTextBox.AppendText("Štatistika testu:\n\n");

            statsTextBox.SelectionFont = new Font("Segoe UI", 12, FontStyle.Bold);
            statsTextBox.SelectionColor = Color.Green;
            statsTextBox.AppendText($"Správne: {correctAnswers}\n");

            statsTextBox.SelectionFont = new Font("Segoe UI", 12, FontStyle.Bold);
            statsTextBox.SelectionColor = Color.Red;
            statsTextBox.AppendText($"Nesprávne: {wrongAnswers}\n");

            statsTextBox.SelectionFont = new Font("Segoe UI", 12, FontStyle.Bold);
            statsTextBox.SelectionColor = Color.Black;
            statsTextBox.AppendText($"Úspešnosť: {(total > 0 ? (correctAnswers * 100 / total) : 0)}%\n\n");

            statsTextBox.SelectionFont = new Font("Segoe UI", 14, FontStyle.Bold);
            statsTextBox.SelectionColor = Color.Red;
            statsTextBox.AppendText("Top 10 nesprávnych odpovedí:\n\n");

            foreach (var (slovak, userAnswer, correctAnswer) in incorrectAnswers.Take(10))
            {
                statsTextBox.SelectionFont = new Font("Segoe UI", 12, FontStyle.Regular);
                statsTextBox.SelectionColor = Color.Green;
                statsTextBox.AppendText($"{slovak} - ");

                statsTextBox.SelectionFont = new Font("Segoe UI", 12, FontStyle.Regular);
                statsTextBox.SelectionColor = Color.Red;
                statsTextBox.AppendText($"Vaša odpoveď: '{userAnswer}' - ");

                statsTextBox.SelectionFont = new Font("Segoe UI", 12, FontStyle.Regular);
                statsTextBox.SelectionColor = Color.Black;
                statsTextBox.AppendText($"Správna: '{correctAnswer}'\n");
            }

            statsForm.Controls.Add(statsTextBox);
            statsForm.ShowDialog();
        }

        private void BtnShowDatabase_Click(object sender, EventArgs e)
        {
            var databaseForm = new Form
            {
                Text = "Gramatické vzory",
                Size = new Size(500, 600),
                StartPosition = FormStartPosition.CenterScreen
            };

            var databaseTextBox = new RichTextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill
            };

            foreach (var line in sentences)
            {
                if (line.StartsWith("###"))
                {
                    databaseTextBox.SelectionFont = new Font("Segoe UI", 14, FontStyle.Bold);
                    databaseTextBox.SelectionColor = Color.Blue;
                    databaseTextBox.AppendText(line.Substring(3).Trim() + "\n");
                }
                else if (line.StartsWith("-"))
                {
                    var parts = line.Substring(1).Trim().Split(new[] { "->" }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        databaseTextBox.SelectionFont = new Font("Segoe UI", 12, FontStyle.Regular);
                        databaseTextBox.SelectionColor = Color.Green;
                        databaseTextBox.AppendText(parts[0].Trim());

                        databaseTextBox.SelectionColor = Color.Black;
                        databaseTextBox.AppendText(" -> " + parts[1].Trim() + "\n");
                    }
                }
            }

            databaseForm.Controls.Add(databaseTextBox);
            databaseForm.ShowDialog();
        }

        private void BtnStopTest_Click(object sender, EventArgs e)
        {
            textBoxSentence.Clear();
            textBoxAnswer.Clear();
            lblResult.Text = "";
            lblUserAnswer.Text = "";

            BtnShowStatistics_Click(sender, e);
        }

        private void BtnExportData_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files|*.txt",
                Title = "Uložiť databázu",
                FileName = string.IsNullOrEmpty(importedFilePath) ? "gramaticke_vzory.txt" : Path.GetFileName(importedFilePath)
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveFileDialog.FileName, sentences);
                MessageBox.Show("Dáta boli úspešne exportované!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnImportData_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files|*.txt",
                Title = "Vyberte súbor s dátami"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importedFilePath = openFileDialog.FileName;
                File.WriteAllText(GetLastImportedFilePath(), importedFilePath);
                LoadSentencesFromFile(importedFilePath);

                string importedFileName = Path.GetFileNameWithoutExtension(importedFilePath);
                lblSentenceCount.Text = $"Naimportovaná databáza: {importedFileName}";
                MessageBox.Show("Dáta boli úspešne importované!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
