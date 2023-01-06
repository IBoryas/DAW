namespace DAW.Common.DTOs.Project
{
    public class UpdateProjectDto
    {
        public string Description { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
