namespace LeetCode._75Questions.Week1
{
    public class _232ImplementQueueUsingStacks
    {
    }

    public class MyQueue
    {
        private Stack<int> _mainContents { get; set; }

        public MyQueue()
        {
            _mainContents = new Stack<int>();
        }

        public void Push(int x)
        {
            _mainContents.Push(x);
        }

        public int Pop()
        {
            var _tempContents = new Stack<int>();

            while (_mainContents.Count > 0)
            {
                _tempContents.Push(_mainContents.Pop());
            }

            var result = _tempContents.Pop();
            while (_tempContents.Count > 0)
            {
                _mainContents.Push(_tempContents.Pop());
            }
            return result;
        }

        public int Peek()
        {
            var _tempContents = new Stack<int>();

            while (_mainContents.Count > 0)
            {
                _tempContents.Push(_mainContents.Pop());
            }

            var result = _tempContents.Peek();
            while (_tempContents.Count > 0)
            {
                _mainContents.Push(_tempContents.Pop());
            }
            return result;
        }

        public bool Empty()
        {
            return _mainContents.Count == 0;
        }
    }
}