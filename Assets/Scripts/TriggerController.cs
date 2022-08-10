using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public Vector3 sizeChangeOnX;
    public Vector3 sizeChangeOnY;
    public Transform spine;
    public Transform leg1;
    public Transform leg2;
    CharacterController cc;
    Animator anim;
    PlayerMovement movement;
    void Start() 
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("+2x"))
        {
            spine.transform.localScale = spine.transform.localScale + sizeChangeOnX;
            leg1.transform.localScale = leg1.transform.localScale + sizeChangeOnX / 2;
            leg2.transform.localScale = leg2.transform.localScale + sizeChangeOnX / 2;
            cc.height += 0.05f;
            Destroy(other.gameObject,.1f);
            print("+2x");
        }
        if(other.gameObject.CompareTag("-2x"))
        {
            transform.localScale = transform.localScale - sizeChangeOnX;
            leg1.transform.localScale = leg1.transform.localScale - sizeChangeOnX / 2;
            leg2.transform.localScale = leg2.transform.localScale - sizeChangeOnX / 2;
            cc.height -= 0.05f;
            Destroy(other.gameObject,.1f);
            print("-2x");
        }
        if(other.gameObject.CompareTag("+2y"))
        {
            transform.localScale = transform.localScale + sizeChangeOnY;
            leg1.transform.localScale = leg1.transform.localScale + sizeChangeOnX / 2;
            leg2.transform.localScale = leg2.transform.localScale + sizeChangeOnX / 2;
            cc.height += 0.02f;
            cc.radius += 0.05f;
            Destroy(other.gameObject,.1f);
            print("+2y");
        }
        if(other.gameObject.CompareTag("-2y"))
        {
            transform.localScale = transform.localScale - sizeChangeOnY;
            leg1.transform.localScale = leg1.transform.localScale - sizeChangeOnX / 2;
            leg2.transform.localScale = leg2.transform.localScale - sizeChangeOnX / 2;
            cc.height -= 0.02f;
            cc.radius -= 0.05f;
            Destroy(other.gameObject,.1f);
            print("-2y");
        }
        if(other.gameObject.CompareTag("diamond"))
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("obstacle"))
        {
            anim.SetBool("isDying", true);
            movement.enabled = false;
        }
    }
}
