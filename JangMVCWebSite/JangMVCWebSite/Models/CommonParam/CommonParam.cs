using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace JangMVCWebSite.Models.CommonParam
{
    public class CommonParam : ICloneable
    {
        private ErrorInfo errorInfo = new ErrorInfo();
        public string Active { get; set; }
        private Dictionary<string, object> objectDic = new Dictionary<string, object>();

        public ErrorInfo ErrorInfo { get { return errorInfo; } set { errorInfo = value; } }

        public object this[string key]
        {
            get { return Get<object>(key); }
            set
            {
                objectDic[key.ToUpper()] = value;
            }
        }

        public static CommonParam Create(object obj)
        {
            CommonParam param = new CommonParam();
            Type type = obj.GetType();
            foreach (PropertyInfo info in type.GetProperties())
            {
                param.objectDic.Add(info.Name.ToUpper(), info.GetValue(obj, null));
            }
            return param;
        }

        public void Add(string key, object obj)
        {
            key = key.ToUpper();
            if (objectDic.ContainsKey(key)) throw new Exception("already exist key : " + key);
            objectDic.Add(key, obj);
        }

        public T Get<T>(string key)
        {
            key = key.ToUpper();
            if (!objectDic.ContainsKey(key)) throw new Exception("there is no key");
            return (T)objectDic[key];
        }

        public object Get(string key)
        {
            key = key.ToUpper();
            if (!objectDic.ContainsKey(key)) throw new Exception("there is no key");
            return objectDic[key];
        }

        public Dictionary<string, object> GetDic()
        {
            return objectDic;
        }

        public IEnumerable<string> GetKeys()
        {
            return objectDic.Keys;
        }

        public IList<T> GetList<T>(string key)
        {
            return Get<IList<T>>(key);
        }

        public T GetOrDefault<T>(string key)
        {
            key = key.ToUpper();
            if (!objectDic.ContainsKey(key)) return default(T);
            return (T)objectDic[key];
        }

        public IEnumerable<SelectListItem> GetSelectList(string key)
        {
            return Get<IEnumerable<SelectListItem>>(key);
        }

        public string GetString(string key)
        {
            key = key.ToUpper();
            if (!objectDic.ContainsKey(key)) return "";
            return objectDic[key].ToString();
        }

        public int GetInt(string key)
        {
            key = key.ToUpper();
            if (!objectDic.ContainsKey(key)) return 0;

            int intValue = 0;
            if (int.TryParse(objectDic[key].ToString(), out intValue)) return intValue;
            return 0;
        }

        public bool HasKey(string key)
        {
            return objectDic.ContainsKey(key.ToUpper());
        }

        public CommonParam Merge(CommonParam addParam)
        {
            if (addParam == null) return this;
            foreach (var key in addParam.GetKeys())
            {
                Add(key, addParam.Get(key));
            }

            foreach (var addError in addParam.ErrorInfo)
            {
                ErrorInfo.Add(addError);
            }

            return this;
        }

        public object Clone()
        {
            return new CommonParam()
            {
                ErrorInfo = this.ErrorInfo,
                objectDic = this.objectDic
            };
        }

        public static CommonParam Merge(params CommonParam[] commonParams)
        {
            CommonParam resultParam = new CommonParam();
            foreach (var param in commonParams) resultParam.Merge(param);
            return resultParam;
        }
    }
}