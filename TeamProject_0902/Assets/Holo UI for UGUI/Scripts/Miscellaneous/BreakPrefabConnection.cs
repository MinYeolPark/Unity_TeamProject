﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class BreakPrefabConnection : MonoBehaviour
{
	void Start()
	{		
		DestroyImmediate(this); // Remove this script
	}
}