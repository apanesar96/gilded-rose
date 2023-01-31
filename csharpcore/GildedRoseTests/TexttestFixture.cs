
using GildedRoseKata;

using System;
using System.Collections.Generic;
using ApprovalTests;

namespace GildedRoseTests
{
    public static class TexttestFixture
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            int days = 2;
            if (args.Length > 0)
            {
                days = int.Parse(args[0]) + 1;
            }

            var output = new List<String>();
            for (var i = 0; i < days; i++)
            {
                var header = "-------- day " + i + " --------";
                output.Add(header);
                var nameSellingQuality = "name, sellIn, quality";
                output.Add(nameSellingQuality);
                
                for (var j = 0; j < Items.Count; j++)
                {
                    var combinedOutput = Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality;
                    output.Add(combinedOutput);
                }

                output.Add("");
                app.UpdateQuality();
            }
        }
    }
}
