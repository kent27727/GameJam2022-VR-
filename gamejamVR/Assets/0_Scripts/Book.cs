using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class Book : DropObjects
{
    public GameObject puzzledObject;
    public List<GameObject> books;
    public List<GameObject> placeHolders;
    public List<GameObject> puzzledBooks;
    public List<GameObject> puzzledBooksPlaceHolders;
    public int counter;

    private void Start() 
    {
        DOTween.SetTweensCapacity(1000,1000);
    }
    void Update()
    {
        SetUpObjectTransform();
        StartCoroutine(UpdatePuzzledBooks());
    }

    public override void SetUpObjectTransform()
    {
        counter = 0;
        foreach (var book in books)
        {

            float dist = Vector3.Distance(book.transform.position, placeHolders[counter].transform.position);
            if (dist <= 1)
            {
                book.transform.DORotate(new Vector3(0, 0, 0), 1);
                book.transform.DOMove(placeHolders[counter].transform.position, 1);
                counter++;

            }
            
        }
       
    }

    public override IEnumerator UpdatePuzzledBooks()
    {
        Sequence mySeq = DOTween.Sequence();
        if (counter == 3)
        {
            yield return new WaitForSeconds(5);
            for (int i = 0; i < 8; i++)
            {
                puzzledBooks[i].transform.DORotate(new Vector3(0, 0, 0), 1f);
                puzzledBooks[i].transform.DOMove(puzzledBooksPlaceHolders[i].transform.position, Random.Range(1,5));
            }
            SetUpPuzzledObject();
        }
    }



    public void SetUpPuzzledObject()
    {
        puzzledObject.transform.DORotate(new Vector3(0, 90, 0), 3);
        UpDownTrap.instance.turnObjectBool = true;
    }
}
