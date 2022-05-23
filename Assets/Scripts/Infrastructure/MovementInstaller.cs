using Assets.Scripts.Interfaces;
using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class MovementInstaller : MonoInstaller
    {
        [SerializeField] private TouchService _touchService;
        [SerializeField] private Slider _jumpForceSlider;
        [SerializeField] private Text _scoreInfo, _coinsInfo;

        public override void InstallBindings()
        {
            BindTouchService();
            BindSliderService();
            BindScoreService();
        }

        private void BindTouchService()
        {
            Container
                .Bind<ITouchService>()
                .To<TouchService>()
                .FromComponentInHierarchy(_touchService)
                .AsSingle();

        }

        private void BindSliderService()
        {
            Container
                .Bind<Slider>()
                .FromComponentInHierarchy(_jumpForceSlider)
                .AsSingle();
        }

        private void BindScoreService()
        {
            Container
                .Bind<Text[]>()
                .FromInstance(new Text[2] { _scoreInfo, _coinsInfo})
                .AsSingle();

        }

    }
}