using System;

namespace uPalette.Runtime.Foundation.TinyRx
{
    public static class DisposableExtensions
    {
        public static void DisposeWith(this IDisposable self, CompositeDisposable compositeDisposable)
        {
            compositeDisposable.Add(self);
        }
    }
}