namespace GamzeNurDemir_Hafta1.Models
{
    public class UserUpdateRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
