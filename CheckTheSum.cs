// See https://aka.ms/new-console-template for more information

//Given a list of numbers and a number k, return wheter any two numbers from the list add up to k
//ES: given [10,15,3,7] and k=17, return true because 10+7 is 17
//Asked by Google

int [] array = {10,15,3,7};
int target = 10;
CheckTheSum(array,target);

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
