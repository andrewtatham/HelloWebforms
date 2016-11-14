using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HelloWebforms.Helpers
{
    public class NestedDictionary<K, V> : Dictionary<K, NestedDictionary<K, V>>
    {
        public V Value { set; get; }

        public new NestedDictionary<K, V> this[K key]
        {
            set { base[key] = value; }

            get
            {
                if (!base.Keys.Contains<K>(key))
                {
                    base[key] = new NestedDictionary<K, V>();
                }
                return base[key];
            }
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Value != null)
            {
                sb.AppendFormat("{0}", Value.ToString()).AppendLine();
            }

            foreach (var key in Keys)
            {
                sb.AppendFormat("{{ {0}: {1} }},", key.ToString(), base[key].ToString()).AppendLine();
            }

            return sb.ToString();
        }
    }
}