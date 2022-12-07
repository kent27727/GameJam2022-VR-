using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public GameObject efectObject;
    private ParticleSystem efect;


    private void Awake()
    {
        efect = GameObject.FindGameObjectWithTag("Efect").GetComponent<ParticleSystem>();
        efectObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            StartCoroutine(DestroyFunct());
        }
    }

    IEnumerator DestroyFunct()
    {
        efectObject.SetActive(true);
        efect.Play();
        yield return new WaitForSeconds(.7f);
        Destroy(gameObject);
    }
}
