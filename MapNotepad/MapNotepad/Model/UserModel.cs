using SQLite;

namespace MapNotepad.Model
{
    [Table("User")]
    public class UserModel: IEntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}