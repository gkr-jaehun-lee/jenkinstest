using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFront
{
	public class ConnectionInfo
	{
		private ConnectionInfo() { }
		public static ConnectionInfo Instance = new ConnectionInfo();

		public int SeqId { get; private set; }

		public bool Checking = false;

		public string CheckingMessage = "";

		public List<string> InboundEndPointList = new List<string>();

		public List<string> ServerWhiteList = new List<string>();
		
		public List<string> ServerBlackList = new List<string>();		

		public void OnRefresh()
		{
			using (var redis = Redis.Instance.GetClient())
			{
				int SeqId = redis.Get<int>("WEBSERVER:SEQID");

				if (SeqId != this.SeqId)
				{
					
				}
            }
		}
	}
}