using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartRotationLook : MonoBehaviour
{
    bool myBool;
    void Update()
    {
        if (myBool)
        {
            transform.rotation = Quaternion.LookRotation(this.GetComponent<Rigidbody>().velocity);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if (myBool && other.gameObject.CompareTag("Ground"))
        {
            this.GetComponent<Rigidbody>().isKinematic = enabled;
        } 
    }
    public void handOut(bool TF)
    {
        myBool = TF;
    }
}
