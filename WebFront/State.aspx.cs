using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFront
{
	public partial class State : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			System.Configuration.AppSettingsReader reader = new System.Configuration.AppSettingsReader();
			System.Configuration.AppSettingsSection section = new System.Configuration.AppSettingsSection();
			
            Response.Write("service environment:" + section.CurrentConfiguration.AppSettings.Settings["ServiceEnvironment"]);
			Response.Write("service environment:" + reader.GetValue("ServiceEnvironment", typeof(string)));
		}
	}
}