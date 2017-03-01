using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MessageCenterDemo
{
	public partial class DemoPage : ContentPage
	{
		public DemoPage()
		{
			InitializeComponent();
			BindingContext = new DemoModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			SubscribeMessage();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			UnSubscribeMessage();
		}

		private void SubscribeMessage()
		{
			MessagingCenter.Subscribe<DemoModel>(this, "Alert", async (obj) =>
			{
				  await DisplayAlert("Message", "Hello World", "OK");
			});

			MessagingCenter.Subscribe<DemoModel, string>(this, "AlertMessage", async (arg1, arg2) =>
			{
				   await DisplayAlert("Message", arg2, "OK");
			});
		}

		private void UnSubscribeMessage()
		{
			MessagingCenter.Unsubscribe<DemoModel>(this, "Alert");
			MessagingCenter.Unsubscribe<DemoPage>(this, "AlertMessage");
		}
	}
}
