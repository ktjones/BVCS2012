using System.Runtime.Serialization;

namespace Ch17Ex01
{
  [DataContract]
  public class AppStateData
  {
    [DataMember]
    public string Data { get; set; }
  }
}
