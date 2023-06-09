namespace PROJ602;

public class Point {
		private double x;
		private double y;
		private double z;

		public Point(double xPos, double yPos, double zPos){
			x = xPos;
			y = yPos;
			z = zPos;
		}

		public double getX() => x;
		public double getY() => y;
		public double getZ() => z;

		public override string ToString() => String.Format("({0}, {1}, {2})",getX(),getY(),getZ());
	}