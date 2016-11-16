using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CreateSmoothTerrain))]
public class GenerateSmoothTerrainEditor : Editor
{

    public override void OnInspectorGUI()
    {
        CreateSmoothTerrain terrainGen = (CreateSmoothTerrain)target;
        if (DrawDefaultInspector())
        {

        }
        if (GUILayout.Button("generate"))
        {
            terrainGen.Generate();
        }
    }
}
