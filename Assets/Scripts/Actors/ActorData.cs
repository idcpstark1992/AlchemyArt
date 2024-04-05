using Commons;

namespace Data
{
    public class ActorData
    {
        public E_Actors ActorType { get; }
        public int ActorPoints { get; private set; }
        public bool CanPlay { get; private set; }
        public ActorData(E_Actors _actorType)
        {
            ActorType = _actorType;
            ActorPoints = 0;
        }
        public void SetActorPoints(int _increaseAmount)
        {
            ActorPoints = _increaseAmount;
        }
        public void SetActorDisponibility(bool _data)
        {
            CanPlay = _data;
        }
        
    }

}
