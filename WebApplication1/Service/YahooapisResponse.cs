using System;
using System.Runtime.Serialization;

namespace WebApplication1.Service
{
    [DataContract]
    public class YahooapisResponse
    {

        [DataMember(Name = "query")]
        public Query query { get; set; }


        [DataContract]
        public class Query
        {

            [DataMember(Name = "results")]
            public Results results { get; set; }


            [DataContract]
            public class Results
            {

                [DataMember(Name = "rate")]
                public Rate rate { get; set; }

                [DataContract]
                public class Rate
                {
                    [DataMember(Name = "Rate")]
                    public float RateVal { get; set; }
                }
            }
        }
    }
}