using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        private readonly ItemProcess _itemProcess;
        private readonly IProcessingItemsFactory _strategy = new ProcessingItemsFactory();

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            _itemProcess = new ItemProcess();
        }

        public void UpdateQuality()
        {
            // STEP 1 TODO - Konvertuojamas ciklas i Foreach
            foreach (var item in Items)
            {
                // STEP 1.1 -- Isrefactorinam i atskira metoda, kad funkcija nedarytu keliu darbu vienu metu (KISS Principas)
                //_itemProcess.SetItemQuality(t); // STEP 2 -> Isrefactorinama i atskira metoda, kuris tures buti skaidomas smulkiau, nes if else "razgalynes" negalima palikt
               
                // Naudojamas Factory + Stragegy patternas
                // Factory (Pasirenkamas konkretus listo elementas 
                // Strategy (Pasirinkus atskira konkretu listo elementa yra reikalinga atskira klase, kurioje aprasoma kaip tas listo elementas apskaiciuojamas)
                var updateStrategy = _strategy.Create(item.Name);
                updateStrategy.UpdateQuality(item);
            }
        }
    }
}
