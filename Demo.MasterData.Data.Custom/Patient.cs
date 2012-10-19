using System.Collections.Generic;
using System.Data.Services.Common;

namespace Demo.MasterData.Data.Custom
{
    [DataServiceKey("Id")]
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
