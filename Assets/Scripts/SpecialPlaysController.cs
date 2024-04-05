using Commons;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class SpecialPlaysController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _printSpecialPlayName;
        [SerializeField] GameObject _relancinaPanel;
        [SerializeField] GameObject _patitosPanel;
        [SerializeField] GameObject _selectionPanel;
        public void Init()
        {
            SpecialCombinationsChecker.Init();
        }
        public void OnSpecialCardsCheck()
        {
            E_SpecialCombination m_CombinationResult = SpecialCombinationsChecker.CheckForPlays();
            switch (m_CombinationResult)
            {
                case E_SpecialCombination.RELANCINA:
                    _relancinaPanel.SetActive(true);
                    EventsListener.TriggerListener(E_ListenerID.ON_PLAYER_WIN.ToString(), 4);
                    break;
                case E_SpecialCombination.PATITOS:
                    _patitosPanel.SetActive(true);
                    EventsListener.TriggerListener(E_ListenerID.ON_PLAYER_WIN.ToString(), 2);
                    break;
                case E_SpecialCombination.NONE:
                    EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(), E_GamePhase.GAME_ACTOR_GAME_PLAY);
                    break;
            }
        }

    }
}

