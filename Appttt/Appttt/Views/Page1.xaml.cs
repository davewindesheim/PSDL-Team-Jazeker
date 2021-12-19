using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Appttt.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace Appttt.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{

		public Page1()
		{
			InitializeComponent();
		}

		private async void BtnSend_Clicked(object sender, EventArgs e)
		{
			API mem = new API
			{
				jahomaSmartIdStr = txtParticipant.Text,
				contestIdStr = txtRoute.Text,
				activityDateStr = txtDate.Date,
				activityStarttimeStr = txtStartTime,
				activityStoptimeStr = txtStopTime,
				activityDistanceM = txtDistance.Text,
				activityDurationS = "10472",
				activityMaxspeedMs = "41,5",
				activityDescriptionStr = "dinsdag middag in Flevoland",
				activityGpxIdStr = "10472010|1623222398310|163223445510",
				activityStartDatetime = txtStartTime,
				activityStopDateTime = txtStopTime,
				activityType = "TYPE_Bike",
				externalsourceIdStr = "JAZEKER",
				externalSourceVersionStr = "v0.1i-07Feb2021-1",
			};

			Uri RequestUri = new Uri("https://jve.jahoma.nl/nl/api/app_upload_activity/appactadd");

			var client = new HttpClient();
			var json = JsonConvert.SerializeObject(mem);
			var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
			var Accesstoken = "X-AUTH-TOKEN KustwachtScheveningen";
			client.DefaultRequestHeaders.Add("Authorization", "Api-key " + Accesstoken);
			var response = await client.PostAsync(RequestUri, contentJson);
			if (response.StatusCode == HttpStatusCode.OK)
			{
				await DisplayAlert("Data", "Succes. Verzending succesvol.", "Ok");
			}

			else if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				await DisplayAlert("Data", "Error. Authorisatie gefaald.", "Ok");
			}

			else if (response.StatusCode == HttpStatusCode.MethodNotAllowed)
			{
				await DisplayAlert("Data", "Error. Method not allowed.", "Ok");
			}

			else
			{
				await DisplayAlert("Data", "Error. Versturing defaald", "Ok");
			}
			Debug.WriteLine(client.DefaultRequestHeaders.Authorization);
		}
	}
};