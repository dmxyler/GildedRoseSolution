using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
  public class ProcessingItemsFactory : IProcessingItemsFactory
    {

        /*
         * NOTES
         * DefaultUpdateStrategy priima parametra INT Tipo, kadangi remiantis reikalavimais, tiek Conjured Items tiek, kitii neisvardinti reikalavimuose t.y. != (Sulfuras, Hand of Ragnaros, Backstage passes to a TAFKAL80ETC concert,Aged Brie)
         * Yra skaiciuojami analogiskai, skiriasi tik daugiklis, Conjured Items reiksme mazeja dvigubai greiciau, negu iprastai. t.y. reikia atimti dvigubai daugiau (arba trigubai, jeigu keistusi uzduotis, paduodmas tik kitas parametras).
         *
         * SulfarasUpdateStrategy -> Lieka tuscias, nes joks if'o keisas neapima jo paskaiciavimo. + Uzduotyje reglamentuota  [- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality]
         */
        public IProcessingItemsStrategy Create(string name)
        {
            switch (name)
            {
                case "Sulfuras, Hand of Ragnaros": // TODO [Komentaras sau] - Sitoje vietoje vietoj string values galetu but enum'ai, arba atskira klase su assigned properciais? nes jeigu keisis reiksme, tai reikes koreguot per minimum 2 vietas, lista ir cia ir jeiu dar kur nors naudosis reiksme, dar kazkur
                    return new SulfarasUpdateStrategy(); // Sitas straegy nepapuola i jokius If'o rezius (visi if'ai yra  t.Name != "Sulfuras....." t.y. nieko skaiciuot nereikia, tai paliekam tuscius rezius ateities implementacijoms
                case "Aged Brie":
                    return new AgedBrieUpdateStrategy(); 
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackStagePassesUpdateStrategy(); 
                case "Conjured Mana Cake":
                    return new DefaultUpdateStrategy(2); 
                                                             
                default:
                    return new DefaultUpdateStrategy(); 
            }
        }
    }

  public class DefaultUpdateStrategy : IProcessingItemsStrategy
  {

      private readonly int _decrementalValue;

      public DefaultUpdateStrategy(int decrementalValue = 1)
      {
          _decrementalValue = decrementalValue; 
      }

      public void UpdateQuality(Item item)
      {
          item.SellIn--;
          if (item.Quality > 0)
          {
              item.Quality -= _decrementalValue * (item.SellIn < 0 ? 2 : 1);
          }
          if (item.Quality < 0)
          {
              item.Quality = 0;
          }
      }
    }

  public class BackStagePassesUpdateStrategy : IProcessingItemsStrategy
  {
      public void UpdateQuality(Item item)
      {
          item.SellIn--;
          if (item.SellIn < 0)
          {
              item.Quality = 0;
          }
          else if (item.SellIn <= 5) // [Uzrasai] Nes sablonineje aplikacijoje UpdateQuality metode if'o salygoje, pripliusuojama +1 buvo. t.y.  Items[i].Quality = Items[i].Quality + 1; ir poto eidavo i if'a if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
          {
              item.Quality += 3;
          }
          else if (item.SellIn <= 10) // [Uzrasai] Nes sablonineje aplikacijoje UpdateQuality metode if'o salygoje, pripliusuojama +1 buvo. t.y.  Items[i].Quality = Items[i].Quality + 1; ir poto eidavo i if'a if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
          {
              item.Quality += 2;
          }
          else if (item.Quality < 50)
          {
              item.Quality += 1;
          }
      }
    }

  public class AgedBrieUpdateStrategy : IProcessingItemsStrategy
  {
      public void UpdateQuality(Item item)
      {
          item.SellIn--;
          if (item.Quality < 50)
          {
              item.Quality += 1;
          }
      }
    }

  public class SulfarasUpdateStrategy : IProcessingItemsStrategy
  {
      public void UpdateQuality(Item item)
      {
          // Sitas straegy nepapuola i jokius If'o rezius (visi if'ai yra  t.Name != "Sulfuras....." t.y. nieko skaiciuot nereikia, tai paliekam tuscius rezius ateities implementacijoms
        }
    }
}
