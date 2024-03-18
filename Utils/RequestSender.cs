using System.Text;

namespace Module.Utils
{
	public class RequestSender
	{
		private readonly HttpClient httpClient;

		public RequestSender()
		{
			httpClient = new HttpClient();
		}

		public async Task<string> SendRequestAsync(string url, HttpMethod method, dynamic requestBody = null)
		{
			HttpRequestMessage request = new HttpRequestMessage(method, url);

			if (!string.IsNullOrEmpty(requestBody))
			{
				request.Content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");
			}

			HttpResponseMessage response = await httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadAsStringAsync();
			}
			else
			{
				throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
			}
		}
	}
}
