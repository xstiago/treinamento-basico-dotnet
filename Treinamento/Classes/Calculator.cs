namespace Treinamento.Classes
{
    public static class Calculator
    {
        public static int Sum(int number1, int number2)
        {
            return number1 + number2;
        }

        public static int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        public static int Multiply(int number1, int number2)
            => number1 * number2;

        public static int Division(int number1, int number2)
            => number1 / number2;
    }
}
