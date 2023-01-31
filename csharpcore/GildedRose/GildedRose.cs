using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string BackStagePassess = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != AgedBrie
                    && Items[i].Name != BackStagePassess
                    && Items[i].Quality > 0 
                    && Items[i].Name != Sulfuras)
                {
                    _DecrementQuality(i);
                }
                else
                {
                    _IfQualityIsBelowFiftyIncrementQuality(i);

                    if (Items[i].Name == BackStagePassess)
                    {
                        _IfItemSellInIsBelow11(i);
                    }
                }

                if (Items[i].Name != Sulfuras)
                {
                    _DecrementSellIn(i);
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != AgedBrie)
                    {
                        if (Items[i].Name != BackStagePassess)
                        {
                            if (Items[i].Quality > 0)
                            {
                                _IfNotSulfurasReduceItemQuality(i);
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        _IfQualityIsBelowFiftyIncrementQuality(i);
                    }
                }
            }
        }

        private void _DecrementSellIn(int i)
        {
            Items[i].SellIn = Items[i].SellIn - 1;
        }

        private void _IfItemSellInIsBelow11(int i)
        {
            if (Items[i].SellIn < 11)
            {
                _IfQualityIsBelowFiftyIncrementQuality(i);
            }
        }

        private void _DecrementQuality(int i)
        {
            Items[i].Quality = Items[i].Quality - 1;
        }

        private void _IfItemQualityIsGreaterThanZero(int i)
        {
            if (Items[i].Quality > 0)
            {
                _IfNotSulfurasReduceItemQuality(i);
            }
        }

        private void _IfNotSulfurasReduceItemQuality(int index)
        {
            if (Items[index].Name != Sulfuras)
            {
                _DecrementQuality(index);
            }
        }

        private void _IfQualityIsBelowFiftyIncrementQuality(int i)
        {
            if (Items[i].Quality < 50)
            {
                _IncrementQuality(i);
            }
        }

        private void _IncrementQuality(int i)
        {
            Items[i].Quality = Items[i].Quality + 1;
        }
    }
}