using System;
using EnvDTE;
using EnvDTE80;
using Extensibility;
using net.r_eg.BugsReview.NJ.Provider;

namespace net.r_eg.BugsReview.NJ.ClientB
{
    public class Connect : IDTExtensibility2
    {
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            DTE2 _applicationObject = (DTE2)application;
            AddIn _addInInstance = (AddIn)addInInst;

            // ...

            /*
               In real case we use - int OnAfterOpenSolution(object pUnkReserved, int fNewSolution) from  Microsoft.VisualStudio.Shell.Interop.IVsSolutionEvents
               However, OnConnection is also suitable...
            */

            try {
                ((ILoader)new Loader()).load("CoreLibrary.dll").init();
            }
            catch(Exception ex) {
                Console.WriteLine("ClientB: '{0}'", ex.ToString());
            }
        }

        #region unused

        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {

        }

        public void OnAddInsUpdate(ref Array custom)
        {

        }

        public void OnStartupComplete(ref Array custom)
        {

        }

        public void OnBeginShutdown(ref Array custom)
        {

        }

        #endregion

    }
}