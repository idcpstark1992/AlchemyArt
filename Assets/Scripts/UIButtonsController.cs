using Commons;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIButtonsController : MonoBehaviour
    {
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _newCardButton;
        [SerializeField] private Button _standButton;
        [SerializeField] private Button _restartButton;

        private void Start()
        {
            _newGameButton.onClick.AddListener(OnNewGameButtonPressed);
            _newCardButton.onClick.AddListener(OnNewCardButtonPressed);
            _standButton.onClick.AddListener(OnStandButtonPressed);
            _restartButton.onClick.AddListener(OnGameRestartButtonPressed);
        }
        private void OnNewGameButtonPressed()
        {
            EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(), E_GamePhase.GAME_BET);
        }
        private void OnNewCardButtonPressed()
        {
            EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(), E_GamePhase.GAME_PLAYER_PLAY_CARDS);
        }
        private void OnStandButtonPressed()
        {
            EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(), E_GamePhase.GAME_ACTOR_SWITCH);
        }
        private void OnGameRestartButtonPressed()
        {
            EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(),E_GamePhase.GAME_RESTARTED);
        }
        public void OnBetState()
        {
            _newGameButton.gameObject.SetActive(false);
        }
        public void OnGameIdle()
        {
            _newCardButton.gameObject.SetActive(false);
            _standButton.gameObject.SetActive(false);
            _newGameButton.gameObject.SetActive(true);
        }
        public void OnGameActor()
        {
            _newCardButton.gameObject.SetActive(true);
            _standButton.gameObject.SetActive(true);
        }
        public void OnAIGameActor()
        {
            _newCardButton.gameObject.SetActive(false);
            _standButton.gameObject.SetActive(false);
        }
        public void OnRestart()
        {
            _restartButton.gameObject.SetActive(false);
            _newCardButton.gameObject.SetActive(false);
            _newGameButton.gameObject.SetActive(true);
            _standButton.gameObject.SetActive(false);
        }
    }

}
