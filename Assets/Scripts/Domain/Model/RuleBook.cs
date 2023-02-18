namespace Domain.Model
{
    public class RuleBook
    {
        private int _currentPage = 0;
        private const int PAGE_NUM = 2; 

        public int currentPage => _currentPage;
        
        public void OpenPage(int pageNum)
        {
            if (CanOpen(pageNum))
                _currentPage = pageNum;
        }

        public void OpenNextPage()
        {
            if (CanOpenNextPage())
                _currentPage++;
        }

        public void OpenPrevPage()
        {
            if (CanOpenPrevPage())
                _currentPage--;
        }
        
        public bool CanOpen(int pageNum)
        {
            return pageNum is >= 0 and < PAGE_NUM;
        }

        public bool CanOpenNextPage()
        {
            return CanOpen(_currentPage + 1);
        }

        public bool CanOpenPrevPage()
        {
            return CanOpen(_currentPage - 1);
        }
    }
}