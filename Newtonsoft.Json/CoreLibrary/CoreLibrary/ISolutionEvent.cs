using System;
using System.Runtime.InteropServices;

namespace net.r_eg.BugsReview.NJ.CoreLibrary
{
    [Guid("552AA0E0-9EFC-4394-B18B-41CF2F549FB3")]
    public interface ISolutionEvent
    {
        string Name { get; set; }

        // ...

        IMode Mode { get; set; }
    }
}