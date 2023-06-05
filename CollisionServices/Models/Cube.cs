namespace CollisionServices.Models
{
	public class Cube
	{
		public double Length { get; }
		public double X { get; }
		public double Y { get; }
		public double Z { get; }

		public Cube(double length, double x, double y, double z)
		{
			Length = length;

			X = x;
			Y = y;
			Z = z;
		}
	}
}