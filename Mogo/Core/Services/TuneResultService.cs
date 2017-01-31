using System;
using System.Threading.Tasks;

namespace Mogo
{
	public class TuneResultService : BaseService<TuneResult,string>
	{
		#region implemented abstract members of BaseService

		protected override string LocalApiUrl {
			get {
				return "http://beta.mogoradio.com";
			}
		}

		#endregion

		//http://beta.mogoradio.com/getrandomaudio?field=channel&fieldVal=Fast%20Start%20School&format=json

		public TuneResultService ()
		{
		}

		public async Task< TuneResult> GetRandomAudio(string channel)
		{
			return await GET("http://beta.mogoradio.com/getrandomaudio?field=channel&fieldVal=" + channel + "&format=json");
		}


	}
}

