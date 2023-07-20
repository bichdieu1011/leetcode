//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Interview
{
    public class KBTG
    {

        public static void Test()
        {
            Console.WriteLine(JsonSerializer.Serialize(itemsSort2(new List<int> { 4, 5, 6, 5, 4, 3 })));
            Console.WriteLine(JsonSerializer.Serialize(itemsSort2(new List<int> { 2, 1, 5, 3, 2 })));
            Console.WriteLine(JsonSerializer.Serialize(itemsSort2(new List<int> { 8, 5, 5, 5, 5, 1, 1, 1, 4, 4 })));

            //var res = await getFoodOutlets("Seattle", 10000);
            //Console.WriteLine(JsonSerializer.Serialize(res));
        }

        static List<int> itemsSort(List<int> items)
        {

            var frequencies = new Dictionary<int, int>();
            foreach (var item in items)
            {
                if (frequencies.ContainsKey(item)) frequencies[item]++;
                else frequencies.Add(item, 1);
            }
            var sortedItems = frequencies.OrderBy(x => x.Value).ThenBy(s => s.Key).ToList();


            var res = new List<int>();
            foreach (var item in sortedItems)
            {
                for (var i = 0; i < item.Value; i++)
                    res.Add(item.Key);
            }
            return res;
        }

        static List<int> itemsSort2(List<int> items)
        {

            var frequencies = new Dictionary<int, int>();
            foreach (var item in items)
            {
                if (frequencies.ContainsKey(item)) frequencies[item]++;
                else frequencies.Add(item, 1);
            }
            //var sortedItems = frequencies.OrderBy(x => x.Value).ThenBy(s => s.Key).ToList();


            var res = new List<int>();
            foreach (var item in frequencies)
            {
                var l = 0;
                var r = res.Count - 1;
                while (l < r)
                {
                    var m = l + (r - l) / 2;
                    if (item.Value == frequencies[res[m]])
                    {
                        if (item.Key > res[m])
                        {
                            var temp = res[m];
                            while (res[m] == temp && m < r) m++;
                            l = m;
                        }
                        else
                        {
                            var temp = res[m];
                            while (res[m] == temp && m > 0) m--;
                            r = m;
                        }
                    }
                    else if (item.Value < frequencies[res[m]])
                    {
                        var temp = res[m];
                        while (res[m] == temp && m > 0) m--;
                        r = m;
                    }
                    else
                    {
                        var temp = res[m];
                        while (res[m] == temp && m < r) m++;
                        l = m;
                    }
                }

                for (var i = 0; i < item.Value; i++)
                    res.Insert(l, item.Key);
            }
            return res;
        }

        static List<List<string>> extractErrorLogs(List<List<string>> logs)
        {
            var result = new List<List<string>>();
            if (logs is null || logs.Count == 0) return result;

            var filterStatusConditions = new List<string> { "ERROR", "CRITICAL" };
            var filteredLogs = new List<(int index, DateTime time, List<string> value)>();
            for (var i = 0; i < logs.Count; i++)
            {
                if (filterStatusConditions.Contains(logs[i][2], StringComparer.CurrentCultureIgnoreCase))
                {
                    var time = DateTime.ParseExact($"{logs[i][0]} {logs[i][1]}", "dd-MM-yyyy HH:ss", CultureInfo.CurrentCulture);
                    filteredLogs.Add((i, time, logs[i]));

                }
            }

            result = filteredLogs.OrderBy(s => s.time)
                .ThenBy(s => s.index)
                .Select(s => s.value)
                .ToList();

            return result;
        }


        static List<string> getFoodOutlets(string city, int maxCost)
        {
            try
            {
                var listFoodOutlets = new List<FoodOutletsModel>();
                var pageNumber = 1;
                var totalPage = 1;
                using (var client = new HttpClient())
                    do
                    {
                        var url = $"https://jsonmock.hackerrank.com/api/food_outlets?city={city}&page={pageNumber++}";
                        using (var message = new HttpRequestMessage(HttpMethod.Get, url))
                        {
                            var response = client.Send(message);
                            if (response.IsSuccessStatusCode)
                            {
                                var responseBody = response.Content.ReadAsStream();
                                var result = JsonSerializer.Deserialize<FoodOutletsResult>(responseBody);
                                if (result is null) break;
                                totalPage = result.total_pages;
                                listFoodOutlets.AddRange(result.data);
                            }
                        }
                    } while (pageNumber <= totalPage);

                return listFoodOutlets.Where(s => s.estimated_cost <= maxCost)
                    .Select(s => s.name).ToList();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Exception. Message: {e.Message}");
            }

            return new List<string>();

        }

        public class FoodOutletsResult
        {
            public int page { get; set; }
            public int per_page { get; set; }
            public int total { get; set; }
            public int total_pages { get; set; }
            public List<FoodOutletsModel> data { get; set; } = new List<FoodOutletsModel>();
        }

        public class FoodOutletsModel
        {
            public string name { get; set; }
            public int estimated_cost { get; set; }
        }
    }
}


