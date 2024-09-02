using System.Runtime.Serialization;

namespace LunaTask.DAL.Enums
{
    public enum Priority
    {
        [EnumMember(Value = "Low")]
        Low = 2,

        [EnumMember(Value = "Medium")]
        Medium = 4,

        [EnumMember(Value = "High")]
        High = 6,
    }
}
