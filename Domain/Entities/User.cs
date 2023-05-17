using Domain.Common;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            Allergies = new HashSet<Allergy>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Allergy> Allergies { get; set; }
    }
}
