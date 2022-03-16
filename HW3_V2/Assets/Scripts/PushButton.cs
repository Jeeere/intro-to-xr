using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class PushButton : MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = 0.025f;
    public AudioSource sound = null;
    public GameObject video = null;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    private VideoPlayer videoPlayer;
    private Canvas videoCanvas;

    public UnityEvent onPressed, onReleased;

    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();

        videoCanvas = video.GetComponentInChildren<Canvas>();
        videoCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetValue() + threshold);
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
        if(sound)
        {
            Debug.Log("Playing sound");
            sound.Play();
        }
        if(video)
        {
            videoCanvas.enabled = true;
            videoPlayer = video.GetComponentInChildren<VideoPlayer> ();
            
            Debug.Log("Playing video");
            videoPlayer.Play();
        }
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
