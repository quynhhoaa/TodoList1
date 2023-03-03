namespace ToDoList.DTOs
{
    public class FilterRequest
    {
        public int? Status { get; set; }
        public DateTime? Day { get; set; }
    }
}
