using System.Text.Json.Serialization;
using KamaFi.Retirement.Snapshot.Data.Constants.Enums;

namespace KamaFi.Retirement.Snapshot.Data.Models
{
    public class RetirementSave
    {
        public int RetirementSaveId { get; set; }

        public Guid PublicKey { get; set; } = Guid.NewGuid();

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RetirementSaveType Type { get; set; }
    }
}