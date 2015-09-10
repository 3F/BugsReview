
namespace net.r_eg.BugsReview.NJ.CoreLibrary
{
    public class ModeScript: IMode, IModeScript
    {
        public ModeType Type
        {
            get { return ModeType.Script; }
        }

        public string Command
        {
            get { return command; }
            set { command = value; }
        }
        private string command = string.Empty;
    }
}
