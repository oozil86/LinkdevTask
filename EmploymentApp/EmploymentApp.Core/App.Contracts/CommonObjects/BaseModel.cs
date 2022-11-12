using System.ComponentModel.DataAnnotations;

namespace EmploymentApp.Contracts.CommonObjects
{
    public class BaseModel
    {
       
    }
    public class BaseModel<T> : BaseModel
    {
        [Key]
        public T Id { get; set; }
    }
}
