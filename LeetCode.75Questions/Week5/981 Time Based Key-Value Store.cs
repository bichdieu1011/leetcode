using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCode._75Questions.Week5._981_Time_Based_Key_Value_Store;

namespace LeetCode._75Questions.Week5
{
    public class _981_Time_Based_Key_Value_Store
    {
        public static void Test()
        {
            //TimeMap timeMap = new TimeMap();
            //timeMap.Set("love", "high", 10);  // store the key "foo" and value "bar" along with timestamp = 1.
            //timeMap.Set("love", "high", 20);  // store the key "foo" and value "bar" along with timestamp = 1.
            //timeMap.Get("love", 5);         // return "bar"
            //timeMap.Get("love", 10);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
            //timeMap.Get("love", 15); // store the key "foo" and value "bar2" along with timestamp = 4.
            //timeMap.Get("love", 20);         // return "bar2"
            //timeMap.Get("love", 25);         // return "bar2"

            TimeMap timeMap = new TimeMap();
            timeMap.Set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
            timeMap.Get("foo", 1);         // return "bar"
            timeMap.Get("foo", 3);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
            timeMap.Set("foo", "bar2", 4); // store the key "foo" and value "bar2" along with timestamp = 4.
            timeMap.Get("foo", 4);         // return "bar2"
            timeMap.Get("foo", 5);         // return "bar2"

        }

        public class TimeMap
        {

            public Dictionary<string, List<(int time, string value)>> _dict;
            public TimeMap()
            {
                _dict = new Dictionary<string, List<(int time, string value)>>();

            }

            public void Set(string key, string value, int timestamp)
            {
                if (!_dict.ContainsKey(key))
                {
                    _dict.Add(key, new List<(int time, string value)>());
                }

                _dict[key].Add((timestamp, value));
            }

            public string Get(string key, int timestamp)
            {
                if (!_dict.ContainsKey(key)) return string.Empty;

                var listValue = _dict[key];
                var l = 0;
                var r = listValue.Count - 1;
                var returnValue = string.Empty;
                while (l <= r)
                {
                    var m = l + (r - l) / 2;
                    if (listValue[m].time == timestamp) return listValue[m].value;
                    if (listValue[m].time < timestamp)
                    {
                        l = m + 1;
                        returnValue = listValue[m].value;
                    }
                    else r = m - 1;
                }
                
                return returnValue;
            }
        }

        /**
         * Your TimeMap object will be instantiated and called as such:
         * TimeMap obj = new TimeMap();
         * obj.Set(key,value,timestamp);
         * string param_2 = obj.Get(key,timestamp);
         */
    }
}
