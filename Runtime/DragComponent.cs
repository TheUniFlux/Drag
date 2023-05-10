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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdox.UniFlux.Drag
{
    [Serializable] public class DragComponent
    {
        [Header("Settings")]
        [Space]
        public bool isClickEnable = false;
        public Vector2 limitInertiaToSnap;
        public Vector2 inertiaDamping;
        public Vector2 inertiaImpulse;
        public Vector2 rotateSpeed;

        [Header("Debug")]
        [Space]
        public bool isClicking = false;
        public Vector2 inertiaVelocity;
        public Vector2 previousMousePosition;
        public Vector2 rotationDelta;
        public Vector2 isInertia;
        public Vector2 isSnap;
        public Action OnClickEnterNew = default;
        public Action OnClickEnterOld = default;
        public Action OnClickEnter = default;
        public Action OnClickExitNew = default;
        public Action OnClickExitOld = default;
        public Action OnClickExit = default;
        public Action OnDragEnterNew = default;
        public Action OnDragEnterOld = default;
        public Action OnDragEnter = default;
        public Action OnDragExitNew = default;
        public Action OnDragExitOld = default;
        public Action OnDragExit = default;
        public Action[] OnInertiaNew = new Action[DragService.Data.AXIS.Length];
        public Action[] OnInertiaOld = new Action[DragService.Data.AXIS.Length];
        public Action[] OnInertia = new Action[DragService.Data.AXIS.Length];
        public Action[] OnSnapNew = new Action[DragService.Data.AXIS.Length];
        public Action[] OnSnapOld = new Action[DragService.Data.AXIS.Length];
        public Action[] OnSnap = new Action[DragService.Data.AXIS.Length];
        public Action[] OnInertiaSnap = new Action[DragService.Data.AXIS.Length];
        private Vector2 MousePosition 
        {
            get 
            {             
                #if UNITY_EDITOR
                return Input.mousePosition;
                #elif UNITY_ANDROID
                return Input.touchCount.Equals(1) ? Input.touches[0].position : Vector2.zero;
                #else
                return Input.mousePosition;
                #endif
            }
        }
        private bool MouseButton  
        {
            get
            {
                #if UNITY_EDITOR
                return Input.GetMouseButton(0);
                #elif UNITY_ANDROID
                return Input.touchCount.Equals(1);
                #else
                return Input.GetMouseButton(0);
                #endif
            }
        }
        public void Update()
        {
            _UpdateClick();
        }
        private void _UpdateClick()
        {
            if (MouseButton && (isClickEnable || isClicking))
            {
                if (!isClicking)
                {
                    isClicking = true;
                    OnClickEnterNew?.Invoke();
                    _OnClickEnterNew();
                }
                else
                {
                    OnClickEnterOld?.Invoke();
                    _OnClickEnterOld();
                }
                OnClickEnter?.Invoke();
                _OnClickEnter();
            }
            else
            {
                if (isClicking)
                {
                    isClicking = false;
                    OnClickExitNew?.Invoke();
                    _OnClickExitNew();
                }
                else
                {
                    OnClickExitOld?.Invoke();
                    _OnClickExitOld();
                }
                OnClickExit?.Invoke();
                _OnClickExit();
            }
        }

        private void _OnClickEnterNew()
        {
            previousMousePosition = Input.mousePosition;
            isInertia = Vector2.zero;
            isSnap = Vector2.zero;
            OnDragEnterNew?.Invoke();
        }
        private void _OnClickEnterOld()
        {
            rotationDelta = (MousePosition - previousMousePosition) * rotateSpeed;
            previousMousePosition = Input.mousePosition;
            OnDragEnterOld?.Invoke();
        }
        private void _OnClickEnter()
        {
            inertiaVelocity = Vector2.zero; // Reset inertia velocity when dragging
            OnDragEnter?.Invoke();
        }
        private void _OnClickExitNew()
        {
            for (int i = 0; i < 2; i++) 
            {
                inertiaImpulse[i] *= rotationDelta[i];
            }
            inertiaVelocity = inertiaImpulse;
            OnDragExitNew?.Invoke();
        }
        private void _OnClickExitOld()
        {
            OnDragExitOld?.Invoke();
        }
        private void _OnClickExit()
        {
            //Por separado
            for (int i = 0; i < DragService.Data.AXIS.Length; i++)
            {
                //Hay Fuerza por Inercia?
                // if (inertiaVelocity[i].Positive() >= limitInertiaToSnap[i])
                if ((inertiaVelocity[i] * inertiaVelocity[i] >= 0 ? 1 : -1) >= limitInertiaToSnap[i])
                {
                    if(isInertia[i].Equals(0))
                    {
                        isInertia[i] = 1;
                        OnInertiaNew[i]?.Invoke();
                    }
                    else
                    {
                        OnInertiaOld[i]?.Invoke();
                    }

                    // Apply inertia
                    inertiaVelocity[i] = Mathf.MoveTowards(inertiaVelocity[i], 0, Time.deltaTime * inertiaDamping[i]);
                    OnInertia[i]?.Invoke();
                }
                else
                {
                    if(isSnap[i].Equals(0))
                    {
                        isSnap[i] = 1;
                        OnSnapNew[i]?.Invoke();
                    }
                    else
                    {
                        OnSnapOld[i]?.Invoke();
                    }

                    // Snap to target element
                    OnSnap[i]?.Invoke();
                }

                inertiaVelocity[i] = Mathf.Lerp(inertiaVelocity[i], 0, Time.deltaTime * inertiaDamping[i]);
                OnInertiaSnap[i]?.Invoke();
            }
            OnDragExit?.Invoke();
        }
    }
}