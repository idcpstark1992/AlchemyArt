using UnityEngine;

namespace Controllers
{
    public class CardsProbabilitiesController : MonoBehaviour
    {
        public  static CardsProbabilitiesController Instance { get; private set; }

        [SerializeField] private ProbabilitieItem _asCard;
        [SerializeField] private ProbabilitieItem _kingCard;
        [SerializeField] private ProbabilitieItem _commonCard;

        public void Init()
        {
            Instance = this;
            _asCard = new(0.1f, .019f);
            _kingCard = new(.07f, .25f);
            _commonCard = new(.25f, 1);
        }
        public int CheckCards(float _seedNumber)
        {
            if (_asCard.IsTrue(_seedNumber))
                return 1;

            if (_kingCard.IsTrue(_seedNumber))
                return 11;

            if (_commonCard.IsTrue(_seedNumber))
                return Random.Range(2, 10);

            return 0;
        }
    }

}
