using GorillaInfoWatch.Models;
using GorillaInfoWatch.Models.Attributes;
using GorillaInfoWatch.Models.Widgets;
using System.Collections.Generic;

[assembly: InfoWatchCompatible]

namespace TemplateGIWPage // note: i had it before set to gorillachatbox's namespace, im very dumb so i copied some parts, sorry, but i changed it as this is its own thing, you can change it to whatever you want idc go crazy with it, just make sure to change the namespace in the plugininfo file as well if you do change this.
{
    [ShowOnHomeScreen]
    internal class Test : InfoScreen
    {
        public override string Title => "Template"; // button name here
        public bool value1 = false; //the value for the switch
        float Number = 1; // the value for the slider
        public override string Description => "Template by sigmatherian!"; // description, but if you want you can keep this one, i would like that but idc really tbh

        public override InfoContent GetContent()
        {
            LineBuilder lines = new();
            
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

            return lines; // ALWAYS put this at the end of the code or else your other buttons WONT WORK! (i think, i dont wanna build it rn lol)
        }

    }

}
