using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;
//using Tweetinvi;
using Learning_Experiment.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Reflection;

namespace Learning_Experiment.Controllers
{
    public class HomeController : Controller
    {
        private string _consumerKey = "jAraqz1rEZrKQmN9nhcowtPS5";
        private string _consumerSecret = "n99Y7ugOV19lXj9NHG7s9ojFkPVJ7EtwobBSPzVf0NzSB5s0ke";
        private string _token = "1115527817293258752-kEmqQcFJo37ccDNdGKoJR9DPXYIrBn";
        private string _tokenSecret = "kYqrttlvGEY7kA06AQAJKddMNlW4srZ9QlP9b1BLdooT1";

      
        public ActionResult Index()
        {
          
            TwitterService service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_token, _tokenSecret);
          

            ListTweetsOnUserTimelineOptions timelineOptions = new ListTweetsOnUserTimelineOptions();
            timelineOptions.ScreenName = "@resonateAU";
            //timelineOptions.Count = 20;

            IEnumerable<TwitterStatus> timeLine = service.ListTweetsOnUserTimeline(timelineOptions);
         
            List<TweetTimelineOption> listTimeline = new List<TweetTimelineOption>();

          
            foreach (var item in timeLine)
            {
                var timelineOps = new TweetTimelineOption
                {
                   
                    UserName = item.User.Name,
                    ScreenName ="@"+  item.Author.ScreenName,
                    
                    CreateDate = (item.CreatedDate.ToString("yyyy")==DateTime.Now.Year.ToString())? item.CreatedDate.ToString("MMM dd"):item.CreatedDate.ToString("dd MMM yyyy"),
                    Text = item.Text,
                    TextAsHTML = item.TextAsHtml,

                    RawSource= item.RawSource
                    
                };

                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                dynamic dobj = jsonSerializer.Deserialize<dynamic>(timelineOps.RawSource);


                string displayUrl = "";

                Dictionary<string, object> entities = dobj["entities"];
              

                foreach (KeyValuePair<string, object> pair in entities)
                {
                    if (pair.Key == "urls")
                    {                        
                        try
                        {
                            displayUrl = dobj["entities"]["urls"][0]["url"];
                            timelineOps.DisplayUrl = displayUrl;
                            timelineOps.MediaType = "iFrame";
                            timelineOps.Expandad_URL = dobj["entities"]["urls"][0]["expanded_url"];
                        }
                        catch { continue; }
                    }
                    else if (pair.Key == "media")
                    {
                      

                        try
                        {
                            displayUrl = dobj["entities"]["media"][0]["media_url"];
                            timelineOps.DisplayUrl = displayUrl;
                            timelineOps.MediaType = "Photo";
                            timelineOps.Expandad_URL = dobj["entities"]["media"][0]["expanded_url"];
                        }
                        catch(Exception ex) { continue; }

                    }

                }

                listTimeline.Add(timelineOps);

            }
          
          
            Console.WriteLine(listTimeline);
            return View(listTimeline);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

       





    }
}