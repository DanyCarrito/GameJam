using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour {
    public Sprite[] spriteClient;
    public GameObject[] indexDecision;
    public GameObject[] pinTag;
    public Sprite[] spriteDecision;
    public Sprite[] spriteDecision1;
    public Sprite[] spriteDecision2;
    public Sprite[] spriteDecision3;
    public Sprite[] spriteDecision4;
    private string Win = "Good";
    private string Defeat = "Bad";

    void Start() {
        ChangeRandomSpriteClient();
        ChangeTreeDecision();
    }

    void Update() {

    }

    void ChangeRandomSpriteClient() {
        if (spriteClient.Length > 0) {
            int randomIndex = Random.Range(0, spriteClient.Length);
            Sprite randomSprite = spriteClient[randomIndex];

            if (GetComponent<SpriteRenderer>() != null) {
                GetComponent<SpriteRenderer>().sprite = randomSprite;

                ChangeDecisionBasedOnIndex(randomIndex);
            } else {
                Debug.LogError("El GameObject no tiene un componente SpriteRenderer.");
            }
        } else {
            Debug.LogError("El arreglo de spriteClient está vacío. Asigna spriteClient en el inspector.");
        }
    }

    void ChangeTreeDecision() {
        if (indexDecision.Length > 0) {
            int decisionLength = Mathf.Min(indexDecision.Length, spriteDecision.Length);

            for (int i = 0; i < decisionLength; i++) {
                if (indexDecision[i] != null && indexDecision[i].GetComponent<SpriteRenderer>() != null) {
                    indexDecision[i].GetComponent<SpriteRenderer>().sprite = spriteDecision[i];
                } else {
                    Debug.LogError("El GameObject en indexDecision[" + i + "] no tiene un componente SpriteRenderer.");
                }
            }
        } else {
            Debug.LogError("El arreglo de indexDecision está vacío. Asigna indexDecision en el inspector.");
        }
    }


    void ChangeDecisionBasedOnIndex(int randomIndex) {
        switch (randomIndex) {
            case 0:
                spriteDecision = spriteDecision1;
                pinTag[0].tag = Win;
                pinTag[1].tag = Defeat;
                pinTag[2].tag = Defeat;
                pinTag[3].tag = Win;
                pinTag[4].tag = Defeat;
                pinTag[5].tag = Defeat;
                break;
            case 1:
                spriteDecision = spriteDecision2;
                pinTag[0].tag = Defeat;
                pinTag[1].tag = Win;
                pinTag[2].tag = Win;
                pinTag[3].tag = Defeat;
                pinTag[4].tag = Defeat;
                pinTag[5].tag = Defeat;
                break;
            case 2:
                spriteDecision = spriteDecision3;
                pinTag[0].tag = Defeat;
                pinTag[1].tag = Defeat;
                pinTag[2].tag = Defeat;
                pinTag[3].tag = Defeat;
                pinTag[4].tag = Win;
                pinTag[5].tag = Win;
                break;
            case 3:
                spriteDecision = spriteDecision4;
                pinTag[0].tag = Defeat;
                pinTag[1].tag = Defeat;
                pinTag[2].tag = Win;
                pinTag[3].tag = Win;
                pinTag[4].tag = Defeat;
                pinTag[5].tag = Defeat;
                break;
            default:
                Debug.LogError("Índice aleatorio fuera de rango.");
                break;
        }
    }
    public void ChangeTreeFull() {
        ChangeRandomSpriteClient();
        ChangeTreeDecision();
    }
}
