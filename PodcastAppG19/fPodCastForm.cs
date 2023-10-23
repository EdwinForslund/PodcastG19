using PodcastAppG19.BLL;
using System;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data;
using PodcastAppG19.ExceptionHandling;


namespace PodcastAppG19
{
    public partial class fPodCast : Form
    {


        Feedcontoller feedcontoller;
        private List<Feed> feeds;
        Catagorycontroller catagorycontroller;




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
            feeds.Add(feed);
            feed.FeedSerailizer(feeds);


        }

        private void txtbNamn_TextChanged(object sender, EventArgs e)
        {

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

        }

        private void btnAndra1_Click(object sender, EventArgs e)
        {
            string oldCategory = cbBKategori.SelectedItem.ToString();
            string newCategory = kategoritxtb.Text;

            catagorycontroller.UppdateKatagory(oldCategory, newCategory);
            feedcontoller.UpdateFeedCategory(oldCategory, newCategory);

            UpdateContentforCatagory();
        }
    }
}
