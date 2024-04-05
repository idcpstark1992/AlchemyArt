using Commons;
using UnityEngine;


namespace Controllers
{
    public class CardTransition : MonoBehaviour
    {
        [SerializeField] private CardData _cardData;
        private void Start()
        {
            CardsPositionController.Instance.SetNewInstancePoint();
            LeanTween.rotateLocal(gameObject, new Vector3(-90f,0,0), .5f).setEaseInCirc();
            LeanTween.move(gameObject, PositionsUtils.CurrentCardPoint, .5f).setEaseOutCubic().setOnComplete(OnFinished);
        }
        private void OnEnable()
        {
            EventsListener.AddListener<byte>(E_ListenerID.ON_STAND.ToString(), OnStand);
        }
        private void OnDisable()
        {
            EventsListener.RemoveListener<byte>(E_ListenerID.ON_STAND.ToString(), OnStand);
        }
        private void OnStand(byte _)
        {
            LeanTween.move(gameObject, PositionsUtils.StayPoint, .5f).setEaseOutCubic().setOnComplete(OnCardMovementFinished);
        }
        private void OnFinished()
        {
            _cardData.OnFinishedTween();
        }
        private void OnCardMovementFinished()
        {
            Destroy(gameObject);
        }
    }

}
