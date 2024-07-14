using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 targetPosition;
    public Quaternion targetRotation;
    public Material m_Material;
    public Material o_Material;

    public int handPosition;
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

    public int orginOrder1 = -1;
    public int orginOrder2 = -1;
    // Mouse Click Event
    private void OnMouseDown()
    {
        Debug.Log("Clicked on Card");
        if (orginOrder1 == -1){
            orginOrder1 = this.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder;
            orginOrder2 = this.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder;
        }
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = orginOrder1 + 200;
        this.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = orginOrder2 + 200;
        moveToPoint(HandController.instance.cardPositions[handPosition] + new Vector3(0, 1, .5f), Quaternion.identity);
      this.transform.GetChild(0).GetComponent<SpriteRenderer>().material = m_Material;
     }

    // Mouse exist Event , go back to original position
    private void OnMouseExit()
    {
        orginOrder1 = -1;
        orginOrder2 = -1;
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = orginOrder1 ;
        this.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = orginOrder2 ;
        HandController.instance.setCardPositions();
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().material = o_Material;
   
        //moveToPoint(HandController.instance.cardPositions[handPosition], Quaternion.identity);
    }
}
