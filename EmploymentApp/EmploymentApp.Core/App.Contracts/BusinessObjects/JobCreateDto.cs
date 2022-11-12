namespace EmploymentApp.Contracts.BusinessObjects
{
    public class JobCreateDto
    {     
        public string Name { set; get; }
        public string Description { set; get; }
        public string ValidityDurationTo { set; get; }
        public string ValidityDurationFrom { set; get; }
        public int MaximumApplications { set; get; }
        public string Responsibilities { set; get; }
        public string Skills { set; get; }
        public string Category { set; get; }
    }
}
