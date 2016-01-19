using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMix
{
    class PriorityQueue     //цена является приоритетом - в первую очередь мы делаем более дорогие коктейли
    {
        public bool warehouseErr = false;
        List<Cocktail> data = new List<Cocktail>();
        public void Add(Cocktail cocktail)
        {
            int i = 0;
            while (i < data.Count)
            {
                if (cocktail.GetPrice() > data[i].GetPrice())
                    i++;
                else
                {
                    data.Insert(i, cocktail);
                    break;
                }
            }
            data.Add(cocktail);
        }
        public Cocktail Pop()
        {
            if (data.Count == 0)
            {
                warehouseErr = false;
                return null;
            }
            Cocktail result = data[data.Count - 1];
            if (result.Make())
            {
                data.RemoveAt(data.Count - 1);
                return result;
            }
            else
            {
                warehouseErr = true;
                return null;
            }
        }
    }
    class OrderSystem
    {
        public static bool warehouseError = false;
        public static PriorityQueue queue = new PriorityQueue();
        private static Cocktail Build(string liq, string ice, string dec, int price)
        {
            CocktailBuilder builder = new ProductBuilder();
            Bar b = new Bar(builder);
            b.Construct(liq, ice, dec);
            Cocktail c = builder.getCocktail(price);
            return c;
        }
        public static void AddOrder(string name)
        {
            ConnectToDB conn = new ConnectToDB();
            int price = conn.GetCocktailPrice(name);
            List<string> content = conn.GetCocktailContent(name);
            Cocktail cocktail = Build(content[0], content[1], content[2], price);
            queue.Add(cocktail);
        }
        public static Cocktail ReleaseOrder()
        {
            Cocktail result = queue.Pop();
            warehouseError = queue.warehouseErr;
            return result;
        }
    }
}
