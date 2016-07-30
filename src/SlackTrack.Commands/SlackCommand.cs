using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackTrack.Commands
{ 

    //token=pwjua1TzfwypM9DBMrteq9yf
    //team_id = T0001
    //team_domain=example
    //channel_id = C2147483705
    //channel_name=test
    //user_id = U2147483697
    //user_name=Steve
    //command =/ weather
    //text=94070
    //response_url=https://hooks.slack.com/commands/1234/5678

    public class SlackCommand
    {

        public string Token { get; set; }

        public string Team_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Team_domain { get; set; }

        public string User_id { get; set; }
        public string User_name { get; set; }
        public string Text { get; set; }

        public string Channel_name { get; set; }

        public string Command { get; set; }

        public string Response_url { get; set; }

    }
}