using GorillaInfoWatch.Models;
using GorillaInfoWatch.Models.Attributes;
using GorillaInfoWatch.Models.Widgets;
using System.Collections.Generic;

[assembly: InfoWatchCompatible]

namespace GorillaChatBox.InfoWatch
{
    [ShowOnHomeScreen]
    internal class Test : InfoScreen
    {
        public override string Title => "Test";
        public bool value1 = false;
        float Number = 1;
        public override string Description => "GIW test page";

        public override InfoContent GetContent()
        {
            LineBuilder lines = new();
            lines.Append("If you see this, GIW works."); //dont mind this, i just didnt know much about how Info Watch worked when I made this so it just straight up dont work.
            return lines;
            lines.Add(
                "Switch", // the switch, can toggle a speed boost or something, its up to you so go wild, just make sure that you follow the steps for the value!
                new List<Widget_Base>
                {
            new Widget_Switch(value1, value =>
            {
                value1 = value; // THIS has to be a public bool!
                SetText();
            })
                }
            );
            // Sorry for making this like the most ugly code ever but I dont care really this is just a template.
            lines.Add(
                "Choose A Number", // title of the button to the left of it
                new List<Widget_Base>
                {
            new Widget_SnapSlider(
                1, // min value
                20, // max value
                1, // current value (i think, i may have confused this with min value, sorry)
                (value, args) =>
                {
                    Number = (float)value; // this is our value we can use in our code!
                    SetText(); // this is how refreshing works
                }
            )
                }
            );
            lines.Add(
    "Text!", // title of the line
    new List<Widget_Base>
    {
      
        new Widget_PromptButton("Enter Number", 10, (value, args) =>
        {
            
            if (float.TryParse(args.Input, out float result))
            {
                Number = result;
                SetText(); 
            } // weird code, but it does work i guess
        })
    }
);

        }
    }
}