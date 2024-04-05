using UnityEngine;
using TMPro;
using UniRx;

namespace UI
{
    public class ViewGamePoints :MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI _printPoints;
        [SerializeField] private RectTransform   _gamePointsTransform;

        PointsModel _pointsModel;
        PointsViewModel _pointsViewModel;
        public   void Init()
        {
            _pointsModel = new();
            _pointsViewModel = new(_pointsModel);
            _pointsViewModel.Data.Subscribe(OnPlayedCards);
        }

        private void OnDisable()
        {
            _pointsModel.OnDestroy();
        }
        private void OnPlayedCards(int _vca)
        {
            LeanTween.scale(_printPoints.gameObject, Vector3.one * 2f, .5f).setLoopPingPong(1).setEaseInOutElastic();
            _printPoints.SetText(_vca.ToString());
        }

        public void OnGameIdle()
        {
            _gamePointsTransform.gameObject.SetActive(false);
        }
        public void OnGameActor()
        {
            _gamePointsTransform.gameObject.SetActive(true);
        }
    }

}
