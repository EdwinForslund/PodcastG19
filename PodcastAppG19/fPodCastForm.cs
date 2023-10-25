using PodcastAppG19.BLL;
using System;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data;
using PodcastAppG19.ExceptionHandling;
using System.Security.Policy;


namespace PodcastAppG19
{
    public partial class fPodCast : Form
    {
        Episodecontroller episodecontroller;

        Feedcontoller feedcontoller;
        private List<Feed> feeds;
        Catagorycontroller catagorycontroller;




        public fPodCast()
        {

            feeds = new List<Feed>();
            InitializeComponent();
            feedcontoller = new Feedcontoller();
            catagorycontroller = new Catagorycontroller();
            episodecontroller = new Episodecontroller();
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

            // Validation: Ensure that the user enters valid data
            if (string.IsNullOrEmpty(namn) || string.IsNullOrEmpty(url) || string.IsNullOrEmpty(stringFrekvensen) || string.IsNullOrEmpty(kategori))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (stringFrekvensen == "1 min")
            {
                frekvens = 1;
            }
            else if (stringFrekvensen == "5 min")
            {
                frekvens = 5;
            }
            else if (stringFrekvensen == "10 min")
            {
                frekvens = 10;
            }

            Category category = new Category(kategori);

            Feed feed = new Feed(namn, url, frekvens, category);

            // Sample episodes
            feed.AddEpisode("Avsnitt 1", "Beskrivning av avsnitt 1");
            feed.AddEpisode("Avsnitt 2", "Beskrivning av avsnitt 2");

            int r = dataGridView1.Rows.Add();
            dataGridView1.Rows[r].Cells[1].Value = namn;
            dataGridView1.Rows[r].Cells[2].Value = feed.getFeedTitle();
            dataGridView1.Rows[r].Cells[3].Value = stringFrekvensen;
            dataGridView1.Rows[r].Cells[4].Value = kategori;
            int antalAvsnitt = feed.getEpisodeNumber();

            // Check if the number of episodes is -1 and handle it appropriately
            if (antalAvsnitt == -1)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Rows[r].Cells[i].Value = "";
                }
            }
            else
            {
                dataGridView1.Rows[r].Cells[0].Value = antalAvsnitt;
            }

            // Add the new feed to the list of feeds
            feeds.Add(feed);

            // Clear and repopulate dataGridView2 with episodes
            dataGridView2.Rows.Clear();
            foreach (var episode in feed.Episodes)
            {
                int row = dataGridView2.Rows.Add();
                dataGridView2.Rows[row].Cells[0].Value = episode.Namn;
            }

