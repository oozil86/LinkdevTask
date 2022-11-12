using EmploymentApp.Contracts.Enums;

namespace EmploymentApp.Contracts.CommonObjects
{
    public class CommonResponse<T> 
    {
        public EnumResponseResult Result { set; get; }
        public T Data { set; get; }
        public List<string> Errors { set; get; }
    }
}
