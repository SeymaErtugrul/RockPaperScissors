using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI attackValue;
    public Image artWork;

    void Start()
    {
        descriptionText.text = card.cardDescription;
        artWork.sprite = card.cardImage;
        attackValue.text=card.attackValue;
    }

}
