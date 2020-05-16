namespace planningpoker.TOs
{
    public class TaskCreateTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Estimation { get; set; }
        
        public string AssignedUserId { get; set; }
        public string ProjectID { get; set; }
    }
}