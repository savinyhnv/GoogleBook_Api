using Terrasoft.Core.Factories;
using Terrasoft.Web.Common;
using Terrasoft.Core;
using ELBase.Files.cs;

namespace Terrasoft.Configuration
 {
 	public class ELAppListener : AppEventListenerBase
	{
		public override void OnAppStart(AppEventContext context) 
		{
			base.OnAppStart(context);
			var appConnection = GetAppConnection(context);
			Program.Main(appConnection);
		}
		
		public override void OnSessionStart(AppEventContext context)
		{
			base.OnSessionStart(context);
			return;
		}

		private AppConnection GetAppConnection(AppEventContext context)
		{
			return context.Application["AppConnection"] as AppConnection;
		}
		
	}
 }