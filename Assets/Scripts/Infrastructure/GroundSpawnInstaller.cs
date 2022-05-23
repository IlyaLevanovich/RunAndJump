using Assets.Scripts.GroundComponents;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class GroundSpawnInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _groundBlock;

        public override void InstallBindings()
        {
            Container.Bind<GameObject>().FromInstance(_groundBlock);
            Container.Bind<GroundSpawner>().AsSingle().NonLazy();

        }

    }
}