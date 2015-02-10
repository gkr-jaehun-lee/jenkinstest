using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace WebFront.Command
{
	public enum ErrorCode
	{
		Success = 0,
		InvalidCommandCode = 10,
		InvalidProtocol = 11,
		InvalidParameters = 12,
		UnhandledException = 100,
		
	}

	public enum CommandCode
	{
		RedisTest = 1000,
	}

	interface ICommand
	{
		bool NeedToken { get; }

		CommandCode CommandCode { get; }

		void MemberBinding(JObject Request);

		ErrorCode Process(JObject result);
    }
}
