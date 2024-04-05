using UnityEngine;
using UniRx;
using Data;
using TMPro;
using UnityEngine.UI;
using Commons;

namespace UI
{
    public class ViewSoulsPool : MonoBehaviour
    {
        [SerializeField] private Button _btnSetBet;
        [SerializeField] private Button _buttonPlus10;
        [SerializeField] private Button _buttonMinus10;
        [SerializeField] private Button _buttonPlus1;
        [SerializeField] private Button _buttonMinus1;
        [SerializeField] private GameObject _uiPanel;

        [SerializeField] private TextMeshProUGUI _printBetAmount;
        [SerializeField] private TextMeshProUGUI _printPlayerSoulsAmount;
        [SerializeField] private Marketplace     _marketPlace;
        private SoulsModel      _soulsModel;
        private SoulsViewModel  _soulsViewModel;
        
        private bool _resetFlag;
        private void Awake()
        {
            _soulsModel = new(20);
            _soulsViewModel = new(_soulsModel);
            _soulsViewModel.Data.Subscribe(GetTotalSoulsData);
            _soulsViewModel.BlockBetButtons.Subscribe(BlockButtons);
            _soulsViewModel.CurrentBetData.Subscribe(GetModifiedBet);
        }
        private void Start()
        {
            _btnSetBet.onClick.AddListener(SetBet);
            _buttonPlus10.onClick.AddListener(delegate { SetBetAmount(10); }) ;
            _buttonMinus10.onClick.AddListener(delegate { SetBetAmount(-10); }) ;
            _buttonPlus1.onClick.AddListener(delegate { SetBetAmount(1); }) ;
            _buttonMinus1.onClick.AddListener(delegate { SetBetAmount(-1); }) ;
            _resetFlag = true;
            _uiPanel.transform.localScale = Vector3.zero;
            SetBetAmount(1);
        }

        private void GetModifiedBet(int _data)
        {
            _printBetAmount.SetText(_data.ToString());
        }

        private void GetTotalSoulsData(int _data) 
        {
            _printPlayerSoulsAmount.SetText(_data.ToString());
            _marketPlace.SetSoulsCounter(_data);
        } 
        private void BlockButtons(ContextBlockButtons _context)
        {
            _buttonPlus1.interactable = _context._plus1;
            _buttonPlus10.interactable = _context._plus10;
            _buttonMinus1.interactable = _context._minus1;
            _buttonMinus10.interactable = _context._minus10;
        }
        private void SetBet() 
        {
            _resetFlag = true;
            _soulsViewModel.SetBet();
            HidePanel();
        }
        private void SetBetAmount(int _betamount)
        {
            if (_resetFlag)
            {
                _resetFlag = false;
                _soulsViewModel.ResetBetAmount();
            }
            _soulsViewModel.SetBetAmount(_betamount);
        }
        private void OpenPanel()
        {
            LeanTween.scale(_uiPanel, Vector3.one, .3f).setEaseOutCirc();
        }
        private void HidePanel()
        {
            LeanTween.scale(_uiPanel, Vector3.zero, .3f).setEaseInCirc().setOnComplete(OnFinishedAnimation);
        }
        private void OnFinishedAnimation()
        {
            EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(), E_GamePhase.GAME_INITIAL_DRAW);
        }
        public void  OpenHidePanel(bool _bool)
        {
            if (_bool)
            {
                OpenPanel();
            }
            else
            {
                HidePanel();
            }
        }
        public void OnRestarted()
        {
            SetBetAmount(1);
        }
    }
    

}
