using System;

namespace Data.Domain.Entities
{
    public class Menu
    {
        private Menu() { }
        public Guid Id { get; private set; }
        public string Text { get;private set; }
        public int Price { get; private set; }

        public static Menu Create(string text, int price)
        {
            var instance = new Menu { Id = Guid.NewGuid()};
            instance.Update(text, price);
            return instance;
        }

        public void Update(string text, int price)
        {
            Text = text;
            Price = price;
        }
    }
}