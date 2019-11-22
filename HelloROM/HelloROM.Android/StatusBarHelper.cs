using Xamarin.Forms;
using Android.Support.V7.App;
using Android.Views;

[assembly: Dependency(typeof(HelloROM.Droid.StatusBarHelper))]

namespace HelloROM.Droid
{
    public class StatusBarHelper : HelloROM.IStatusBar
    {
        private WindowManagerFlags _originalFlags;
        private bool IsHide { get; set; }

        #region IStatusBar implementation

        /// <summary>
        /// Hide
        /// </summary>
        public void HideStatusBar()
        {
            if (IsHide) return;

            IsHide = true;

            var activity = (AppCompatActivity)Forms.Context;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;
        }

        /// <summary>
        /// Show
        /// </summary>
        public void ShowStatusBar()
        {
            if (!IsHide) return;

            IsHide = false;

            var activity = (AppCompatActivity)Forms.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags = _originalFlags;
            activity.Window.Attributes = attrs;
        }

        #endregion
    }
}