using System;

namespace net.r_eg.BugsReview.NJ.CoreLibrary
{
    [Serializable]
    public class SolutionEvents
    {
        public SBEEvent[] PreBuild
        {
            get { return preBuild; }
            set { preBuild = value; }
        }
        [NonSerialized]
        private SBEEvent[] preBuild = new SBEEvent[] { new SBEEvent() };
    }
}