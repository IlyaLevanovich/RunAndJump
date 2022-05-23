using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private GameObject _player;

        public override void InstallBindings()
        {
            var player = Container
                .InstantiatePrefabForComponent<SpriteRenderer>(_player, _startPoint.position, Quaternion.identity, null);

            Container
                .Bind<SpriteRenderer>()
                .FromInstance(player)
                .AsSingle();
        }
    }
}