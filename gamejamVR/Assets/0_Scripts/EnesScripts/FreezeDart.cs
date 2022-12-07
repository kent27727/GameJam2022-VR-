using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FreezeDart : MonoBehaviour
{
    public Rigidbody rigid;
    [SerializeField] private Animator anim;
    public Transform hideObjectTransform;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        hideObjectTransform.position = gameObject.transform.position;
        anim.SetBool("IsTurning", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HideObject"))
        {
            rigid.constraints = RigidbodyConstraints.FreezePositionX;
            rigid.constraints = RigidbodyConstraints.FreezePositionZ;
            anim.SetBool("IsTurning", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HideObject"))
        {
            anim.SetBool("IsTurning", true);
            rigid.constraints = RigidbodyConstraints.None;
        }
    }

    public void GoStartPos()
    {
        gameObject.transform.position = hideObjectTransform.position;
    }

}
