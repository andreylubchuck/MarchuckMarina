using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMix
{
    abstract class CocktailBuilder
    {
        public abstract void buildLiquid(string liq);
        public abstract void buildIce(string ice);
        public abstract void buildDecoration(string dec);
        public abstract Cocktail getCocktail(int price);
    }

    class Cocktail
    {
        List<string> ingredients = new List<string>();
        int price;
        public void Add(string part)
        {
            ingredients.Add(part);
        }
        public string Print()
        {
            string ing = "";
            for (int i = 0; i < ingredients.Count; i++)
            {
                ing += ingredients[i] + "\n";
            }
            return ing;
        }
        public void SetPrice(int p)
        {
            price = p;
        }
        public int GetPrice()
        {
            return price;
        }
        public bool Make()
        {
            ConnectToDB conn = new ConnectToDB();
            bool liq = false;
            if (ingredients[0] != "")
                liq = conn.RemoveItemFromWarehouse(ingredients[0], 1);
            bool dec = false;
            if (ingredients[2] != "")
                dec = conn.RemoveItemFromWarehouse(ingredients[2], 1);

            if (liq && dec)
                return true;
            else
            {
                if (liq)
                    conn.AddItemToWarehouse(ingredients[0], 1);
                else if (dec)
                    conn.AddItemToWarehouse(ingredients[2], 1);
                return false;
            }
        }
    }

    class Bar
    {
        CocktailBuilder builder;
        public Bar(CocktailBuilder builder)
        {
            this.builder = builder;
        }
        public void Construct(string liq, string ice, string dec)
        {
            builder.buildLiquid(liq);
            builder.buildIce(ice);
            builder.buildDecoration(dec);
        }
    }
}
