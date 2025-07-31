namespace HotelProject.WUI.Dtos.FollowersDto
{
    public class ResultTwitterFollowersDto
    {

        public class Rootobject
        {
            public string status { get; set; }
        }



        public class Stats
        {
            public string posts { get; set; }
            public string following { get; set; }
            public string followers { get; set; }
            public string likes { get; set; }
        }


    }
}
