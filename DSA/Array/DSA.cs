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

}