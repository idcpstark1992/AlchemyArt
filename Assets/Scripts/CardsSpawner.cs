using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CardsSpawner : MonoBehaviour
    {
        public static CardsSpawner Instance;
        public int InstantiatedCardsCounter { get; private set; }
        [SerializeField] private bool DEVELOPMENT;
        [SerializeField] private Transform  _spawnPoint;
        [SerializeField] private CardData   _cardPrefab;
        [SerializeField] private List<int>  _testCardValues;
        private List<GameObject> _instantiatedItems = new();
        private int _counter=0;
        private void Awake()
        {
            Instance = this;
        }
        public void InstantiateObject()
        {
            InstantiatedCardsCounter++;
            CardData m_toInstantiate = Instantiate(_cardPrefab);
            m_toInstantiate.transform.position = _spawnPoint.position;
            int _value = DEVELOPMENT? _testCardValues[_counter] : CardsProbabilitiesController.Instance.CheckCards(Random.Range(0.1f, 1f));
            if (DEVELOPMENT)
            {
                _counter++;
            }
            SpecialCombinationsChecker.AddNewCardToChek(_value);
            m_toInstantiate.Init(_value);
            _instantiatedItems.Add(m_toInstantiate.gameObject);
            
        }
        public void OnSwitchedActor()
        {
            
            InstantiatedCardsCounter = 0;
            
        }
        public void OnRestart()
        {
            foreach (var item in _instantiatedItems)
            {
                Destroy(item);
            }
            _instantiatedItems.Clear();
        }
    }

}
