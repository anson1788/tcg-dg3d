using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HandController : MonoBehaviour
{

    public static HandController instance;
    public Card[] cardsInHand;
    public List<Vector3> cardPositions = new List<Vector3>();

    public Transform minPos, maxPos;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        setCardPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCardPositions()
    {
        cardPositions.Clear();
        
        Vector3 distanceBetweenPoints = Vector3.zero;

        if (cardsInHand.Length > 1)
        {
            distanceBetweenPoints = (maxPos.position - minPos.position) / (cardsInHand.Length - 1);
        }

        for(int i=0;i<cardsInHand.Length;i++)
        {
            cardPositions.Add(minPos.position + distanceBetweenPoints * i);
            
            cardsInHand[i].handPosition = i;
            cardsInHand[i].moveToPoint(cardPositions[i],minPos.rotation);
            //cardsInHand[i].gameObject.fi.sortingOrder = i + 5;
            // get child named "front" and set sorting order
            cardsInHand[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = (i + 5);
            cardsInHand[i].transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = (i + 5);
        }
    }

    public void addCardToHand(Card card)
    {
        List<Card> temp = new List<Card>(cardsInHand);
        temp.Add(card);
        cardsInHand = temp.ToArray();
        setCardPositions();
    }
}
