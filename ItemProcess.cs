namespace csharp
{
    public class ItemProcess
    {
        public ItemProcess()
        {
        }


        // REFACTORED (Metodas nebenaudojamas po STEP 2 [FACTORY / STRATEGY] realizacijos) paliekamas kaip if else spread sheet'as

        public void SetItemQuality(Item t)
        {

            if (t.Name != "Aged Brie" && t.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (t.Quality > 0)
                {
                    if (t.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        t.Quality -= 1;
                    }
                }
            }
            else
            {
                if (t.Quality < 50)
                {
                    t.Quality += 1;

                    if (t.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        BackStagePassesToA_TAFKAL80ETC_concert(t);
                    }
                }
            }

            if (t.Name != "Sulfuras, Hand of Ragnaros")
            {
                t.SellIn -= 1;
            }

            if (t.SellIn < 0)
            {
                if (t.Name != "Aged Brie")
                {
                    if (t.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (t.Quality > 0)
                        {
                            if (t.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                t.Quality -= 1;
                            }
                        }
                    }
                    else
                    {
                        t.Quality = t.Quality - t.Quality;
                    }
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality += 1;
                    }
                }
            }
        }

        // STEP 4 - If'as < 11 ir < 6, jis gali but apjungtas su Quality Tikrinimu
        private void BackStagePassesToA_TAFKAL80ETC_concert(Item t)
        {
            if (t.Quality < 50)
            {
                if (t.SellIn < 11)
                {
                    t.Quality += 1;
                }

                if (t.SellIn < 6)
                {
                    t.Quality += 1;
                }
            }
        }
    }
}