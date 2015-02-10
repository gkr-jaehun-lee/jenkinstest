using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using ServiceStack.Redis;


namespace WebFront.Command
{
	public class RedisTest : ICommand
	{
		public bool NeedToken { get { return false; } }

		public CommandCode CommandCode { get { return CommandCode.RedisTest; } }

		public void MemberBinding(JObject Request)
		{
			_key = (string)Request["key"];
		}

		private string _key = null;

		public ErrorCode Process(JObject result)
		{
			using (var redis = Redis.Instance.GetClient())
			{
				var config = redis.GetAllEntriesFromHash("WEBSERVER:CONFIG");

				result.Add("cmd", (int)this.CommandCode);
			}

			return ErrorCode.Success;
		}
	}
}