using Azure.AI.FormRecognizer.DocumentAnalysis;
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
        private float zoomFactor = 1.0f; // Variabile per il fattore di zoom
        private Image originalImage; // Memorizza l'immagine originale
        private List<Image> pdfImages;
        private int currentPageIndex = 0;


        public TestDocFabri()
        {
            InitializeComponent();
            this.Load += MainForm_Load; // Evento per caricamento form
            this.MouseWheel += new MouseEventHandler(MainForm_MouseWheel);
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Mouse wheel");
            if (e.Delta >1)
            {
                ZoomInOut(false);
            }
            else
            {
                ZoomInOut(true);
            }
            
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
            currentPageIndex = 0;
            pdfImages = new List<Image>();
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
                        await LoadPdfAndDisplayImagesAsync(selectedFilePath);
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



        private async Task LoadPdfAndDisplayImagesAsync(string filePath)
        {
            await Task.Run(() =>
            {
                // Crea un'istanza di PdfDocument
                PdfDocument pdf = new PdfDocument();

                // Carica il PDF selezionato
                pdf.LoadFromFile(filePath);

                // Inizializza la lista di immagini
                pdfImages = new List<Image>();

                // Cicla tutte le pagine del PDF
                for (int i = 0; i < pdf.Pages.Count; i++)
                {
                    try
                    {
                        // Converte ogni pagina in immagine Bitmap
                        Stream imageStream = pdf.SaveAsImage(i, PdfImageType.Bitmap);

                        // Controlla se lo stream è vuoto o corrotto
                        if (imageStream == null || imageStream.Length == 0)
                        {
                            throw new Exception($"Errore nella conversione della pagina {i + 1}");
                        }

                        Image pageImage = Image.FromStream(imageStream);

                        // Aggiungi l'immagine alla lista
                        pdfImages.Add(pageImage);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Errore nella conversione della pagina {i + 1}: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Aggiungi un'immagine di fallback o interrompi il processo
                    }
                }

                // Usa Invoke per aggiornare la PictureBox nel thread della UI
                if (pictureBox.InvokeRequired)
                {
                    pictureBox.Invoke((MethodInvoker)delegate
                    {
                        // Mostra la prima pagina
                        DisplayPage(0);
                    });
                }
                else
                {
                    // Mostra la prima pagina
                    DisplayPage(0);
                }
            });
        }

        private void DisplayPage(int pageIndex)
        {
            if (pageIndex >= 0 && pageIndex < pdfImages.Count)
            {
                // Aggiorna la pictureBox con l'immagine della pagina corrente
                pictureBox.Image = pdfImages[pageIndex];
                currentPageIndex = pageIndex;
            }
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

        private void ZoomInOut(bool zoom)
        {
            //Zoom ratio by which the images will be zoomed by default
            int zoomRatio = 10;
            //Set the zoomed width and height
            int widthZoom = pictureBox.Width * zoomRatio / 100;
            int heightZoom = pictureBox.Height * zoomRatio / 100;
            //zoom = true --> zoom in
            //zoom = false --> zoom out
            if (!zoom)
            {
                widthZoom *= -1;
                heightZoom *= -1;
            }
            //Add the width and height to the picture box dimensions
            pictureBox.Width += widthZoom;
            pictureBox.Height += heightZoom;

        }

        private void TestDocFabri_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPageIndex > 0)
            {
                DisplayPage(currentPageIndex - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pdfImages.Count - 1)
            {
                DisplayPage(currentPageIndex + 1);
            }
        }
    }
}
