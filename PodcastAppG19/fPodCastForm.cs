using PodcastAppG19.BLL;
using System;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data;
using PodcastAppG19.ExceptionHandling;
using PodcastAppG19.PodcastAppG19;

namespace PodcastAppG19
{
    public partial class fPodCast : Form
    {


        Feedcontoller feedcontoller;
        private List<Feed> feeds;
        Catagorycontroller catagorycontroller;
        private bool valideringPasserad = false;



        public fPodCast()
        {

            feeds = new List<Feed>();
            InitializeComponent();
            feedcontoller = new Feedcontoller();
            catagorycontroller = new Catagorycontroller();
            UpdateContentforCatagory();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblRubrik_Click(object sender, EventArgs e)
        {

        }

        private void btnTaBort_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {

                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;


                Feed selectedFeed = feeds[selectedRowIndex];


                feeds.Remove(selectedFeed);


                feedcontoller.DeleteFeedAndContents(selectedFeed);


                dataGridView1.Rows.RemoveAt(selectedRowIndex);
            }
            else
            {
                MessageBox.Show("Please select a feed to delete.");
            }


        }




        private void btnLaggTill_Click(object sender, EventArgs e)
        {
            string namn = txtbNamn.Text;
            string url = txtbURL.Text;
            string stringFrekvensen = cbBFrekvens.Text;
            int frekvens = 0;
            string kategori = cbBKategori.Text;
            if (Validering.NamnKontroll(namn, RutaNamn))
            {
                if (cbBFrekvens.Text == "1 min")
                {
                    frekvens = 1;
                }
                else if (cbBFrekvens.Text == "5 min")
                {
                    frekvens = 5;
                }
                else if (cbBFrekvens.Text == "10 min")
                {
                    frekvens = 10;
                }

                Category category = new Category(kategori);

                Feed feed = new Feed(namn, url, frekvens, category);

                string title = feed.getFeedTitle();
                int antalAvsnitt = feed.getEpisodeNumber();

                // Använd AddEpisode-metoden för att lägga till avsnitt i feeden
                feed.AddEpisode("Avsnitt 1", "Beskrivning av avsnitt 1");
                feed.AddEpisode("Avsnitt 2", "Beskrivning av avsnitt 2");

                int r = dataGridView1.Rows.Add();
                dataGridView1.Rows[r].Cells[1].Value = namn;
                dataGridView1.Rows[r].Cells[2].Value = title;
                dataGridView1.Rows[r].Cells[3].Value = stringFrekvensen;
                dataGridView1.Rows[r].Cells[4].Value = kategori;
                dataGridView1.Rows[r].Cells[0].Value = antalAvsnitt;

                if (antalAvsnitt == -1)
                {
                    dataGridView1.Rows[r].Cells[1].Value = "";
                    dataGridView1.Rows[r].Cells[2].Value = "";
                    dataGridView1.Rows[r].Cells[3].Value = "";
                    dataGridView1.Rows[r].Cells[4].Value = "";
                    dataGridView1.Rows[r].Cells[0].Value = "";
                }
                else
                {
                    dataGridView1.Rows[r].Cells[0].Value = antalAvsnitt;
                }

                // Clear and repopulate dataGridView2 with episodes
                dataGridView2.Rows.Clear();
                foreach (var episode in feed.Episodes)
                {
                    int row = dataGridView2.Rows.Add();
                    dataGridView2.Rows[row].Cells[0].Value = episode.Namn;
                }

                // Add the new feed to the list of feeds
                feeds.Add(feed);

                // Serialize the updated list of feeds
                feed.FeedSerailizer(feeds);
            }
            else
            {
                // Visa felmeddelande om valideringen misslyckas.
                MessageBox.Show("Valideringen misslyckades. Åtgärda fel innan du fortsätter.");

            }
            
        }



        private void txtbNamn_TextChanged(object sender, EventArgs e)
        {

            bool valideringResultat = Validering.NamnKontroll(txtbNamn.Text, RutaNamn);
            valideringPasserad = valideringResultat;

        }

