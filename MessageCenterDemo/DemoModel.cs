using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MessageCenterDemo
{
	public class DemoModel : BaseViewModel
	{
		public string Text { get; set; }

		private Command buttonCommand;
		public Command ButtonCommand
		{
			get { return buttonCommand ?? (buttonCommand = new Command(() => showDisplayAlert())); }
		}

		private void showDisplayAlert()
		{
			MessagingCenter.Send(this, "Alert");
		}

		private Command buttonMessageCommand;
		public Command ButtonMessageCommand
		{
			get { return buttonMessageCommand ?? (buttonMessageCommand = new Command(() => showMessageDisplayAlert())); }
		}

		private void showMessageDisplayAlert()
		{
			MessagingCenter.Send(this, "AlertMessage", Text);
		}
	}
}