            // Serialize the updated list of feeds
            feed.FeedSerailizer(feeds);
        }


        private void txtbNamn_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {





            string selectedCategory = cbBFilter.SelectedItem.ToString();

            // Clear the current rows in the DataGridView
            dataGridView1.Rows.Clear();

            // Filter the feeds based on the selected category
            List<Feed> filteredFeeds = feeds.Where(feed => feed.category.Title == selectedCategory).ToList();

            // Populate the DataGridView with the filtered feeds
            foreach (var feed in filteredFeeds)
            {
                int r = dataGridView1.Rows.Add();
                dataGridView1.Rows[r].Cells[1].Value = feed.namn;
                dataGridView1.Rows[r].Cells[2].Value = feed.getFeedTitle();
                dataGridView1.Rows[r].Cells[3].Value = feed.uppdateringsfrekvens.ToString() + " min";
                dataGridView1.Rows[r].Cells[4].Value = feed.category.Title;
                int antalAvsnitt = feed.getEpisodeNumber();

                // Check if the number of episodes is -1 and handle it appropriately
                if (antalAvsnitt == -1)
                {
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dataGridView1.Rows[r].Cells[i].Value = "";
                    }
                }
                else
                {
                    dataGridView1.Rows[r].Cells[0].Value = antalAvsnitt;
                }
            }





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
            // Check if the clicked cell is valid
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Clear the rows in dataGridView2
                dataGridView2.Rows.Clear();

                // Get the selected feed based on the clicked cell in dataGridView1
                Feed selectedFeed = feeds[e.RowIndex];

                // Loop through the episodes and add them to dataGridView2
                    foreach (var episode in selectedFeed.Episodes)
                   {
                        int r = dataGridView2.Rows.Add();
                        dataGridView2.Rows[r].Cells[0].Value = episode.Namn;
                        dataGridView2.Rows[r].Cells[1].Value = episode.Beskrivning;
                    }// Display episode description


               
           }
         }
        private void fPodCast_Load(object sender, EventArgs e)
        {

        }

        string name;


        private void Catagory_Click(object sender, EventArgs e)
        {
            Catagorycontroller controll = new Catagorycontroller();
            controll.create(kategoritxtb.Text);
            //  controll.create(name);

            int r = dataGridView3.Rows.Add();

            //dataGridView3.Rows[r].Cells[0].Value = txtbKategori.Text;

            dataGridView3.Rows[r].Cells[0].Value = kategoritxtb.Text;



            UpdateContentforCatagory();

        }



        private void UpdateContentforCatagory()
        {
            cbBKategori.Items.Clear();
            dataGridView3.Rows.Clear();
            cbBFilter.Items.Clear(); // Clear the filter combo box
            int categoryRow = 0;
            foreach (Category category in catagorycontroller.GetallaCatagory())
            {
                cbBKategori.Items.Add(category.Title);
                cbBFilter.Items.Add(category.Title); // Add categories to the filter combo box
                dataGridView3.Rows.Add();
                dataGridView3.Rows[categoryRow].Cells[0].Value = category.Title;
                categoryRow++;
            }

            if (cbBKategori.Items.Count == 0)
            {
                return;
            }

            cbBKategori.SelectedIndex = 0;
            cbBFilter.SelectedIndex = 0; // Set the default selected category for filtering
        }








        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateContentforCatagory();
        }






        private void btnTaBort1_Click(object sender, EventArgs e)
        {
            string categoryName;
            try
            {
                categoryName = (string)dataGridView3.SelectedRows[0].Cells[0].Value;
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ingen kategori var vald!" + Environment.NewLine + "Se till att markera en kategori genom att klicka på rutan bredvid kategorinamnet!");
                return;
            }
            Category category = catagorycontroller.GetCategoryByName(categoryName);
            DialogResult dialogResult = MessageBox.Show("Radera kategorin " + category.Title, "Varning!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                feedcontoller.DeleteOnCategory(category);
                catagorycontroller.remove(category);

                catagorycontroller.RemoveCategory(categoryName);

                UpdateContentforCatagory();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Ingen kategori har raderats");
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

        }

        private void btnAndra1_Click(object sender, EventArgs e)
        {
            string oldCategory;
            string newCategory;
            try
            {
                oldCategory = (string)dataGridView3.SelectedRows[0].Cells[0].Value; //cbBKategori.SelectedItem.ToString();
                newCategory = kategoritxtb.Text;
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ingen kategori var vald!" + Environment.NewLine +"Se till att markera en kategori genom att klicka på rutan bredvid kategorinamnet!");
                return;
            }

            if (string.IsNullOrWhiteSpace(newCategory)) 
            {
                MessageBox.Show("Kategori namnet får inte vara tomt!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Ändra namn på " + oldCategory + " till " + newCategory, "Varning!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) 
            {
                catagorycontroller.UppdateKatagory(oldCategory, newCategory);
                feedcontoller.UpdateFeedCategory(oldCategory, newCategory);
                UpdateContentforCatagory();
            }
        }

        private void btnAndra_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                Feed selectedFeed = feeds[selectedRowIndex];
                string newFeedName = txtbNamn.Text; // H�mta namn fr�n anv�ndaren

                // Kontrollera att det nya namnet inte �r tomt eller ogiltigt
                if (!string.IsNullOrWhiteSpace(newFeedName))
                {
                    feedcontoller.UpdateFeedName(selectedFeed, newFeedName);

                    // Uppdatera anv�ndargr�nssnittet med det nya namnet
                    dataGridView1.Rows[selectedRowIndex].Cells[1].Value = newFeedName;

                    MessageBox.Show("Namnet p� feeden har uppdaterats.");
                }
                else
                {
                    MessageBox.Show("Ange ett giltigt nytt namn f�r feeden.");
                }
            }
            else
            {
                MessageBox.Show("V�lj en feed att uppdatera namnet f�r.");
            }
        }

        private void cbBFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbBFilter.SelectedItem != null)
            {
                string selectedCategory = cbBFilter.SelectedItem.ToString();

                // Now, update your DataGridView with the filtered feeds
                dataGridView1.Rows.Clear();

                // Filter the feeds based on the selected category
                List<Feed> filteredFeeds = feeds.Where(feed => feed.category.Title == selectedCategory).ToList();

                foreach (var feed in filteredFeeds)
                {
                    int frekvens = 0;
                    string stringFrekvensen = cbBFrekvens.Text;

                    if (stringFrekvensen == "1 min")
                    {
                        frekvens = 1;
                    }
                    else if (stringFrekvensen == "5 min")
                    {
                        frekvens = 5;
                    }
                    else if (stringFrekvensen == "10 min")
                    {
                        frekvens = 10;
                    }

                    int antalAvsnitt = feed.getEpisodeNumber();
                    int r = dataGridView1.Rows.Add();
                    dataGridView1.Rows[r].Cells[0].Value = antalAvsnitt;
                    dataGridView1.Rows[r].Cells[1].Value = feed.namn;
                    dataGridView1.Rows[r].Cells[2].Value = feed.getFeedTitle();
                    dataGridView1.Rows[r].Cells[3].Value = stringFrekvensen;
                    dataGridView1.Rows[r].Cells[4].Value = feed.category.Title;
                }
            }
        }





        private void btnAterstall_Click(object sender, EventArgs e)
            {
                // Clear input fields
                txtbNamn.Text = string.Empty;
                txtbURL.Text = string.Empty;

                // Clear the filter combo box if it's not empty
                if (cbBFilter.SelectedItem != null)
                {
                    cbBFilter.SelectedIndex = -1;
                }

              

                // Clear the category combo box
                cbBKategori.SelectedIndex = -1;


            if (cbBFrekvens.SelectedItem != null)
            {
                cbBFrekvens.SelectedIndex = -1;
            }

            // Clear the frequency combo box
            cbBFrekvens.SelectedIndex = -1;

        }







        private void cbBFrekvens_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
