using System;
using System.Collections.Generic;
using System.Linq;

namespace DipGitApiLib
{
    public class Product 
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }

        public Product () {}
        public Product (string name, float price, int qty) {
            this.Name = name;
            this.Price = price;
            this.Qty = qty;
        }
    }

    public class Products
    {
        public List<Product> ProductList { get; set; }

        /// <summary>
        /// Sums the qty of all items in ProductList together
        /// </summary>
        /// <returns></returns>
        public int GetTotalQtyProducts(List<Product> ProductList)
        {
            int totalQtyProducts = 0;
            // using a loop to go through the list and count qty

            ProductList.ForEach(Product =>
            {
                totalQtyProducts += Product.Qty;
            });

            return totalQtyProducts;
        }

        /// <summary>
        /// Gets the total cost of inventory, that is the sum of the cost of all items 
        /// </summary>
        /// <returns></returns>
        public float GetTotalValueProducts(List<Product> ProductList)
        {

            float TotalQtyValue = 0;

            // again loop through the values and multiply the row qty with row price

            ProductList.ForEach(Product =>
            {
                TotalQtyValue += (Product.Qty * Product.Price);

            });

            return TotalQtyValue;

        }
    }

    public class ProductResponse
    {

        public ProductResponse(List<Product> productList, int totalQuantity, float totalValues)
        {
            ProductList = productList;
            TotalQty = totalQuantity;
            TotalValues = totalValues;
        }

        Products productFunctions = new Products();

        public List<Product> ProductList { get; set; }
        public int TotalQty { get; set; }
        public float TotalValues { get; set; }
    }
}
