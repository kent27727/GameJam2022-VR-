using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;

public class startGame : MonoBehaviour
{
    public CharacterController myCharController;
    public Movement movement;
    public LocomotionSystem locomotionController;
    public SmoothTurnProvider smoothTurnProvider;
    public float startDelay;
    public Vector3 startRotation;
    public float animSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startEnum());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator startEnum()
    {

        yield return new WaitForSeconds(startDelay);
        transform.DORotate(startRotation, animSpeed).OnComplete(() =>
        {
            unlockAll();
        });

    }
    void unlockAll()
    {

        myCharController.enabled = true;
        movement.enabled = true;
        locomotionController.enabled = true;
        smoothTurnProvider.enabled = true;
    }
}
