namespace PROJ602;

public class Program {
	static void Main(string[] args)
	{
		
		/* Forme de test */
		/* Représente un octogone avec un carré dedans */
		const int NB_POINTS = 13;
		Point[] listePoints = new Point[NB_POINTS] {
			new Point(1.0,0.0),new Point(2.0,0.0),new Point(0.0,1.0),new Point(1.0,1.0),
			new Point(2.0,1.0),new Point(3.0,1.0),new Point(0.0,2.0),new Point(1.0,2.0),
			new Point(2.0,2.0),new Point(3.0,2.0),new Point(1.0,3.0),new Point(2.0,3.0),
			new Point(1.5,1.5)
		};
		Arete[] listeAretes = new Arete[28]{
			new Arete(listePoints[0],listePoints[1]),new Arete(listePoints[0],listePoints[4]),new Arete(listePoints[0],listePoints[3]),new Arete(listePoints[0],listePoints[2]),
			new Arete(listePoints[1],listePoints[5]),new Arete(listePoints[1],listePoints[4]),
			new Arete(listePoints[2],listePoints[3]),new Arete(listePoints[2],listePoints[7]),new Arete(listePoints[2],listePoints[6]),
			new Arete(listePoints[3],listePoints[4]),new Arete(listePoints[3],listePoints[12]),new Arete(listePoints[3],listePoints[7]),
			new Arete(listePoints[4],listePoints[5]),new Arete(listePoints[4],listePoints[9]),new Arete(listePoints[4],listePoints[8]),new Arete(listePoints[4],listePoints[12]),
			new Arete(listePoints[5],listePoints[9]),
			new Arete(listePoints[12],listePoints[8]), new Arete(listePoints[12],listePoints[7]),
			new Arete(listePoints[6],listePoints[7]),new Arete(listePoints[6],listePoints[10]),
			new Arete(listePoints[7],listePoints[8]),new Arete(listePoints[7],listePoints[11]),new Arete(listePoints[7],listePoints[10]),
			new Arete(listePoints[8],listePoints[9]),new Arete(listePoints[8],listePoints[11]),
			new Arete(listePoints[9],listePoints[11]),
			new Arete(listePoints[10],listePoints[11]),
		};
		Triangle[] listeSurfaces = new Triangle[16] {
			new Triangle(listeAretes[2],listeAretes[3],listeAretes[6]),
			new Triangle(listeAretes[1],listeAretes[2],listeAretes[9]),
			new Triangle(listeAretes[0],listeAretes[1],listeAretes[5]),
			new Triangle(listeAretes[4],listeAretes[5],listeAretes[12]),
			new Triangle(listeAretes[7],listeAretes[8],listeAretes[19]),
			new Triangle(listeAretes[6],listeAretes[7],listeAretes[11]),
			new Triangle(listeAretes[10],listeAretes[11],listeAretes[18]),
			new Triangle(listeAretes[9],listeAretes[10],listeAretes[15]),
			new Triangle(listeAretes[18],listeAretes[17],listeAretes[21]),
			new Triangle(listeAretes[14],listeAretes[15],listeAretes[17]),
			new Triangle(listeAretes[13],listeAretes[14],listeAretes[24]),
			new Triangle(listeAretes[12],listeAretes[13],listeAretes[16]),
			new Triangle(listeAretes[19],listeAretes[20],listeAretes[23]),
			new Triangle(listeAretes[22],listeAretes[23],listeAretes[27]),
			new Triangle(listeAretes[21],listeAretes[22],listeAretes[25]),
			new Triangle(listeAretes[24],listeAretes[25],listeAretes[26])
		};

		Forme2D forme = new Forme2D(listeSurfaces,listeAretes,listePoints);
		Point[] listeBords = forme.getBords();

		Matrice2D matrice = new Matrice2D(NB_POINTS,NB_POINTS);
		matrice.ajouterIdentite(listeBords.Length);
		matrice.ajouterRelationsBords(forme, listeBords);
		Console.WriteLine(matrice);
	}
}