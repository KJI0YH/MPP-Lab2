namespace Core.Core
{
    public class CyclicChecker
    {
        private Dictionary<Type, int> _nestingLevel;
        private static int _maxNesting = 3;

        public CyclicChecker()
        {
            _nestingLevel = new Dictionary<Type, int>();
        }

        public bool IsCyclic(Type type)
        {
            if (_nestingLevel.ContainsKey(type))
            {
                _nestingLevel[type]++;
            }
            else
            {
                _nestingLevel.Add(type, 0);
            }

            if (_nestingLevel[type] >= _maxNesting)
                return true;
            else
                return false;
        }

        public void DeleteFromCycle(Type type)
        {
            if (_nestingLevel.ContainsKey(type))
            {
                _nestingLevel[type]--;
                if (_nestingLevel[type] <= 0)
                {
                    _nestingLevel.Remove(type);
                }
            }
        }
    }
}
