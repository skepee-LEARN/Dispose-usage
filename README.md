# Using and Dispose in C#
Use of dispose and using in C# managed and unmanaged classes.

##  Introduction
Simple example of how using `<using>` keyword in our C# code and what is required to implement correctly in our classes.


## Let's introduce the problem
Let's suppose we have a class:

```
public class myclass
    {
        public int? x { get; set; }
        public string text { get; set; }

        public myclass()
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
```


and we want to use in our program. Let's say for example: 

```
static void Main(string[] args)
  {
      myclass x = new myclass();
      x.myset();
  }    
```
When program will finish the memory allocated will be freed by using [garbage collector](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals) mechanism.  

This is true for managed code (code managed by CLR) [(here)](https://docs.microsoft.com/en-us/dotnet/standard/managed-code) but for unmanaged code a destructor should be implemented.  


## Let's introduce `using`
The `using` statement is used to perform optimzation in memory allocation and helps to perform clean-up activities [(here)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement). Following our example, the code could be something like this:

```
  using (myclass c = new myclass()) //<== ERROR: myclass does not implements IDisposable interface.
  {
      c.myset();
  }
```
&#x1F534;
Yes, in order to use correctly `using` statement the class must implement `IDisposable` interface, and then the `Dispose()` method should be implemented. Our class then will be something like ths:

```
public class myclass:IDisposable
    {
        public int? x { get; set; }
        public string text { get; set; }

        public myclass()
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
        
        public void Dispose()
        {
            x = null;
            text = null;
            Console.WriteLine("Disposed.");
        }
    }

```
&#x1F535; Finally, our main program will be something like this:


```
    using (myclass c = new myclass())
    {                                       //<== Here cnt is invoked
        c.myset();                          //<== Here myset method is invoked
    }                                       //<== Here Dispose is invoked
```


## Release notes
Example on how to use `using` statement and use of `IDisposable` interface. More details in the project.

