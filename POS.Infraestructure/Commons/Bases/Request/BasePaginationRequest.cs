namespace POS.Infraestructure.Commons.Bases.Request
{
    public class BasePaginationRequest
    {
        private readonly int _numMaxRecordsPage = 50;

        public int NumPage { get; set; } = 1;
        public int NumRecordsPerPage { get; set; } = 10;
        public string Order { get; set; } = "asc";
        public string? Sort { get; set; } = null;

        public int Records
        {
            get => NumRecordsPerPage;
            set
            {
                NumRecordsPerPage = (value > _numMaxRecordsPage) ? _numMaxRecordsPage : value;
            }
        }
    }
}
