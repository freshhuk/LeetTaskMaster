namespace LeetTaskMaster.TaskServices
{
    public class FibonacciNumbers
    {
        public bool IsFabonacci(int num)
        {
            int nextNum = 0;
            int i = 1;
            List<int> Fibonacci_numbers = new List<int>() { 0, 1};
            while (nextNum <= num)
            {
                
                nextNum = Fibonacci_numbers[i--] + Fibonacci_numbers[i];
                Fibonacci_numbers.Add(nextNum);
                i++;
                if(nextNum == num) 
                {
                    //its fabonacci
                    return true;
                }
               
            }
            return false;



        }
    }
}
