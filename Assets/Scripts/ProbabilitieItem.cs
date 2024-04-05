using Commons;

namespace Controllers
{
    public class ProbabilitieItem : ICommitedCircunstance
    {
        private readonly float _minRange;
        private readonly float _maxRange;
        public ProbabilitieItem(float _minimunRange , float _maximunRange)
        {
            _minRange = _minimunRange;
            _maxRange = _maximunRange;
        }
        public bool IsTrue(float _seed)=> _seed >= _minRange && _seed <= _maxRange;
    }

}
