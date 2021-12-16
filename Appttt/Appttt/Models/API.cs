using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Xamarin.Forms;

namespace Appttt.Models
{

    public class APIPayload
    {
        internal string jahomaSmartIdStr;
        internal string contestIdStr;
        internal DateTime activityDateStr;
        internal object activityStarttimeStr;
        internal object activityStoptimeStr;
        internal string activityDistanceM;
        internal string activityMaxspeedMs;
        internal string activityDescriptionStr;
        internal string activityGpxIdStr;
        internal TimePicker activityStartDatetime;
        internal TimePicker activityStopDateTime;
        internal string activityType;
        internal string externalsourceIdStr;
        internal string externalSourceVersionStr;

        public string ActivityMaxspeedMs { get; internal set; }
        public string Participant { get; internal set; }
        public string Route { get; internal set; }
        public string Distance { get; internal set; }
        public string StartTime { get; internal set; }
        public string StopTime { get; internal set; }
        public string activityDurationS { get; internal set; }
    }
}

