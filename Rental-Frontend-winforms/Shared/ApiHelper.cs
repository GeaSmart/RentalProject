using Mach.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System;
using System.Net;

namespace Mach.Shared
{
    public class ApiHelper
    {
        private static readonly string baseURL = @"https://localhost:44329/api/contrato";

        public enum methodHttp
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        private HttpMethod CreateHttpMethod(methodHttp method)
        {
            switch (method)
            {
                case methodHttp.GET:
                    return HttpMethod.Get;
                case methodHttp.POST:
                    return HttpMethod.Post;
                case methodHttp.PUT:
                    return HttpMethod.Put;
                case methodHttp.DELETE:
                    return HttpMethod.Delete;
                default:
                    throw new NotImplementedException("Not implemented http method");
            }
        }

        public async Task<Reply> Execute<T>(string url, methodHttp method, T objectRequest)
        {
            Reply oReply = new Reply();
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    var myContent = JsonConvert.SerializeObject(objectRequest);
                    var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                    bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    var request = new HttpRequestMessage(CreateHttpMethod(method), url)
                    {                        
                        Content = method != methodHttp.GET ?  bytecontent:null
                    };

                    using (HttpResponseMessage res = await client.SendAsync(request))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                                oReply.Data = JsonConvert.DeserializeObject<T>(data);

                            oReply.StatusCode = res.StatusCode.ToString();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                oReply.StatusCode = "ServerError";
                var response = (HttpWebResponse)ex.Response;
                if (response != null)
                    oReply.StatusCode = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                oReply.StatusCode = "AppError";
            }
            return oReply;
        }













        public static async Task<string> GetAll()
        {
            using(HttpClient client = new HttpClient())
            {
                using(HttpResponseMessage res = await client.GetAsync(baseURL))
                {
                    using(HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {                
                using (HttpResponseMessage res = await client.GetAsync(baseURL + $"/{id}"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> Post(Contrato contrato)
        {
            using (HttpClient client = new HttpClient())
            {
                
                var myContent = JsonConvert.SerializeObject(contrato);
                var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                
                using (HttpResponseMessage res = await client.PostAsync(baseURL, bytecontent))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> Put(int id, Contrato contrato)
        {
            using (HttpClient client = new HttpClient())
            {
                var myContent = JsonConvert.SerializeObject(contrato);
                var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                using (HttpResponseMessage res = await client.PutAsync(baseURL + $"/{id}",bytecontent))
                {
                    using (HttpContent content = res.Content)

                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(baseURL + $"/{id}"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }


        public static string BeautifyJson(string jsonString)
        {
            JToken parseJson = JToken.Parse(jsonString);
            return parseJson.ToString(Formatting.Indented);
        }


    }
}
