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

        }

        /*
         * I love <bridgerTrait> so much I'd <action1>
         * my <valuableThing> and <action2> for <timeVal>
         * <Ending>
         * -<fName> <lName>
         */

        private static Random _rando = new Random();

        List<string> madValues = new List<string>();

        List<string> traits = new List<string>
        {
            "the way you get excited about things",
            "the smirk you make when land an 'edgy' joke",
            "trait3",
            "trait4",
            "trait5",
            "trait6"
        };

        List<string> action1 = new List<string>
        {
            "'earn it' with",
            "forget about",
            "breast feed",
            "donate",
            "penguin wrestle",
            "kill a doe with"
        };

        List<string> valuableThing = new List<string>
        {
            "first born child",
            "studded belts",
            "dirty jokes"

        };

        List<string> action2 = new List<string>
        {
            "play puke dragon",
            "swear of Big Buck",

        };

        List<string> timeVal = new List<string>
        {
            "8 seconds",
            "12 minutes",
            "83 days",
            "every day for 11 years",
            "as long as I live"
        };

        protected void Button1_Click(object sender, EventArgs e)
        {
            int rando1 = _rando.Next(0, 8);
            int rando2 = _rando.Next(0, 8);
            int rando3 = _rando.Next(0, 8);
            int rando4 = _rando.Next(0, 8);
            int rando5 = _rando.Next(0, 8);
            int rando6 = _rando.Next(0, 8);

            for (int6 i = 0; i < 6; i++)
            {
                int rando = _rando.Next(0, 8);
                var madTemp = 

            }
            

        }
    }
}