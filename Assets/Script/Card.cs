using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 targetPosition;
    public Quaternion targetRotation;
    public float moveSpeed = 5f , rotateSpeed = 540f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

    public void moveToPoint(Vector3 targetPosition, Quaternion rotation)
    {
        this.targetPosition = targetPosition;
        this.targetRotation = rotation;
    }
}
