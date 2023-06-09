namespace PROJ602;

public class Matrice2D {
	#region Class attributes
	private readonly int NB_COLONNES;
	private readonly int NB_LIGNES;
	private double[,] data;
	#endregion
	#region Constructors
	public Matrice2D(int nbLignes, int nbColonnes){
		NB_COLONNES = nbColonnes;
		NB_LIGNES = nbLignes;
		data = new double[getRowCount(),getColumnCount()];
	}
	#endregion
	#region Class methods
	public void ajouterIdentite(int nbbords){
		/* Matrice identité sur les bords*/
		for(int i = 0; i < nbbords; i++){
			set(i,i,1.0);
		}
	}
	public void ajouterRelationsBords(Forme forme, Point[] bords){
		/* TODO */
	}
	#endregion
	#region Getters
	public double get(int indexLigne, int indexColonne) => data[indexLigne, indexColonne];
	public double[] getRowContent(int index){
		if(0 <= index && index < getRowCount()){
			double[] res = new double[getRowCount()];
			for(int i = 0; i < getRowCount();i++) res[i] += data[i,index];
			return res;
		} else {
			throw new IndexOutOfRangeException("getRowContent : L'index doit être entre 0 et " + (getRowCount() - 1));
		}
	}
	public double[] getColumnContent(int index){
		if(0 <= index && index < getColumnCount()){
			double[] res = new double[getColumnCount()];
			for(int i = 0; i < getColumnCount();i++) res[i] += data[i,index];
			return res;
		} else {
			throw new IndexOutOfRangeException("getColumnContent : L'index doit être entre 0 et " + (getColumnCount() - 1));
		}
	}
	public int getRowCount() => NB_LIGNES;
	public int getColumnCount() => NB_COLONNES;
	#endregion
	#region Setters
	public void set(int indexColonne, int indexLigne, double value) => data[indexLigne, indexColonne] = value;
	#endregion
	#region ToString
	public override string ToString(){
		string res = "╔" + string.Join("", Enumerable.Repeat("════╦",getColumnCount() - 1)) + "════╗\r\n";
		for(int ligne = 0; ligne < getRowCount(); ligne++){
			res += "║";
			for(int colonne = 0; colonne < getColumnCount(); colonne++){
				res += data[ligne,colonne].ToString("00.0") + "║";
			}
			res += "\r\n"; 
			if(ligne != getRowCount() - 1) res += "╠" + string.Join("", Enumerable.Repeat("════╬",getColumnCount() - 1)) + "════╣\r\n";
			else res += "╚" + string.Join("", Enumerable.Repeat("════╩",getColumnCount() - 1)) + "════╝";
		}
		return res;
	}
	#endregion
}