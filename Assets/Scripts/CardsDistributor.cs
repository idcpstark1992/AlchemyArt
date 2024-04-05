using Commons;
using Data;
using System.Collections;
using UnityEngine;

namespace Controllers
{
    public class CardsDistributor: MonoBehaviour
    {
        [SerializeField] private int _minimunCards;

        public void OnInitialDrawState()
        {
            StartCoroutine(CStartPrimaryCards());
        }
        public void CheckAITurn()
        {
            if(GameActorsManager.CurrentActor.ActorType == E_Actors.AI)
                StartCoroutine(CAICards());

        }
        private IEnumerator CStartPrimaryCards()
        {
            int m_counter = 0;
            while (m_counter < _minimunCards)
            {
                CardsSpawner.Instance.InstantiateObject();
                m_counter++;
                yield return new WaitForSeconds(1f);
            }
            EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(), E_GamePhase.GAME_SPECIAL_CARDS_CHECK);
        }
        private IEnumerator CAICards()
        {
            int m_counter = 0;
            while (GameActorsManager.CurrentActor.CanPlay)
            {
                CardsSpawner.Instance.InstantiateObject();
                m_counter++;
                yield return new WaitForSeconds(1f);
            }
        }
    }

}
