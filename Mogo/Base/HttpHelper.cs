using System.Threading.Tasks;
using System.Net.Http;
using System.Text;

namespace Mogo
{
	public class HttpHelper
	{
		public event ResponseReceivedHandler ResponseReceived;

		public delegate void ResponseReceivedHandler (string item);

		protected void OnResponseReceived (string item)
		{
			if (ResponseReceived != null) {
				ResponseReceived (item);
			}
		}

		public HttpHelper ()
		{
		}

		public async Task<string> GET (string url)
		{
			using (var client = new HttpClient ()) {
				string response = "";
				try {
					response = await client.GetStringAsync (url);
					OnResponseReceived (response);
				} catch (System.Exception ex) {
					BaseEntity<string> baseEntity = new BaseEntity<string> {
						Code = 500,
						Error = ex.Message
					};

					OnResponseReceived (baseEntity.ToJson ());
					return baseEntity.ToJson ();
				}

				return response;
			}
		}

		public async Task<string> POST (string url, string data)
		{
			using (var client = new HttpClient ()) {
				
				StringContent content = new StringContent (data, Encoding.UTF8, "application/json");

				var response = await client.PostAsync (url, content);

				string responseBody = await response.Content.ReadAsStringAsync ();
				OnResponseReceived (responseBody);
				return responseBody;
			}
		}

		public async Task<string> PUT (string url, string data)
		{
			using (var client = new HttpClient ()) {

				StringContent content = new StringContent (data, Encoding.UTF8, "application/json");

				var response = await client.PutAsync (url, content);

				string responseBody = await response.Content.ReadAsStringAsync ();
				OnResponseReceived (responseBody);
				return responseBody;
			}
		}

		public async Task<string> DELETE (string url)
		{
			using (var client = new HttpClient ()) {

				var response = await client.DeleteAsync (url);

				string responseBody = await response.Content.ReadAsStringAsync ();
				OnResponseReceived (responseBody);
				return responseBody;
			}
		}
	}
}

