/* Snippet rowcounter
 * Counts the rows of a DataView
 */
 
public int CaoRows()
{
	m_intCaoRows = myConCao.dvCao.Count - 1;	
}



public class Ctoolbox
{
	public Ctoolbox()
	
	
     /// <summary>
     /// Splits a given String and givs back the Result as String[]</summary>
     /// <param name="foo"> Parameter description for s goes here</param>
	public string[] VornameNachname(string name)
    {
        string[] result;
        result = name.Split();
        return result;
    }
}

/* Using VornameNachname */
string[] sh00p;
CToolbox myToolbox = new CToolbox();
sh00p = myToolbox.VornameNachname("Hans Meier");   




