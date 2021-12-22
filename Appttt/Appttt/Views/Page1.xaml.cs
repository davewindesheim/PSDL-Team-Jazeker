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
			String myDate = DateTime.Now.ToString("yyyy-MM-dd");
			APIPayload mem = new APIPayload

			{
			 activityMaxspeedMs = "181.5631",
			 activityStartDatetime = myDate + "T" + txtStartTime.Text + ":00.000Z",
			 activityStopDatetime = myDate + "T" + txtStopTime.Text + ":00.000Z",
			 activityDateStr = txtDate.Text,
			 activityDescriptionStr = "dinsdag middag in Zeewolde",
			 activityDistanceM = txtDistance.Text,
			 activityDurationS = "10472",
			 activityGpxIdStr = "10472090|1632223983090|163223445590",
			 activityStarttimeStr = txtStartTime.Text,
			 activityStoptimeStr = txtStopTime.Text,
			 activityType = "TYPE_BIKE",
			 contestIdStr = txtRoute.Text,
			 externalSourceIdStr = "JAZEKER",
			 externalSourceVersionStr = "v0.1i-07Feb2021-1",
			 jahomaSmartIdStr = txtParticipant.Text
			};

			Uri RequestUri = new Uri("https://jve.jahoma.nl/nl/api/app_upload_activity/appactadd");

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
				await DisplayAlert("Data", "Error. Authorisatie gefaald." + json, "Ok");
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