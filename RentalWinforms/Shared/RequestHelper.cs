using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mach.Shared
{
    public class RequestHelper
    {
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
			string resp;
			Reply oReply = new Reply();
			try
			{
				string json = JsonConvert.SerializeObject(objectRequest);

				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.Method = method.ToString();
				request.PreAuthenticate = true;
				request.ContentType = "application/json;charset=utf-8";
				request.Timeout = 60000;

				if (method.Equals("post") || method.Equals("put"))
				{
					using (StreamWriter archivo = new StreamWriter(await request.GetRequestStreamAsync()))
					{
						archivo.Write(json);
						archivo.Flush();
					}
				}

				HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();

				using (StreamReader archivo = new StreamReader(response.GetResponseStream()))
				{
					resp = archivo.ReadToEnd();
				}
				oReply.Data = JsonConvert.DeserializeObject<T>(resp);
				oReply.StatusCode = response.StatusCode.ToString();
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
	}
}
