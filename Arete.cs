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

	public override bool Equals(object? obj)
	{
		if (obj != null && obj is Arete)
		{

			// Cast
			Arete objArete = (Arete)obj;

			// Tests -----
			// On fait attention à tester le sens inverse si le sens normal n'est pas bon

			// notre p1 = obj p1
			if (p1.getX() == objArete.getP1().getX())
			{
				// On teste le reste
				if (p1.getY() == objArete.getP1().getY() && p1.getZ() == objArete.getP1().getZ() && p2.getX() == objArete.getP2().getX() && p2.getY() == objArete.getP2().getY() && p2.getZ() == objArete.getP2().getZ()) return true;
			}
			// notre p1 = obj p2 (Sens inverse)
			if (p1.getX() == objArete.getP2().getX())
			{
				// On teste le reste
				if (
					p1.getY() == objArete.getP2().getY() &&
					p1.getZ() == objArete.getP2().getZ() &&
					p2.getX() == objArete.getP1().getX() &&
					p2.getY() == objArete.getP1().getY() &&
					p2.getZ() == objArete.getP1().getZ()
				) return true;
			}

			// Les arêtes sont différentes
			return false;
		}
		// Les types sont différents
		else return false;
	}
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
