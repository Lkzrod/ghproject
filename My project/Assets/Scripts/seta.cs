using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seta : MonoBehaviour
{
    public AnimationCurve curve;
    public bool inverted;
    private Vector3 setaPosition;
    // Start is called before the first frame update
    void Start()
    {
        curve = new AnimationCurve(new Keyframe (0,0),new Keyframe(0.5f,0.2f));
        curve.preWrapMode = WrapMode.PingPong;
        curve.postWrapMode = WrapMode.PingPong;
        setaPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (inverted) 
        transform.position = new Vector3(setaPosition.x - curve.Evaluate(Time.time),setaPosition.y, setaPosition.z);
        else
        transform.position = new Vector3(setaPosition.x + curve.Evaluate(Time.time),setaPosition.y, setaPosition.z);
    }
}
