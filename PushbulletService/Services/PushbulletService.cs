using PushbulletService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PushbulletService
{
    public class PushbulletService : IPushbulletService
    {
        /// <summary>
        /// Sends a Pushbullet push notification to a specific user, identified by API key.
        /// Notification can either be a text or include a link.
        /// </summary>
        /// <param name="title">Notification title</param>
        /// <param name="message">Notification body</param>
        /// <param name="url">Add a URL to push, leave empty for a note push</param>
        /// <param name="apiKey">API key required to send push to correct user</param>
        public void PbPush(Push push, string apiKey)
        {
            WebRequest request = WebRequest.Create("https://api.pushbullet.com/v2/pushes");

            request.Method = "POST";
            request.Headers.Add("Authorization", "Bearer " + apiKey);
            request.ContentType = "application/json; charset=UTF-8";
            string requestString = "{\"body\":\"" + push.Message + "\", \"title\":\"" + push.Title + "\", \"type\":" 
                + (!string.IsNullOrEmpty(push.URL) ? ("\"link\", \"url\":\"" + push.URL + "\"") : "\"note\"}");
            byte[] buffer = Encoding.GetEncoding("UTF-8").GetBytes(requestString);
            request.ContentLength = buffer.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();

            WebResponse response = request.GetResponse();
        }
    }
}
