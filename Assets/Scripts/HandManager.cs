using UnityEngine;
using RPDeckBuilding;
using System.Collections.Generic;
using UnityEngine.AI;
using Unity.VisualScripting.Dependencies.NCalc;


public class HandManager : MonoBehaviour {
    public GameObject cardPrefab; // Assign in inspector
    public Transform handTransform; // Hand position root
    public float fanSpread = 7.5f;
    public float cardSpacing = 100f;
    public float verticalSpacing = 0f;
    public List<GameObject> cardsInHand = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
    }

    public void AddCardToHand() {
        GameObject newCard = Instantiate(
                cardPrefab,
                handTransform.position,
                Quaternion.identity,
                handTransform
            );

        cardsInHand.Add(newCard);
        UpdateHandVisuals();
    }

    void Update() {
        UpdateHandVisuals();
    }

    public void UpdateHandVisuals() {
        int cardCount = cardsInHand.Count;
        for (int i = 0; i < cardCount; i++) {
            float rotationAngle = CalculateOffset(fanSpread, i, cardCount);
            float horizontalOffset = CalculateOffset(cardSpacing, i, cardCount);
            float verticalOffset = CalculateOffset(verticalSpacing, i, cardCount);

            cardsInHand[i]
                .transform
                .SetLocalPositionAndRotation(
                    new Vector3(horizontalOffset, verticalOffset, 0f),
                    Quaternion.Euler(0f, 0f, rotationAngle)
                );
        }
    }

    float CalculateOffset(float spacing, int i, int cardCount) {
        return spacing * (i - (cardCount - 1) / 2f);
    }
}
