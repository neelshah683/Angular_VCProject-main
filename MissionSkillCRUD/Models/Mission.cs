using System;

namespace MissionApi.Models
{
    public class Mission
    {
        public int id { get; set; }
        public string missiontitle { get; set; }
        public string missiondescription { get; set; }
        public string missionorganisationname { get; set; }
        public string missionorganisationdetail { get; set; }
        public int countryid { get; set; }
        public int cityid { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string missiontype { get; set; }
        public int totalsheets { get; set; }
        public DateTime registrationdeadline { get; set; }
        public string missionthemeid { get; set; }
        public string missionskillid { get; set; }
        public string missionimages { get; set; }
        public string missiondocuments { get; set; }
        public string missionavailability { get; set; }
        public string missionvideourl { get; set; }

    }
}
