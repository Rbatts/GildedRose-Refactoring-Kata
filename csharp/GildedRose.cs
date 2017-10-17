using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RestSharp.Extensions;

namespace csharp
{
    public enum ItemType
    {
        Legendary,
        Cheese,
        BackstagePass,
        Normal,
        Conjured
    }

    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        
        // Item type (categories of Items, Makes it easier to add new Items and stock types in future.
        public ItemType GetItemType(string name)
        {
            if (name.Contains("Brie"))
            {
                return ItemType.Cheese;
            }
            if (name.Contains("Conjured"))
            {
                return ItemType.Conjured;
            }
            if (name.Contains("Elixir"))
            {
                return ItemType.Normal;
            }
            if (name.Contains("Vest"))
            {
                return ItemType.Normal;
            }
            if (name.Contains("Backstage passes to a TAFKAL80ETC concert"))
            {
                return ItemType.BackstagePass;
            }
            if (name.Matches(".*, Hand of.*"))
            {
                return ItemType.Legendary;
            }

            switch (name)
            {
                case "+5 Dexterity Vest":
                    return ItemType.Normal;
                case "Elixir of the Mongoose":
                    return ItemType.Normal;
                case "Conjured Mana Cake":
                    return ItemType.Conjured;
                case "Aged Brie":
                    return ItemType.Cheese;
                case "Sulfuras":
                    return ItemType.Legendary;
                case "Backstage passes to a TAFKAL80ETC concert":
                    return ItemType.BackstagePass;
                default:
                    return ItemType.Normal;
            }
        }

        // Methods of calculating SellIns and Qualities of Items, after every day cycle. 
        public int GetNewQualityForBackstagePass(Item item)
        {
            if (item.SellIn <= 0)
            {
                return item.Quality = 0;
            }
            else if (item.SellIn > 10)
            {
                return item.Quality + 1;
            }
            else if (item.Quality > 5)
            {
                return item.Quality + 2;
            }
            else
            {
                return item.Quality + 3;
            }
        }

        // Cheese Quality
        public int GetNewQualityForCheese(Item item)
        {
            return item.Quality + 1;
        }

        //Legendary Quality
        public int GetNewQualityForLegendary(Item item)
        {
            return item.SellIn = 0;
        }

        // Conjured Quality
        public int GetNewQualityForConjured(Item item)
        {
            return item.Quality / 2;
        }

        public int GetDefaultSellIn(Item item)
        {
            return item.SellIn - 1;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var itemType = GetItemType(item.Name);
                switch (itemType)
                {
                    case ItemType.BackstagePass:
                        GetNewQualityForBackstagePass(item);
                        item.SellIn = GetDefaultSellIn(item);
                        break;
                    case ItemType.Cheese:
                        GetNewQualityForCheese(item);
                        item.SellIn = GetDefaultSellIn(item);
                        break;
                    case ItemType.Legendary:
                        GetNewQualityForLegendary(item);
                        item.SellIn = GetDefaultSellIn(item);
                        break;
                    case ItemType.Conjured:
                        GetNewQualityForConjured(item);
                        item.SellIn = GetDefaultSellIn(item);
                        break;
                    default:
                        return;
                }
            }
        }
    }
} 

    

