using Commons;
using System.Collections.Generic;

namespace Controllers
{
    public static class SpecialCombinationsChecker 
    {
        private static Dictionary<string, E_SpecialCombination> _eventNameToTrigger = new();
        private static List<string> _eventNames = new();
        public static void Init()
        {
            _eventNameToTrigger.Add("22", E_SpecialCombination.PATITOS);
            _eventNameToTrigger.Add("111", E_SpecialCombination.RELANCINA);
            _eventNameToTrigger.Add("NONE", E_SpecialCombination.NONE);
        }
        public static void AddNewCardToChek (int _cardValue)
        {
            _eventNames.Add(_cardValue.ToString());
        }
        public static E_SpecialCombination CheckForPlays()
        {
            string m_Key = "";
            for (int i = 0; i < _eventNames.Count; i++)
                m_Key += _eventNames[i].ToString();

            if (!_eventNameToTrigger.ContainsKey(m_Key))
                return E_SpecialCombination.NONE;

            return _eventNameToTrigger[m_Key];
        }
        public  static void OnRestart()
        {
            _eventNames.Clear();
        }
        
    }

}
