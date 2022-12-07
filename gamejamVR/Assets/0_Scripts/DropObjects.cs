using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class DropObjects : MonoBehaviour
{ 
    public GameObject dropPlace;
    public GameObject placeHolder;
    public abstract void SetUpObjectTransform();
    public abstract IEnumerator UpdatePuzzledBooks();

}
