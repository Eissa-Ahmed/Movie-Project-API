namespace Movie.BL.Response
{
    public class ResponseModel<t1>
    {
        public bool Status { get; set; }
        public int Code { get; set; }
        public string message { get; set; }
        public t1? data {get; set;}
    }
}
