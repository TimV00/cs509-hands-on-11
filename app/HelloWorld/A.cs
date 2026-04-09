namespace HelloWorld
{
    public class A
    {
        public static int f1(int x)
        {
            x = x + 1;
            return x;
        }

        internal static int f2(int x)
        {
            x = x + 2;
            return x;
        }

        protected static int f3(int x)
        {
            x = x + 3;
            return x;
        }

        internal static int f4(int x)
        {
            x = x + 4;
            return x;
        }

        public static double f5(int x, int y)
        {
            return x / y;
        }

        public static int f6(int x)
        {
            if (x < 0)
            {
                throw new Exception("x can't be negative");
            }

            return x + 5;
        }

        public static string f7(string s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            var ss = s + " more stuff";
            return ss;
        }

        public virtual int f8(int x)
        {
            // Assume this calls a sql database such as "selct * from where something = x"
            return x + 8;
        }
    }
}