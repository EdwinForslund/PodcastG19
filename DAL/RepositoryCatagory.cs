using PodcastAppG19.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastAppG19.DAL
{
   public class RepositoryCatagory : CatagoryIFRepository<Category>
    {
        Category category;

        List<Category> lista;
        // Serializer serializeXml = new Serializer();
        class1 se = new class1();


        public RepositoryCatagory()
        {
            lista = new List<Category>();
            GetAll();
        }


        public List<Category> GetAll()
        {
            return lista = se.DeserializeCategory();
        }
        public void ChangeCategory(Category newCategory)
        {
            category = newCategory;
        }

        public void DeleteAllCategories()
        {
            throw new NotImplementedException();
        }

        public void DeleteCategoryByName(string name)
        {
            
            
                Category categoryToRemove = null;

                foreach (Category category in lista)
                {
                    if (category.Title.Equals(name))
                    {
                        categoryToRemove = category;
                        break;
                    }
                }

                if (categoryToRemove != null)
                {
                    lista.Remove(categoryToRemove);
                    Save();
                
            }

        }

        public void DeleteCategoryByIndex(int index)
{
    if (index >= 0 && index < lista.Count)
    {
        lista.RemoveAt(index);
        Save();
    }
}


        public Category GetCategoryByName(string name)
        {
            Category category = GetAll().FirstOrDefault(category => category.Title.Equals(name));
            return category;
        }

        public void UpdateCategoryByName(string name, string newName)
        {
            throw new NotImplementedException();
        }

       public void CreateCategory( Category category)
        {
            
                lista.Add(category);
                Save();
                GetAll();
            

        }


        public void Save()
        {
           // serializeXml.SerializeCatagoryXML(lista);
            se.SerializeCategory(lista);
        }

        public void removet(Category en)
        {
            lista.Remove(en); Save();
        }


        public void UppdateraKategori(string GammaltNamn, string NyttNamn)
        {
            Category category1 = GetCategoryByName(GammaltNamn);
            category1.changeTitle(NyttNamn);
            Save();
        }

    }
}
