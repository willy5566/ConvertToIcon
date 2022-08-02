using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToIcon
{
    public static class WindowMouse
    {
        #region 滑鼠操作
        //首先定義一個列舉，其繼承uint。這樣可以直觀的體現滑鼠的各類動作。
        //[Flags]位標誌屬性，從而使該列舉型別的例項可以儲存列舉列表中定義值的任意組合。可以用 與(&)、或(|)、異或(^)進行相應的運算。
        [Flags]
        public enum MouseEventFlag : uint //設定滑鼠動作的鍵值
        {
            Move = 0x0001,               //發生移動
            LeftDown = 0x0002,           //滑鼠按下左鍵
            LeftUp = 0x0004,             //滑鼠鬆開左鍵
            RightDown = 0x0008,          //滑鼠按下右鍵
            RightUp = 0x0010,            //滑鼠鬆開右鍵
            MiddleDown = 0x0020,         //滑鼠按下中鍵
            MiddleUp = 0x0040,           //滑鼠鬆開中鍵
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,              //滑鼠輪被移動
            VirtualDesk = 0x4000,        //虛擬桌面
            Absolute = 0x8000
        }
        //設定滑鼠位置
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        //設定滑鼠按鍵和動作
        [DllImport("user32.dll")]
        public static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        //方法：滑鼠左鍵單擊操作：滑鼠左鍵按下和鬆開兩個事件的組合即一次單擊
        public static void MouseLeftClickEvent(int dx, int dy, uint data)
        {
            SetCursorPos(dx, dy);
            System.Threading.Thread.Sleep(2 * 1000);
            mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.LeftUp, dx, dy, data, UIntPtr.Zero);
        }
        //方法：滑鼠右鍵單擊操作：滑鼠右鍵鍵按下和鬆開兩個事件的組合即一次單擊
        public static void MouseRightClickEvent(int dx, int dy, uint data)
        {
            SetCursorPos(dx, dy);
            System.Threading.Thread.Sleep(2 * 1000);
            mouse_event(MouseEventFlag.RightDown | MouseEventFlag.RightUp, dx, dy, data, UIntPtr.Zero);
        }

        #endregion

        #region 控制程式碼函式

        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        //獲得視窗的控制程式碼
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //獲得子視窗、子控制元件的控制程式碼；需要提前知道父窗體的控制程式碼，以及視窗的類名或者標題名。
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        //該函式返回指定視窗的邊框矩形的尺寸。該尺寸以相對於螢幕座標左上角的螢幕座標給出
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, out Rect rect);
        #endregion
    }
}
