using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace RestAPI.Core.Models
{
    public class DynamicLinkCollection : DynamicObject
    {
        public DynamicLinkCollection()
        {
            _links = new Dictionary<string, string>();
        }
        private readonly Dictionary<string, string> _links;

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            var index = (string)indexes[0];
            if (_links.ContainsKey(index))
                _links[index] = value.ToString();
            else
                _links.Add(index, value.ToString());
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _links.Select(link => link.Key);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            try
            {
                result = _links[binder.Name];
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}