namespace LeetCode
{
    public abstract class ATest
    {
        protected abstract void RunFirst();

        protected virtual void RunSecond()
        {
            Console.WriteLine("do some action...");
            Console.WriteLine($"{nameof(ATest)}+{nameof(RunSecond)}");
        }

        public void Calculated()
        {
            Console.WriteLine(DateTime.Now.ToLongDateString());
        }
    }
    public class Parent1
    {
        protected string Level { get; set; }

        protected string GetLevel()
        {
            return Level;
        }
    }

    public class Parent2 : Parent1
    {
        protected string Level2 { get; set; }
        protected string GetLevel2()
        {
            return Level2;
        }
    }

    public class MyTest : ATest, ITest, IBasicTest
    {
        public string MyName
        {
            get
            {
                if (_myName is null) return DateTime.Now.ToString("dd/MMMM/yyyyy hh:mm:ss.ffffff");
                return _myName;
            }

            set { _myName = DateTime.Now.ToString("dd/MMMM/yyyyy hh:mm:ss.ffffff"); }
        }

        private string _myName;

        public MyTest()
        {
        }

        public void Run()
        {
            RunFirst();

            Console.WriteLine("waiting...");
            RunSecond();
            Calculated();
            Console.WriteLine("tell me my name:");
            TellMeMyName();
        }

        public string TellMeMyName()
        {
            Console.WriteLine(MyName);
            return MyName;
        }

        protected override void RunFirst()
        {
            //this.RunSecond();
            Console.WriteLine($"{nameof(MyTest)}+{nameof(RunFirst)}");
        }

        protected override void RunSecond()
        {
            Console.WriteLine($"{nameof(MyTest)}+{nameof(RunSecond)}");

            base.RunSecond();
        }
    }

    public interface ITest
    {
        public string MyName { get; set; }

        string TellMeMyName();
    }

    public interface IBasicTest
    {
        public string MyName { get; set; }

        string TellMeMyName();
    }

    public class Child : Parent2
    {
        public Child()
        {
            Level = "a";
            Level2 = "b";
        }
        public void Test()
        {           
            Console.WriteLine(GetLevel2());
            Console.WriteLine(GetLevel());
        }
    }
}