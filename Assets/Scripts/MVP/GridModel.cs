using UniRx;

namespace MVP
{
    public class GridModel
    {
        public ReactiveProperty<string> PlayerSide { get; }

        public GridModel()
        {
            PlayerSide = new ReactiveProperty<string>();
        }
    }
}