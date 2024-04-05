using Commons;
using UnityEngine;

namespace Controllers
{
    public class CardsPositionController : MonoBehaviour
    {
        public static CardsPositionController Instance { get; private set; }
        private Vector3 CurrentPoint;
        private float SpawnPointX;
        
        [SerializeField] private GameObject  _initialPlayerPoint;
        [SerializeField] private GameObject  _initialCpuPoint;
        [SerializeField] private Transform   _playerStayPoint;
        private void Awake()
        {
            Instance = this;
        }
        public void Init()
        {
            PositionsUtils.SetStayPoint(_playerStayPoint.position);

            SpawnPointX = _initialPlayerPoint.transform.position.x;
            CurrentPoint = new Vector3(_initialPlayerPoint.transform.position.x, 
                _initialPlayerPoint.transform.position.y, 
                _initialPlayerPoint.transform.position.z);
        }
        public void  SetNewInstancePoint()
        {
            CurrentPoint = new Vector3(SpawnPointX, _initialPlayerPoint.transform.position.y, _initialPlayerPoint.transform.position.z);
            PositionsUtils.SetSpawnPosition(CurrentPoint);
            SpawnPointX += 4;
        }
        public void OnSwitchedActor()
        {
            SpawnPointX = _initialPlayerPoint.transform.position.x;
            CurrentPoint = new Vector3(_initialPlayerPoint.transform.position.x,
                _initialPlayerPoint.transform.position.y,
                _initialPlayerPoint.transform.position.z);
            EventsListener.TriggerListener(E_ListenerID.ON_STAND.ToString(), new byte());
        }
        public void OnRestart()
        {
            SpawnPointX = _initialPlayerPoint.transform.position.x;
            CurrentPoint = new Vector3(_initialPlayerPoint.transform.position.x,
                _initialPlayerPoint.transform.position.y,
                _initialPlayerPoint.transform.position.z);
        }
    }
}

