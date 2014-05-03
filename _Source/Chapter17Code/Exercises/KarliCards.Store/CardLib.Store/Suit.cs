using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardLib.Store;
using System.Runtime.Serialization;

namespace CardLib
{
  [DataContact]
   public enum Suit
   {
    [EnumMember] 
      Club,
    [EnumMember] 
      Diamond,
    [EnumMember] 
      Heart,
    [EnumMember] 
      Spade,
   }
}
