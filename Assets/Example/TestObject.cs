using UnityEngine;

// Example of the automatic script to prefab generation
// Remove the comment to make it implement IAutomatic, and on the next reload
// (when Unity recompiles or when you hit play) a new prefab object
// containing this class will appear in your Resources/AutomaticPrefabs folder

public class TestObject : MonoBehaviour//, AutomaticPrefabs.IAutomatic
{
	public Color color = Color.red;
}
