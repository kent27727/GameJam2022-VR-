using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpDownTrap : MonoBehaviour
{
    #region Singleton
        public static UpDownTrap instance { get;private set; }
        private void Awake() 
        {
            instance = this;
        }
    #endregion
    [SerializeField] private GameObject upCube;
    public bool turnObjectBool;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (turnObjectBool == false)
            {
                upCube.transform.DOMove(new Vector3(upCube.transform.position.x,1.24f, upCube.transform.position.z), 1f).SetEase(Ease.OutSine);
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (turnObjectBool == false)
            {
                turnObjectBool = false;
                upCube.transform.DOMove(new Vector3(upCube.transform.position.x, 0, upCube.transform.position.z), 1f).SetEase(Ease.OutSine);
            }
            
        }
    }

}
