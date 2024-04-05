using Commons;
using System.Collections.Generic;

namespace Data
{
    public static class GameActorsManager
    {
        public static   ActorData         CurrentActor { get; private set; }
        private static  List<ActorData>   _actors = new();
        public static void SwitchActor(int _actor)
        {
            CurrentActor = _actors[_actor];
            EventsListener.TriggerListener(E_ListenerID.ON_RESTART_POINTS_MODEL.ToString(), 0);
        }
        public static void AddActor(ActorData _data)
        {
            _actors.Add( _data );   
        }
        /// <summary>
        /// 0 = Player , 1 = AI
        /// </summary>
        /// <param name="_activeActorIndex"></param>
        /// <returns></returns>
        public static ActorData GetActor(int _activeActorIndex)
        {
            return _actors[_activeActorIndex];
        }
        public static void AddActorsPoints(int _points)
        {
            UnityEngine.Debug.Log($"Actorpoints  {_points} --- Actor Name {CurrentActor.ActorType} " );
            CurrentActor.SetActorPoints(_points);
        }

        public static void OnRestart()
        {
            CurrentActor = _actors[0];
            CurrentActor.SetActorPoints(0);
        }
    }

}
