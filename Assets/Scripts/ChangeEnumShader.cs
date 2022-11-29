using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnumShader : MonoBehaviour
{

    public Renderer rend;
    [SerializeField]
    private int _enum;
    // Start is called before the first frame update
    void Start()
    {
    /*    rend = GetComponent<Renderer>();
       
        rend.material.GetInteger("_Subs");
        Debug.Log(rend.material.GetType());*/
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
