﻿using System;
using uPalette.Editor.Core.Shared;
using uPalette.Runtime.Core;
using uPalette.Runtime.Foundation.TinyRx;

namespace uPalette.Editor.Core.PaletteEditor
{
    internal sealed class PaletteEditorWindowEmptyViewController : IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private readonly PaletteEditorWindowEmptyView _view;

        public PaletteEditorWindowEmptyViewController(PaletteEditorWindowEmptyView view)
        {
            _view = view;
            _view.CreateButtonClickedAsObservable.Subscribe(_ =>
            {
                if (PaletteStore.LoadAsset() == null)
                    PaletteStore.CreateAsset(UPaletteProjectSettings.instance.AutomaticRuntimeDataLoading);
                else
                    throw new InvalidOperationException($"{nameof(PaletteStore)} already exists.");
            }).DisposeWith(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
