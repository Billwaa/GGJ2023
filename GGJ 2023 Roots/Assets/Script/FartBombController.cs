using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FartBombController : MonoBehaviour
{
    public float effectTimer = 5;
    public float effectTime = 2;
    public int ownerID = -1;

    //public TMP_Text display;


    // Start is called before the first frame update
    void Start()
    {
      //  display.text = "" + this.ownerID;
    }

    // Update is called once per frame
    void Update()
    {
        effectTimer -= Time.deltaTime;

        if(effectTimer <= 0)
            Destroy(this.gameObject);

        
    }
}
