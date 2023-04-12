using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ProductApp.Models
{
    public class CRepository
    {
        private readonly static List<CCartInfo> CartList = new List<CCartInfo>();
        public static IEnumerable<CCartInfo> CartLists
        {
            get { return CartList; }
        }
        public static void CreateCInterface(CCartInfo cartobj)
        {
            CartList.Add(cartobj);
            Debug.Write(cartobj.productPrice);
        }
        public static void RemoveFromCart(CCartInfo cartobj)
        {
            CartList.Remove(cartobj);
            Debug.Write(cartobj.productPrice);
        }
    }
}
