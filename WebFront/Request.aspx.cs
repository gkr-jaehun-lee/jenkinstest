using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceStack.Redis;

using WebFront.Command;

namespace WebFront
{
	public partial class Request : System.Web.UI.Page
	{

		static int i = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			JObject req = null;
			CommandCode cmdCode;

			try
			{
				req = JsonConvert.DeserializeObject<JObject>(Request.QueryString["json"]);
				cmdCode = (CommandCode)Enum.Parse(typeof(CommandCode), req["cmd"].ToString());
			}
			catch (Exception)
			{
				ResponseError(ErrorCode.InvalidProtocol);
				return;
			}

			ICommand command = null;
			#region Get Command
			switch (cmdCode)
			{
				case CommandCode.RedisTest:
					command = new RedisTest();
					break;

				default:
					ResponseError(ErrorCode.InvalidCommandCode);
					return;
			}
			#endregion

			try
			{
				command.MemberBinding(req);
            }
			catch (Exception)
			{
				ResponseError(ErrorCode.InvalidParameters);
				return;
			}

			JObject responseData = new JObject();
			responseData.Add("cmd", (int)cmdCode);
			command.Process(responseData);
		}

		public void ResponseError(ErrorCode ErrorCode)
		{
			JObject result = new JObject();
			result.Add("success", false);
			result.Add("err", (int)ErrorCode);
			result.Add("err_desc", ErrorCode.ToString());

			Response.ContentType = "text/json";
			Response.Write(result);
			Response.End();
		}
    }
}