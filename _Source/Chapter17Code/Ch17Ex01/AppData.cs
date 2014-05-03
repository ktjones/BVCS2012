using System.Runtime.Serialization;

namespace Ch17Ex01
{
  [DataContract]
  [KnownType(typeof(AppStateData))]
  public class AppData
  {
    [DataMember]
    public int TheAnswer { get; set; }

    [DataMember]
    public AppStates State { get; set; }

    [DataMember]
    public object StateData { get; set; }

  }
}
