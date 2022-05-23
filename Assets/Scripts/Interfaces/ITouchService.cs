using System;

namespace Assets.Scripts.Interfaces
{
    public interface ITouchService
    {
        public event Action<bool> OnTouch;
    }
}
