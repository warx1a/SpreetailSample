using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public class MultiValueDictionary
    {
        //holds our dictionary of string/value pairs
        private Dictionary<string, List<string>> dictValues;

        public MultiValueDictionary()
        {
            this.dictValues = new Dictionary<string, List<string>>();
        }

        public string Add(string key, string value)
        {
            //if the key is already in the dictionary, add it to the existing list of values
            if (dictValues.ContainsKey(key))
            {
                List<string> vals = dictValues[key];
                //update our list of values w/ the new value we're adding
                if (!vals.Contains(value))
                {
                    vals.Add(value);
                    dictValues[key] = vals;
                    return "Success";
                }
                else //the value we want to add is already in the dictionary, so throw an error
                {
                    return "ERROR, member already exists for key";
                }
            }
            //the key isn't in the dictionary, so add in the k/v pair
            else
            {
                dictValues[key] = new List<string>();
                dictValues[key].Add(value);
                return "Success";
            }
        }

        public string Keys()
        {
            if (dictValues.Count == 0)
            {
                return "(empty set)";
            }
            else
            {
                int idx = 1;
                StringBuilder sbKeys = new StringBuilder();
                foreach(string sKey in dictValues.Keys)
                {
                    sbKeys.Append($"{idx}) {sKey}\n");
                    idx++;
                }
                return sbKeys.ToString();
            }
        }

        public string Members(string key)
        {
            if (dictValues.ContainsKey(key))
            {
                StringBuilder sbMembers = new StringBuilder();
                int idx = 1;
                foreach(string val in dictValues[key])
                {
                    string sRecord = $"{idx}) {val}\n";
                    sbMembers.Append(sRecord);
                    idx++;
                }
                return sbMembers.ToString();
            }
            else //throw an error since we can't retrieve any values for that key
            {
                return "ERROR, key does not exist";
            }

        }

        public string AllMembers()
        {
            if(dictValues.Count == 0)
            {
                return "(empty set)";
            }
            //select the List<string> of values, and join all the values inside of that in a flat list
            List<string> allMembers = dictValues.Values.SelectMany((vals) => vals.Select((innerVal) => innerVal)).ToList();
            int idx = 1;
            StringBuilder sbAllMems = new StringBuilder();
            foreach(string mem in allMembers)
            {
                string sRecord = $"{idx}) {mem}\n";
                sbAllMems.Append(sRecord);
                idx++;
            }
            return sbAllMems.ToString();
        }

        public string Remove(string key, string value)
        {
            if (dictValues.ContainsKey(key))
            {
                //get the current values in the dictionary
                List<string> vals = dictValues[key];
                if (vals.Contains(value))
                {
                    vals.Remove(value);
                }
                else
                {
                    return "ERROR, member does not exist";
                }
                //if no values remain for the given key, remove the key itself from the dictonary
                if (vals.Count == 0)
                {
                    dictValues.Remove(key);
                } else //update the kv pair w/ the updated list of values
                {
                    dictValues[key] = vals;
                }
                return "Removed";
            }
            else //we didn't find they key in the dictionary
            {
                return "ERROR, key does not exist";
            }
        }

        /// <summary>
        /// Removes all values tied to a given key in the dictionary. Also removes the key itself.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>'Removed' if the key is in the dictionary. An error otherwise.</returns>
        public string RemoveAll(string key)
        {
            if(dictValues.ContainsKey(key))
            {
                //reset the values under the given key
                dictValues.Remove(key);
                return "Removed";
            } else
            {
                //if the key isn't in the dictionary, return an error
                return "ERROR, key does not exist";
            }
        }

        /// <summary>
        /// Clears all keys and values from the dictionary. This is a call to the underlying Dictionary.Clear() method
        /// </summary>
        /// <returns>'Ckeared'</returns>
        public string Clear()
        {
            dictValues.Clear();
            //output this how the instructions did
            return "Cleared";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns true if the dictionary contains 0 records. False otherwise.</returns>
        public bool IsEmpty()
        {
            return dictValues.Count == 0;
        }

        /// <summary>
        /// Function to check if a key is contained in the dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True if the key is contained in the dictionary. False otherwise.</returns>
        public bool KeyExists(string key)
        {
            return dictValues.ContainsKey(key);
        }

        /// <summary>
        /// Function to check if a value is contained under a key in the dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>True if the value is in the list of members for the given key. False otherwise.</returns>
        public bool MemberExists(string key, string value)
        {
            if(dictValues.ContainsKey(key))
            {
                //if the values under the given key contain the value we're searching for return true
                if(dictValues[key].Contains(value))
                {
                    return true;
                }
            }
            //all other paths should return false since the member doesn't exist
            return false;
        }

        /// <summary>
        /// Prints out all they key/value pairs in the dictionary
        /// </summary>
        /// <returns>Key/value pairs in the form of: key: val1,val2,val3</returns>
        public string Items()
        {
            //if no k/v pairs, return an empty set
            if(dictValues.Count == 0)
            {
                return "(empty set)";
            }
            //use StringBuilder here, so we aren't creating a bunch of unnecessary strings when looping
            StringBuilder sbItems = new StringBuilder();
            int idx = 1;
            foreach(KeyValuePair<string, List<string>> kvPair in dictValues)
            {
                string sRecord = $"{idx}) {kvPair.Key}: {string.Join(",", kvPair.Value)}\n";
                sbItems.Append(sRecord);
                idx++;
            }
            return sbItems.ToString();
        }

    }
}