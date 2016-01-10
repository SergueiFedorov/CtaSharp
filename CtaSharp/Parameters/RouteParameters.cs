namespace CtaSharp.Parameters
{
    public enum EnumTrainRoute 
	{
		NotDetermined,
		Red,
        Blue,
        Brown,
        Purple,
        Green,
        Orange,
        Pink,
        Yellow
    }
    public class RouteParameters
    {
        public EnumTrainRoute Route { get; set; }
    }
}
