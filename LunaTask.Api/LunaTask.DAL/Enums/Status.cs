using System.Runtime.Serialization;

namespace LunaTask.DAL.Enums
{
    public enum Status
    {
        [EnumMember(Value = "Pending")]
        Pending = 2,

        [EnumMember(Value = "InProgress")]
        InProgress = 4,

        [EnumMember(Value = "Completed")]
        Completed = 6,
    }
}
