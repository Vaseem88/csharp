using System.Text;

public class DSA
{
    public static bool IsUnique(string str) {
        bool[] charset = new bool[128];
        
        if(str.Length > 128){
            return false;
        }
        
        for(int i=0;i<str.Length;i++){
            var charVal = str[i];
            Console.WriteLine($"charVal: {charVal} for i: {i} and charset[charVal] :{charset[charVal]}");
            if(charset[charVal]){
                return false;
            }
            charset[charVal] = true;
        }
        return true;
        
    }
    
    public static bool IsUniqueFast(string str){
        
        int checker =0;
        for(int i=0;i<str.Length;i++){
            int val = str[i] - 'a';
            Console.WriteLine($"val: {val} , Checker : {checker}, (1 << val) : {(1 << val)}");
            Console.WriteLine($"(checker & (1 << val)) : {(checker & (1 << val))}");
            if((checker & (1 << val)) > 0){
                return false;
                
            }
            checker |= (1 << val);
        }
        return true;
    }

    public static bool CheckPermutationBySorting(string source, string target){
        var sourceArray = source.ToCharArray();
        var targetArray = target.ToCharArray();
        Array.Sort(sourceArray);
        Array.Sort(targetArray);

        return string.Join("",sourceArray) ==
        string.Join("",targetArray);
    }

    public static bool CheckPermutationByCount(string source, string target){
        int[] count = new int[128];

        for(int i=0;i<source.Length;i++){
            count[source[i]]++;
        }

        for(int i=0;i<target.Length;i++){
            if(count[target[i]] <= 0){
                return false;
            }
            count[target[i]]--;
        }
        return true;
    }

    //1.3
    public static string URLify(char[] str, int trueLength){
        // count the number of spaces
        int spaceCount = 0;
        for(int i=0;i<trueLength;i++){
            if(str[i] == ' '){
                spaceCount++;
            }
        }
        int totalLength = (spaceCount * 2) + trueLength;
        
        for(int i=trueLength - 1;i>0;i--){
            if(str[i]==' '){
                str[totalLength - 1] = '0';
                str[totalLength - 2] = '2';
                str[totalLength - 3] = '%';
                totalLength = totalLength - 3;
            }
            else{
                str[totalLength - 1] = str[i];
                totalLength--;
            }
        }
        return new string(str);
    }

    //1.4
    public static bool isPermutationOfPalindrome(string str){
        var table = buildCharFrequency(str);
        var foundOdd = false;
        foreach(var item in table){
            if(item %2 == 1){
                if(foundOdd){
                    return false;
                }
                foundOdd = true;
            }
        }
        return true;
    }
    public static int GetCharNumber(char c){
        int a = (int)'a';
        int z = (int)'z';
        if(a <= c && c <= z)
        {
            return c - a;
        }
        return -1;
    }
    public static int[] buildCharFrequency(string str){
        int[] table = new int[GetCharNumber('z') + 1];
        foreach(var c in str){
            var val = GetCharNumber(c);
            if(val != -1){
                table[val]++;
            }            
        }
        return table;
    }

    public static bool IsPermutationOfPalindromeOptimized(string str){
        int[] table = new int[GetCharNumber('z') + 1];
        int countOdd = 0;
        foreach(var c in str){
            var val = GetCharNumber(c);
            if(val != -1){
                table[val]++;
                if(table[val] % 2 == 0){
                    countOdd--;
                }
                else{
                    countOdd++;
                }
            }          
        }
        return countOdd <= 1;
    }

    public static bool IsPermutationOfPalindromeByBitVector(string str)
    {
        int bitVector = CreateBitVector(str);
        return bitVector == 0 || CheckExactlyOneBitSet(bitVector);
    }

    public static int CreateBitVector(string str){
        int bitVector = 0;
        foreach(var c in str){
            int x = GetCharNumber(c);
            bitVector = toggle(bitVector, x);
        }
        return bitVector;
    }

    public static int toggle(int bitVector, int index){
        if (index < 0) return bitVector;

        int mask = 1 << index;

        if((bitVector & mask) == 0){
            bitVector |= mask;
        }
        else{
            bitVector &= ~mask;
        }
        return bitVector;
    }

    public static bool CheckExactlyOneBitSet(int bitVector){
        return (bitVector & (bitVector - 1)) == 0;
    }

    //1.5
    public static bool OneWayChange(string s1, string s2){
        if(s1.Length == s2.Length){
            return OneReplaceCheck(s1, s2);
        }
        else if(s1.Length + 1 == s2.Length){
            return OneInsertCheck(s1, s2);
        }
        else if (s1.Length -1 == s2.Length){
            return OneInsertCheck(s2, s1);
        }
        return false;
    }

    public static bool OneReplaceCheck(string s1, string s2){
        var foundDifference = false;
        for(int i=0;i<s1.Length;i++){
            if(s1[i] != s2[i]){
                if(foundDifference){
                    return false;
                }
                foundDifference = true;
            }
        }
        return true;
    }
    
    public static bool OneInsertCheck(string s1, string s2){
        int index1 = 0, index2 = 0;
        while(index2 < s2.Length && index1 <s1.Length){
            if(s1[index1] != s2[index2]){
                if(index1 != index2){
                    return false;
                }
                index2++;
            }
            else{
                index1++;
                index2++;
            }
        }
        return true;
    }

    public static bool OneWayChange2(string s1, string s2){
        if(Math.Abs(s1.Length - s2.Length) > 1){
            return false;
        }

        string shortStr = s1.Length > s2.Length ? s2 : s1;
        string longStr = s1.Length < s2.Length ? s2 : s1;

        int index1 = 0, index2 = 0;
        var foundDifference = false;
        while(index2 < longStr.Length && index1< shortStr.Length){
            if (longStr[index2] != shortStr[index1])
            {
                if(foundDifference){
                    return false;
                }
                foundDifference = true;

                if(shortStr.Length == longStr.Length){
                    index1++;
                }
            }
            else{
                index1++;
            }
            index2++;
        }
        return true;
    }
}