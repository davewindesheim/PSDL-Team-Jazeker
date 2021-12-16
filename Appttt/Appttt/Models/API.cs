using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Xamarin.Forms;

namespace Appttt.Models
{

    public class APIPayload
    {
        public string jahomaSmartIdStr { get; internal set; }
        public string contestIdStr { get; internal set; }
        public  DateTime activityDateStr { get; internal set; }
        public string activityStarttimeStr { get; internal set; }
        public string activityStoptimeStr { get; internal set; }
        public string activityDistanceM { get; internal set; }
        public string activityMaxspeedMs { get; internal set; }
        public string activityDescriptionStr { get; internal set; }
        public string activityGpxIdStr { get; internal set; }
        public string activityStartDatetime { get; internal set; }
        public string activityStopDateTime { get; internal set; }
        public string activityType { get; internal set; }
        public string externalsourceIdStr { get; internal set; }
        public string externalSourceVersionStr { get; internal set; }

        public string ActivityMaxspeedMs { get; internal set; }
        public string Participant { get; internal set; }
        public string Route { get; internal set; }
        public string Distance { get; internal set; }
        public string StartTime { get; internal set; }
        public string StopTime { get; internal set; }
        public string activityDurationS { get; internal set; }
    }
}

