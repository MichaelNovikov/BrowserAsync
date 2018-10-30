using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrowserAsync
{
    public partial class MainPage : ContentPage
    {
        HtmlSource htmlSource;

        public MainPage()
        {
            InitializeComponent();
            htmlSource = new HtmlSource();
            btnGo.Clicked += BtnGo_Click;
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            Spinner.IsRunning = true;

            var urlTxt = txtEntry.Text;
            var result = await htmlSource.GetHtmlAsync(urlTxt);

            Browser.Source = result;
            Spinner.IsRunning = false;
        } 
    }
}
