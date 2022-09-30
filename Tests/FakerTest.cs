using Faker.Core;
using Faker.Interfaces;
using System.Collections;

namespace Tests
{
    public class Tests
    {
        private IFaker _faker;

        [SetUp]
        public void Setup()
        {
            _faker = new Faker.Core.Faker();
        }

        [Test]
        [TestCase(typeof(bool))]
        [TestCase(typeof(byte))]
        [TestCase(typeof(char))]
        [TestCase(typeof(DateTime))]
        [TestCase(typeof(decimal))]
        [TestCase(typeof(double))]
        [TestCase(typeof(float))]
        [TestCase(typeof(int))]
        [TestCase(typeof(List<int>))]
        [TestCase(typeof(long))]
        [TestCase(typeof(string))]
        [TestCase(typeof(short))]
        public void CreateSimpleType(Type type)
        {
            Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(type), _faker.Create(type)));
        }

        [Test]
        public void CreateCustomType()
        {
            MiniUser mu = _faker.Create<MiniUser>();
            Assert.Multiple(() =>
            {
                Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(mu.Age.GetType()), mu.Age));
                Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(mu.Name.GetType()), mu.Name));
                Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(mu.Degenerate.GetType()), mu.Degenerate));
            });
        }

        [Test]
        public void CreateCycleDependency()
        {
            Assert.DoesNotThrow(() => _faker.Create<A>());
        }

        [Test]
        public void CheckCycleDependency()
        {
            A a = _faker.Create<A>();
            Assert.Multiple(() =>
            {
                Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(a.b.GetType()), a.b));
                Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(a.b.c.GetType()), a.b.c));
                Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(a.b.c.a.GetType()), a.b.c.a));
            });
        }

        [Test]
        public void WithoutPublicConstructor()
        {
            Assert.Catch<FakerException>(() =>
            {
                Alone alone = _faker.Create<Alone>();
            });
        }

        [Test]
        public void CreateStructCtor()
        {
            S1 s1 = _faker.Create<S1>();

            Assert.Multiple(() =>
            {
                Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(s1.KJI0YH.GetType()), s1.KJI0YH));
                Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(s1.Name.GetType()), s1.Name));
            });
        }

        [Test]
        public void CreateStructNoCtor()
        {
            S2 s2 = _faker.Create<S2>();

            Assert.Multiple(() =>
            {
                Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(s2.Nick.GetType()), s2.Nick));
                Assert.IsFalse(Equals(ObjectInitor.GetDefaultValue(s2.Some.GetType()), s2.Some));
            });
        }

        [Test]
        public void CreateSimpleList()
        {
            List<int> list = _faker.Create<List<int>>();
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(list);
                Assert.NotZero(list.Count);
                Assert.IsTrue(list.Where(x => x == 0).Count() == 0);
            });
        }

        [Test]
        [TestCase(typeof(List<List<User>>))]
        [TestCase(typeof(List<List<int>>))]
        public void CreateCustomList(Type type)
        {
            var list = (IList)_faker.Create(type);

            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(list);
                Assert.IsNotEmpty((IList)list[0]);
            });
        }
    }
}