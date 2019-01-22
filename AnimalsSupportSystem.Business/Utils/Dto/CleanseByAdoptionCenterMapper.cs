using System.Collections.Generic;

namespace AnimalsSupportSystem.Business.Utils.Dto
{
    public class CleanseByAdoptionCenterMapper
    {
        public string CleanseCenter { get; set; }
        public ICollection<int> Animals { get; set; }
    }
}