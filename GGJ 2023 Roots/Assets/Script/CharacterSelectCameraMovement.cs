using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectCameraMovement : MonoBehaviour
{
    private bool start = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start){
            transform.Translate(Vector3.back*Time.deltaTime*50,Space.World);
        }
    }

    public void startGame(){
        start = true;
    }
}
