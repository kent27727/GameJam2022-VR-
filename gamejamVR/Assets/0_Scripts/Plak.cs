using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Plak : DropObjects
{

    void Start()
    {
        DOTween.Init();
    }


    void Update()
    {

    }

    public override void SetUpObjectTransform()
    {
        float dist = Vector3.Distance(transform.position, placeHolder.transform.position);
        if (dist <= 1)
        {
            transform.DORotate(new Vector3(0,0,0),1);
            transform.DOMove(placeHolder.transform.position,1);

        }
    }

    public override IEnumerator UpdatePuzzledBooks()
    {
        throw new System.NotImplementedException();
    }
}
