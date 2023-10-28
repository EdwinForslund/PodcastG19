using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using PodcastAppG19.BLL;
using PodcastAppG19.ExceptionHandling;
using System.Net;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Reflection;

namespace PodcastAppG19.DAL
{
    public class RepositoryFeed : FeedIFRepository<Feed>
    {



      //  Serializer serializeXml = new Serializer();
       
 
        NewSerailzer se = new NewSerailzer();
        List<Feed> lista;






        public RepositoryFeed()
        {
            lista = new List<Feed>();
            GetAll();

        }


        public void insert(Feed entity)
        {
            lista.Add(entity);
            Save();
        }



        public void Save()
        {
            //serializeXml.SerializeFeedXML(lista);
            se.SerializeFeedfodcast(lista);
        }




        public List<Feed> GetAll()
        {
            //  return serializeXml.DeserializeFeedXML();
           return  se.DeserializeFeedpodcast();

        }

        public void Updatenamn(string gammaltNamn, string nyttNamn)
        {
            foreach (Feed feed in lista)
            {
                if (feed.namn.Equals(gammaltNamn))
                {
                    feed.namn = nyttNamn;
                }
            }
            Save();
        }



        public Feed GetByName(string name)
        {
            // Skapar en LINQ-fråga som filtrerar mediaobjekt i lista där namn-egenskapen matchar det angivna namnet.
            var podQuery = from feed in lista
                           where feed.namn == name
                           select feed;

            // Sparar data innan du returnerar och uppdaterar sedan listan
            Save();
            GetAll();

            // Returnerar det första matchande mediaobjektet om det finns något.
            return podQuery.FirstOrDefault();
        }


        public void delete(Feed t)

        {

            lista.Remove(t);
            Save();
        }

        public void update(Feed t)
        {

            // Create a list to store updated podcasts
            List<Feed> updatedPodcasts = new List<Feed>();

            // Iterate through the existing podcasts and remove those with the same name as the new podcast
            foreach (var pod in lista)
            {
                if (pod.namn != t.namn)
                {
                    updatedPodcasts.Add(pod);
                }
            }

            // Replace the old list with the updated list
            lista = updatedPodcasts;

            // Add the new podcast
            insert(t);

            // Retrieve all data
            GetAll();




        }

      



        public async Task<string> GetFeedTitleAsync(string url)
        {
            try
            {
                if (url.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    XDocument file = XDocument.Load(url);
                    var firstTitle = await Task.Run(() => file.Descendants("title").First());
                    string title = firstTitle.Value;
                    return title;
                }
                else
                {
                    throw new UrlException(new XDocument(), "URL ska sluta på .xml");
                }
            }
            catch (UrlException ex)
            {
                // Observera: Här används normalt en Exception-loggning eller annan hantering,
                // eftersom MessageBox inte är tillgänglig utanför UI-tråden.
                // Logga ex med lämplig mekanism eller använd lämplig hantering för applikationen.
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("URL ej hittad, försök igen!");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception klass :(" + ex.Message);
                return null;
            }
        }









        // Metod som retunerar siffran på antalet objekt där objekten är avnsitt LINQ-fråga
        public int ItemCounter(string url)
        {

            int antalObjekt = -1;  // Initiera antalObjekt med ett standardvärde för att kunna lämna objekt tomma senare i koden.

            try
            {
                if (url.Contains("feed", StringComparison.OrdinalIgnoreCase)
                     || url.Contains("pod", StringComparison.OrdinalIgnoreCase))
                {

                    XDocument filen = XDocument.Load(url);
                    List<XElement> antalObjektsLista = filen.Descendants("title").ToList();
                    int index = 0;

                    foreach (XElement item in antalObjektsLista)
                    {
                        string title = (string)item;
                        if (title.Contains("."))
                        {
                            index++;
                        }
                    }

                    antalObjekt = index;
                }
                else

                    // Kasta ett anpassat undantag med felmeddelandet om URL:en inte har rätt format
                    throw new UrlException(new XDocument(), "Denna länk är ogiltig eller leder inte till en prenumererbar podcast");
            }
            catch (UrlException)
            {

            }
            catch (System.IO.FileNotFoundException)
            {
                //MessageBox.Show("URL ej hittad, försök igen!");
            }
            catch (Exception)
            {

            }
            
            return antalObjekt;  // Returnera antalObjekt
        
        }

        public List<Episode> GetEpisodes(string url) 
        {
            List<Episode> avsnittsLista = new List<Episode>();

            try
            {
                if (url.Contains("feed", StringComparison.OrdinalIgnoreCase)
                    || url.Contains("pod", StringComparison.OrdinalIgnoreCase))
                {

                XDocument filen = XDocument.Load(url);
                List<XElement> beskrivningsLista = filen.Descendants("description").ToList();
                List<XElement> titleLista = filen.Descendants("title").ToList(); 
                int index = 0;

                    foreach (XElement item in titleLista)
                    {
                        string title = (string)item;
                        if (title.Contains("."))
                        {
                            avsnittsLista.Add(new Episode(title, (string)beskrivningsLista.ElementAt(index)));
                            index++;

                        }
                    }

                    return avsnittsLista;
                }
                else

                    //Kasta ett anpassat undantag med felmeddelandet om URL:en inte har rätt format
                    throw new UrlException(new XDocument(), "Denna länk är ogiltig eller leder inte till en prenumererbar ljud- eller videofeed");
            }
            catch
            {
                return avsnittsLista;
            }
        }


        public void UpdateFeedCategory(string oldCategory, string newCategory)
        {
            foreach (Feed feed in lista)
            {
                if (feed.category.Title.Equals(oldCategory))
                {
                    feed.category.Title = newCategory;
                }
            }
            Save();
        }


        public void DeleteFeedAndContents(Feed feed)
        {
            // Remove the feed from the list
            lista.Remove(feed);

            // Optionally, delete any associated content or perform cleanup here

            Save(); // Save the updated list
        }



        public void DeletePodcastOnCategory(Category cat)
        {
            lista.RemoveAll(podcast => podcast.category.Title == cat.Title);
            Save();
            GetAll();
        }


        public void UpdateFeedName(Feed feed, string newFeedName)
        {
            foreach (Feed f in lista)
            {
                if (f == feed)
                {
                    f.namn = newFeedName;
                    Save(); // Save the updated feed list
                    break;
                }
            }
        }
    }




}
