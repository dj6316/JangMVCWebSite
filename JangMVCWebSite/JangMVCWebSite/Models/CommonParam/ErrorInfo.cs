using System.Collections.Generic;
using System.Linq;

namespace JangMVCWebSite.Models.CommonParam
{
    public class ErrorInfo : List<Error>
    {
        public ErrorInfo Add(string field, string code)
        {
            Add(new Error() { Field = field, Code = code });
            return this;
        }

        public ErrorInfo Add(string field, string code, string info)
        {
            Add(new Error() { Field = field, Code = code, Info = info });
            return this;
        }

        public ErrorInfo Add(ErrorInfo errorInfo)
        {
            foreach (Error errorItem in errorInfo)
            {
                this.Add(errorInfo);
            }
            return this;
        }

        public bool IsValid()
        {
            return this.Count == 0;
        }
    }

    public class Error
    {
        private string field = "";
        private string code = "";
        private string info = "";

        public string Field
        {
            get { return field; }
            set { field = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    }
}