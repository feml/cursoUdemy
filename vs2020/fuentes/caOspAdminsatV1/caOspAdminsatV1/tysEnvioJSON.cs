using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.IO;

namespace caOspAdminsatV1
{
    class tysEnvioJSON
    {
        private string cuerpo;

        public string Cuerpo
        {
            get { return cuerpo; }
            set { cuerpo = value; }
        }

        private string respuesta;

        public string Respuesta
        {
            get { return respuesta; }
            set { respuesta = value; }
        }

        public void sendJSON(string mytoken, string json, string url)
        {
            var tkjmy = reportarJSON(mytoken, json, url);
            respuesta = tkjmy.Result;
        }
        public void sendJSONPUT(string mytoken, string json, string url)
        {
            var tkjmy = reportarJSONPUT(mytoken, json, url);
            respuesta = tkjmy.Result;
        }
        static public async Task<string> reportarJSON(string mytoken, string json, string url)
        {
            string myRespuesta = string.Empty;
            Uri requestUri = new Uri(url);
            HttpContent micontent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            try
            {
                AuthenticationHeaderValue authHeaders = new AuthenticationHeaderValue("JWT", mytoken);
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("JWT", mytoken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("JWT", mytoken);

                    using (HttpResponseMessage response = await client.PostAsync(requestUri, micontent))//.PutAsync(requestUri, micontent))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            try
                            {
                                myRespuesta = mycontent;
                            }
                            catch (Exception ex)
                            {
                                myRespuesta = ex.Message;
                            }
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                myRespuesta = ex.Message;
                mensajeError(ex);
            }
            catch (Exception ex)
            {
                myRespuesta = ex.Message;
                mensajeError(ex);
            }
            return myRespuesta;
        }

        static public async Task<string> reportarJSONPUT(string mytoken, string json, string url)
        {
            string myRespuesta = string.Empty;
            Uri requestUri = new Uri(url);
            HttpContent micontent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            try
            {
                AuthenticationHeaderValue authHeaders = new AuthenticationHeaderValue("JWT", mytoken);
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("JWT", mytoken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("JWT", mytoken);

                    using (HttpResponseMessage response = await client.PutAsync(requestUri, micontent))//.PutAsync(requestUri, micontent))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            try
                            {
                                myRespuesta = mycontent;
                            }
                            catch (Exception ex)
                            {
                                myRespuesta = ex.Message;
                            }
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                myRespuesta = ex.Message;
                mensajeError(ex);
            }
            catch (Exception ex)
            {
                myRespuesta = ex.Message;
                mensajeError(ex);
            }
            return myRespuesta;
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


    }
}
