using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject plr;
    public int location = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (location == 0)
            {
                plr.transform.position = new Vector3(25,1f,25);
                location = 1;
            }
            //if (location == 1)
            else
            {
                plr.transform.position = new Vector3(0,1f,0);
                location = 0;
            }
        }
    }
}
