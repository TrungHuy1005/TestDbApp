using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using TestDbApp.Interface;
using TestDbApp.Models;

namespace TestDbApp.Services
{
    public class CashFlowService : ICashFlowService
    {
        public void SendPost()
        {
            var symbol = "ARMN";
            var region = "US";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yh-finance.p.rapidapi.com/stock/v2/get-cash-flow?symbol=" + symbol + "&region=" + region),
                Headers =
                {
                    { "X-RapidAPI-Key", "SIGN-UP-FOR-KEY" },
                    { "X-RapidAPI-Host", "yh-finance.p.rapidapi.com" },
                },
            };
        }
        public string Extract(string yahooHttpRequestString)
        {
            //if need to pass proxy using local configuration  
            System.Net.WebClient webClient = new WebClient();
            webClient.Proxy = HttpWebRequest.GetSystemWebProxy();
            webClient.Proxy.Credentials = CredentialCache.DefaultCredentials;

            Stream strm = webClient.OpenRead(yahooHttpRequestString);
            StreamReader sr = new StreamReader(strm);
            string result = sr.ReadToEnd();
            strm.Close();
            return result;

        }
    }
}
