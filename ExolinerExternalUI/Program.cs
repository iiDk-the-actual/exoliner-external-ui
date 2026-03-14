using ExolinerExternalUI.Classes;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExolinerExternalUI {
    internal static class Program {
        private const string REPOSITORY_URL = "TheJustFox/exoliner-external-ui";
        public static string ASSEMBLY_VERSION = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        private class GithubResponse {
            public string tag_name { get; set; }
            public string html_url { get; set; }
        }
        private static async Task CheckUpdates() {
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip;

            HttpClient client = new HttpClient(handler);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/repos/{REPOSITORY_URL}/releases/latest");
            request.Headers.Add("Accept", "application/json, text/plain, */*");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            request.Headers.Add("User-Agent", $"ExolinerExternal/{ASSEMBLY_VERSION}");

            HttpResponseMessage response = await client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();
            GithubResponse githubResponse = JsonConvert.DeserializeObject<GithubResponse>(responseBody);
            bool isLatest = githubResponse.tag_name == ASSEMBLY_VERSION;
            if (isLatest || githubResponse.tag_name == null) return;
            DialogResult result = MessageBox.Show("A newer version of Exoliner External has been found!\n" +
            $"Current version: {ASSEMBLY_VERSION} - Latest version: {githubResponse.tag_name}\n" +
            "Would you like to update?", "Exoliner", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Process.Start(githubResponse.html_url);
                Process.GetCurrentProcess().Kill();
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // Updater (experimental)
            try {
                CheckUpdates().GetAwaiter().GetResult();
            }
            catch { }

            FileManager.Init();
            FileManager.LoadSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            FileManager.SaveSettings();
        }
    }
}
