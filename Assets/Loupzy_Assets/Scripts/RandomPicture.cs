using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;
public class RandomSprite : MonoBehaviour {
    public Sprite[] spriteClient;
    public GameObject[] indexDecision;
    public GameObject[] pinTag;
    private TextMeshPro textoTMP;
    public GameObject textDescription;
    public Sprite[] spriteDecision;
    public Sprite[] spriteDecision1;
    public Sprite[] spriteDecision2;
    public Sprite[] spriteDecision3;
    public Sprite[] spriteDecision4;
    private string Win = "Good";
    private string Defeat = "Bad";

    void Start() {

        textoTMP = textDescription.GetComponent<TextMeshPro>();
        ChangeRandomSpriteClient();
        ChangeTreeDecision();

    }

    void Update() {
        if (GameManager.instance.isPlaying()) {
        Invoke("DeleteText", 5f);
        }

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
            Debug.LogError("El arreglo de spriteClient est� vac�o. Asigna spriteClient en el inspector.");
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
            Debug.LogError("El arreglo de indexDecision est� vac�o. Asigna indexDecision en el inspector.");
        }
    }


    void ChangeDecisionBasedOnIndex(int randomIndex) {
        switch (randomIndex) {
            case 0:
                spriteDecision = spriteDecision1;
                textoTMP.text = "Hola, �c�mo est�s? Me preguntaba si podr�as hacerme una pizza un poco diferente. Me encantar�a tener queso, tomate y peperoni.�Estar� muy agradecido! Gracias";
                pinTag[0].tag = Win;
                pinTag[1].tag = Defeat;
                pinTag[2].tag = Defeat;
                pinTag[3].tag = Win;
                pinTag[4].tag = Defeat;
                pinTag[5].tag = Win;
                break;
            case 1:
                spriteDecision = spriteDecision2;
                textoTMP.text = "Hola, pizzero creativo! Quiero una pizza que me haga volar la mente. Ponle pez, queso y... �s�, lo has adivinado! Rata. �Sorpr�ndeme con esa combinaci�n �nica y loca!";
                pinTag[0].tag = Defeat;
                pinTag[1].tag = Win;
                pinTag[2].tag = Win;
                pinTag[3].tag = Defeat;
                pinTag[4].tag = Win;
                pinTag[5].tag = Defeat;
                break;
            case 2:
                spriteDecision = spriteDecision3;
                textoTMP.text = "Oye, esc�chame bien. No quiero tus tonter�as habituales. Solo quiero una pizza con queso, pez y pi�a, y que no me pongas esa rata de tomate. Si metes tomate, �prepar�te para lo peor!";
                pinTag[0].tag = Win;
                pinTag[1].tag = Win;
                pinTag[2].tag = Defeat;
                pinTag[3].tag = Win;
                pinTag[4].tag = Defeat;
                pinTag[5].tag = Defeat;
                break;
            case 3:
                spriteDecision = spriteDecision4;
                textoTMP.text = "Necesito algo �nico, algo que solo alguien con mi gusto refinado pueda apreciar. Hazme una pizza con queso exquisito, pez ahumado de la mejor calidad, pi�a fresca y tomates de una granja exclusiva. ";
                pinTag[0].tag = Defeat;
                pinTag[1].tag = Win;
                pinTag[2].tag = Win;
                pinTag[3].tag = Defeat;
                pinTag[4].tag = Win;
                pinTag[5].tag = Win;
                break;
            default:
                Debug.LogError("�ndice aleatorio fuera de rango.");
                break;
        }
    }
    public void ChangeTreeFull() {
        ChangeRandomSpriteClient();
        ChangeTreeDecision();
    }
    void DeleteText() {
        
        textoTMP.text = " ";
    }
}
