namespace Controllers
{
    public class CardsPointsController
    {

        public int PlayerPoints => _playerTotalPoints;
        public int AIPoints => _aiTotalPoint;

        private int _MaxPointsPerRound;
        private int _totalPoints    = 0;
        private int _aiTotalPoint   = 0;
        private int _playerTotalPoints = 0;
        


        public CardsPointsController(int _maxPoints)
        {
            _MaxPointsPerRound = _maxPoints;
        }   

        public void ResetTotalPointsCounter()
        {
            _totalPoints = 0;
        }
        public void AddPointsToCounter(int _points)
        {


        }
    }

}
