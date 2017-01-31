using System;
using System.Threading.Tasks;

namespace Mogo
{
	public class TuneResultListService : BaseService<TuneResultList,string>
	{
		#region implemented abstract members of BaseService

		protected override string LocalApiUrl {
			get {
				return "http://beta.mogoradio.com";
			}
		}

		#endregion

		//http://beta.mogoradio.com/getrandomaudio?field=channel&fieldVal=Fast%20Start%20School&format=json

		public TuneResultListService ()
		{
		}

		public async Task< TuneResultList> GetAudio(string channel,string userid)
		{
			return await GET("http://beta.mogoradio.com/getAudioByField?field=channel&fieldVal=" + channel + "&&userID=" + userid + "&format=json");
		}


	}
}

