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
        HtmlSource _htmlSource;

        public MainPage()
        {
            InitializeComponent();
            _htmlSource = new HtmlSource();
            btnGo.Clicked += BtnGo_Click;
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            Spinner.IsRunning = true;

            var urlTxt = txtEntry.Text;
            var result = await _htmlSource.GetHtmlAsync(urlTxt);

            Browser.Source = result;
            Spinner.IsRunning = false;
        } 
    }
}
