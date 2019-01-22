using System.Collections.Generic;


namespace AnimalsSupportSystem.Business.Utils.Dto
{
    public class CleanseAssignmentMapper
    {
        public string CleanseCenter { get; set; }
        public ICollection<int> Animals { get; set; }
    }
}