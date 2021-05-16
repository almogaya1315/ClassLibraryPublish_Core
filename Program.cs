using System;

namespace ClassLibraryPublish_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Publish.Pack<Member>();
        }
    }

    public class Member
    {
        public int MembershipId { get; set; }
        public int NationalityId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
