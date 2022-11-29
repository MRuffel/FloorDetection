using UnityEditor;
using UnityEngine;

public class MyWindow : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    Material material;
    int numberOfMaterials = 1;
    enum MyMaterials {Wood,Metal,Sand };
    MyMaterials myMat;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Tools/Material Editor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        MyWindow window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
        window.Show();
    }

    void OnGUI()
    {

        
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        numberOfMaterials = EditorGUILayout.IntField("Number of Materials", numberOfMaterials);
        myString = EditorGUILayout.TextField("Text Field", myString);
        myMat = (MyMaterials)EditorGUILayout.EnumPopup("Primitive to create:", myMat);
        groupEnabled = EditorGUILayout.BeginFoldoutHeaderGroup(false,"Optional Settings");
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        
        Material[] materials = new Material[numberOfMaterials] ;
        for (int i = 0; i < numberOfMaterials; i++) {
            materials[i]= EditorGUILayout.ObjectField("List of Material", material, typeof(Material), false) as Material;
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
    }
}
