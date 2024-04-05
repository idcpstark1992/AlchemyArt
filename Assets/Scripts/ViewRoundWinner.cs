using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ViewRoundWinner : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _printMessage;
        [SerializeField] private Sprite      _winSprite;
        [SerializeField] private Sprite      _lostSprite;
        [SerializeField] private Image       _printSprite;
        [SerializeField] private CanvasGroup _canvas;
        [SerializeField] private Button      _btnOnClose;
        [SerializeField] private Marketplace _marketplace;
        private void Awake()
        {
            _canvas.alpha = 0f;
            _canvas.interactable    = false;
            _canvas.blocksRaycasts  = false;
            _btnOnClose.onClick.AddListener(OnClose);
        }

        public void Open()
        {
            _printSprite.sprite = BetUtils.IsPlayerActorWinner ? _winSprite : _lostSprite;
            _printMessage.SetText(BetUtils.IsPlayerActorWinner ? "This round is yours!" : " ha ha ha Those souls are mine !");
            _canvas.interactable = true;
            _canvas.blocksRaycasts = true;
            LeanTween.alphaCanvas(_canvas, 1, .5f);
        }
        private void OnClose()
        {
            _marketplace.OpenMarketPlace();
            _canvas.alpha = 0;
            _canvas.interactable = false;
            _canvas.blocksRaycasts = false;
        }
    }

}
