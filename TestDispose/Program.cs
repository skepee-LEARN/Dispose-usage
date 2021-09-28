using System;

namespace TestDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            // myclass should implement IDisposable interface.
            // This is the best practise of programming becuse it optimizes the resources through garbage collector that uses the Dispose method.

            using (myclass c = new myclass())
            {                                       //<== Here cnt is invoked
                c.myset();                          //<== Here myset method is invoked
            }                                       //<== Here Dispose is invoked


            /*
            using (anotherclass c = new anotherclass()) //<== ERROR: anotherclass does not implements IDispoable interface.
            {
                c.myset();
            }
            */

            anotherclass x = new anotherclass();
            x.myset();
        }                                          //<== Here memory allocation anotherclass is freed (as for all the resources in Main), unless a proper destructor is implemented (which is good practise).
    }

    public class myclass:IDisposable
    { 
        public int? x { get; set; }
        public string text { get; set; }

        public myclass()
        {
            x = 0;
            text = string.Empty;
        }

        public void Dispose()
        {
            x = null;
            text = null;
            Console.WriteLine("Disposed.");
        }

        public void myset()
        {
            x = 100;
            text = "test";
            Console.WriteLine($"x={x}, text={text}");
        }
    }

    public class anotherclass
    {
        public int? x { get; set; }
        public string text { get; set; }

        public anotherclass()
        {
            x = 0;
            text = string.Empty;
        }

        public void myset()
        {
            x = 100;
            text = "test";
            Console.WriteLine($"x={x}, text={text}");
        }
    }

}
