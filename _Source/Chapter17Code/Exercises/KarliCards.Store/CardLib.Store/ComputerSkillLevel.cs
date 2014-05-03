using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CardLib
{
  [DataContract]
  public enum ComputerSkillLevel
  {
    [EnumMember]
    Dumb,
    [EnumMember]
    Good,
    [EnumMember]
    Cheats
  }
}
