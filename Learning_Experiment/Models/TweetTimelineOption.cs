using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetSharp;

namespace Learning_Experiment.Models
{
    public class TweetTimelineOption
    {
        //public TweetSharp.ITweeter Author { get; set; }
        public string UserName { get; set; }
        public string CreateDate { get; set; }
        public string Text { get; set; }
        public string TextAsHTML { get; set; }

        public string ScreenName { get; set; }

        public string RawSource { get; set; }
        public string DisplayUrl { get; set; }
        public string MediaType { get; set; }
        public string Expandad_URL { get; set; }
    }
}