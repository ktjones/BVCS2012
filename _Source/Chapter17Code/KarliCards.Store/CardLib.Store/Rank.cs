using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CardLib
{
  [DataContract]
   public enum Rank
   {
    [EnumMember] 
      Ace = 1,
    [EnumMember] 
      Deuce,
    [EnumMember] 
      Three,
    [EnumMember] 
      Four,
    [EnumMember] 
      Five,
    [EnumMember] 
      Six,
    [EnumMember] 
      Seven,
    [EnumMember] 
      Eight,
    [EnumMember] 
      Nine,
    [EnumMember] 
      Ten,
    [EnumMember] 
      Jack,
    [EnumMember] 
      Queen,
    [EnumMember] 
      King,
   }
}
