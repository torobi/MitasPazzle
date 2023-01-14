namespace Domain.Model
{
    public class Trash
    {
        private const int CoolTimeTurn = 3;
        private int _remainTime = 0; // 0でTrash可能
        private bool _canTrash = true;

        public void ReduceRemain()
        {
            if (_canTrash) return;

            _remainTime -= 1;
            if (_remainTime <= 0)
            {
                _canTrash = true;
            }
        }

        public void TrashMino()
        {
            _canTrash = false;
            _remainTime = CoolTimeTurn;
        }

        public float Remain()
        {
            return (float)_remainTime / CoolTimeTurn;
        }
    }
}