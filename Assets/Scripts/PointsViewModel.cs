using Commons;
using Data;
using UniRx;
public class PointsViewModel
{
    private readonly PointsModel           _pointsModel;

    private readonly ReactiveProperty<int> _data = new();
    public  IReadOnlyReactiveProperty<int> Data => _data;

    public PointsViewModel(PointsModel _model)
    {
        _data.Skip(1);
        _pointsModel = _model;
        _pointsModel.Data.Subscribe(OnGetData);
    }
    public void OnGetData(int _datain)
    {
        _data.Value = _datain;

        GameActorsManager.AddActorsPoints(_datain);
        EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(), E_GamePhase.GAME_ACTOR_POINTS_COMPRASION);
        
    }
}
