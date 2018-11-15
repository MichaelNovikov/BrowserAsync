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
        CancellationTokenSource cts = new CancellationTokenSource();

        public MainPage()
        {
            InitializeComponent();
            _htmlSource = new HtmlSource();
            btnGo.Clicked += BtnGo_Click;
            btnC.Clicked += BtnGo_C;
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            HtmlWebViewSource result = new HtmlWebViewSource();
            Spinner.IsRunning = true;

            var urlTxt = txtEntry.Text;

            try
            {
                 result = await _htmlSource.GetHtmlAsync(urlTxt, cts);
            }
            catch(OperationCanceledException ex)
            {
                result.Html = ex.Message;
            }

            Browser.Source = result;
            Spinner.IsRunning = false;
        }

        private void BtnGo_C(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}
