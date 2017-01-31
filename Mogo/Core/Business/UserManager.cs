using System;

namespace Mogo
{
	public class UserManager : BaseBusiness<User,string>
	{
		public UserManager () : base (new UserData ())
		{
		}
	}
}

