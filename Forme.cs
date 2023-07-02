namespace PROJ602;

using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

public class Forme
{
	#region Class attributes
	private Point[] positions;
	private Arete[] aretes;
	private Polygone[] surfaces;

	public Point[] Positions { get => positions; set => positions = value; }
	public Arete[] Aretes { get => aretes; set => aretes = value; }
	public Polygone[] Surfaces { get => surfaces; set => surfaces = value; }
	#endregion

	#region Constructor
	public Forme(string path)
	{
		string? line;
		List<Point> pointsList = new List<Point>();
		List<Arete> aretesList = new List<Arete>();
		List<Polygone> surfacesList = new List<Polygone>();
		try
		{
			// On donne le nom du fichier et son chemin au lecteur de flux / "fichier"
			StreamReader sr = new StreamReader(path);

			// Lecture de la première ligne
			line = sr.ReadLine();

			// On lit chaque ligne tant qu'elle n'est pas vide
			while (line != null)
			{
				string[] split = line.Split(" ");
				switch (split[0])
				{
					case "v":
						addPointObj(ref pointsList, split[1..]);
						break;
					case "f":
						addEdgesAndSurfaces(pointsList, ref aretesList, ref surfacesList, split[1..]);
						break;
				}
				line = sr.ReadLine();
			}
			//close the file
			sr.Close();
		}
		// Cas où le ficher n'existe pas (Chemin incorrect)
		catch (Exception e)
		{
			Console.WriteLine("Exception: " + e.Message);
		}

		Console.WriteLine("===== SURFACES =====");
		foreach (var item in surfacesList)
		{
			Console.WriteLine(item);
		}
		Console.WriteLine("====================");
		Console.WriteLine();
		Console.WriteLine("====== ARETES ======");
		foreach (var item in aretesList)
		{
			Console.WriteLine(item);
		}
		Console.WriteLine("====================");
		Console.WriteLine();
		Console.WriteLine("====== POINTS ======");
		foreach (var item in pointsList)
		{
			Console.WriteLine(item);
		}
		Console.WriteLine("====================");
		Console.WriteLine();

		/* Affectations */
		surfaces = surfacesList.ToArray();
		aretes = aretesList.ToArray();
		positions = pointsList.ToArray();
	}
	#endregion

	#region Class methods
	public void retirerSurface(Polygone p)
	{
		retirerSurface(Array.FindIndex(surfaces, item => item.Equals(p)));
	}
	public void retirerSurface(int idx)
	{
		if (idx >= 0 && idx < surfaces.Length)
		{
			for (int i = idx; i < surfaces.Length - 1; i++)
			{
				surfaces[i] = surfaces[i + 1];
			}
			Array.Resize(ref surfaces, surfaces.Length - 1);
		}

	}
	#endregion

