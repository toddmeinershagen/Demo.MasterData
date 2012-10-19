using System.Collections.Generic;

namespace Demo.MasterData.Data.CodeFirst
{
    public class Episode
    {
        public Episode()
        {
            Visits = new List<Visit>();
        }

        public int Id { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
