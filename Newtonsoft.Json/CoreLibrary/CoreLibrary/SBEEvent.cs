using Newtonsoft.Json;

namespace net.r_eg.BugsReview.NJ.CoreLibrary
{
    public class SBEEvent: ISolutionEvent
    {
        public string Name
        {
            get;
            set;
        }

        // ...

        [JsonProperty(TypeNameHandling = TypeNameHandling.All)]
        public IMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        private IMode mode = new ModeFile();
    }
}