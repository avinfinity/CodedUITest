using System;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System.Windows.Input;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;

namespace CodedUITest
{
    public class UIWindowsExplorer : WinWindow
    {
        public UIWindowsExplorer()
        {
            Keyboard.SendKeys("E", ModifierKeys.Windows);
            Playback.Wait(1000);

            SearchProperties[UITestControl.PropertyNames.Name] = "File Explorer";
            SearchProperties[UITestControl.PropertyNames.ClassName] = "CabinetWClass";
            WindowTitles.Add("File Explorer");
        }

        public WinToolBar FilePathToolbar
        {
            get
            {
                if ((this.mUIAddressQuickaccessToolBar == null))
                {
                    this.mUIAddressQuickaccessToolBar = new WinToolBar(this);
                    this.mUIAddressQuickaccessToolBar.SearchProperties[WinToolBar.PropertyNames.Name] = "Address: Quick access";
                    this.mUIAddressQuickaccessToolBar.WindowTitles.Add("File Explorer");
                }
                return this.mUIAddressQuickaccessToolBar;
            }
        }

        private WinToolBar mUIAddressQuickaccessToolBar;
    }

    public class GetButton : WpfButton
    {
        private string AppName { get; }

        public GetButton(UITestControl searchLimitContainer, string buttonId, string appName) :
                base(searchLimitContainer)
        {
            AppName = appName;
            SearchProperties[WpfButton.PropertyNames.AutomationId] = buttonId;
            WindowTitles.Add(AppName);
        }

        private WpfCustom Button
        {
            get
            {
                var button = new WpfCustom(this);
                button.SearchProperties[WpfControl.PropertyNames.ClassName] = null;
                button.SearchProperties[WpfControl.PropertyNames.AutomationId] = "_Button";
                button.WindowTitles.Add(AppName);
                return button;
            }
        }

        public void Click()
        {
            Mouse.Click(Button);
        }
    }
}