using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Dynamic;
using System.Net.Http;
using System.IO;

namespace caOspAdminsatV1
{
    class tysToken
    {
        private string token;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }
        public void getToken()
        {
            //var tkjmy = authenticacionJSON("http://api-development.adminsat.com/api-token-auth/");//30/01/2018
            var tkjmy = authenticacionJSON("https://api.adminsat.com/api-token-auth/"); //30/01/2018
            token = tkjmy.Result;
        }

        static public async Task<string> authenticacionJSON(string url)
        {
            string mytoken = string.Empty;
            Uri requestUri = new Uri(url);
            dynamic dynamicJson = new ExpandoObject();
            dynamicJson.username = "milenio";
            dynamicJson.password = "Milenio123";
            string jsonAuthentication = "";
            jsonAuthentication = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicJson);
            HttpContent micontent = new StringContent(jsonAuthentication, System.Text.Encoding.UTF8, "application/json");
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PostAsync(requestUri, micontent))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            mytoken = JSONDeserilaize(mycontent);
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                mensajeError(ex);
            }
            catch (Exception ex)
            {
                mensajeError(ex);
                mytoken = ex.Message;
            }
            return mytoken;
        }
        private static string JSONDeserilaize(string mycontent)
        {
            string myToken = string.Empty;
            try
            {
                apiToken aToken = JsonConvert.DeserializeObject<apiToken>(mycontent);
                myToken = aToken.token;
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }
            return myToken;

        }
        private static void mensajeError(Exception ex)
        {
            using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\logError.txt"))
            {
                writer.WriteLine(" ");
                writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(ex.Message);
                writer.WriteLine("*");
            }
        }
        private static void mensajeError(HttpRequestException ex)
        {
            using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\logHttpRequestException.txt"))
            {
                writer.WriteLine(" ");
                writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(ex.Message);
                writer.WriteLine("*");
            }
        }


        class apiToken
        {
            public string idioma { get; set; }
            public string token { get; set; }
        }

    }
}
