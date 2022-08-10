using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpToEnd : MonoBehaviour
{
    GameObject endPos;
    public float jumpPower;
    public int jumpCount;
    public float duration;
    CharacterController ct;
    void Start()
    {
        ct = GetComponent<CharacterController>();
        endPos = GameObject.FindGameObjectWithTag("jumpTo");
    }

    private void OnTriggerEnter(Collider other) //dotween scale
    {
        if(other.gameObject.CompareTag("end"))
        {
            ct.enabled = false;
            transform.DOJump(endPos.transform.position, jumpPower, jumpCount, duration).OnComplete(()=>{
                ct.enabled = true;
            });
        }
    }
}
