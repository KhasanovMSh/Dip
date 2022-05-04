using System.Windows.Controls;

namespace Dip
{
    public static class PageManager
    {
        private static Frame _frameMain;

        public static Frame FrameMain
        {
            get => _frameMain;
            set => _frameMain = value;
        }
    }
}
