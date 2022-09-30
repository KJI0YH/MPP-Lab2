namespace Tests
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime bDay;
        public bool Degenerate = false;
        public User Parent;
        public byte Salary;
        public char Favorite;
        public decimal Atoms;
        public double Triple;
        public float Drown;
        public List<User> Friends;
        public long Height;
        public short IQ;
        private int Tst;

        public User(string name, int age, DateTime bday, bool deg, User parent, byte sal, char fav, decimal atoms, double trip, float drown, List<User> friends, long height, short iq)
        {
            Name = name;
            Age = age;
            bDay = bday;
            Degenerate = deg;
            Parent = parent;
            Salary = sal;
            Favorite = fav;
            Atoms = atoms;
            Triple = trip;
            Drown = drown;
            Friends = friends;
            Height = height;
            IQ = iq;
        }

        public User(string name, int age, bool deg)
        {
            this.Name = name;
            this.Age = age;
            this.Degenerate = deg;
        }

        private User()
        {

        }
    }

    public class MiniUser
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public bool Degenerate = false;
        private double Some;

        public MiniUser(int age, string name, bool deg)
        {
            Age = age;
            Name = name;
            Degenerate = deg;
        }
    }

    public class A
    {
        public B b { get; set; }
    }

    public class B
    {
        public C c { get; set; }
    }

    public class C
    {
        public A a { get; set; }
    }

    public class Alone
    {
        public string Name;
        public int Google;

        private Alone(string name, int google)
        {
            Name = name;
            Google = google;
        }

        private Alone()
        {

        }
    }

    public struct S1
    {
        public int KJI0YH;
        public string Name;

        public S1(int nick, string name)
        {
            KJI0YH = nick;
            Name = name;
        }
    }

    public struct S2
    {
        public int Nick;
        public string Some;
    }
}
