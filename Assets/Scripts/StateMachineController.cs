using Commons;
using UnityEngine;
namespace Controllers
{

    public class StateMachineController : MonoBehaviour
    {
        [SerializeField] private Animator _stateMachineController;
        private E_GamePhase _gamePhase;

       
        private void OnStatusChange (StateContext _context)
        {
            
            if (_context.UseStateValue)
            {
                _stateMachineController.SetBool(_context.StateName.ToString(), _context.StateValue);
            }
            else
            {
                _stateMachineController.SetTrigger(_context.StateName.ToString());
            }
        }
        public void GameIdle()
        {
            _gamePhase = E_GamePhase.GAME_IDLE;
            ChangeStateMachine();
        }
        public void GameBetState()
        {
            _gamePhase = E_GamePhase.GAME_BET;
            ChangeStateMachine();
        }
        public void GameInitialDrawState()
        {
            Debug.Log("jhs");
            _gamePhase = E_GamePhase.GAME_INITIAL_DRAW;
            ChangeStateMachine();
        }
        public void GameSpecialCardsCheck()
        {
            _gamePhase = E_GamePhase.GAME_SPECIAL_CARDS_CHECK;
            ChangeStateMachine();
        }
        public void GameActorGamePlay()
        {
            _gamePhase = E_GamePhase.GAME_ACTOR_GAME_PLAY;
            ChangeStateMachine();
        }
        public void GameReward()
        {
            _gamePhase = E_GamePhase.GAME_REWARD;
            ChangeStateMachine();
        }
        public void GameSwitchActor()
        {
            
        }
        public void GameActionPointsComparer()
        {
            _gamePhase = E_GamePhase.GAME_ACTOR_POINTS_COMPRASION;
            ChangeStateMachine();
        }
        public void GameBuy()
        {
            _gamePhase = E_GamePhase.GAME_BUY;
            ChangeStateMachine();
        }
        private void ChangeStateMachine()
        {
            EventsListener.TriggerListener(E_ListenerID.ON_STATE_MACHINE.ToString(), _gamePhase);
        }

        

    }
}
