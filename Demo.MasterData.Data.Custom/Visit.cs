using System.Data.Services.Common;

namespace Demo.MasterData.Data.Custom
{
    [DataServiceKey("Id")]
    public class Visit
    {
        public int Id { get; set; }
    }
}
