namespace PROJ602;

public class Program {
	static void Main(string[] args)
	{

		Forme tet = new Forme("C:\\Users\\User\\Documents\\Workspace C#\\PROJ\\PROJ602_CMI\\files.obj\\tet.obj");
		// Forme copy = dé12;
		// tet.retirerSurface(1);
		Console.WriteLine(tet.ToString());

		
		// Problème avec les bords...
		Point[] listeBords = tet.getBords();

		// Bords
		// Console.WriteLine("\r\nBords =============");
		// foreach(Point p in listeBords){
		// 	Console.WriteLine(p.ToString());
		// }


		// Matrice2D matrice = new Matrice2D(4,4);

		// // Principe : Ajouter l'identité puis ajouter les relations bords - bords et bords - intérieur
		// matrice.ajouterIdentite(listeBords.Length);
		// matrice.ajouterRelationsBords(dé12, listeBords);
		// Console.WriteLine(matrice);
	}
}