using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Xamarin.Forms;

namespace Appttt.Models
{

    public class API
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
        internal string externalSourceeVersionStr;

        public string ActivityMaxspeedMs { get; set; }
        public string Participant { get; set; }
        public string Route { get; set; }
        public string Distance { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public string activityDuraionS { get; internal set; }
    }
}

