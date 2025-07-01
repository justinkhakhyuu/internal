using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Celestial_Mods_V3.models
{
    public class UsersModel
    {
            public string credential { get; set; }
    }
    public class user_data_structure
    {
        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string ip { get; set; }
        [DataMember]
        public string hwid { get; set; }
        [DataMember]
        public string createdate { get; set; }
        [DataMember]
        public string lastlogin { get; set; }
        [DataMember]
        public List<Data> subscriptions { get; set; } // array of subscriptions (basically multiple user ranks for user with individual expiry dates
    }
    public class Data
    {
        public string subscription { get; set; }
        public string expiry { get; set; }
        public string timeleft { get; set; }
    }
}