using UniRx;
namespace Data
{
    public class SoulsModel
    {
        private int _soulsAmount;
        private readonly ReactiveProperty<int> _data = new();
        public IReadOnlyReactiveProperty<int> Data => _data;
        public SoulsModel(int _amount)
        {
            _soulsAmount = _amount;
            _data.Value = _soulsAmount;
        }
        public void OnDataChanged(int _datain)
        {   
            _soulsAmount = _datain;
            _data.Value  = _soulsAmount;
        }
    }
   

}
