using Commons;
using Controllers;
using UniRx;
using UnityEngine;

namespace Data
{
    public struct ContextBlockButtons
    {
        public bool _plus10;
        public bool _plus1;
        public bool _minus1;
        public bool _minus10;
    }
    public class SoulsViewModel
    {
        private int _betValue;
        private ContextBlockButtons _contextButtons;
        private readonly SoulsModel _soulsmodel;

        private readonly ReactiveProperty<int> _data = new();
        private readonly ReactiveProperty<int> _currentBetData = new();
        private readonly ReactiveProperty<ContextBlockButtons> _blockBetButtons = new();
        public IReadOnlyReactiveProperty<int> Data => _data;
        public IReadOnlyReactiveProperty<ContextBlockButtons> BlockBetButtons => _blockBetButtons;
        public IReadOnlyReactiveProperty<int> CurrentBetData => _currentBetData;

        public SoulsViewModel(SoulsModel _model)
        {
            _contextButtons = new()
            {
                _plus1 = true,
                _plus10 = true,
                _minus1 = true,
                _minus10 = true
            };
            _currentBetData.Value = 0;
            _blockBetButtons.Value = _contextButtons;
            _soulsmodel = _model;
            _soulsmodel.Data.Subscribe(GetData);
            EventsListener.AddListener<int>(E_ListenerID.ON_PLAYER_WIN.ToString(), SetPlayerReward);
        }
        private void   OnDisable()
        {
            EventsListener.RemoveListener<int>(E_ListenerID.ON_PLAYER_WIN.ToString(), SetPlayerReward);
        }     
        public void    GetData(int _datain)
        {
            _data.Value = _datain;
            BetUtils.SetPlayerSoulsAmount(_data.Value);
        }
        public void    ResetBetAmount()
        {
            _betValue = 0;
            _currentBetData.Value = _betValue;
        }
        public void    SetBetAmount(int _bet)
        {
            _betValue = Mathf.Clamp(_betValue + _bet, 1, _data.Value);
            CheckButtonConditions(_betValue);
            _currentBetData.Value = _betValue;
        }
        private void   CheckButtonConditions(int _value)
        {
            if (_value>0 && _value < _data.Value)
            {
                _contextButtons._plus1      = true;
                _contextButtons._minus1     = true;
                _contextButtons._minus10    = true;
                _contextButtons._plus10     = true;
            }
            if (_value >= _data.Value)
            {
                _contextButtons._plus1 = false;
                _contextButtons._minus1 = true;
                _contextButtons._minus10 = true;
                _contextButtons._plus10 = false;
            }
            if (_value < 1)
            {
                _contextButtons._plus1 = true;
                _contextButtons._minus1 = false;
                _contextButtons._minus10 = false;
                _contextButtons._plus10 = true;
            }
            _blockBetButtons.Value = _contextButtons;
        }
        public void    SetBet() 
        { 
            _soulsmodel.OnDataChanged(_data.Value - _betValue);
            BetUtils.SetBetAmount(_betValue);
        }
        public void    SetPlayerReward(int _rewardMultipler)
        {
            int m_totalAmount = _data.Value + (BetUtils.CurrentBetAmount * _rewardMultipler);
            _soulsmodel.OnDataChanged(m_totalAmount);
            BetUtils.DeleteBetAmount();
        }
    }
}
