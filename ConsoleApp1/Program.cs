using System;
using System.Collections;
using System.Collections.Generic;

public class PrintAllPalindrome
{
   
    public static void Main(String[] args)
    {
       
        int[] arr6 = { 2, 0, 2, 1, 1, 0 };
        int[] arr5 = { 2, 5, 6, 7, 8 };
         int[] arr4 = { 48, 99, 37, 4, -31 };
        int[] arr1 = { 0, 1, 0, 3, 12 };
        int[] arr = { 11, 12, 4, 6, 8, 5,76 };
        String input = "sadbutsad";
        int[] arr2 = { 0,2,1,0};

        Check();
        SortColors(arr6);

        TwoSum(arr5, 9);

        ShortestSubarray1(arr4,140);

        MinSpeedOnTime(new int[] {1,2,3 },2.7);
        var ans3 = PeakIndexInMountainArray(arr2);

        var ans2 = TwoSum2(new int[] { 3, 2, 4 }, 6);


        var obj = new PrintAllPalindrome();

        var ans1 = obj.StrStr("aaa", "aaaa");

        obj.MoveZeroes(arr1);
        var abc = obj.SecondLargestElement(arr);

        var ans =  obj.RomanToInt("MCMXCIV");
       
        Console.WriteLine("All possible palindrome" +
                            "partitions for " + input
                            + " are :");
        
        //allPalPartitions(input);
  
        var res = RemoveDuplicates(arr);
        //int target = 9;
        //var ans = TwoSum2(arr, target);

        //CombinationSum(arr, target);

        //var ans = WordPattern("abba", "dog dog dog dog");

        //var ans = SubsetsWithDup(arr);
        //var ans = LengthOfLongestSubstring("pwwkew");
        //MinimumRounds(new int[] { 2,3,3});

        string environmentName = null;
        string customerId = "123";
        // ans = MinDeletionSize(new string[] { "cba", "daf", "ghi" });
       var  UserName = $"U{environmentName}_{customerId}_powerbi";
        Console.WriteLine(UserName);
        Console.ReadKey();
       
    }


    public static void Check()
    {
        List<string> permissions = new List<string> {
            "Sanjeet_Jha_Read",
            "Sanjeet_Jha_Edit",
            "Other_Report_Read",
            "Another_Report_Edit"
        };

        string reportName = "Sanjeet Jha";

        bool hasPermission = CheckPermission(permissions, reportName);

        if (hasPermission)
        {
            Console.WriteLine($"User has permission for {reportName}.");
        }
        else
        {
            Console.WriteLine($"User does not have permission for {reportName}.");
        }
    }

    static bool CheckPermission(List<string> permissions, string reportName)
    {
        string cleanedReportName = reportName.Replace(" ", "_");

        foreach (string permission in permissions)
        {
            if (permission.StartsWith(cleanedReportName + "_", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }


    // Hard Question 862. Shortest Subarray with Sum at Least K

    public int ShortestSubarray(int[] nums, int k)
    {
        int n = nums.Length;
        int[] prefixSum = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        int minLength = n + 1;
        var deque = new LinkedList<int>();

        for (int i = 0; i <= n; i++)
        {
            while (deque.Count > 0 && prefixSum[i] - prefixSum[deque.First.Value] >= k)
            {
                minLength = Math.Min(minLength, i - deque.First.Value);
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && prefixSum[i] <= prefixSum[deque.Last.Value])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i);
        }

        return minLength <= n ? minLength : -1;
    }
    public static void SortColors(int[] nums)
    {
        var pointer = 0;
        for (int y = 0; y < 3; y++)
        {           
            for (int i = pointer; i < nums.Length; i++)
            {
                if (nums[i] == y )
                {
                    int temp = nums[i];
                    nums[i] = nums[pointer];
                    nums[pointer] = temp;
                    pointer++;
                }
            }
        }
    }

    
    public static int ShortestSubarray1(int[] nums, int k)
    {
        int sum = 0;
        int count = int.MaxValue;
        var preSum = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            var rem = sum - k;
            if (nums[i] == k)
            {
                count = Math.Min(count, 1);
            }
            if (sum == k)
            {
                count = Math.Min(count, (i + 1));
            }
            if (preSum.ContainsKey(rem))
            {
                count = Math.Min(count, ((i) - preSum[rem]));                
            }
            preSum.Add(sum, i);
        }
        if (count == int.MaxValue) return -1;

        return count;
    }

    public static int MinSpeedOnTime(int[] dist, double hour)
    {
        if (dist.Length - 1 > hour)
        {
            return -1;
        }
        var total = 0;
        foreach(var item in dist)
        {
            total += item;
        }

        var ans = Math.Ceiling(total / hour);

        return (int)ans;
    }


public static int PeakIndexInMountainArray(int[] arr)   //Binary search
    {
        int l = 0, r = arr.Length - 1, mid;
        while (l < r)
        {
            mid = (l + r) / 2;
            if (arr[mid] < arr[mid + 1])
                l = mid + 1;
            else
                r = mid;
        }
        return l;
    }

    public int StrStr(string haystack, string needle)
    { 
        int flag = 0;
        
        for(int i = 0; i < haystack.Length; i++)
        {
            flag = 0;
            if(haystack[i] == needle[0])
            {
                for(int j = 1; j < needle.Length; j++)
                {
                    if(j+i == haystack.Length || haystack[j+i] != needle[j])
                    {
                        flag = 1;
                        break;
                    }                   
                }    
                if(flag == 0)
                {
                    return i;
                }
            }
        }
        return -1;
    }
    public void MoveZeroes(int[] nums)
    {
        int zeroIdx = 0;
        int flag = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (flag == -1)
            {
                if (nums[i] == 0)
                {
                    zeroIdx = i;
                    flag = 0;
                    continue;
                    
                }
                continue;
            }
            if (nums[i] != 0)
            {
                if (i != zeroIdx)
                {
                    nums[zeroIdx] ^= nums[i];
                    nums[i] ^= nums[zeroIdx];
                    nums[zeroIdx] ^= nums[i];
                }
                zeroIdx++;
            }
        }
    }
    public void  rotateArrayByK(int[] a, int k)
    {
        
    }


