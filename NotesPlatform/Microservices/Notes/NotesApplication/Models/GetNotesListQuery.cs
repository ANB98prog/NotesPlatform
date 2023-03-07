namespace NotesApplication.Models
{
    /// <summary>
    /// Query model to fetch notes
    /// </summary>
    public record GetNotesListQuery
    {
        // TO DO other query parameters

        private int _pageNumber = Constants.DEFAULT_PAGE_NUMBER;

        /// <summary>
        /// Page number
        /// </summary>
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value;

                if (_pageNumber < 0)
                {
                    _pageNumber = 0;
                }
            }
        }

        private int _pageSize = Constants.DEFAULT_PAGE_SIZE;

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
    }
}