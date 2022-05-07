
using Asteroids.Common;
using Asteroids.Effect;
using Asteroids.Enemies;
using Asteroids.GameLogic;
using Asteroids.Statistics;

namespace Asteroids.Test2
{
    //public interface IMoveController {
    //    void Move();
    //}

    //public interface IMover
    //{
    //}
    //public class Enemy
    //{
    //    private IMoveController _moveController;
    //    private HitDetector hitDetector;
    //    private string deathActions;

    //    public void Move()
    //    {
    //        _moveController.Move();
    //    }

    //    public Enemy(IMoveController moveController, HitDetector hitDetector) { }
    //}
    //public class Asteroid : Enemy
    //{
    //    public Asteroid(IMoveController moveController, HitDetector hitDetector, IDestroyAction[] destroyActions) : base(moveController, hitDetector)
    //    {
    //    }
    //}
    //public class Ufo : Enemy
    //{
    //    public Ufo(IMoveController moveController, HitDetector hitDetector, IDestroyAction[] destroyActions) : base(moveController, hitDetector)
    //    {
    //    }
    //}

    //public class AsteroidFactory : IEnemyFactory<Asteroid>
    //{
    //    private IEffectsManager _effectsManager;
    //    private IEnemyFactory _enemyFactory;
    //    private IPlayerStat _playerStat;
    //    public AsteroidFactory(IEffectsManager effectsManager, IEnemyFactory enemyFactory, IPlayerStat playerStat)
    //    {
    //        _effectsManager = effectsManager;
    //        _enemyFactory = enemyFactory;
    //        _playerStat = playerStat;
    //    }
    //    public Asteroid Get()
    //    {
    //        var mover = new SimpleMover();
    //        var moveController = new MoveController(mover);
    //        var hitDetector = new HitDetector(GroupType.Enemy);
    //        var destroyActions = new IDestroyAction[]
    //        {
    //            new CreateEnemy(EnemyType.asteroidShard), 
    //            new ParticleAction(EffectType.DeathBig), 
    //            new StatAction(StatType.DestroyAsteroid)
    //        };
    //        return new Asteroid(moveController, hitDetector, destroyActions);
    //    }
    //}

    //public class UfoFactory
    //{
    //    public Ufo Get()
    //    {
    //        var mover = new TargetMover();
    //        var moveController = new TargetMoveController(mover);
    //        var hitDetector = new HitDetector(GroupType.Enemy);
    //        var destroyActions = new IDestroyAction[]
    //        {
    //            new ParticleAction(EffectType.DeathMiddle), 
    //            new StatAction(StatType.DestroyUfo)
    //        };
    //        return new Ufo(moveController, hitDetector, destroyActions);
    //    }
    //}

    //public class CreateEnemy : IDestroyAction
    //{
    //    public CreateEnemy(EnemyType enemyType)
    //    {

    //    }
    //}

    //public class ParticleAction : IDestroyAction
    //{
    //    public ParticleAction(EffectType effectType)
    //    {

    //    }
    //}

    //public class StatAction : IDestroyAction
    //{
    //    public StatAction(StatType statType)
    //    {

    //    }
    //}

    //public interface IDestroyAction
    //{

    //}

    //public class Player
    //{

    //}

    //public class TargetMoveController: IMoveController
    //{
    //    public TargetMoveController(IMover mover)
    //    {

    //    }

    //    public void Move()
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public class MoveController : IMoveController
    //{
    //    public MoveController(IMover mover)
    //    {

    //    }

    //    public void Move()
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public class HitDetector
    //{
    //    public HitDetector(GroupType groupType) { }
    //}
    //public class SimpleMover : IMover { }
    //public class TargetMover : IMover { }
}