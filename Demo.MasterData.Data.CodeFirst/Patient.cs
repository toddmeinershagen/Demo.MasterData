using System.Collections.Generic;

namespace Demo.MasterData.Data.CodeFirst
{
    public class Patient
    {
        public Patient()
        {
            Episodes = new List<Episode>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
