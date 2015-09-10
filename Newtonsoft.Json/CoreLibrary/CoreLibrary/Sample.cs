using System;
using System.IO;
using System.Text;
using net.r_eg.BugsReview.NJ.Bridge;
using Newtonsoft.Json;

namespace net.r_eg.BugsReview.NJ.CoreLibrary
{
    public class Sample: IEntryPoint
    {
        public void init()
        {
            string data1 = @"
                            {
                                ""PreBuild"": [
                                  {
                                      ""Name"": ""Act1"",
                                      ""Mode"": {
                                          ""$type"": ""net.r_eg.BugsReview.NJ.CoreLibrary.ModeFile, CoreLibrary"",
                                          ""Type"": ""file"",
                                          ""Command"": ""booo""
                                      }
                                  }
                                ]
                            }";

            string data2 = @"
                            {
                                ""PreBuild"": [
                                  {
                                      ""Name"": ""Act1"",
                                      ""Mode"": {
                                          ""$type"": ""net.r_eg.BugsReview.NJ.CoreLibrary.ModeScript, CoreLibrary"",
                                          ""Type"": ""script"",
                                          ""Command"": ""muahahaha""
                                      }
                                  }
                                ]
                            }";

            status(from(data1).PreBuild[0]); // ClientA - ok  / ClientB - ok
            status(from(data2).PreBuild[0]); // ClientA - ok  / ClientB - failed (v7.0.1) / ClientB - ok (v6.0.8)
        }

        protected SolutionEvents from(string data)
        {
            return deserialize(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(data))));
        }

        protected void status(ISolutionEvent evt)
        {
            Console.WriteLine(String.Format("Name: '{0}'", evt.Name));
            Console.WriteLine(String.Format("Mode: '{0}'", evt.Mode.Type));

            if(evt.Mode.Type == ModeType.File) {
                Console.WriteLine(String.Format("Command in File mode: '{0}'", ((IModeFile)evt.Mode).Command));
                return;
            }

            if(evt.Mode.Type == ModeType.Script) {
                Console.WriteLine(String.Format("Command in Script mode: '{0}'", ((IModeScript)evt.Mode).Command));
                return;
            }

            throw new Exception("Unsupported mode");
        }

        protected SolutionEvents deserialize(StreamReader stream)
        {
            using(JsonTextReader reader = new JsonTextReader(stream))
            {
                JsonSerializer js = new JsonSerializer() {
                    Binder = new JsonSerializationBinder() 
                };
                return js.Deserialize<SolutionEvents>(reader);
            }
        }
    }
}
