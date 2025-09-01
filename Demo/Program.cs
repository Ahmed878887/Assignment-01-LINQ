using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

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
            #region Q04
            //4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            var productOnlyFirstLetters = productFirstLetters
            .Except(customerFirstLetters)
            .OrderBy(c => c)
            .ToList();

            Console.WriteLine("First letters of product names not in customer names:");
            foreach (var letter in productOnlyFirstLetters)
            {
                Console.WriteLine($"- {letter}");
            }
            #endregion
            #region Q05
            //5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            var customerLastThreeChars = CustomerList
            .Select(c =>
            {
                var name = c.CompanyName;
                return name.Length >= 3 ? name.Substring(name.Length - 3) : name;
            });

            var productLastThreeChars = ProductList
                .Select(p =>
                {
                    var name = p.ProductName;
                    return name.Length >= 3 ? name.Substring(name.Length - 3) : name;
                });

            var allLastThreeChars = customerLastThreeChars
                .Concat(productLastThreeChars)
                .ToList();

            Console.WriteLine("Last three characters from all names (including duplicates):");
            foreach (var chars in allLastThreeChars)
            {
                Console.WriteLine($"- {chars}");
            }
            #endregion
            #region Part 04 LINQ - Quantifiers
            //1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.

            // First, read the dictionary file
            string[] words = File.ReadAllLines("dictionary_english.txt");

            // Check if any words contain 'ei'
            bool hasEiWords = words.Any(word => word.Contains("ei", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"Any words contain 'ei': {hasEiWords}");

            // Optional: Show some examples if they exist
            if (hasEiWords)
            {
                var eiWords = words.Where(word => word.Contains("ei", StringComparison.OrdinalIgnoreCase))
                                  .Take(10)
                                  .ToList();
                Console.WriteLine($"Examples: {string.Join(", ", eiWords)}");
            }
            #endregion
            #region Q02
            //2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

            var categoriesWithOutOfStock = ProductList
            .GroupBy(p => p.Category)
            .Where(g => g.Any(p => p.UnitsInStock == 0)) // Categories with at least one out-of-stock product
            .Select(g => new {
                Category = g.Key,
                Products = g.ToList(),
                OutOfStockCount = g.Count(p => p.UnitsInStock == 0)
            })
            .ToList();

            Console.WriteLine("Categories with out-of-stock products:");
            foreach (var category in categoriesWithOutOfStock)
            {
                Console.WriteLine($"\n{category.Category} ({category.OutOfStockCount} out of stock):");
                foreach (var product in category.Products)
                {
                    string status = product.UnitsInStock == 0 ? "OUT OF STOCK" : $"In stock: {product.UnitsInStock}";
                    Console.WriteLine($"  - {product.ProductName} ({status})");
                }
            }
            #endregion
            #region Q03
            //3. Return a grouped a list of products only for categories that have all of their products in stock.

            var categoriesAllInStock = ProductList
            .GroupBy(p => p.Category)
            .Where(g => g.All(p => p.UnitsInStock > 0)) // Categories where ALL products are in stock
            .Select(g => new {
                Category = g.Key,
                Products = g.ToList(),
                TotalProducts = g.Count()
            })
            .ToList();

            Console.WriteLine("Categories where all products are in stock:");
            foreach (var category in categoriesAllInStock)
            {
                Console.WriteLine($"\n{category.Category} ({category.TotalProducts} products all in stock):");
                foreach (var product in category.Products)
                {
                    Console.WriteLine($"  - {product.ProductName} (Stock: {product.UnitsInStock})");
                }
            }
            #endregion
            #region Part05 LINQ – Grouping Operators
            //Use group by to partition a list of numbers by their remainder when divided by 5
            // List<int> numbers = new list<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            List<int> numbers = new List<int> { 0, 12, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var groupedByRemainder = numbers
                .GroupBy(n => n % 5)
                .OrderBy(g => g.Key)
                .ToList();

            Console.WriteLine("Numbers grouped by remainder when divided by 5:");
            foreach (var group in groupedByRemainder)
            {
                Console.WriteLine($"\nNumbers with remainder {group.Key} when divided by 5:");
                foreach (var number in group.OrderBy(n => n))
                {
                    Console.WriteLine($"  {number}");
                }
            }

            #endregion
            #region Q02
            //02-Uses group by to partition a list of words by their first letter.
            //Use dictionary_english.txt for Input
           
            string[] words = File.ReadAllLines("dictionary_english.txt");

            var groupedByFirstLetter = words
                .GroupBy(word => char.ToUpper(word[0])) 
                .OrderBy(g => g.Key)
                .ToList();

            Console.WriteLine("Words grouped by first letter:");
            foreach (var group in groupedByFirstLetter)
            {
                Console.WriteLine($"\nWords starting with '{group.Key}':");

                
                foreach (var word in group.Take(5))
                {
                    Console.WriteLine($"  {word}");
                }

                if (group.Count() > 5)
                {
                    Console.WriteLine($"  ... and {group.Count() - 5} more words");
                }

                Console.WriteLine($"  Total: {group.Count()} words");
            }

            #endregion
        }
    }
}
