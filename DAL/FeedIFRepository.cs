using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public  interface FeedIFRepository<T> where T : class
    {
      

         public void delete(T t);
         public void update(T t);
         public void insert(T t);
         public void Save();
       //  public string getFeedTitle(string t);
         public int ItemCounter(string t);

        
         public List<T> GetAll();
    }

