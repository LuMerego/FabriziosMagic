﻿using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure;
using Spire.Pdf.Graphics;
using System.Drawing.Imaging;
using Spire.Pdf;
using System.Media;


namespace TestDocRecognizer
{
    public partial class TestDocFabri : Form
    {
        private string selectedFilePath;
        private Button uploadButton;
        private TextBox resultTextBox;
        private Button analyzeButton;
        private SoundPlayer soundPlayer; // Per la riproduzione audio
        private bool isMuted = false; // Stato mute


        public TestDocFabri()
        {
            InitializeComponent();
            this.Load += MainForm_Load; // Evento per caricamento form
        }

        // Metodo per avviare la canzone all'apertura della form
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Rihanna on the beat
                soundPlayer = new SoundPlayer("Media/Rihanna - Take A Bow.wav"); 
                soundPlayer.PlayLooping(); 
            }
            catch
            { 
                //niente musica :(
            }
        }

        // Carica il file da analizzare e genera relativa anteprima
        private async void UploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files pdf|*.pdf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                // Mostra anteprima
                if (Path.GetExtension(selectedFilePath).ToLower() == ".pdf")
                {
                    
                    try
                    {
                        pictureBox1.Visible = true;
                        // Genera anteprima in maniera asincrona, libreria freespire (NON produttiva)
                        await LoadPdfAndDisplayImageAsync(selectedFilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Errore durante la conversione del PDF: {ex.Message}");
                    }
                    finally
                    {
                        pictureBox1.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("PDF preview is not supported yet, but it will be sent for analysis.");
                }
            }
        }

        // Metodo asincrono per caricare e convertire il PDF
        private async Task LoadPdfAndDisplayImageAsync(string filePath)
        {
           
            await Task.Run(() =>
            {
                // Crea un'istanza di PdfDocument
                PdfDocument pdf = new PdfDocument();

                // Carica il PDF selezionato
                pdf.LoadFromFile(filePath);

                // Converte la prima pagina del PDF in immagine Bitmap, se sono più pagine ti attacchi :)
                Stream image = pdf.SaveAsImage(1, PdfImageType.Bitmap);
                //setta picturebox con immagine generata
                pictureBox.Image = Image.FromStream(image);
            });
        }



        // Che la Fabrizio's Magic abbia inizio
        private async void AnalyzeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Si ma prima devi mettere un file, sveglia");
                return;
            }

            // Chiamo azure in modalità asincrona
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show($"Modello, EndPoint e ApiKey devono essere valorizzati");
                }
                else
                {
                    resultTextBox.Text = "Sto analizzando....";
                    var analysisResult = await AnalyzeDocumentAsync(selectedFilePath, textBox2.Text, textBox3.Text, textBox1.Text);
                    resultTextBox.Text = analysisResult;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'analisi: {ex.Message}");
            }
        }

        // metodo asincrono per l'analisi con azure
        private async Task<string> AnalyzeDocumentAsync(string filePath, string endpoint, string apyKey, string Model)
        {
            var client = new DocumentAnalysisClient(new Uri(endpoint), new AzureKeyCredential(apyKey));

            using FileStream stream = new FileStream(filePath, FileMode.Open);

            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, Model, stream);

            var resultText = "RISULTATI" + Environment.NewLine + Environment.NewLine;
            foreach (var kvp in operation.Value.Documents[0].Fields)
            {
                resultText += $"{kvp.Key}:  {kvp.Value.Content}{Environment.NewLine}";
            }
            return resultText;
        }



        private void TestDocFabri_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
