using System;
using System.IO;
using System.Reflection;
using net.r_eg.BugsReview.NJ.Bridge;
using net.r_eg.vsSBE.Provider;

namespace net.r_eg.BugsReview.NJ.Provider
{
    public class Loader: ILoader
    {
        protected string dllpath;
        private Object _lock = new Object();

        /// <param name="libname">Library name</param>
        /// <returns></returns>
        public IEntryPoint load(string libname)
        {
            dllpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
            return Instance<IEntryPoint>.from(prepare(Path.Combine(dllpath, libname)));
        }

        /// <param name="path">Full path to library</param>
        /// <returns></returns>
        protected Assembly prepare(string lib)
        {
            lock(_lock) {
                AppDomain.CurrentDomain.AssemblyResolve -= asmResolver;
                AppDomain.CurrentDomain.AssemblyResolve += asmResolver;
            }

            return Assembly.LoadFile(lib);
        }

        private Assembly asmResolver(object sender, ResolveEventArgs args)
        {
            if(String.IsNullOrEmpty(args.Name)) {
                return null;
            }

            try {
                int split = args.Name.IndexOf(",");
                return Assembly.LoadFrom(String.Format("{0}{1}.dll",
                                                        dllpath, 
                                                        args.Name.Substring(0, (split == -1)? args.Name.Length : split)));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Use other resolver for '{0}' :: {1}", args.Name, ex.Message);
            }

            return null;
        }
    }
}
