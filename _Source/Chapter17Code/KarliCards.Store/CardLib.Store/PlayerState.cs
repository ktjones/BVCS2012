using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CardLib
{
  [DataContract]
  public enum PlayerState
  {
    [EnumMember] 
    Inactive,
    [EnumMember] 
    Active,
    [EnumMember] 
    MustDiscard,
    [EnumMember] 
    Winner,
    [EnumMember] 
    Loser
  }
}
