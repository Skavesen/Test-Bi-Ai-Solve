using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                string baseUrl = "https://localhost:44320";
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // для сложения нечетных чисел
                int[] numbers = { 1, 2, -3, 4, 5, 6, 7, 8, 9, 10 };
                var response = await client.PostAsJsonAsync("api/Sum/sum-odd", numbers);
                if (response.IsSuccessStatusCode)
                {
                    int sum = await response.Content.ReadFromJsonAsync<int>();
                    Console.WriteLine($"Sum of odd numbers: {sum}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }

                // для определения палиндрома
                string inputString = "racecar";
                var palindromeResponse = await client.PostAsJsonAsync("api/Palindrome/check-palindrome", inputString);
                if (palindromeResponse.IsSuccessStatusCode)
                {
                    bool isPalindrome = await palindromeResponse.Content.ReadFromJsonAsync<bool>();
                    Console.WriteLine($"Is palindrome: {isPalindrome}");
                }
                else
                {
                    Console.WriteLine($"Error: {palindromeResponse.StatusCode}");
                }

                // для сортировки чисел
                int[] unsortedNumbers = { 5, 2, 8, 1, -9 };
                var sortResponse = await client.PostAsJsonAsync("api/Sort/sort-numbers", unsortedNumbers);
                if (sortResponse.IsSuccessStatusCode)
                {
                    int[] sortedNumbers = await sortResponse.Content.ReadFromJsonAsync<int[]>();
                    Console.WriteLine("Sorted numbers:");
                    foreach (int num in sortedNumbers)
                    {
                        Console.Write($"{num} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Error: {sortResponse.StatusCode}");
                }
            }
        }
    }
}
