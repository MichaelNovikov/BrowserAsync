using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrowserAsync
{
    public class HtmlSource
    {
        public HtmlWebViewSource GetHtml(string urlStr)
        {
            var htmlSource = new HtmlWebViewSource();
            string html = "";
            string url = @"";

            if(!(urlStr.Contains("https://") || urlStr.Contains("http://")))
            {
                url = "https://";
            }
            url += urlStr;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                htmlSource.Html = ex.Message;
                return htmlSource;
            }

            htmlSource.Html = html;
            return htmlSource;
        }

        public async Task<HtmlWebViewSource> GetHtmlAsync(string urlStr)
        {
           return await Task.Run(() => GetHtml(urlStr));
        }
    }
}
