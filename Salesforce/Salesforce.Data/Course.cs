using System;

namespace Salesforce.Data
{
    public class Course // POCO -> Plain Old CLR Object
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Fees { get; set; }
        public DateTime StartDate { get; set; }
    }
}
