using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundTriggerBath : MonoBehaviour
{
    [SerializeField] GameObject ballon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ballon.transform.DOMove(new Vector3(ballon.transform.position.x,7.5f,ballon.transform.position.z),1f);
        }
    }
}
