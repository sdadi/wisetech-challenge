using System.Net;

namespace hackerrank
{
    internal class LowestSalePrice
    {
        internal static void Run()
        {
            #region Sample Input 0
            //List<List<string>> products = [
            //    ["10", "sale", "january-sale"],
            //    ["200", "sale", "EMPTY"]
            //];
            //List<List<string>> discounts = [
            //        ["sale", "0", "10"],
            //    ["january-sale", "1", "10"]
            //    ];
            #endregion
            #region Sample Input 1
            List<List<string>> products = [
                ["100", "dcoupon1"],
                ["50", "dcoupon1"],
                ["30", "dcoupon1"],
                ["100", "dcoupon2"],
                ["50", "dcoupon2"],
                ["30", "dcoupon2"],
            ];
            List<List<string>> discounts = [
                ["dcoupon1", "0", "60"],
                ["dcoupon1", "1", "30"],
                ["dcoupon1", "1", "20"],
                ["dcoupon2", "2", "20"],
                ["dcoupon2", "1", "85"],
                ["dcoupon2", "0", "15"],
            ];

            #endregion

            int totalPrice = 0;
            var disMap = new Dictionary<KeyValuePair<string,int>, int>();
            

            for(int i=0; i < discounts.Count; i++)
            {
                int dType = Convert.ToInt32(discounts[i][1]);
                var kv = new KeyValuePair<string, int>(discounts[i][0],dType);
                int disValue = Convert.ToInt32(discounts[i][2]);
                if (disMap.ContainsKey(kv))
                {
                    switch (kv.Value)
                    {
                        case 0:
                            if (disValue < disMap[kv])
                                disMap[kv] = disValue;
                            break;
                        case 1:
                        case 2:
                            if (disValue > disMap[kv])
                                disMap[kv] = disValue;
                            break;
                    }
                }
                else
                    disMap.Add(kv, disValue);

            }
            
            for(int p=0;p< products.Count;p++)
            {
                int price = Convert.ToInt32(products[p][0]);
                int salePrice = price;
                for(int i = 1; i < products[p].Count;i++)
                {
                    if (products[p][i] == "EMPTY")
                        continue;
                    var kv = new KeyValuePair<string, int>(products[p][i], 0);//discType = 0;
                    int discPrice = price;

                    if (disMap.ContainsKey(kv))
                    {
                        discPrice = disMap[kv];
                    }
                    kv = new KeyValuePair<string, int>(products[p][i], 1);// disType =1;
                    if (disMap.ContainsKey(kv))
                    {
                        decimal temp = price;
                        temp = temp - (temp * disMap[kv] / 100);
                        if (temp < discPrice)
                            discPrice = (int)temp;
                    }
                    kv = new KeyValuePair<string, int>(products[p][i], 2);// disType =2;
                    if (disMap.ContainsKey(kv))
                    {
                        if (discPrice > (price - disMap[kv]))
                            discPrice = price - disMap[kv];
                    }
                    salePrice = Math.Min(salePrice, discPrice);
                }
                totalPrice += Math.Min(salePrice, price);
            }

            Console.WriteLine(totalPrice);
        }

        internal static void RunBruteForce()
        {
            #region Sample Input 0
            //List<List<string>> products = [
            //    ["10", "sale", "january-sale"],
            //    ["200", "sale", "EMPTY"]
            //];
            //List<List<string>> discounts = [
            //        ["sale", "0", "10"],
            //    ["january-sale", "1", "10"]
            //    ];
            #endregion
            #region Sample Input 1
            List<List<string>> products = [
                ["100", "dcoupon1"],
                ["50", "dcoupon1"],
                ["30", "dcoupon1"],
                ["100", "dcoupon2"],
                ["50", "dcoupon2"],
                ["30", "dcoupon2"],
            ];
            List<List<string>> discounts = [
                ["dcoupon1", "0", "60"],
                ["dcoupon1", "1", "30"],
                ["dcoupon1", "1", "20"],
                ["dcoupon2", "2", "20"],
                ["dcoupon2", "1", "85"],
                ["dcoupon2", "0", "15"],
            ];
            #endregion

            int totalPrice = 0;
            foreach (var product in products)
            {
                int price = Convert.ToInt32(product[0]);
                int salePrice = price;
                var tags = product.GetRange(1, product.Count - 1);
                var discoupons = discounts.Where(x => tags.Any(y => y == x[0]));

                foreach (var disc in discoupons)
                {
                    int discValue = Convert.ToInt32(disc[2]);
                    int discPrice = price;
                    switch (disc[1])
                    {
                        case "0":
                            discPrice = discValue;
                            break;
                        case "1":
                            decimal temp = price;
                            temp = temp - (temp * (discValue) / 100);
                            discPrice = (int)temp;
                            break;
                        case "2":
                            discPrice = price - discValue;
                            break;
                    }
                    salePrice = Math.Min(salePrice, discPrice);
                }
                totalPrice += Math.Min(salePrice, price);
            }

            Console.WriteLine(totalPrice);
        }

    }
}
