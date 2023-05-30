namespace PROJ602;
public class Arete
{
	private Point p1;
	private Point p2;
	public Arete(Point pA, Point pB)
	{
		p1 = pA;
		p2 = pB;
	}

	public Point getP1() => p1;
	public Point getP2() => p2;

	public override string ToString() => String.Format("[{0} --- {1}]", getP1(), getP2());
}
