using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public static class CardsSpritesUtils
    {
        private static Dictionary<int, CardDataStorage> CardsDictionary = new();
        public static void Init(CardDataStorage _data)
        {
             CardsDictionary.Add(_data.CardValue, _data);
        }
        public static Sprite GetCardSprite(int _id)
        {
            return CardsDictionary[_id].CardSprite;
        }
    }

}
