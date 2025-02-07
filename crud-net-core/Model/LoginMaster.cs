namespace crud_net_core.Model
{
    public class LoginMaster
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }

    public class LoginBody
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
    }

}
