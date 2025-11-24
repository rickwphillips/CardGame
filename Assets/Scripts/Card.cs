using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPDeckBuilding
{
    [CreateAssetMenu(fileName = "New card", menuName = "Card")]
    public class Card : ScriptableObject
  {
        public string Name;

        public List<CardType> cardType;

        public int Health;

        public int DamageMin;

        public int DamageMax;

        public List<DamageType> damageType;

        public enum CardType
        {
            Fire,
            Earth,
            Water,
            Dark,
            Light,
            Air
        }

        public enum DamageType
    {
            Fire,
            Earth,
            Water,
            Dark,
            Light,
            Air
    }
  }
}
