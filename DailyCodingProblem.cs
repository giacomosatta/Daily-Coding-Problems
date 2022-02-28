// See https://aka.ms/new-console-template for more information

#region  CheckTheSum 

//Given a list of numbers and a number k, return wheter any two numbers from the list add up to k
//ES: given [10,15,3,7] and k=17, return true because 10+7 is 17
//Asked by Google

// int [] array = {10,15,3,7};
// int target = 10;
// CheckTheSum(array,target);

void CheckTheSum(int[] intArray,int target){
    bool flag = false;
    HashSet<long> hashSet = new HashSet<long>();

    foreach(int i in intArray){
        if(hashSet.Contains(target-i))
        flag = true;
        hashSet.Add(i);
    }

    if(flag)
        Console.WriteLine("Il numero è una somma di due numeri dell'array");
    
    if(!flag)
        Console.WriteLine("Il numero non è una somma di due numeri dell'array");
}

#endregion

#region ArrayProduct
//Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i
//ES: If our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]
//Asked by Uber

// int [] array = {1,2,3,4,5};
// ArrayProduct(array);

void ArrayProduct(int[] intArray){
    string outputArray = "";

    for(int i = 0; i < intArray.Length; i++){
        int product = 1;
        for(int j = 0; j < intArray.Length; j++){
            if(i==j)
                continue;
            
            product *= intArray[j];
        }
        outputArray += product.ToString() +",";
    }
    Console.WriteLine(outputArray);
}
#endregion

#region  CheckLowestPositive
//Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.
//For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
//Asked by Stripe

 int [] array = {2,1,-1,0};
 int size = array.Length;
// CheckLowestPositive(array);

void CheckLowestPositive(int[] arr){

     int shift = segregate(arr, size);
        int[] arr2 = new int[size - shift];
        int j = 0;
 
        for (int i = shift; i < size; i++) {
            arr2[j] = arr[i];
            j++;
        }
 
        // Shift the array and call
        // findMissingPositive for
        // positive part
        int missing= findMissingPositive(arr2, j);
        
        Console.WriteLine("Il numero mancante è:"+missing); 
}
 static int segregate(int[] arr, int size)
    {
        int j = 0, i;
        for (i = 0; i < size; i++) {
            if (arr[i] <= 0) {
                int temp;
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
 
                // increment count of non-positive
                // integers
                j++;
            }
        }
 
        return j;
    }

 static int findMissingPositive(int[] arr, int size){
        int i;
 
        // Mark arr[i] as visited by making
        // arr[arr[i] - 1] negative. Note that
        // 1 is subtracted as index start from
        // 0 and positive numbers start from 1
        for (i = 0; i < size; i++) {
            if (Math.Abs(arr[i]) - 1 < size && arr[ Math.Abs(arr[i]) - 1] > 0)
                arr[ Math.Abs(arr[i]) - 1] = -arr[ Math.Abs(arr[i]) - 1];
        }
 
        // Return the first index value at
        // which is positive
        for (i = 0; i < size; i++)
            if (arr[i] > 0)
                return i + 1;
 
        // 1 is added because indexes
        // start from 0
        return size + 1;
    }

#endregion  

#region DecodeNumber
//Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
//For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.
//Asked by Facebook

// A naive recursive C# implementation
// to count number of decodings that
// can be formed from a given digit sequence
char[] digits = { '1', '2', '3', '4' };
// DecodeNumber(digits);
void DecodeNumber(char[] digits) {
	int n = digits.Length;
	Console.Write("Count is ");
	Console.Write(countWays(digits, n));		
}

static int countDecoding(char[] digits, int n)
	{
		// base cases
		if (n == 0 || n == 1)
			return 1;

		// Initialize count
		int count = 0;

		// If the last digit is not 0, then
		// last digit must add to
		// the number of words
		if (digits[n - 1] > '0')
			count = countDecoding(digits, n - 1);

		// If the last two digits form a number
		// smaller than or equal to 26, then
		// consider last two digits and recur
		if (digits[n - 2] == '1'
			|| (digits[n - 2] == '2'
				&& digits[n - 1] < '7'))
			count += countDecoding(digits, n - 2);

		return count;
	}

// Given a digit sequence of length n,
	// returns count of possible decodings by
	// replacing 1 with A, 2 with B, ... 26 with Z
	static int countWays(char[] digits, int n)
	{
		if (n == 0 || (n == 1 && digits[0] == '0'))
			return 0;
		return countDecoding(digits, n);
	}


#endregion

#region AutoCompleteSystem
//given a query string s and a set of all possible query strings, return all strings in the set that have s as a prefix.
//For example, given the query string de and the set of strings [dog, deer, deal], return [deer, deal].
//Asked by Twitter

string s = "de";
string[] arrayStrings = {"dog","deer","deal"};
CheckTheString(s,arrayStrings);

void CheckTheString(string s, string[] arrayStrings)
{
    List<string> output = new List<string>();
    foreach(var str in arrayStrings)
    {
        if (str.StartsWith(s))
            output.Add(str);
    }

    Console.WriteLine(string.Join(",",output));
}

#endregion
