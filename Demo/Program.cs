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
            #region Q03     
            //3. Retrieve the second number greater than 5 
            //Int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var secondNumberGreaterThan5 = Arr
                .Where(n => n > 5)          // Filter numbers > 5
                .Skip(1)                    // Skip the first one
                .FirstOrDefault();          // Get the second one (or default if none exists)

            Console.WriteLine($"Second number greater than 5: {secondNumberGreaterThan5}");
            #endregion
            #region Part02 LINQ - Aggregate Operators
            //1. Uses Count to get the number of odd numbers in the array
            //Int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddCount = Arr.Count(n => n % 2 != 0);
            Console.WriteLine($"Number of odd numbers: {oddCount}");
            #endregion
        }
    }
}
