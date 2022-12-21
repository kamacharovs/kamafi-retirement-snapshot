using System.Text.Json.Serialization;

namespace KamaFi.Retirement.Snapshot.Data.Constants.Enums
{
    public enum RetirementSaveType
    {
        [JsonPropertyName("tax_non_exempt")] TaxNonExempt,
        [JsonPropertyName("tax_exempt")] TaxExempt,
    }
}