	#region .obj
	private void addPointObj(ref List<Point> list, string[] points)
	{
		var format = new NumberFormatInfo();
		format.NegativeSign = "-";
		format.NumberDecimalSeparator = ".";

		NumberStyles style = NumberStyles.AllowExponent | NumberStyles.Float | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;

		// Notation scientifique
		if (points[0].Contains('e'))
		{
			list.Add(
				new Point(
					double.Parse(points[0].ToUpper(), style, CultureInfo.InvariantCulture),
					double.Parse(points[1].ToUpper(), style, CultureInfo.InvariantCulture),
					double.Parse(points[2].ToUpper(), style, CultureInfo.InvariantCulture)
				)
			);
		}
		// Notation classique
		else
		{
			list.Add(
				new Point(
					Convert.ToDouble(points[0].ToUpper(), format),
					Convert.ToDouble(points[1].ToUpper(), format),
					Convert.ToDouble(points[2].ToUpper(), format)
				)
			);
		}
	}
	private void addEdgesAndSurfaces(List<Point> listPts, ref List<Arete> listA, ref List<Polygone> listP, string[] faces)
	{
		// On souhaite ajouter les arêtes et faces (surfaces)
		// Pour cela, on va chercher les points dans chaque face
		// On crée la liste de points
		int[] listPoints = new int[faces.Length];

		// Insérer à l'index n le point trouvé
		int nbPoints = 0;

		// Notation point/normale/texture (ex : 1/2/3 2/3/4 3/4/5)
		if (Regex.IsMatch(faces[0], "^[0-9]*/"))
			foreach (string point in faces)
				// On récupère l'index du point qui se trouve au début de chaque séquence [a]/b/c
				listPoints[nbPoints++] = Convert.ToInt32(point.Split("/")[0]);
		
		// Notation point uniquement (ex : 1 2 3)
		else
			foreach (string point in faces)
				// On récupère directement l'index du point
				listPoints[nbPoints++] = Convert.ToInt32(point);

		List<Arete> listAretes = new List<Arete>();

		// n points = n arêtes
		// Les .obj numérotent les index à partir de 1, donc on soustrait 1 à l'index
		for (int i = 0; i < nbPoints; i++)
		{
			if(i == nbPoints - 1){
				listAretes.Add(
					new Arete(
						listPts.ElementAt(listPoints[i] - 1),
						listPts.ElementAt(listPoints[0] - 1)
					)
				);
			} else
			listAretes.Add(
				new Arete(
					listPts.ElementAt(listPoints[i] - 1),
					listPts.ElementAt(listPoints[i+1] - 1)
				)
			);
		}

		// Ajout des arêtes dans le polygone
		foreach (Arete a in listAretes)
		{
			if (!listA.Contains(a)) {
				listA.Add(a);
			}
		}

		Console.WriteLine("_____ DEBUG _____");
		listA.ForEach(arete => Console.WriteLine(arete));
		Console.WriteLine("_________________");

		// Ajout d'un polygone dans la liste
		listP.Add(new Polygone(listAretes.ToArray()));
	}
	#endregion

	#region Useful for Matrice class
	public Arete[] getAretes(Point p)
	{
		List<Arete> res = new List<Arete>();
		foreach (Arete elem in aretes)
			if (elem.getP1().Equals(p) || elem.getP2().Equals(p))
				res.Add(elem);
		return res.ToArray();
	}

	public int nbPolygones(Arete a)
	{
		int count = 0;
		foreach (Polygone elem in surfaces)
		{
			foreach (Arete aE in elem.getAretes()){
				if (aE.Equals(a))
				{
					count++;
					break;
				}
			}
		}
		return count;
	}

	public Point[] getBords()
	{
		List<Point> res = new List<Point>();

		/* On parcours tous les points */
		foreach (Point elem in positions)
		{
			/* On récupère les arêtes liées au point */
			Arete[] liste = getAretes(elem);

			/* On regarde combien de triangles sont associés à l'arête */
			foreach (Arete a in liste){
				/* L'arête est sur un bord ? */
				if (nbPolygones(a) == 1)
				{
					res.Add(elem);
					break;
				}
			}
		}
		return res.ToArray();
	}
	#endregion

	#region ToString
	public override string ToString()
	{
		string res = ToStringResume();
		res += "\r\n\r\n";
		res += "Liste des points : \r\n";
		foreach (Point p in positions)
		{
			res += p.ToString() + "\r\n";
		}
		res += "\r\nListe des arêtes : \r\n";
		foreach (Arete a in aretes)
		{
			res += a.ToString() + "\r\n";
		}
		res += "\r\nListe des surfaces : \r\n";
		foreach (Polygone p in surfaces)
		{
			res += p.ToString() + "\r\n";
		}
		res += "\r\n--------------------------------";
		return res;
	}
	public string ToStringResume()
	{
		string res = "Forme ==========================\r\n";
		res += "Nombre de points : " + positions.Count() + "\r\n";
		res += "Nombre d'arêtes : " + aretes.Count() + "\r\n";
		res += "Nombre de polygones : " + surfaces.Count() + "\r\n";
		res += "================================";
		return res;
	}
	#endregion
}