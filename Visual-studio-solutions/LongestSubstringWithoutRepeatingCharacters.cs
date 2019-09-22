using System;
using System.Collections.Generic;
using System.Text;


/*
 * Assignment: https://leetcode.com/problems/longest-substring-without-repeating-characters/
 * 
 */
namespace Visual_studio_solutions
{
    public class LongestSubstringWithoutRepeatingCharacters
    {

        // "Sliding window" solution from https://leetcode.com/problems/longest-substring-without-repeating-characters/solution/
        // O(2n) complexity
        /*
         * In the naive approaches, we repeatedly check a substring to see if it has duplicate character. But it is unnecessary.
         * A sliding window is a window "slides" its two boundaries to the certain direction.
         */
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            HashSet<char> set = new HashSet<char>();
            int res = 0, i = 0, j = 0;
            while (i < n && j < n)
            {
                // try to extend the range [i, j]
                if (!set.Contains(s[j]))
                {
                    // Add the character to set and then increment j
                    set.Add(s[j++]);
                    // Update res
                    res = Math.Max(res, j - i);
                }
                else
                {
                    // Remove the starting character and keep iterating with the j index since we already know that the characters
                    // we have checked do not contain any duplicates
                    set.Remove(s[i++]);
                }
            }
            return res;
        }

        // "Sliding window" optimized solution from https://leetcode.com/problems/longest-substring-without-repeating-characters/solution/
        // O(n) complexity
        public int LengthOfLongestSubstringOptimized(string s)
        {
            int n = s.Length, ans = 0;
            Dictionary<char, int> map = new Dictionary<char, int>(); // current index of character
            // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    // set i to the either the current index of this character or the first occurrence of this character
                    i = Math.Max(map[s[j]], i);
                }
                // result is the difference between starting character index i and the current j
                ans = Math.Max(ans, j - i + 1);
                map[s[j]] = j + 1;
            }
            return ans;
        }

        /*
        public int LengthOfLongestSubstring(string s)
        {
            HashSet<char> hashSet = new HashSet<char>();
            int result = 0;
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                // If we find the same char twice, clear the hash set and result string
                if (hashSet.Contains(c))
                {
                    if (sb.Length > result)
                        result = sb.Length;
                    hashSet.Clear();
                    sb.Clear();
                }

                // Add char to hash set and result string
                hashSet.Add(c);
                sb.Append(c);
            }
            if (sb.Length > result)
            {
                return sb.Length;
            } else
            {
                return result;
            }
        }
        */
    }
}
