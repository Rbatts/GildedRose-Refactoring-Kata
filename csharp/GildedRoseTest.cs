using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void CreateNewItem()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            //Act
            app.UpdateQuality();
            // Assert
            Assert.AreEqual("foo", items[0].Name);
        }

        [Test]
        public void ItemQuality()
        {
            // Arrange 
            // Dates and Quality are reduced by 1 each time updateQuality is run
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 1}};
            GildedRose app = new GildedRose(items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void ItemSellBy()
        {
            // Arrange 
            // Dates and Quality are reduced by 1 each time updateQuality is run
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(-1, items[0].SellIn);
        }

        [Test]
        public void SellByDatePassed()
        {
            // Arrange 
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 2 } };
            GildedRose app = new GildedRose(items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void QualityNeverNegative()
        {
            // Arrange 
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void BrieIncreasesWithAge()
        {
            // Arrange 
            IList<Item> brie = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 2 } };
            GildedRose app = new GildedRose(brie);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(4, brie[0].Quality);
        }

        [Test]
        public void QualityNeverAboveFifty()
        {
            // Arrange 
            IList<Item> items = new List<Item> { new Item { Name = "Foo", SellIn = 1, Quality = 51 } };
            GildedRose app = new GildedRose(items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void SulfurasQuality()
        {
            // Arrange 
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 81 } };
            GildedRose app = new GildedRose(items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(81, items[0].Quality);
        }

        [Test]
        public void BackStagePassesQuality()
        {
            // Arrange 
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void ConjuredItems()
        {
            // Arrange 
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            GildedRose app = new GildedRose(items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(3, items[0].Quality);
        }

    }
}
