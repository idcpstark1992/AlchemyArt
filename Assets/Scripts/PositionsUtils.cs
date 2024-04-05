using UnityEngine;

namespace Controllers
{
    public static class PositionsUtils
    {
        public static Vector3 CurrentCardPoint { get; private set;  }
        public static Vector3 StayPoint { get; private set; }
        public static int CardsSpawnedAmount{ get; private set; }

        public static Vector3 WorldPosition(Vector2 _screenPosition)
        {
            return Camera.main.ScreenToWorldPoint(_screenPosition);
        }

        public static void SetSpawnPosition(Vector3 _currentPosition)
        {
            CurrentCardPoint = _currentPosition;
        }
        public static void SetStayPoint (Vector3 _stayPoint)
        {
            StayPoint = _stayPoint;
        }
        public static void AddInstanceToCounter(int _amount)
        {
            CardsSpawnedAmount += _amount;
        }
        public static void SortStayPlayerCards()
        {

        }
        public static void SortStayAICards()
        {

        }
    }
}

