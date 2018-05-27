using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyBirthdayBridgerBaby
{
    public partial class BridgerBaby : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                skate = false;

            }
            else{
                Button1.Text = "More Love?";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "openModal()", true);
            };
        }

        /*
         * I love <bridgerTrait> so much I'd <action1>
         * my <valuableThing> and <action2> for <timeVal>
         * <Ending>
         * -<fName> <lName>
         */

        bool skate;

        
        private static Random _rando = new Random();

        List<string> madValues = new List<string>();

        List<string> traits = new List<string>
        {
            "the way you get excited about things",
            "that smirk you make when landing an 'edgy' joke",
            "the way you run away and circle back laughing at a joke",
            "that you cock the gun overhand when you 'get serious' on buck",
            "how goddamn thoughtful you are of others",
            "how you listen and learn with genuine interest"
        };

        List<string> action1 = new List<string>
        {
            "take care of",
            "forget about",
            "give mani/pedi's to",
            "soft block",
            "penguin wrestle",
            "kill a doe with"
            

        };

        List<string> valuableThing = new List<string>
        {
            "my first born child",
            "the pony bubba got you",
            "your Juul",
            "everyone you've ever loved",
            "Gage Wilson",
            "your Skamania Membership Card"
        };

        List<string> action2 = new List<string>
        {
            "discuss the nuances of typography",
            "trash my own ranking",
            "wear your weird pants",
            "carry a merkin on my key-ring",
            "play golf with Bob... fuckin' Bob",
            "play Connect 4 with you"

        };

        List<string> timeVal = new List<string>
        {
            "until I lose my sense of self,",
            "'til someone starts crying",
            "for 83 straight days",
            "every day for 11 years",
            "all day, everyday until you tell me I can stop",
            "until we've 'grown up cats'"

        };

        List<string> ending = new List<string>
        {
            "to prove it",
            "in your honor",
            "if it made you happy...promise",
            "or until you stop watching",
            "or until it scares a small child",
            "just for the jokes we'd mine from it",
            "if you asked me to"
        };

        List<string> credit = new List<string>
        {
            "anon",
            "unknown",
            "various",
            "Bridger's Friend"
        };

        


        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
            if (skate == false)
            {
                DisplayPicture.ImageUrl = "/App_Data/Rock2.jpg";
                skate = true;
            }
            else DisplayPicture.ImageUrl = "/App_Data/Skate2.jpg";
            */
            int waysToSay = traits.Count * action1.Count * valuableThing.Count * action2.Count * timeVal.Count * ending.Count;

            WaysToSay.Text = string.Format("({0} ways to say it...)", waysToSay.ToString());
            WaysToSay.Visible = true;

            madValues.Clear();

            int rando1 = _rando.Next(0, 6);
            int rando2 = _rando.Next(0, 6);
            int rando3 = _rando.Next(0, 6);
            int rando4 = _rando.Next(0, 6);
            int rando5 = _rando.Next(0, 6);
            int rando6 = _rando.Next(0, 7);
            int rando7 = _rando.Next(0, 4);

            madValues.Add(traits.ElementAtOrDefault(rando1));
            madValues.Add(action1.ElementAtOrDefault(rando2));
            madValues.Add(valuableThing.ElementAtOrDefault(rando3));
            madValues.Add(action2.ElementAtOrDefault(rando4));
            madValues.Add(timeVal.ElementAtOrDefault(rando5));
            madValues.Add(ending.ElementAtOrDefault(rando6));
            madValues.Add(credit.ElementAtOrDefault(rando7));

            ResultLabel.Text = String.Format("<b>\"I love</b> {0} <b>so much, I'd</b> {1} {2} <b>and</b> {3} {4} {5}<b>.\"</b><br/><br/>-{6}          ",
                madValues.ElementAt(0),
                madValues.ElementAt(1),
                madValues.ElementAt(2),
                madValues.ElementAt(3),
                madValues.ElementAt(4),
                madValues.ElementAt(5),
                madValues.ElementAt(6)
                );

        }
    }
}