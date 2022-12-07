using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public ParticleSystem ps;
    public GameObject balloon,sphere;


    void Start()
    {
        //ParticleSystem ps = GameObject.Find("BalloonPopGreen").GetComponent<ParticleSystem>();
    }

    public void BalloonLoop()
    {
        ps.Play();
        StartCoroutine(WaitAndDestory());
        sphere.GetComponent<Rigidbody>().useGravity=true;
    }

    private IEnumerator WaitAndDestory()
    {
        yield return new WaitForSeconds(0.2f);
        balloon.SetActive(false);
    }

}