    public int SecondLargestElement(int[] a)
    {
        int Ll = int.MinValue;
        int Rl = int.MinValue;

        var r = a.Length-1;
        var l = 0;

        var ans = -1;
        while (l < r) {
            if (a[l] > Ll) Ll = a[l];
            if (a[r] > Rl) Rl = a[r];
            l++; r--;
        }

        if (Ll > Rl || Ll == Rl) ans = Ll;
        else ans = Rl;

        return ans;
    }

    public int RomanToInt(string s)
    {
        var dict = new Dictionary<char, int>()
        {
            {'I',1 },
            {'V',5 },
            {'X',10 },
            {'L',50 },
            {'C',100 },
            {'D',500 },
            {'M',1000 },
        };
        
        var ans = 0;
        var prevNum = 0;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            var curr = dict[s[i]];
            ans = curr < prevNum ? ans - curr : ans + curr;
            prevNum = curr;
        }
        return ans;
    }

    public int GetNumber(char c)
    {
        var dict = new Dictionary<char, int>();
        if (!dict.ContainsKey(c))
        {
            switch (c)
            {
                case 'I':
                    dict.Add(c, 1);
                    return 1;
                case 'V':
                    dict.Add(c, 5);
                    return 5;
                case 'X':
                    dict.Add(c, 10);
                    return 10;
                case 'L':
                    dict.Add(c, 50);
                    return 50;
                case 'C':
                    dict.Add(c, 100);
                    return 100;
                case 'D':
                    dict.Add(c, 500);
                    return 500;
                case 'M':
                    dict.Add(c, 1000);
                    return 1000;
            }
        }
        return dict.GetValueOrDefault(c);
    }
    public static int RemoveDuplicates(int[] nums)
    {
        int i = 1;

        foreach (int n in nums)
        {
            if (nums[i - 1] != n) nums[i++] = n;
        }

        return i;
    }
    // Function to print all possible
    // palindromic partitions of str.
    // It mainly creates vectors and
    // calls allPalPartUtil()
    private static void allPalPartitions(String input)
    {
        int n = input.Length;

        // To Store all palindromic partitions
        List<List<String>> allPart = new List<List<String>>();

        // To store current palindromic partition
        List<String> currPart = new List<String>();

        // Call recursive function to generate
        // all partitions and store in allPart
        allPalPartitonsUtil(allPart, currPart, 0, n, input);

        // Print all partitions generated by above call
        for (int i = 0; i < allPart.Count; i++)
        {
            for (int j = 0; j < allPart[i].Count; j++)
            {
                Console.Write(allPart[i][j] + " ");
            }
            Console.WriteLine();
        }

    }

    // Recursive function to find all palindromic
    // partitions of input[start..n-1] allPart --> A
    // List of Deque of strings. Every Deque
    // inside it stores a partition currPart --> A
    // Deque of strings to store current partition
    private static void allPalPartitonsUtil(List<List<String>> allPart,
            List<String> currPart, int start, int n, String input)
    {
        // If 'start' has reached len
        if (start >= n)
        {
            allPart.Add(new List<String>(currPart));
            return;
        }

        // Pick all possible ending points for substrings
        for (int i = start; i < n; i++)
        {

            // If substring str[start..i] is palindrome
            if (isPalindrome(input, start, i))
            {

                // Add the substring to result
                currPart.Add(input.Substring(start, i + 1 - start));

                // Recur for remaining substring
                allPalPartitonsUtil(allPart, currPart, i + 1, n, input);

                // Remove substring str[start..i] from current
                // partition
                currPart.RemoveAt(currPart.Count - 1);
            }
        }
    }

    // A utility function to check
    // if input is Palindrome
    private static bool isPalindrome(String input,
                                    int start, int i)
    {
        while (start < i)
        {
            if (input[start++] != input[i--])
                return false;
        }
        return true;
    }

    //private static int isPalindromeNumber(int num , int rev)
    //{ 
    //    if(num == 0)
    //    {
    //        return rev;
    //    }


    //}

    public static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        int[] indices = new int[2];
        for (int i = 0; i < nums.Length; i++)
        {
            if (!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], i);
            }
            
            int key = target - nums[i];
           
            
            if (map.ContainsKey(key) && i != map[key])
            {
                indices[0] = map[key];
                indices[1] = i;
                break;
            }
        }
        return indices;
    }
    public static int[] TwoSumHashMethod(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        int[] ans = new int[2];
        for (int i = 0; i < nums.Length; i++)
        {
            var rem = target - nums[i];
            if (dict.ContainsKey(rem))
            {
                ans[0] = dict[rem];
                ans[1] = i;
            }
            dict.Add(i, nums[i]);
        }
        return ans;
    }

    public static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        var ds = new List<int>();
        findCombination(0, candidates, target, result, ds);
        return result;
    }
    private static void findCombination(int i, int[] candidates, int target, List<IList<int>> result, List<int> ds)
    {
        if (target<0 || i == candidates.Length)
        {
            return;
        }

        if (target == 0)
        {
            result.Add(new List<int>(ds));
            return;
        }
            

            ds.Add(candidates[i]);
            findCombination(i, candidates, target - candidates[i], result, ds);
            ds.Remove(candidates[i]);       
            findCombination(i + 1, candidates, target , result, ds);
    }

    public static int[] TwoSum2(int[] nums, int target)
    {
        var ans = new List<int>();
        findCombi(0, nums, target, ans);
        return (ans.ToArray());
    }
    private static bool findCombi(int i, int[] nums, int target, List<int> ans)
    {
        if (i == nums.Length)
        {
            if (target == 0)
                return true;
            else
                return false;
        }
        

        ans.Add(nums[i]);
        if (findCombi(i + 1, nums, target - nums[i], ans) == true)
            return true;

        ans.Remove(nums[i]);
        if (findCombi(i + 1, nums, target, ans) == true)
            return true;

        return false;
    }
    ////////////////
    public static IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        var ans = new List<IList<int>>();
        var ds = new List<int>();
        Array.Sort(nums);
        findSubset(0, nums, ans, ds);
        return ans;
    }

    private static void findSubset(int ind, int[] nums, List<IList<int>> ans, List<int> ds)
    {        
            ans.Add(new List<int>(ds));                

        for (int i = ind; i < nums.Length; i++)
        {
            if (i > ind && nums[i] == nums[i - 1]) continue;
            ds.Add(nums[i]);
            findSubset(i + 1, nums, ans, ds);
            ds.Remove(nums[i]);
        }
    }

    public static bool WordPattern(string pattern, string s)
    {

        string[] ans = s.Split(' ');
        if (pattern.Length != ans.Length) return false;

        Dictionary<String, String> d = new Dictionary<String, String>();
        for (int i = 0; i < ans.Length; i++)
        {
            string p = Char.ToString(pattern[i]);
            if (!d.ContainsKey(p))
            {
                d.Add(p, ans[i]);
            }
            else
            {
                if (d[p] != ans[i])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static int MinDeletionSize(string[] strs)
    {
        int ans = 0;
        for (int i = 0; i < strs[0].Length; i++)
        {
            int flag = 0;
            for (int j = 1; j < strs.Length; j++)
            {
                if (strs[j][i] < strs[j - 1][i])
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 1)
            {
                ans++;
            }
        }
        return ans;
    }
    public static int MinimumRounds(int[] tasks)
    {
        int ans = 0;
        Hashtable d = new Hashtable();
        for (int i = 0; i < tasks.Length; i++)
        {
            if (!d.ContainsKey(tasks[i])) d.Add(tasks[i], 1);
            else
            {
                var count = d[tasks[i]];               
                d[tasks[i]] = (int)count+1;
                // d.Remove(tasks[i]);
                //d.Add(tasks[i],count+1);
            }
        }
        if (d.ContainsValue(1)) return -1;

        foreach (KeyValuePair<int, int> entry in d)
        {
            if (entry.Value % 3 == 0) ans += (entry.Value / 3);
            else ans += ((entry.Value / 3) + 1);
        }
        return ans;
    }

    public static int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 1) return 1;
        int ans = 0, ind = 0,flag = 0;
        Hashtable h = new Hashtable();
        for (int i = 0; i < s.Length; i++)
        {
            flag = 0;
            if (!h.ContainsKey(s[i]))
            {
                h.Add(s[i], i);
                flag = 1;
            }
            else
            {
                if ((int)h[s[i]] >= ind)
                {
                    ans = Math.Max(ans, i - ind);
                    h[s[i]] = i;
                    if (s[i] == s[i - 1]) ind = i;
                    else i++;
                }
            }
        }
        if(flag == 1) ans = Math.Max(ans, s.Length - ind);
        return ans;
    }
}