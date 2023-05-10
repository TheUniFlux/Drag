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
namespace Kingdox.UniFlux.Drag
{
    public static partial class DragService // Data
    {
        internal static partial class Data
        {
            internal const string X = "X";
            internal const string Y = "Y";
            internal static readonly string[] AXIS = new string[]
            {
                X,
                Y
            };
        }
    }
    public static partial class DragService // Key
    {
        public static partial class Key
        {
            private const string K =  nameof(Drag) + ".";
            public const string OnDragEnterNew = K + nameof(OnDragEnterNew);
            public const string OnDragEnterOld = K + nameof(OnDragEnterOld);
            public const string OnDragEnter = K + nameof(OnDragEnter);
            public const string OnDragExitNew = K + nameof(OnDragExitNew);
            public const string OnDragExitOld = K + nameof(OnDragExitOld);
            public const string OnDragExit = K + nameof(OnDragExit);
            public const string OnInertiaNew_X = K + nameof(OnInertiaNew_X) + Data.X;
            public const string OnInertiaNew_Y = K + nameof(OnInertiaNew_Y) + Data.Y;
            public const string OnInertiaOld_X = K + nameof(OnInertiaOld_X) + Data.X;
            public const string OnInertiaOld_Y = K + nameof(OnInertiaOld_Y) + Data.Y;
            public const string OnInertia_X = K + nameof(OnInertia_X) + Data.X;
            public const string OnInertia_Y = K + nameof(OnInertia_Y) + Data.Y;
            public const string OnSnapNew_X = K + nameof(OnSnapNew_X) + Data.X;
            public const string OnSnapNew_Y = K + nameof(OnSnapNew_Y) + Data.Y;
            public const string OnSnapOld_X = K + nameof(OnSnapOld_X) + Data.X;
            public const string OnSnapOld_Y = K + nameof(OnSnapOld_Y) + Data.Y;
            public const string OnSnap_X = K + nameof(OnSnap_X) + Data.X;
            public const string OnSnap_Y = K + nameof(OnSnap_Y) + Data.Y;
            public const string OnInertiaSnap_X = K + nameof(OnInertiaSnap_X) + Data.X;
            public const string OnInertiaSnap_Y = K + nameof(OnInertiaSnap_Y) + Data.Y;
        }
    }
    public static partial class DragService // Methods
    {
    }
}