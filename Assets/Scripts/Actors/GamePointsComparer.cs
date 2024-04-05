using Commons;
using ActorData = Data.GameActorsManager;
namespace Controllers
{
    public class GamePointsComparer 
    {
        public void CheckAutomaticActorsState()
        {
            if(ActorData.CurrentActor.ActorType == E_Actors.PLAYER)
                CheckPlayerPoints();
            else
                CheckAIPoints();

        }
        private void CheckPlayerPoints()
        {
            if (ActorData.CurrentActor.ActorPoints == 21)
            {
                EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(), E_GamePhase.GAME_ACTOR_SWITCH);
                BetUtils.SetActorWinner(true);
            }
             
            if (ActorData.CurrentActor.ActorPoints > 21)
            {
                UnityEngine.Debug.Log("El jugador Voló  ejecutar evento de volar");
                ActorData.CurrentActor.SetActorDisponibility(false);
                BetUtils.SetActorWinner(false);
                EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(), E_GamePhase.GAME_REWARD);
            }
        }
        private void CheckAIPoints()
        {
            int m_AiPoints      = ActorData.CurrentActor.ActorPoints;
            int m_PlayerPoints  = ActorData.GetActor(0).ActorPoints;

            ActorData.CurrentActor.SetActorDisponibility(m_AiPoints < m_PlayerPoints);
      
            if (!ActorData.CurrentActor.CanPlay)
                CheckFinalPointsWithIA();
        }
        private void CheckFinalPointsWithIA()
        {

            var m_currentAI         = ActorData.CurrentActor;
            var m_currentPlayer     = ActorData.GetActor(0);

            if (m_currentAI.ActorPoints > m_currentPlayer.ActorPoints  && m_currentAI.ActorPoints <= 21)
            {
                UnityEngine.Debug.Log("La IA Ha GANADO contra el  Jugador");
                BetUtils.SetActorWinner(false);
            }
            if (m_currentAI.ActorPoints == m_currentPlayer.ActorPoints)
            {
                UnityEngine.Debug.Log("GANA EL JUGADOR");
                BetUtils.SetActorWinner(true);
            }
            if (m_currentAI.ActorPoints > 21)
            {
                UnityEngine.Debug.Log("La IA voló , ejecutar el evento de Ganar jugador");
                EventsListener.TriggerListener(E_ListenerID.ON_PLAYER_WIN.ToString(), 2);
                BetUtils.SetActorWinner(true);
            }
            EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(), E_GamePhase.GAME_REWARD);
        }
    }

}
