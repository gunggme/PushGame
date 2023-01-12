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
            if(GUILayout.Button("��ư�� ���� �ֽðڽ��ϱ�?"))
            {
                myGenerator.BuildGenerator();
            }
        }
}
