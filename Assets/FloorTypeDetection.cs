using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class FloorTypeDetection : MonoBehaviour
{
    [Tooltip("What layers the character uses as ground")]
    public LayerMask GroundLayers;
    private CharacterController _controller;
    Renderer material;
    private RaycastHit hit;
    [SerializeField]
    private float detectionLength;
    private int indexInt;
    private string[] options;
    private StarterAssetsInputs input;
    private ThirdPersonController thirdPCAudioClip;
    string ressourcesString;
    private List<AudioClip> footStepSounds;
    AudioClip jumpSound;
    
    Object[] resoucesFootStepSounds;
    [SerializeField]
    Object[] resoucesJumpSounds;
    string lastEntrie = "";
 

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = this.gameObject.GetComponent<ThirdPersonController>().JumpAudioClip;
       // footStepSounds = GetComponent<ThirdPersonController>().FootstepAudioClips;
        _controller = GetComponent<CharacterController>();
        input = _controller.GetComponent<StarterAssetsInputs>();
        Renderer material = new Renderer();
        options = GameObject.Find("ListSubstance").GetComponent<SurfaceSubstanceList>().GetOptionsList;
        footStepSounds = this.gameObject.GetComponent<ThirdPersonController>().FootstepAudioClips;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (input.move != Vector2.zero || input.jump)
        {

            CheckForInput();

        }
    }

    public void CheckForInput()
    {
        
        bool isTypeFloorChanged = false;
        
            Physics.Raycast(_controller.bounds.center, Vector3.down, out hit, _controller.bounds.extents.y + detectionLength, GroundLayers);
            Debug.DrawRay(_controller.bounds.center, Vector3.down * (_controller.bounds.extents.y + detectionLength), Color.green);



            material = hit.transform.gameObject.GetComponent<Renderer>();
            indexInt = material.material.GetInteger("_Index");

          

            ressourcesString = options[indexInt];
            if (ressourcesString != lastEntrie) { isTypeFloorChanged = true; lastEntrie = ressourcesString; } else { isTypeFloorChanged = false; }
            if (isTypeFloorChanged)
            {


                LoadRessourcesFromString(ressourcesString);

                isTypeFloorChanged = false;
            }
        
    }


    public void LoadRessourcesFromString(string ressourcesString)
    {

            resoucesFootStepSounds = Resources.LoadAll("AudioClip/WalkAudio/" + ressourcesString, typeof(AudioClip));
            
            resoucesJumpSounds = Resources.LoadAll("AudioClip/JumpAudio/" + ressourcesString, typeof(AudioClip));
            var index = Random.Range(0,resoucesJumpSounds.Length);

           
        jumpSound = (AudioClip)resoucesJumpSounds[index];
        Debug.Log(jumpSound);

            footStepSounds.Clear();

            for (int i = 0; i < resoucesFootStepSounds.Length; i++)
            {

                    footStepSounds.Add((AudioClip)resoucesFootStepSounds[i]);

            }

    }
   
}
