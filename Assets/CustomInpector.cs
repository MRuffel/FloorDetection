using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CustomInpector : Editor
{
    private  int index;
    private string[] options;
    private GameObject subs;
    Renderer renderer;

    public void OnEnable()
    {
        
    }

    public override void OnInspectorGUI()
    {

        
        subs = GameObject.Find("ListSubstance");
        options = subs.GetComponent<SurfaceSubstanceList>().GetOptionsList;

       

        index = EditorGUILayout.Popup("Substance ground 1 ", index, options);
      
        
        
        
    }
}
