using System;
using net.r_eg.BugsReview.NJ.Provider;

namespace net.r_eg.BugsReview.NJ.ClientA
{
    class Program
    {
        public static void Main(string[] args)
        {
            try {
                ((ILoader)new Loader()).load("CoreLibrary.dll").init();
            }
            catch(Exception ex) {
                Console.WriteLine("ClientA: '{0}'", ex.ToString());
            }
        }
    }
}
