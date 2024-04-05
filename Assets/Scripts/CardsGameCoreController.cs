using UnityEngine;

namespace Controllers
{
    public class CardsGameCoreController :  MonoBehaviour
    {
        private  CardsPointsController  _cardsPointsController;
        public void Init()
        {
            _cardsPointsController  = new(21);
        }
    }
}

