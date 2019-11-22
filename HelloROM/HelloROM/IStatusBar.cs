using System;
using System.Collections.Generic;
using System.Text;

namespace HelloROM
{
    public interface IStatusBar
    {
        /// <summary>
        /// Hide Status Bar
        /// </summary>
        void HideStatusBar();

        /// <summary>
        /// Show Status Bar
        /// </summary>
        void ShowStatusBar();
    }
}
