using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PodcastAppG19.BLL;

namespace PodcastAppG19.DAL
{
     internal class Serializer : XmlSerializer
    {
        public Serializer() { }

        public void SerializeFeedXML(List<Feed> lista)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Feed>));

            using (FileStream filestream = new FileStream("Podcast.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(filestream, lista);
            }
            
        }

        public List<Feed> DeserializeFeedXML()
        {
            List<Feed> lista = new List<Feed>();
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Feed>));

                using (FileStream filestream = new FileStream("Podcast.xml", FileMode.Open, FileAccess.Read))
                {
                    lista = (List<Feed>)xmlSerializer.Deserialize(filestream);
                }

                return lista;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Podcast.xml hittas ej");
                return lista;
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine("Fel på XML dokument, dubbelkolla taggar.");
                return lista;
            }
        }

        public void SerializeCatagoryXML(List<Category> lista)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Category>));

            using (FileStream filestream = new FileStream("Category.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(filestream, lista);
            }
        }

        public List<Category> DeserializeCatagoryXML()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Category>));
            List<Category> lista;

            using (FileStream filestream = new FileStream("Category.xml", FileMode.Open, FileAccess.Read))
            {
                lista = (List<Category>)xmlSerializer.Deserialize(filestream);
            }

            return lista;
        }


    }

}
