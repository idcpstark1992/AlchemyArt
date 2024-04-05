using TMPro;
using UnityEngine;
namespace UI
{
    public class UIPrintStayPoints : MonoBehaviour
    {
        [SerializeField] private RectTransform      _stayPointsHolder;
        [SerializeField] private TextMeshProUGUI    _printAmount;
        private int _cardsCounter;
        private WaitForSeconds _delay = new (.3f);
        private void OnEnable()
        {
            OnGameRestart();
        }

        public   void OnSwitchedActor(int _points)
        {
            _printAmount.SetText(_points.ToString());
            LeanTween.scale(_stayPointsHolder.gameObject, Vector3.one, 1f).setEaseOutCirc();
        }
        public void OnGameRestart()
        {
            _printAmount.SetText("0");
            LeanTween.scale(_stayPointsHolder.gameObject, Vector3.zero, 1f).setEaseOutCirc();
        }

    }
}