        private void cbBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {



            // Rensa DataGridView2 för att börja med en tom lista av avsnitt
            dataGridView2.Rows.Clear();

            // Kontrollera om användaren klickade på en giltig cell
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Hämta den valda feeden baserat på raden i DataGridView1
                Feed selectedFeed = feeds[e.RowIndex];

                // Loopa igenom avsnitten och lägg till beskrivning (eller namn) i DataGridView2
                foreach (var episode in selectedFeed.Episodes)
                {
                    int r = dataGridView2.Rows.Add();
                    dataGridView2.Rows[r].Cells[0].Value = episode.Beskrivning; // Byt ut mot episode.Namn om du vill ha namnen istället
                }
            }
        }














        private void fPodCast_Load(object sender, EventArgs e)
        {

        }

        string name;


        private void Catagory_Click(object sender, EventArgs e)
        {
            if (valideringPasserad)
            {
                Catagorycontroller controll = new Catagorycontroller();
                controll.create(kategoritxtb.Text);
                //  controll.create(name);

                int r = dataGridView3.Rows.Add();

                dataGridView3.Rows[r].Cells[0].Value = kategoritxtb.Text;

                UpdateContentforCatagory();
            }
            else
            {
                MessageBox.Show("Valideringen misslyckades. Åtgärda fel innan du fortsätter.");
            }

        }
        private void UpdateContentforCatagory()
        {
            cbBKategori.Items.Clear();
            foreach (Category category in catagorycontroller.GetallaCatagory())
            {
                cbBKategori.Items.Add(category.Title);
            }

            if (cbBKategori.Items.Count == 0)
            {
                return;
            }

            cbBKategori.SelectedIndex = 0;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateContentforCatagory();
        }






        private void btnTaBort1_Click(object sender, EventArgs e)
        {


            Category category = catagorycontroller.GetCategoryByName(kategoritxtb.Text);
            DialogResult dialogResult = MessageBox.Show($"Radera kategorin " + category.Title, "Varning!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                feedcontoller.DeleteOnCategory(category);
                catagorycontroller.remove(category);

                // catagorycontroller.removeCategorybyindex();

                //catagorycontroller.RemoveCategory(cbBKategori.ToString());
                catagorycontroller.RemoveCategory(kategoritxtb.ToString());

                UpdateContentforCatagory();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Ingen kategorier har raderats");
            }


        }

        private void txtbKategori_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbBKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kategoritxtb_TextChanged(object sender, EventArgs e)
        {
            bool valideringResultat = Validering.NamnKontroll(kategoritxtb.Text, KategoriNamn);
            valideringPasserad = valideringResultat;
        }

        private void btnAndra1_Click(object sender, EventArgs e)
        {
            string oldCategory = cbBKategori.SelectedItem.ToString();
            string newCategory = kategoritxtb.Text;

            catagorycontroller.UppdateKatagory(oldCategory, newCategory);
            feedcontoller.UpdateFeedCategory(oldCategory, newCategory);

            UpdateContentforCatagory();
        }

        private void btnAndra_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                Feed selectedFeed = feeds[selectedRowIndex];
                string newFeedName = txtbNamn.Text; // Hämta namn från användaren

                // Kontrollera att det nya namnet inte är tomt eller ogiltigt
                if (!string.IsNullOrWhiteSpace(newFeedName))
                {
                    feedcontoller.UpdateFeedName(selectedFeed, newFeedName);

                    // Uppdatera användargränssnittet med det nya namnet
                    dataGridView1.Rows[selectedRowIndex].Cells[1].Value = newFeedName;

                    MessageBox.Show("Namnet på feeden har uppdaterats.");
                }
                else
                {
                    MessageBox.Show("Ange ett giltigt nytt namn för feeden.");
                }
            }
            else
            {
                MessageBox.Show("Välj en feed att uppdatera namnet för.");
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
