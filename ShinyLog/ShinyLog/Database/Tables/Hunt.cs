using SQLite;

namespace ShinyLog.Database.Tables
{
    [Table("Hunt")]
    public class Hunt
    {
        [PrimaryKey, AutoIncrement]
        public int HuntId { get; set; }

        [NotNull]
        public required string HuntName { get; set; }

        [NotNull]
        public int Attempts { get; set; } = 0;
    }
}
