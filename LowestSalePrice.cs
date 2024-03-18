using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (var product in products)
            {
                int price = Convert.ToInt32(product[0]);
                int salePrice = price;
                var tags = product.GetRange(1,product.Count-1);
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

        #region OldCode
        //internal static void Run()
        //{
        //    #region Sample Input 0
        //    //List<List<string>> products = [
        //    //    ["10", "sale", "january-sale"],
        //    //    ["200", "sale", "EMPTY"]
        //    //];
        //    //List<List<string>> discounts = [
        //    //        ["sale", "0", "10"],
        //    //    ["january-sale", "1", "10"]
        //    //    ];
        //    #endregion
        //    #region Sample Input 1
        //    List<List<string>> products = [
        //        ["100", "dcoupon1"],
        //        ["50", "dcoupon1"],
        //        ["30", "dcoupon1"],
        //        ["100", "dcoupon2"],
        //        ["50", "dcoupon2"],
        //        ["30", "dcoupon2"],
        //    ];
        //    List<List<string>> discounts = [
        //        ["dcoupon1", "0", "60"],
        //        ["dcoupon1", "1", "30"],
        //        ["dcoupon1", "1", "20"],
        //        ["dcoupon2", "2", "20"],
        //        ["dcoupon2", "1", "85"],
        //        ["dcoupon2", "0", "15"],
        //    ];
        //    #endregion

        //    int totalPrice = 0;
        //    foreach (var product in products)
        //    {
        //        int price = Convert.ToInt32(product[0]);
        //    int salePrice = price;
        //        for (int tag = 1; tag<product.Count; tag++)
        //        {
        //            foreach (var disc in discounts)
        //            {
        //                if (product[tag] == disc[0])
        //                {
        //                    int discValue = Convert.ToInt32(disc[2]);
        //    int discPrice = price;
        //                    switch (disc[1])
        //                    {
        //                        case "0":
        //                            discPrice = discValue;
        //                            break;
        //                            case "1":
        //                            decimal temp = price;
        //    temp = temp - (temp* (discValue) / 100);
        //                            discPrice = (int) temp;
        //                            break;
        //                            case "2":
        //                            discPrice = price - discValue;
        //                            break;
        //                    }
        //salePrice = Math.Min(salePrice, discPrice);
        //                }
        //            }
        //        }
        //        totalPrice += Math.Min(salePrice, price);
        //    }

        //    Console.WriteLine(totalPrice);
        //}
        #endregion
    }
}
