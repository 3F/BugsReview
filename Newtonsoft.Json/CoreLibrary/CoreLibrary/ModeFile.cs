
namespace net.r_eg.BugsReview.NJ.CoreLibrary
{
    public class ModeFile: IMode, IModeFile
    {
        public ModeType Type
        {
            get { return ModeType.File; }
        }

        public string Command
        {
            get { return command; }
            set { command = value; }
        }
        private string command = string.Empty;
    }
}
