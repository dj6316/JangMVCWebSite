using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JangMVCWebSite.Object
{
    public class NameChangeAttribute : Attribute
    {
        public string ChangeName { get; set; }
        public NameChangeAttribute(string value)
        {
            ChangeName = value;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface)]
    public class ClassTypeAttribute : Attribute
    {
        public Type ClassType { get; private set; }
        public ClassTypeAttribute(Type ownedClassType)
        {
            ClassType = ownedClassType;
        }
    }
}