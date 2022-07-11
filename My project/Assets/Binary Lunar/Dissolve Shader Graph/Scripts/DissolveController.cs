using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public float dissolveAmount;
    public float dissolveSpeed;
    public bool isDissolving;
    [ColorUsageAttribute(true,true)]
    public Color outColor;
    [ColorUsageAttribute(true, true)]
    public Color inColor;
    public Boss boss;
    private Material mat;


    // Start is called before the first frame update
    void Start()
    {
        //boss = GameObject.Find("Boss").GetComponent<Boss>();
        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.bossH==0)
            isDissolving = true;

        if (boss.bossH ==4)
            isDissolving = false;

        if (isDissolving)
        {
            DissolveOut(dissolveSpeed, outColor);
        }

        if (!isDissolving)
        {
            DissolveIn(dissolveSpeed, inColor);
        }

        mat.SetFloat("_DissolveAmount", dissolveAmount);


    }



    public void DissolveOut(float speed, Color color)
    {
        mat.SetColor("_DissolveColor", color);
        if (dissolveAmount > -0.1)
            dissolveAmount -= Time.deltaTime * speed;
    }

    public void DissolveIn(float speed, Color color)
    {
        mat.SetColor("_DissolveColor", color);
        if (dissolveAmount < 1)
            dissolveAmount += Time.deltaTime * dissolveSpeed;
    }
}
