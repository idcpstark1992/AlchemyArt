using Commons;
using UnityEngine;

namespace Data
{
    public class GameActorSwitcher : MonoBehaviour
    {
       
        public void Awake()
        {
            ActorData m_PlayerActor = new(E_Actors.PLAYER);
            ActorData m_AIActor = new(E_Actors.AI);
            GameActorsManager.AddActor(m_PlayerActor);
            GameActorsManager.AddActor(m_AIActor);
            GameActorsManager.SwitchActor(0);
        }
        /// <summary>
        /// 0  = for Player, 1 = AI
        /// </summary>
        /// <param name="_activeActorIndex"></param>
        public void SwitchActor(int _activeActorIndex)
        {
           
            GameActorsManager.SwitchActor(_activeActorIndex);
            
        }
    }

}
