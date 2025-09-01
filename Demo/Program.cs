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
            #region Q09
            //9. Get the total units in stock for each product category.

            var categoryStock = ProductList
            .GroupBy(p => p.Category)
            .Select(g => new {
                Category = g.Key,
                TotalUnits = g.Sum(p => p.UnitsInStock)
            })
            .ToList();

            foreach (var category in categoryStock)
            {
                Console.WriteLine($"{category.Category}: {category.TotalUnits} units in stock");
            }
            #endregion
            #region Q10
            //10. Get the cheapest price among each category's products

            var minPricePerCategory = ProductList
            .GroupBy(p => p.Category)
            .Select(g => new {
                Category = g.Key,
                MinPrice = g.Min(p => p.UnitPrice)
            })
            .ToList();

            foreach (var category in minPricePerCategory)
            {
                Console.WriteLine($"{category.Category}: ${category.MinPrice:F2}");
            }
            #endregion
            #region Q11
            //11. Get the products with the cheapest price in each category (Use Let)
            var cheapestProducts = ProductList
            .GroupBy(p => p.Category)
            .Select(g => {
                var minPrice = g.Min(p => p.UnitPrice);
                return new
                {
                    Category = g.Key,
                    CheapestProducts = g.Where(p => p.UnitPrice == minPrice).ToList(),
                    Price = minPrice
                };
            })
            .ToList();

            foreach (var category in cheapestProducts)
            {
                Console.WriteLine($"{category.Category} (${category.Price:F2}):");
                foreach (var product in category.CheapestProducts)
                {
                    Console.WriteLine($"  - {product.ProductName}");
                }
            }
            #endregion
            #region Q12
            //12. Get the most expensive price among each category's products.
            var maxPricePerCategory = ProductList
            .GroupBy(p => p.Category)
            .Select(g => new {
                Category = g.Key,
                MaxPrice = g.Max(p => p.UnitPrice)
            })
            .ToList();

            foreach (var category in maxPricePerCategory)
            {
                Console.WriteLine($"{category.Category}: ${category.MaxPrice:F2}");
            }
            #endregion
            #region Q13
            //13. Get the products with the most expensive price in each category.
            var expensiveProducts = ProductList
            .GroupBy(p => p.Category)
            .Select(g => {
                var maxPrice = g.Max(p => p.UnitPrice);
                return new
                {
                    Category = g.Key,
                    ExpensiveProducts = g.Where(p => p.UnitPrice == maxPrice).ToList(),
                    Price = maxPrice
                };
            })
            .ToList();

            foreach (var category in expensiveProducts)
            {
                Console.WriteLine($"{category.Category} (${category.Price:F2}):");
                foreach (var product in category.ExpensiveProducts)
                {
                    Console.WriteLine($"  - {product.ProductName}");
                }
            }
            #endregion
            #region Q14
            //14. Get the average price of each category's products.
            var avgPricePerCategory = ProductList
            .GroupBy(p => p.Category)
            .Select(g => new {
                Category = g.Key,
                AveragePrice = g.Average(p => p.UnitPrice)
            })
            .ToList();

            foreach (var category in avgPricePerCategory)
            {
                Console.WriteLine($"{category.Category}: ${category.AveragePrice:F2} average");
            }
            #endregion
            #region Part03 LINQ - Set Operators
            //1. Find the unique Category names from Product List
            var uniqueCategories = ProductList
            .Select(p => p.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToList();

            Console.WriteLine("Unique Categories:");
            foreach (var category in uniqueCategories)
            {
                Console.WriteLine($"- {category}");
            }
            #endregion
            #region Q02 
            //2. Produce a Sequence containing the unique first letter from both product and customer names.

            var productFirstLetters = ProductList
            .Select(p => p.ProductName[0])
            .Distinct();

            var customerFirstLetters = CustomerList
                .Select(c => c.CompanyName[0])
                .Distinct();

            var uniqueFirstLetters = productFirstLetters
                .Union(customerFirstLetters)
                .OrderBy(c => c)
                .ToList();

            Console.WriteLine("Unique first letters from both product and customer names:");
            foreach (var letter in uniqueFirstLetters)
            {
                Console.WriteLine($"- {letter}");
            }
            #endregion
            #region Q03
            //3. Create one sequence that contains the common first letter from both product and customer names.
            var commonFirstLetters = productFirstLetters
            .Intersect(customerFirstLetters)
            .OrderBy(c => c)
            .ToList();

            Console.WriteLine("Common first letters from both product and customer names:");
            foreach (var letter in commonFirstLetters)
            {
                Console.WriteLine($"- {letter}");
            }
            #endregion
        }
    }
}
