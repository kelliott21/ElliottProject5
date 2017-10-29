using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElliottProject5
{
    public class DataItem
    {
        public int occurences = 1;
        public string Value { get; set; }

        public DataItem(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(Value))
                return (Value + " (" + occurences.ToString() + " occurence(s))");
            return base.ToString();
        }
    }
    public class StringKey
    {
        public int occurences = 1;
        public string Value { get; set; }

        public StringKey(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(Value))
                return (Value + " (" + occurences.ToString() + " occurence(s))");
            return base.ToString();
        }
    }
}
