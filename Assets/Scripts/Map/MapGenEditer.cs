using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(MapGenerator))]
public class MapGenEditer : Editor
{
     public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            MapGenerator myGenerator = (MapGenerator)target;
            if(GUILayout.Button("버튼을 눌러 주시겠습니까?"))
            {
                myGenerator.BuildGenerator();
            }
        }
}
