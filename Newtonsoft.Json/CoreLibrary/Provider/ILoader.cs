using net.r_eg.BugsReview.NJ.Bridge;

namespace net.r_eg.BugsReview.NJ.Provider
{
    public interface ILoader
    {
        /// <param name="libname">Library name</param>
        /// <returns></returns>
        IEntryPoint load(string libname);
    }
}
