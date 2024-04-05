using UniRx;
using Commons;

public class PointsModel
{
    private int _points;
    private readonly ReactiveProperty<int> _data = new();
    public IReadOnlyReactiveProperty<int> Data => _data;
    public PointsModel() 
    {
        _data.Skip(1);
        EventsListener.AddListener<int>(E_ListenerID.ON_FINISHED_CARD_TWEEN.ToString(), OnDataChanged);
        EventsListener.AddListener<int>(E_ListenerID.ON_RESTART_POINTS_MODEL.ToString(), OnRestartPointsModel);
    }
    public void OnDestroy()
    {
        EventsListener.RemoveListener<int>(E_ListenerID.ON_FINISHED_CARD_TWEEN.ToString(), OnDataChanged);
        EventsListener.AddListener<int>(E_ListenerID.ON_RESTART_POINTS_MODEL.ToString(), OnRestartPointsModel);

        EventsListener.RemoveListenerRoot(E_ListenerID.ON_FINISHED_CARD_TWEEN.ToString());
        EventsListener.RemoveListenerRoot(E_ListenerID.ON_RESTART_POINTS_MODEL.ToString());
    }
    private void OnDataChanged(int _datain)
    {
        _points += _datain;
        _data.Value = _points;
    }
    private void OnRestartPointsModel(int _dataf)
    {
        _data.Value = 0;
        _points = 0;
    }
}
