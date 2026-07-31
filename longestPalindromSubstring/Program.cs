using System.Runtime.ConstrainedExecution;

public class Solution {
    public string LongestPalindrome(string s) {
        int pos = 0;
        char[] str = s.ToCharArray();
        List<string> letras = new List<string>();

        if (str.Count() == 1) return s;
        for (int i = 0; i < s.Count(); i++)
        {
            for (int j = str.Count(); j >= 0 ; j--)
            {
                if (j-i >= 1 && esPal(str[i..j]))
                {
                    letras.Add(new string(str[i..j]));
                    break;
                }
            }
        }
        if (letras.Count == 0) letras.Add(new string(str[0..1]));

        for (int i = 0; i < letras.Count(); i++)
        {
            pos = letras[i].Count() > letras[pos].Count() ? i:pos;
        }
        return letras[pos];
    }

    public static bool esPal(char[] s)
    {
        if (s.Count() == 2 && s[0] == s[1]) return true;
        int largo = s.Count() - 1;
        for (int i = 0; i < s.Count(); i++)
        {   
            if (i == largo-i) break;
            if (s[i] != s[largo - i]) return false;
        }
        return true;
    }
}

public class myProyect
{
    public static void Main()
    {
        Solution sol = new Solution();
        System.Console.WriteLine("retorna: " + sol.LongestPalindrome("babad"));
        System.Console.WriteLine("retorna: " + sol.LongestPalindrome("ccc"));
        System.Console.WriteLine("retorna: " + sol.LongestPalindrome("abb"));
        System.Console.WriteLine("retorna: " + sol.LongestPalindrome("cccc"));
        
    }
}