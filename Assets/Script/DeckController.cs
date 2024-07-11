using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{

    public static DeckController instance;
    public List<Card> cardsInDeck = new List<Card>();
    public Card cardPrefab;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            drawCardToHand();
        }
    }

    public void setupDeck(){

    }

    public void drawCardToHand(){
        if(cardsInDeck.Count > 0){
          Card newCard =  Instantiate(cardPrefab,transform.position,transform.rotation);
          HandController.instance.addCardToHand(newCard);
        }
    }
}
