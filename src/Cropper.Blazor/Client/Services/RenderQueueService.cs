﻿using Cropper.Blazor.Client.Components.Docs;

namespace Cropper.Blazor.Client.Services
{
    public interface IRenderQueueService
    {
        int Capacity { get; }

        void Enqueue(QueuedContent component);
        Task WaitUntilEmpty();
        void Clear();
    }

    public class RenderQueueService : IRenderQueueService
    {
        private Queue<QueuedContent> _queue = new();
        private TaskCompletionSource _tcs;

        public int Capacity { get; init; }

        public RenderQueueService()
        {
            Capacity = 3;
        }

        public void Clear()
        {
            lock (_queue)
            {
                _queue.Clear();
                _tcs?.TrySetResult();
                _tcs = null;
            }
        }

        void IRenderQueueService.Enqueue(QueuedContent component)
        {
            bool renderImmediately = false;
            lock (_queue)
            {
                renderImmediately = _queue.Count == 0;
                _queue.Enqueue(component);
                component.Rendered += OnComponentRendered;
                component.Disposed += OnComponentDisposed;
            }
            if (renderImmediately)
                component.Render();
        }

        private async void RenderNext()
        {
            QueuedContent componentToRender = null;
            lock (_queue)
            {
                while (_queue.Count > 0)
                {
                    var component = _queue.Dequeue();
                    if (component.IsDisposed || component.IsRendered)
                    {
                        component.Rendered -= OnComponentRendered;
                        component.Disposed -= OnComponentDisposed;
                        continue;
                    }
                    componentToRender = component;
                    break;
                }
                if (componentToRender == null)
                {
                    _tcs?.TrySetResult();
                    _tcs = null;
                    return;
                }
            }
            await Task.Delay(1);
            componentToRender.Render();
        }

        private void OnComponentRendered(QueuedContent component)
        {
            RenderNext();
        }

        private void OnComponentDisposed(QueuedContent component)
        {
            RenderNext();
        }

        public Task WaitUntilEmpty()
        {
            lock (_queue)
            {
                if (_queue.Count == 0)
                    return Task.CompletedTask;
                if (_tcs == null)
                    _tcs = new TaskCompletionSource();
                return _tcs.Task;
            }
        }
    }
}
