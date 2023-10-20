
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PodcastAppG19.BLL;

namespace PodcastAppG19.DAL
{
    public class class1
    {

        public class1()
        {

        }

        public void SerializeCategory(List<Category> listOfCategorys)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(listOfCategorys.GetType());

            using (FileStream fs = new FileStream("Categorys.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fs, listOfCategorys);
            }

        }

        public List<Category> DeserializeCategory()
        {
            List<Category> categories;
            List<Category> categoriesEmpty = new List<Category>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Category>));

            if (File.Exists(Environment.CurrentDirectory + @"\Categorys.xml"))
            {
                using (FileStream fs = new FileStream("Categorys.xml", FileMode.Open, FileAccess.Read))
                {
                    categories = (List<Category>)xmlSerializer.Deserialize(fs);
                    return categories;
                }
            }
            else
            {
                return categoriesEmpty;
            }

        }

        public void SerializePodcast(List<Feed> listOfPodcast)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(listOfPodcast.GetType());

            using (FileStream fs = new FileStream("Podcast.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fs, listOfPodcast);
            }

        }

        public List<Feed> DeserializePodcast()
        {
            List<Feed> podcastList;
            List<Feed> podcastListEmpty = new List<Feed>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Feed>));

            try
            {
                if (File.Exists(Environment.CurrentDirectory + @"\Podcast.xml"))
                {
                    using (FileStream fs = new FileStream("Podcast.xml", FileMode.Open, FileAccess.Read))
                    {
                        podcastList = (List<Feed>)xmlSerializer.Deserialize(fs);
                        return podcastList;
                    }

                }
                else
                {
                    return podcastListEmpty;
                }
            } catch (System.InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

    }

}
