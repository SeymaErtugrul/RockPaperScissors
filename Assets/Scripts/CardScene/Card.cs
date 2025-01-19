using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card",menuName ="Card")]
public class Card : ScriptableObject
{
    public CardClass cardClass;
    public string attackValue;
    public string cardDescription;
    public Sprite cardImage;
}

public enum CardClass
{
    rock,
    paper,
    scissors
};
