using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class SurfaceSubstanceList : MonoBehaviour

    {
        [SerializeField]
        private string[] options = { "Wood", "Grass" };

        private static int storedIndex;
        public string[] GetOptionsList { get { return options; } }
        public int GetIndex { get { return storedIndex; } }
        public int SetIndex { set { storedIndex = value; } }

    }
// change the array for a list and implement a button + string to add into the list it self so need to go in the script to change it