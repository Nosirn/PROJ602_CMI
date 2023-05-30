namespace PROJ602;

public class Forme2D {
	private Point[] positions;
	private Arete[] aretes;
	private Triangle[] surfaces;

	private readonly int nbElements = 0;

	public Forme2D(Triangle[] srfc, Arete[] art, Point[] pos){
		/*  */
		surfaces = srfc;
		aretes = art;

		/* */
		positions = new Point[pos.Length];
		foreach (Point elem in pos) positions[nbElements++] = elem;
	}

	public Arete[] getAretes(Point p){
		List<Arete> res = new List<Arete>();
		foreach(Arete elem in aretes)
			if(elem.getP1().Equals(p) || elem.getP2().Equals(p)) 
				res.Add(elem);
		return res.ToArray();
	}

	public int nbTriangle(Arete a){
		int count = 0;
		foreach(Triangle elem in surfaces) 
			if(elem.getA1().Equals(a) || elem.getA2().Equals(a) || elem.getA3().Equals(a)) 
				count++;
		return count;
	}

	public Point[] getBords(){
		List<Point> res = new List<Point>();

		/* On parcours tous les points */
		foreach(Point elem in positions){
			/* On récupère les arêtes liées au point */
			Arete[] liste = getAretes(elem);

			/* On regarde combien de triangles sont associés à l'arête */
			foreach(Arete a in liste)
				/* L'arête est sur un bord ? */
				if(nbTriangle(a) == 1) {
					res.Add(elem);
					break;
				}
		}
		return res.ToArray();
	}
}