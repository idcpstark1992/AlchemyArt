using Commons;
using UnityEngine;

namespace Controllers
{
    public class CardData : MonoBehaviour
    {
        private int CardValue;

        [SerializeField] private SpriteRenderer _render;

        private void OnEnable()
        {
            EventsListener.AddListener<byte>(E_ListenerID.ON_RESTARTED.ToString(), RestartGame);
        }
        private void OnDisable()
        {
            EventsListener.RemoveListener<byte>(E_ListenerID.ON_RESTARTED.ToString(), RestartGame);
        }
        private void RestartGame(byte _)
        {
            Destroy(gameObject);
        }
        public void Init(int _value)
        {
            _render.sprite = CardsSpritesUtils.GetCardSprite(_value == 11 ? Random.Range(11, 13) : _value);
            if (_value == 11)
                _value = 10;
            CardValue = _value;
           
        }
        public void OnFinishedTween()
        {
            EventsListener.TriggerListener(E_ListenerID.ON_FINISHED_CARD_TWEEN.ToString(), CardValue);
        }

    }
}
