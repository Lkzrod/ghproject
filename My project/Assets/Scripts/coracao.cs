using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coracao : MonoBehaviour
{
    public AnimationCurve curve;
    public bool inverted;

    private Vector3 curaPosition;

    // Start is called before the first frame update
    void Start()
    {
        curve = new AnimationCurve(new Keyframe (0,0), new Keyframe(0.8f, 0.2f));
        curve.preWrapMode = WrapMode.PingPong;
        curve.postWrapMode = WrapMode.PingPong;
        curaPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (inverted) 
        transform.position = new Vector3(curaPosition.x,curaPosition.y - curve.Evaluate(Time.time), curaPosition.z);
        else
        transform.position = new Vector3(curaPosition.x,curaPosition.y + curve.Evaluate(Time.time), curaPosition.z);
    }
}
