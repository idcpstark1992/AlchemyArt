using Commons;
using Controllers;
using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Data
{
  
    public class GameFlowManager:MonoBehaviour
    {
        private Dictionary<E_GamePhase, Action>                 _stateExecutionDictionary = new();
        [SerializeField] private ViewsController                _viewsController;
        [SerializeField] private GameActorSwitcher              _gameActorSwitcher;
        [SerializeField] private CardsSpawner                   _spawner;
        [SerializeField] private CardsDistributor               _cardsDistributor;
        [SerializeField] private SpecialPlaysController         _specialPlaysController;
        [SerializeField] private CardsProbabilitiesController   _cardsProbabilitiesController;
        [SerializeField] private CardsPositionController        _cardsPositionController;
        private GamePointsComparer    _gamePointsComparer;
        private CardsPointsController _cardsPointController;
        private void Awake()
        {
            _cardsPointController = new(21);
            _gamePointsComparer = new();

            _specialPlaysController.Init();
            _cardsPositionController.Init();
            _cardsProbabilitiesController.Init();
        }
        private void Start()
        {
            _stateExecutionDictionary.Add(E_GamePhase.GAME_BET, GameBetState);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_IDLE, GameIdle);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_INITIAL_DRAW, GameInitialDrawState);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_SPECIAL_CARDS_CHECK, GameSpecialCardsCheck);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_ACTOR_GAME_PLAY, GameActorGamePlay);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_REWARD, GameReward);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_ACTOR_POINTS_COMPRASION, GameActionPointsComparer);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_BUY, GameBuy);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_PLAYER_PLAY_CARDS, OnPlayerPlayCards);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_ACTOR_SWITCH, GameSwitchActor);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_ACTOR_POINTS_CHECK_MANUAL, GameActionPointManualComparer);
            _stateExecutionDictionary.Add(E_GamePhase.GAME_RESTARTED, OnRestartedGame);
        }
        private void  OnEnable()
        {
            EventsListener.AddListener<E_GamePhase>(E_ListenerID.ON_GAME_PHASE.ToString(), OnStateChanged);
        }
        private void  OnDisable()
        {
            EventsListener.RemoveListener<E_GamePhase>(E_ListenerID.ON_GAME_PHASE.ToString(), OnStateChanged);
            EventsListener.RemoveListenerRoot(E_ListenerID.ON_GAME_PHASE.ToString());
        }
        private void  OnRestartedGame()
        {
            _spawner.OnSwitchedActor();
            _spawner.OnRestart();
            _cardsPositionController.OnRestart();
            _viewsController.OnRestart();
            SpecialCombinationsChecker.OnRestart();
            GameActorsManager.OnRestart();
            EventsListener.TriggerListener(E_ListenerID.ON_RESTART_POINTS_MODEL.ToString(), 0);
            BetUtils.DeleteBetAmount();
           
        }
        private void  OnStateChanged(E_GamePhase _phase)
        {
            if(_stateExecutionDictionary.TryGetValue(_phase,out Action _toExecute))
            {
                _toExecute?.Invoke();
            }
        }
        private void  GameIdle()
        {
            _gameActorSwitcher.SwitchActor(0);
            _viewsController.OnGameIdle();
            
        }
        private void  GameBetState()
        {
            _viewsController.OnBetState();
        }
        private void  GameInitialDrawState()
        {
            _cardsDistributor.OnInitialDrawState();
        }
        private void  GameSpecialCardsCheck()
        {
            _specialPlaysController.OnSpecialCardsCheck();
        }
        private void  GameActorGamePlay()
        {
            _viewsController.OnActorGamePlay();
            _cardsDistributor.CheckAITurn();
        }
        private void  OnPlayerPlayCards()
        {
            _spawner.InstantiateObject();
        }
        private void  GameReward()
        {
            _viewsController.OnFinishedRound();
        }
        private void  GameSwitchActor()
        {
            _viewsController.OnSwitchedActor();
            _cardsPositionController.OnSwitchedActor();
            _gameActorSwitcher.SwitchActor(1);
            _spawner.OnSwitchedActor();
            GameInitialDrawState();
        }
        private void  GameActionPointsComparer()
        {
            _gamePointsComparer.CheckAutomaticActorsState();
        }
        private void  GameActionPointManualComparer()
        {

        }
        private void  GameBuy()
        {
        }

    }

}
