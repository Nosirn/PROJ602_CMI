namespace PROJ602;

public class Triangle
{
	private Arete a1;
	private Arete a2;
	private Arete a3;

	public Triangle(Arete s1, Arete s2, Arete s3)
	{
		a1 = s1;
		a2 = s2;
		a3 = s3;
	}

	public Arete getA1() => a1;
	public Arete getA2() => a2;
	public Arete getA3() => a3;

	public override string ToString() => String.Format("|{0}|{1}|{2}|", getA1(), getA2(), getA3());
}

