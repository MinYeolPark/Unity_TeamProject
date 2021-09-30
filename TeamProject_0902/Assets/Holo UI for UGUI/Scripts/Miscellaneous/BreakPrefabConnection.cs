using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class BreakPrefabConnection : MonoBehaviour
{
	void Start()
	{
		#if UNITY_EDITOR
		PrefabUtility.GetPropertyModifications(gameObject);
		#endif
		DestroyImmediate(this); // Remove this script
	}
}