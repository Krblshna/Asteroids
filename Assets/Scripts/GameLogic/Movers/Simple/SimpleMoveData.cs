namespace Asteroids.GameLogic.Movers
{
    public class SimpleMoveData
    {
        public float MinStartVelocity { get; }
        public float MaxStartVelocity { get; }
        public float MinRotation { get; }
        public float MaxRotation { get; }

        public SimpleMoveData(float minStartVelocity, float maxStartVelocity, float minRotation, float maxRotation)
        {
            MinStartVelocity = minStartVelocity;
            MaxStartVelocity = maxStartVelocity;
            MinRotation = minRotation;
            MaxRotation = maxRotation;
        }
    }
}