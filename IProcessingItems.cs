using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public interface IProcessingItemsFactory  
    {
        IProcessingItemsStrategy Create(string name); // Paduodamas suformuoto listo elementas paeiliui (pvz. Conjured... | Backstage....|) ir t.t.
    }

    public interface IProcessingItemsStrategy
    {
        void UpdateQuality(Item item); // Naudojant Strategy metoda iskaidomas atskiro listo elemento apskaiciavimas (Quality ir SellIn)
    }
}
