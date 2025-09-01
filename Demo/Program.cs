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
            #region Q02
            //2. Return a list of customers and how many orders each has.

                    var customerOrderCounts = CustomerList
            .Select(c => new {
                CustomerName = c.CompanyName,
                OrderCount = c.Orders.Count()
            })
            .ToList();

            foreach (var customer in customerOrderCounts)
            {
                Console.WriteLine($"{customer.CustomerName}: {customer.OrderCount} orders");
            }
            #endregion
            #region Q03
            //3. Return a list of categories and how many products each has

            var categoryProductCounts = ProductList
            .GroupBy(p => p.Category)
            .Select(g => new {
                Category = g.Key,
                ProductCount = g.Count()
            })
            .ToList();

                    foreach (var category in categoryProductCounts)
            {
                Console.WriteLine($"{category.Category}: {category.ProductCount} products");
            }
            #endregion
            #region Q04
            //4. Get the total of the numbers in an array.
            //Int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0}; 
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int total = Arr.Sum();
            Console.WriteLine($"Total sum: {total}");
            #endregion
            #region Q05
            //5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            long totalChars = words.Sum(word => word.Length);
            Console.WriteLine($"Total characters: {totalChars}");
            #endregion
            #region Q06
            //6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            int shortestLength = words.Min(word => word.Length);
            Console.WriteLine($"Shortest word length: {shortestLength}");
            #endregion
            #region Q07
            //7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            int longestLength = words.Max(word => word.Length);
            Console.WriteLine($"Longest word length: {longestLength}");
            #endregion
            #region Q08
            //8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            double averageLength = words.Average(word => word.Length);
            Console.WriteLine($"Average word length: {averageLength:F2}");
            #endregion
        }
    }
}
