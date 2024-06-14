using System;

namespace uPalette.Runtime.Foundation.TinyRx
{
    public sealed class AnonymousDisposable : IDisposable
    {
        private readonly Action _dispose;

        public AnonymousDisposable(Action dispose)
        {
            _dispose = dispose;
        }

        public void Dispose()
        {
            _dispose?.Invoke();
        }
    }
}
