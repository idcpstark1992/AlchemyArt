using Data;
using UnityEngine;
namespace UI
{
    public class ViewsController : MonoBehaviour
    {
        
        [SerializeField] private ViewRoundResults      _uiRoundResult;
        [SerializeField] private ViewGamePoints        _viewGamePoints;
        [SerializeField] private ViewSoulsPool         _betPanel;
        [SerializeField] private UIPrintStayPoints     _printStayPoints;
        [SerializeField] private UIButtonsController   _buttonControllers;
        [SerializeField] private ViewRoundWinner       _printWinner;

        private void Start()
        {
            _viewGamePoints.Init();
            _uiRoundResult.Init();
        }
        public void OnBetState()
        {
            _buttonControllers.OnBetState();
            _betPanel.OpenHidePanel(true);
        }
        public void OnGameIdle()
        {
            _buttonControllers.OnGameIdle();
            _viewGamePoints.OnGameIdle();
        }
        public void OnActorGamePlay()
        {
            _viewGamePoints.OnGameActor();
            if (GameActorsManager.CurrentActor.ActorType == Commons.E_Actors.AI) 
            {
                _buttonControllers.OnAIGameActor();
            }
            else
            {
                _buttonControllers.OnGameActor();
            }
        }
        public void OnSwitchedActor()
        {
            _printStayPoints.OnSwitchedActor(GameActorsManager.CurrentActor.ActorPoints);
        }
        public void OnFinishedRound()
        {
            _printWinner.Open();
            
        }
        public void OnRestart()
        {
            _printStayPoints.OnGameRestart();
            _buttonControllers.OnRestart();
            _betPanel.OnRestarted();
        }
    }

}
