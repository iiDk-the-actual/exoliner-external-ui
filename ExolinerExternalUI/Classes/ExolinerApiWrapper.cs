using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExolinerExternalUI.Classes {
    internal class ExolinerApiWrapper {
        public static string JSONWebToken = null;
        private static string SiteURL = "https://api.serverside.plus/";
        // TODO
        public static string AttemptLogin(string Email, string Password) {
            return "";
        }

        public class BaseExolinerData {
            public bool success { get; set; }
            public string message { get; set; }
        }

        public class ExolinerUser : BaseExolinerData {
            public Data data { get; set; }
            public class Data {
                public int id { get; set; }
                public string username { get; set; }
                public string rank { get; set; }
            }
        }

        public static ExolinerUser currentUser;
        public static async Task<ExolinerUser> GetInfo() {
            if (string.IsNullOrEmpty(JSONWebToken)) return new ExolinerUser { success = false, message = "No JSONWebToken received." };
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.None;

            HttpClient client = new HttpClient(handler);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{SiteURL}/v1/user/me");

            request.Headers.Add("Accept", "application/json, text/plain, */*");
            request.Headers.Add("Authorization", JSONWebToken);
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("DNT", "1");

            HttpResponseMessage response = await client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) {
                MessageBox.Show(response.StatusCode.ToString());
            }
            currentUser = JsonConvert.DeserializeObject<ExolinerUser>(responseBody);
            return currentUser;
        }

        public class ScriptData {
            public string script { get; set; }
            public bool convert { get; set; }
        }

        public static async Task<BaseExolinerData> Execute(string script, bool convert) {
            if (string.IsNullOrEmpty(JSONWebToken)) return new BaseExolinerData { success = false, message = "No JSONWebToken received." };
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip;

            HttpClient client = new HttpClient(handler);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{SiteURL}/v1/execute");

            request.Headers.Add("Accept", "application/json, text/plain, */*");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            request.Headers.Add("Authorization", JSONWebToken);
            request.Headers.Add("Sec-GPC", "1");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("DNT", "1");
            request.Headers.Add("Priority", "u=0");

            ScriptData data = new ScriptData();
            data.script = String.Concat(FileManager.GetPayload(), script);
            data.convert = convert;
            request.Content = new StringContent(JsonConvert.SerializeObject(data));

            HttpResponseMessage response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode) {
                MessageBox.Show(response.StatusCode.ToString());
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            return new BaseExolinerData();
            //return JsonConvert.DeserializeObject<BaseExolinerData>(responseBody);
        }
    }
}
