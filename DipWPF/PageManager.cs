using System.Windows.Controls;

namespace DipWPF
{
    public static class PageManager
    {
        private static Frame _frameMain;

        public static Frame FrameMain
        {
            get => _frameMain;
            set => _frameMain = value;
        }

        private static Frame _frameLogin;

        public static Frame FrameLogin
        {
            get => _frameMain;
            set => _frameMain = value;
        }
    }
}
