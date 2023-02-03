using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartBombController : MonoBehaviour
{
    public float effectTimer = 5;
    public float effectTime = 2;
    public int ownerID = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        effectTimer -= Time.deltaTime;

        if(effectTimer <= 0)
            Destroy(this.gameObject);

        
    }
}
