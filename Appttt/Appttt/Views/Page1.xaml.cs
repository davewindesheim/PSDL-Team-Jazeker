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
using Microsoft.AspNetCore.Authorization;

namespace Appttt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{

		public Page1()
		{
			InitializeComponent();
		}

		[Authorize]
		private async void BtnSend_Clicked(object sender, EventArgs e)
		{
			APIPayload mem = new APIPayload
			{
				jahomaSmartIdStr = "2853325", // txtParticipant.Text,
				contestIdStr = "60", //txtRoute.Text,
				activityDateStr = txtDate.Date,
				activityStarttimeStr = txtStartTime,
				activityStoptimeStr = txtStopTime,
				activityDistanceM = txtDistance.Text,
				activityDurationS = "20472",
				activityMaxspeedMs = "412",
				activityDescriptionStr = "dinsdag middag in Flevoland",
				activityGpxIdStr = "10472025|1623222398325|163223445525",
				activityStartDatetime = txtStartTime,
				activityStopDateTime = txtStopTime,
				activityType = "TYPE_Bike",
				externalsourceIdStr = "JAZEKER",
				externalSourceVersionStr = "v0.1i-07Feb2021-1",
			};

			// Uri RequestUri = new Uri("https://jve.jahoma.nl/nl/api/app_upload_activity/appactadd");
			Uri RequestUri = new Uri("https://jve.jahoma.nl/nl/api/app_upload_activity/appgetconfig");

			var client = new HttpClient();
			client.DefaultRequestHeaders.Add("x-auth-token", "KustwachtScheveningen");
			var json = JsonConvert.SerializeObject(mem);
			var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync( RequestUri, contentJson);
			Console.WriteLine(response);
			if (response.StatusCode == HttpStatusCode.OK)
			{
				await DisplayAlert("Data", "Succes. Verzending succesvol." + "content:" + json + " end", "Ok");
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
		}
	}
};