using System;
using CtaSharp.Enums;

namespace CtaSharp
{
	public class RouteHelper
	{
		internal static string GetTrainRouteString(EnumTrainRoute route)
		{
			switch (route)
			{
			case EnumTrainRoute.Red:
				return "Red";
			case EnumTrainRoute.Blue:
				return "Blue";
			case EnumTrainRoute.Brown:
				return "Brn";
			case EnumTrainRoute.Purple:
				return "P";
			case EnumTrainRoute.Green:
				return "G";
			case EnumTrainRoute.Orange:
				return "Org";
			case EnumTrainRoute.Pink:
				return "Pink";
			case EnumTrainRoute.Yellow:
				return "Y";
			default:
				throw new Exception("Cannot determine train route by enum");
			}
		}

		internal static EnumTrainRoute GetTrainRouteEnum(string name)
		{
			switch (name.ToLower()) 
			{
			case "red":
				return EnumTrainRoute.Red;
			case "blue":
				return EnumTrainRoute.Blue;
			case "brn":
				return EnumTrainRoute.Brown;
			case "p":
				return EnumTrainRoute.Purple;
			case "g":
				return EnumTrainRoute.Green;
			case "org":
				return EnumTrainRoute.Orange;
			case "pink":
				return EnumTrainRoute.Pink;
			case "y":
				return EnumTrainRoute.Yellow;
			default:
				throw new Exception ("Cannot determine train route by string");
			}
		}
	}
}

