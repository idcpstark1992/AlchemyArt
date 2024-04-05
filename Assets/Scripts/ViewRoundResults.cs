using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Commons;

namespace UI
{
    public class ViewRoundResults : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _printTextResult;
        [SerializeField] private Image  _printImage;
        [SerializeField] private Sprite _winSprite;
        [SerializeField] private Sprite _lostSprite;

        public void Init()
        {
            gameObject.transform.localScale = Vector3.zero;
        }
        public void OnGameRoundResult(string _result)
        {
            _printTextResult.SetText(_result);
            LeanTween.scale(gameObject, Vector3.one, .3f).setEaseOutBounce();            
        }
        public void ClosePanel()
        {
            LeanTween.scale(gameObject, Vector3.zero, .3f).setEaseInBounce();
        }

    }

}
