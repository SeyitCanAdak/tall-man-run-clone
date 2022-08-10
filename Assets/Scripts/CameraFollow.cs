using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playersPos;
    public Transform camsTransform;
    Vector3 offset;
    public float smoothTime = .3f;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        offset = camsTransform.position - playersPos.position;
    }
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = playersPos.position - offset;
        transform.position = Vector3.Lerp(pos, targetPos, Time.deltaTime * 3);
    }
        private void LateUpdate()
    {
        // update position
        Vector3 targetPosition = playersPos.position + offset;
        camsTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
 
        // update rotation
        transform.LookAt(playersPos);
    }
}
