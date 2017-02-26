using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace News.Api
{
	internal class WebClient
	{
		public async Task<Result> GetDataAsync(Uri uri)
		{
			var client = new HttpClient();
			var result = new Result();

			try
			{
				var response = await client.GetAsync(uri);
			
				if (response.StatusCode == HttpStatusCode.OK)
				{
					result.Json = await response.Content.ReadAsStringAsync();
					result.Success = true;
				}

				return result;
				
			}
			catch (Exception e)
			{
				result.Error = e.Message;
				return result;
			}
		}

		public Result GetData(Uri uri)
		{
			var client = new HttpClient();
			var result = new Result();

			try
			{
				var response = client.GetAsync(uri).Result;

				if (response.StatusCode == HttpStatusCode.OK)
				{
					result.Json = response.Content.ReadAsStringAsync().Result;
					result.Success = true;
				}

				return result;

			}
			catch (Exception e)
			{
				result.Error = e.Message;
				return result;
			}
		}
	}
}
