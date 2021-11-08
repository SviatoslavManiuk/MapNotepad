using SQLite;

namespace MapNotepad.Model
{
    [Table("Pin")]
    public class PinModel: IEntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public string Label { get; set; }
        
        public string Description { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
        
        public bool IsSelected { get; set; }
    }
}