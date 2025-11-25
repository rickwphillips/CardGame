using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RPDeckBuilding;
using System;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;

    public Image cardImage;

    public TMP_Text nameText;

    public TMP_Text healthText;

    public TMP_Text damageText;

    public Image[] typeImages;

    private readonly Color[] typeColors = {
        new(1f, 0.4f, 0.4f), // fire
        new(0.8f, 0.52f, 0.24f), // earth
        new(0.35f, 0.35f, 1f), // water
        Color.magenta, // dark
        new(1f, 0.95f, 0.45f), // light
        Color.cyan, // air
    };

    private readonly Color[] cardColors = {
        Color.red, // fire
        new(0.8f, 0.52f, 0.24f), // earth
        Color.blue, // water
        new(0.7f, 0.0f,0.7f), // dark
        new(0.78f, 0.75f, 0.1f), // light
        new(0.0f, 0.75f, 0.75f) // air
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {
        // Debug null checks

        cardImage.color = cardColors[(int)cardData.cardType[0]];
        nameText.text = cardData.Name;
        healthText.text = cardData.Health.ToString();
        damageText.text = $"{cardData.DamageMin}-{cardData.DamageMax}";

        for(int i = 0; i < typeImages.Length; i++) {
          if (i < cardData.cardType.Count) {
            typeImages[i].gameObject.SetActive(true);
            typeImages[i].color = typeColors[(int)cardData.cardType[i]];
          } else {
             typeImages[i].gameObject.SetActive(false);
          }
        }
    }
}
