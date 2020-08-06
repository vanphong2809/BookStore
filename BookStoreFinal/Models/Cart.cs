using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreFinal.Models
{
    [Serializable]
    public class CartItem
    {
        public BOOKS Book { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        private List<CartItem> lineCollection = new List<CartItem>();
        public void AddItem(BOOKS b, int quantity)
        {
            CartItem line = lineCollection
                .Where(x => x.Book.ID == b.ID)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    Book = b,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
                if (line.Quantity <= 0)
                {
                    lineCollection.RemoveAll(l => l.Book.ID == b.ID);
                }
            }
        }

        public void UpdateCart(BOOKS book, int quantity)
        {
            CartItem line = lineCollection.Where(x => x.Book.ID == book.ID).FirstOrDefault();
            if (line != null)
            {
                if (quantity > 0)
                {
                    line.Quantity = quantity;
                }
                else
                {
                    lineCollection.RemoveAll(x => x.Book.ID == book.ID);
                }
            }
        }
        public void RemoveLine(BOOKS book)
        {
            lineCollection.RemoveAll(x => x.Book.ID == book.ID);
        }
        public int? ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Book.PRICE * x.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }
    }
}