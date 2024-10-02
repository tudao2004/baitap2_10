using System;

namespace ProductManagement
{
    abstract class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public abstract void DisplayProductInfo();
        public abstract void ApplyDiscount(decimal percentage);
    }

    interface ISellable
    {
        void Sell(int quantity);
        bool IsInStock();
    }

    class MobilePhone : Product, ISellable
    {
        public MobilePhone(string name, decimal price, int stock) : base(name, price, stock) { }

        public override void DisplayProductInfo()
        {
            Console.WriteLine($"Dien thoai: {Name}, Gia: {Price:C}, Ton kho: {Stock}");
        }

        public override void ApplyDiscount(decimal percentage)
        {
            Price -= Price * (percentage / 100);
        }

        public void Sell(int quantity)
        {
            if (quantity <= Stock)
            {
                Stock -= quantity;
                Console.WriteLine($"Da ban {quantity} dien thoai. Ton kho con: {Stock}");
            }
            else
            {
                Console.WriteLine("Khong du hang trong kho.");
            }
        }

        public bool IsInStock()
        {
            return Stock > 0;
        }
    }

    class Laptop : Product, ISellable
    {
        public Laptop(string name, decimal price, int stock) : base(name, price, stock) { }

        public override void DisplayProductInfo()
        {
            Console.WriteLine($"May tinh xach tay: {Name}, Gia: {Price:C}, Ton kho: {Stock}");
        }

        public override void ApplyDiscount(decimal percentage)
        {
            Price -= Price * (percentage / 100);
        }

        public void Sell(int quantity)
        {
            if (quantity <= Stock)
            {
                Stock -= quantity;
                Console.WriteLine($"Da ban {quantity} may tinh. Ton kho con: {Stock}");
            }
            else
            {
                Console.WriteLine("Khong du hang trong kho.");
            }
        }

        public bool IsInStock()
        {
            return Stock > 0;
        }
    }

    class Accessory : Product, ISellable
    {
        public Accessory(string name, decimal price, int stock) : base(name, price, stock) { }

        public override void DisplayProductInfo()
        {
            Console.WriteLine($"Phu kien: {Name}, Gia: {Price:C}, Ton kho: {Stock}");
        }

        public override void ApplyDiscount(decimal percentage)
        {
            Price -= Price * (percentage / 100);
        }

        public void Sell(int quantity)
        {
            if (quantity <= Stock)
            {
                Stock -= quantity;
                Console.WriteLine($"Da ban {quantity} phu kien. Ton kho con: {Stock}");
            }
            else
            {
                Console.WriteLine("Khong du hang trong kho.");
            }
        }

        public bool IsInStock()
        {
            return Stock > 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MobilePhone phone = new MobilePhone("iPhone 14", 1000m, 50);
            Laptop laptop = new Laptop("MacBook Pro", 2500m, 20);
            Accessory accessory = new Accessory("AirPods", 200m, 100);

            phone.DisplayProductInfo();
            laptop.DisplayProductInfo();
            accessory.DisplayProductInfo();

            phone.Sell(10);
            Console.WriteLine($"Dien thoai con hang? {phone.IsInStock()}");

            laptop.Sell(5);
            Console.WriteLine($"May tinh con hang? {laptop.IsInStock()}");

            accessory.Sell(30);
            Console.WriteLine($"Phu kien con hang? {accessory.IsInStock()}");

            phone.ApplyDiscount(10);
            laptop.ApplyDiscount(15);
            accessory.ApplyDiscount(5);

            phone.DisplayProductInfo();
            laptop.DisplayProductInfo();
            accessory.DisplayProductInfo();
        }
    }
}