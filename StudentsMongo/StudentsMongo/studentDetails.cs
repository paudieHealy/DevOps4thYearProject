using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;


namespace StudentsMongo
{
    public class studentDetails
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string tNumber { get; set; }
        public string password { get; set; }
        public Boolean feesPaid { get; set; }
        public String college { get; set; }
        public string subject1 { get; set; }
        public string subject2 { get; set; }
        public string subject3 { get; set; }
        public string subject4 { get; set; }
        public string subject5 { get; set; }
    }
}