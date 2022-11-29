using UnityEditor;
using UnityEngine;
using System.Collections;
using System;
[Serializable]
public class CustomMaterialShaderGUI : ShaderGUI
{

    private GameObject subs;
 

    
    private  static int index;
    private int storedIndex; 
    private string[] options;


    SerializedProperty property;
  public SurfaceSubstanceList surfaceSubstanceList;

    void OnEnable()
    {

       
        
        

    }

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] materialProperty)
    {


        subs = GameObject.Find("ListSubstance");
        options = subs.GetComponent<SurfaceSubstanceList>().GetOptionsList;

        index = EditorGUILayout.Popup("Substance ground  ", index, options); 

        base.OnGUI(materialEditor, materialProperty);

    }


    

    public void Init()
    {
        //  myMat = (MyMaterials)EditorGUILayout.EnumPopup("Primitive to create:", myMat);
       

    }

    public int GetIndex { get { return index; } }
    public int SetInt { set { index = value; } }
}

    