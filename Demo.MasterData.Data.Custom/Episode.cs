using System.Collections.Generic;
using System.Data.Services.Common;

namespace Demo.MasterData.Data.Custom
{
    [DataServiceKey("Id")]
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
