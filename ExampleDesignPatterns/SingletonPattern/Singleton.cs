namespace SingletonPattern;

//Lets make it perfect, short, thread-safe and LAZY

public class Singleton
{
    public DateTime CreatedAt { get; }

    private Singleton() => CreatedAt = DateTime.Now;

    private static readonly Lazy<Singleton> Lazy = new(() => new Singleton());

    public static Singleton GetInstance() => Lazy.Value;
}

//Almost perfect, thanks to evolution of C# and 
//relatively new features
//public class Singleton
//{
//    private static readonly Singleton Instance = new Singleton();

//    public DateTime CreatedAt { get; }

//    private Singleton() => CreatedAt = DateTime.Now;

//    public static Singleton GetInstance() => Instance;
//}

//This is now good, but look, how much code we produced
//for this simple pattern, and complex issues and nuances 
//we needed to take care
//public class Singleton
//{
//    private volatile static Singleton _instance;
//    private static object _dummy = new object();

//    public DateTime CreatedAt { get; }

//    private Singleton() => CreatedAt = DateTime.Now;


//    //Thread safe but not optimal - locking is costly
//    public static Singleton GetInstance() //it is not thread-safe
//    {
//        if (_instance != null)
//            return _instance;

//        lock(_dummy)
//        {
//            if (_instance == null)
//                _instance = new Singleton();
//        }

//        return _instance;
//    }
//}


//BETTER - THREAD SAFE, BUT NOT OPTIMAL
//public class Singleton
//{
//    private static Singleton _instance;
//    private static object _dummy = new object();

//    public DateTime CreatedAt { get; }

//    private Singleton() => CreatedAt = DateTime.Now;


//    //Thread safe but not optimal - locking is costly
//    public static Singleton GetInstance() //it is not thread-safe
//    {
//        lock (_dummy)
//        {
//            if (_instance == null)
//                _instance = new Singleton();
//        }


//        return _instance;
//    }
//}



//IT IS NOT THREAD SAFE - SO YOU SHOULDN'T USE IT 
//IN MULTITHREADED APPLICATION
//public class Singleton
//{
//    private static Singleton _instance;

//    public DateTime CreatedAt { get; }

//    private Singleton() => CreatedAt = DateTime.Now;

//    public static Singleton GetInstance() //it is not thread-safe
//    {
//        if (_instance == null)
//            _instance = new Singleton();

//        return _instance;
//    }
//}