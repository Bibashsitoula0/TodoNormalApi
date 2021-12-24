namespace ApiTodo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TodoDate { get; set; }=DateTime.Now;
        public string Discription { get; set; }
        
    }
}