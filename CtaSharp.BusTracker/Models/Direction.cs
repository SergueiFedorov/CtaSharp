namespace CtaSharp.BusTracker.Models
{
    public enum DirectionEnum { Error = 0, North, West, East, South  }

    /// Class wrapped around an enum to allow partial classes and inheritence if necessary
    public class Direction
    {
        public DirectionEnum DirectionSpecification { get; set; }
    }
}
