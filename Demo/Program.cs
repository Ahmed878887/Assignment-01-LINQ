namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part01 LINQ - Element Operators

            //1. Get first Product out of Stock 

            var firstOutOfStockProduct = ProductList
                .FirstOrDefault(p => p.UnitsInStock == 0);

            Console.WriteLine($"First out of stock product: {firstOutOfStockProduct?.ProductName}");
            #endregion
            #region Q02
            //2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            var expensiveProduct = ProductList
    .FirstOrDefault(p => p.UnitPrice > 1000);

            if (expensiveProduct != null)
            {
                Console.WriteLine($"First product > 1000: {expensiveProduct.ProductName} - ${expensiveProduct.UnitPrice}");
            }
            else
            {
                Console.WriteLine("No product found with price > 1000");
            }
            #endregion
        }
    }
}
