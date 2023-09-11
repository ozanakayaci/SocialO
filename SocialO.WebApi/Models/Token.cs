using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialO.WebApi.Models
{
	public class Token
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public DateTime Expiration { get; internal set; }
	}
}