namespace PROJ602;

public class Polygone
{
	private Arete[] aretes;

	public Polygone(params Arete[] arts){
		aretes = arts;
	}

	public Arete getArete(int idx) => aretes[idx];
	public Arete[] getAretes() => aretes;

	public override string ToString(){
		string res = "| ";
		Point[] list = new Point[aretes.Length+1];
		int idx = 0;
		foreach(Arete a in aretes){
			if(!list.Contains(a.getP1())) list[idx++] = a.getP1();
			if(!list.Contains(a.getP2())) list[idx++] = a.getP2();
		}
		foreach(Point p in list){
			res += p.ToString() + " | ";
		}
		return res;
	}

	public override bool Equals(object? obj)
	{
		if (obj != null && obj is Polygone){
			// Cast
			Polygone poly = (Polygone) obj;

			// On teste s'ils ont le même nombre d'arêtes
			if(poly.getAretes().Length != aretes.Length) return false;

			// On compare les arêtes
			foreach(Arete a in poly.getAretes()){
				bool isFound = false;
				foreach(Arete arts in this.getAretes()){
					if(a.Equals(arts)) isFound = true;
				}
				if(!isFound) return false;
			}
			return true;
		} else return false;
	}
	
	public override int GetHashCode(){
		return base.GetHashCode();
	}
}

