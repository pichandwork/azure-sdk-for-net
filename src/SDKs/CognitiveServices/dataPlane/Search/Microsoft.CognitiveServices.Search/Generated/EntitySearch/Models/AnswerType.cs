// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.CognitiveServices.Search.EntitySearch.Models
{
    using Microsoft.CognitiveServices;
    using Microsoft.CognitiveServices.Search;
    using Microsoft.CognitiveServices.Search.EntitySearch;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for AnswerType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AnswerType
    {
        [EnumMember(Value = "Entities")]
        Entities,
        [EnumMember(Value = "Places")]
        Places
    }
    internal static class AnswerTypeEnumExtension
    {
        internal static string ToSerializedValue(this AnswerType? value)  =>
            value == null ? null : ((AnswerType)value).ToSerializedValue();

        internal static string ToSerializedValue(this AnswerType value)
        {
            switch( value )
            {
                case AnswerType.Entities:
                    return "Entities";
                case AnswerType.Places:
                    return "Places";
            }
            return null;
        }

        internal static AnswerType? ParseAnswerType(this string value)
        {
            switch( value )
            {
                case "Entities":
                    return AnswerType.Entities;
                case "Places":
                    return AnswerType.Places;
            }
            return null;
        }
    }
}