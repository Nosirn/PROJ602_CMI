namespace PROJ602;

public class Point {
		private double x;
		private double y;

		public Point(double xPos, double yPos){
			x = xPos;
			y = yPos;
		}

		public double getX() => x;
		public double getY() => y;

		public override string ToString() => String.Format("({0},{1})",getX(),getY());
	}