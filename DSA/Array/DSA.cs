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

}