using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastAppG19.PodcastAppG19
{
    public class Validering
    {
        public static bool NamnKontroll(string namn, Label meddelandeLabel)
        {
            if (string.IsNullOrWhiteSpace(namn))
            {
                meddelandeLabel.ForeColor = Color.Red;
                meddelandeLabel.Text = ("Namnet får inte lämnas tomt!");
                return false;
            }else if (namn.Length > 10)
            {
                meddelandeLabel.ForeColor = Color.Red;
                meddelandeLabel.Text = ("Namnet överskrider gränsen på 10 tecken!");
                return false;
            }
            meddelandeLabel.Text = "";
            return true;
        }
    }

}
