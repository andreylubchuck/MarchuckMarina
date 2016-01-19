using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMix
{
    class ProductBuilder : CocktailBuilder
    {
        Cocktail product = new Cocktail();
        public override void buildLiquid(string liq)
        {
            product.Add(liq);
        }
        public override void buildIce(string ice)
        {
            product.Add(ice);
        }
        public override void buildDecoration(string dec)
        {
            product.Add(dec);
        }
        public override Cocktail getCocktail(int price)
        {
            product.SetPrice(price);
            return product;
        }
    }
}
