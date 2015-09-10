using System;
using System.Runtime.Serialization;

namespace net.r_eg.BugsReview.NJ.CoreLibrary
{
    public class JsonSerializationBinder: SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            return Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
        }
    }
}
