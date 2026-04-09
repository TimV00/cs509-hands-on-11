namespace HelloWorld
{
    public class HelloWorld
    {
        public static void Main(string[] args)
        {

            var v1 = A.f1(1);
            var v2 = A.f2(2);
            var v5 = A.f5(5, 2);
            var v6 = A.f6(3);
            var v7 = A.f7("hello");
            var a = new A();
            var v8 = B.g1(1, a);
        }
    }
}