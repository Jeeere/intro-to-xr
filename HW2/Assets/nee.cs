using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nee : MonoBehaviour
{
    //public Transform Camera;
    public GameObject CameraRig;
    public GameObject VRCamera;

    private  Vector3 position0;
    private Quaternion rotation0;

    private bool pos = false;
    private bool rot = false;

    // Start is called before the first frame update
    void Start()
    {
        position0 = VRCamera.transform.position;
        rotation0 = VRCamera.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            pos = !pos;
            Debug.Log("positional tracking: " + !pos);
        }
        if (Input.GetKeyDown("l"))
        {
            rot = !rot;
            Debug.Log("rotational tracking: " + !rot);
        }
        // if (Input.GetKeyUp("k"))
        // {
        //     pos = false;
        // }
        // if (Input.GetKeyUp("l"))
        // {
        //     rot = false;
        // }
        if(rot && pos)
        {
            // transform.localPosition = Quaternion.Inverse(Camera.localRotation) * /*<- jos rotational tracking pois */ -Camera.localPosition; /* jos positional tracking päällä -> */ //+ Camera.localPosition;
            // transform.localRotation = Quaternion.Inverse(Camera.localRotation); // jos rotatinal trackingpois
            disablePositionalTracking(position0);
            disableRotationalTracking(rotation0);
        }
        else if(rot)
        {
            disableRotationalTracking(rotation0);
        }
        else if(pos)
        {
            disablePositionalTracking(position0);
        }
        position0 = VRCamera.transform.position;
        rotation0 = VRCamera.transform.localRotation;
    }

    void disablePositionalTracking(Vector3 position0)
    {
        CameraRig.transform.position += position0 - VRCamera.transform.position;
        // Debug.Log("positional tracking disabled");
    }

    void disableRotationalTracking(Quaternion rotation0)
    {
        CameraRig.transform.localRotation *= rotation0 * Quaternion.Inverse(VRCamera.transform.localRotation);
        // Debug.Log("rotational tracking disabled");
    }
}
