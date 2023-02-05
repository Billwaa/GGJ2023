using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public void panLeft()
    {
        if (this.transform.position.x > -23)
            this.transform.position = this.transform.position + new Vector3(-2, 0, 0);
    }

    public void panRight()
    {
        if (this.transform.position.x < 15)
            this.transform.position = this.transform.position + new Vector3(2, 0, 0);

    }


}