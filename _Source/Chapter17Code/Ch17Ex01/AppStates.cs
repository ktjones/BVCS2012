using System.Runtime.Serialization;

namespace Ch17Ex01
{
  [DataContract]
  public enum AppStates
  {
    [EnumMember]
    Started,
    [EnumMember]
    Suspended,
    [EnumMember]
    Closing
  }
}
