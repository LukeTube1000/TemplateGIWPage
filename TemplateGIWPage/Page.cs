using GorillaInfoWatch.Models;
using GorillaInfoWatch.Models.Attributes;

[assembly: InfoWatchCompatible]

namespace GorillaChatBox.InfoWatch
{
    [ShowOnHomeScreen]
    internal class Test : InfoScreen
    {
        public override string Title => "Test";
        public override string Description => "GIW test page";

        public override InfoContent GetContent()
        {
            LineBuilder lines = new();
            lines.Append("If you see this, GIW works.");
            return lines;
        }
    }
}