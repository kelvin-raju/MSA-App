using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuoteSaver
{
    public class BingSpellCheckService : IBingSpellCheckService
    {
        public readonly string SpellCheckAPIKey = "79c71da5f3824010b428e17f0a65a4ae";
        public readonly string APIURLEndPoint = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/";

        public async Task<SpellCheckResult> SpellChecker(string text)
        {
            string requestUri = GenerateReqUri(APIURLEndPoint, text, SpellCheckMode.Spell);
            var resp = await SendReq(requestUri, SpellCheckAPIKey);
            var scResult = JsonConvert.DeserializeObject<SpellCheckResult>(resp);

            return scResult;
        }

        string GenerateReqUri(string sCEndPoint, string text, SpellCheckMode mode)
        {
            string reqUri = sCEndPoint;
            reqUri += string.Format("?text={0}", text);
            reqUri += string.Format("&mode={0}", mode.ToString().ToLower());

            return reqUri;
        }

        public async Task<string> SendReq(string url, string key)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
                var response = await httpClient.GetAsync(url);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
