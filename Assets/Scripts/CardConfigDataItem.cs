using UnityEngine;

namespace Controllers
{
    [CreateAssetMenu(fileName = "Data", menuName = "Cards/Item")]
    public class CardConfigDataItem:ScriptableObject 
    {
        public int Cardvalue;
        public Sprite CardSprite;
    }

}
