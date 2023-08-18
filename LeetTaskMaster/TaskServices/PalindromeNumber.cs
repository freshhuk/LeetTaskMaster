namespace LeetTaskMaster.TaskServices
{
    public class PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            // `n` сохраняет заданное целое число
            int n = x;

            // `rev` хранит обратную сторону заданного целого числа
            int rev = 0;

            while (n > 0)
            {
                // это сохранит последнюю цифру `n` в переменной `r`
                // например, если `n` равно 1234, то `r` будет равно 4
                int r = n % 10;

                // добавляем `r` к `rev` вместо себя
                // например, если `rev = 65` и `r = 4`, то новый `rev` будет 654
                rev = rev * 10 + r;

                // удалить последнюю цифру из `n`
                // например, если `n` равно 1234, то новое `n` будет 123
                n = n / 10;
            }
            return (x == rev);
        }
    }
}
