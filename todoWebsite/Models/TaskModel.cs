namespace todoWebsite.Models
{
    public class TaskModel
    {
        public int idtasks { get; set; }
        public string? task { get; set; }
        public DateTime dateCreated { get; set; }
        public byte completed { get; set; }

    }
}
