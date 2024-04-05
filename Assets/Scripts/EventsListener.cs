using System;
using System.Collections.Generic;

namespace Commons
{
    public class EventsListener
    {
        private static Dictionary<string, List<Delegate>> eventDictionary = new();
        public static void AddListener<T>(string _EventID, Action<T> _listener)
        {
            if (!eventDictionary.ContainsKey(_EventID))
            {
                List<Delegate> m_list = new() { _listener };
                eventDictionary.Add(_EventID, m_list);
            }
            else if (eventDictionary.TryGetValue(_EventID, out _))
            {
                eventDictionary[_EventID].Add(_listener);
            }
        }
        public static void RemoveListener<T>(string _EventID, Action<T> _listener)
        {
            if (eventDictionary.TryGetValue(_EventID, out List<Delegate> _outValue))
                _outValue.Remove(_listener);
        }
        public static void RemoveListenerRoot(string _EventID)
        {
            if (eventDictionary.ContainsKey(_EventID))
                eventDictionary.Remove(_EventID);
        }
        public static void TriggerListener<T>(string _EventID, T _eventData)
        {
            if (eventDictionary.TryGetValue(_EventID, out List<Delegate> _actions))
            {
                for (int i = 0; i < _actions.Count; i++)
                {
                    if (_actions[i] is Action<T> listener)
                    {
                        listener?.Invoke(_eventData);
                    }
                }
            }
        }
    }
}

