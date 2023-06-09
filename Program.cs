namespace PROJ602;

public class Program {
	static void Main(string[] args)
	{

		Forme dé12 = new Forme("C:\\Users\\User\\Documents\\Workspace C#\\PROJ\\PROJ602_CMI\\files.obj\\dodecahedron_poly.obj");
		dé12.retirerSurface(4);

		Console.WriteLine(dé12.ToStringResume());
		
		// Problème avec les bords...
		Point[] listeBords = dé12.getBords();

		Matrice2D matrice = new Matrice2D(20,20);

		// Principe : Ajouter l'identité puis ajouter les relations bords - bords et bords - intérieur
		matrice.ajouterIdentite(listeBords.Length);
		matrice.ajouterRelationsBords(dé12, listeBords);
		Console.WriteLine(matrice);
	}
}