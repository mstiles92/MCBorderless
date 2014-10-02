using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCBorderless {
    class FullscreenManager {
        public static int GWL_STYLE = -16;
        public static int WS_BORDER = 8388608;
        public static int WS_DLGFRAME = 4194304;
        public static int WS_THICKFRAME = 262144;
        public static int WS_CAPTION = WS_BORDER | WS_DLGFRAME | WS_THICKFRAME;

        private static bool isFullscreen = false;
        private static int originalX = -1;
        private static int originalY = -1;
        private static int originalWidth = -1;
        private static int originalHeight = -1;
        private static int originalWindowLong = -1;

        /*
         * Get the process for the main Minecraft window.
         */
        private static Process getMinecraftProcess() {
            Config config = Config.loadFromRegistry();
            Process[] processes = Process.GetProcessesByName("javaw");
            foreach (Process p in processes) {
                string windowTitle = p.MainWindowTitle;
                if (containsAny(windowTitle, config.WindowTitleContents) && !containsAny(windowTitle, config.WindowTitleExclusions)) {
                    return p;
                }
            }
            return null;
        }

        /*
         * Check that the string value supplied does not contain any of the listed substrings.
         */
        private static bool containsAny(string value, string[] list) {
            foreach (string s in list) {
                if (value.Contains(s)) {
                    return true;
                }
            }
            return false;
        }

        /*
         * Toggle the fullscreen status of the main Minecraft process.
         */
        public static void toggleFullscreen() {
            if (isFullscreen) {
                setWindowed();
            } else {
                setFullscreen();
            }
        }

        /**
         * Set the main Minecraft process to fullscreen.
         */
        public static void setFullscreen() {
            Process process = getMinecraftProcess();
            if (process != null) {
                Rectangle rect = new Rectangle();
                GetWindowRect(process.MainWindowHandle, ref rect);
                originalX = rect.Left;
                originalY = rect.Top;
                originalWidth = rect.Width - rect.Left; // Right -> Width
                originalHeight = rect.Height - rect.Top; // Bottom -> Height

                SetForegroundWindow(process.MainWindowHandle);
                originalWindowLong = GetWindowLong(process.MainWindowHandle, GWL_STYLE);
                SetWindowLong(process.MainWindowHandle, GWL_STYLE, originalWindowLong & ~WS_CAPTION);
                Screen screen = getScreenWithLargestIntersect(new Rectangle(originalX, originalY, originalWidth, originalHeight));
                SetWindowPos(process.MainWindowHandle, IntPtr.Zero, screen.Bounds.Left, screen.Bounds.Top, screen.Bounds.Width, screen.Bounds.Height, SetWindowPosFlags.ShowWindow);

                isFullscreen = true;
            }
        }

        private static Screen getScreenWithLargestIntersect(Rectangle windowBounds) {
            Screen largest = Screen.PrimaryScreen;
            int largestArea = 0;

            foreach (Screen s in Screen.AllScreens) {
                Rectangle intersect = Rectangle.Intersect(s.Bounds, windowBounds);
                int intersectArea = intersect.Width * intersect.Height;

                if (intersectArea > largestArea) {
                    largestArea = intersectArea;
                    largest = s;
                }
            }

            return largest;
        }

        /*
         * Set the main Minecraft process to windowed.
         */
        public static void setWindowed() {
            Process process = getMinecraftProcess();
            if (process != null) {
                SetForegroundWindow(process.MainWindowHandle);
                SetWindowLong(process.MainWindowHandle, GWL_STYLE, originalWindowLong);
                SetWindowPos(process.MainWindowHandle, IntPtr.Zero, originalX, originalY, originalWidth, originalHeight, SetWindowPosFlags.ShowWindow);
                
                isFullscreen = false;
            }
        }

        [Flags]
        public enum SetWindowPosFlags : uint {
            IgnoreResize = 1,
            IgnoreMove = 2,
            IgnoreZOrder = 4,
            DoNotRedraw = 8,
            DoNotActivate = 16,
            DrawFrame = 32,
            FrameChanged = 32,
            ShowWindow = 64,
            HideWindow = 128,
            DoNotCopyBits = 256,
            DoNotReposition = 512,
            DoNotChangeOwnerZOrder = 512,
            DoNotSendChangingEvent = 1024,
            DeferErase = 8192,
            SynchronousWindowPosition = 16384
        }

        [DllImport("user32.dll", CharSet = CharSet.None)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.None)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.None)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.None)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [DllImport("user32.dll", CharSet = CharSet.None)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle rect);
    }
}
