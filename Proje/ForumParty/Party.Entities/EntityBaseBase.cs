namespace Party.Entities
{
    public class EntityBaseBase
    {
        public int ID { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedUserName { get; set; }
    }
}