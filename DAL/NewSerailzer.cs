﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using PodcastAppG19.BLL;

namespace PodcastAppG19.DAL
{
    public class NewSerailzer
    {
        public NewSerailzer()
        {

        }

        public void Serializercategory(List<Category> listOfCategorys)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(listOfCategorys.GetType());

                using (FileStream fs = new FileStream("Katagori.xml", FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(fs, listOfCategorys);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public List<Category> Deserializercategory()
        {
            List<Category> categorilista = new List<Category>();

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Category>));

                if (File.Exists(Environment.CurrentDirectory + @"\Katagori.xml"))
                {
                    using (FileStream fs = new FileStream("Katagori.xml", FileMode.Open, FileAccess.Read))
                    {
                        return (List<Category>)xmlSerializer.Deserialize(fs);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return categorilista;
        }

        public void SerializeFeedfodcast(List<Feed> listOfPodcast)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(listOfPodcast.GetType());

                using (FileStream fs = new FileStream("Podcast.xml", FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(fs, listOfPodcast);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public List<Feed> DeserializeFeedpodcast()
        {
            List<Feed> podcastListEmpty = new List<Feed>();

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Feed>));

                if (File.Exists(Environment.CurrentDirectory + @"\Podcast.xml"))
                {
                    using (FileStream fs = new FileStream("Podcast.xml", FileMode.Open, FileAccess.Read))
                    {
                        return (List<Feed>)xmlSerializer.Deserialize(fs);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return podcastListEmpty;
        }
    }
}
