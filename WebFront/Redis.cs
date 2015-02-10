
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Redis;

namespace WebFront
{
	public class Redis
	{
		private Redis()
		{
			this._pool = new RedisManagerPool("10.66.6.7");
        }

		public static readonly Redis Instance = new Redis();
		
		private RedisManagerPool _pool = null;

		public RedisClient GetClient()
		{
			return (RedisClient)_pool.GetClient();
		}
	}
}