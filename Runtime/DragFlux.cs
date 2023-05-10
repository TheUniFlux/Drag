/*
Copyright (c) 2023 Xavier Arpa López Thomas Peter ('Kingdox')

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using UnityEngine;
namespace Kingdox.UniFlux.Drag
{
    public sealed class DragFlux : MonoFlux
    {
        [SerializeField] private DragComponent drag = new()
        {
            OnDragEnterNew = DragService.Key.OnDragEnterNew.Dispatch,
            OnDragEnterOld = DragService.Key.OnDragEnterOld.Dispatch,
            OnDragEnter = DragService.Key.OnDragEnter.Dispatch,
            OnDragExitNew = DragService.Key.OnDragExitNew.Dispatch,
            OnDragExitOld = DragService.Key.OnDragExitOld.Dispatch,
            OnDragExit = DragService.Key.OnDragExit.Dispatch,
            OnInertiaNew = new Action[]
            {
                DragService.Key.OnInertiaNew_X.Dispatch,
                DragService.Key.OnInertiaNew_Y.Dispatch
            },
            OnInertiaOld = new Action[]
            {
                DragService.Key.OnInertiaOld_X.Dispatch,
                DragService.Key.OnInertiaOld_Y.Dispatch
            },
            OnInertia = new Action[]
            {
                DragService.Key.OnInertia_X.Dispatch,
                DragService.Key.OnInertia_Y.Dispatch
            },
            OnSnapNew = new Action[]
            {
                DragService.Key.OnSnapNew_X.Dispatch,
                DragService.Key.OnSnapNew_Y.Dispatch
            },
            OnSnapOld = new Action[]
            {
                DragService.Key.OnSnapOld_X.Dispatch,
                DragService.Key.OnSnapOld_Y.Dispatch
            },
            OnSnap = new Action[]
            {
                DragService.Key.OnSnap_X.Dispatch,
                DragService.Key.OnSnap_Y.Dispatch
            },
            OnInertiaSnap = new Action[]
            {
                DragService.Key.OnInertiaSnap_X.Dispatch,
                DragService.Key.OnInertiaSnap_Y.Dispatch
            }
        };
        private void Update() => drag.Update();
    }
}