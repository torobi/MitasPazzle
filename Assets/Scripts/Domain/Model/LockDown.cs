namespace Domain.Model
{
    public class LockDown
    {
        private int _lockDownCount = 0;
        private const int LOCK_DOWN_LIMIT = 15;

        public bool CanRockDown()
        {
            return _lockDownCount < LOCK_DOWN_LIMIT;
        }

        public void DidRockDown()
        {
            _lockDownCount++;
        }

        public void Reset()
        {
            _lockDownCount = 0;
        }
    }
}