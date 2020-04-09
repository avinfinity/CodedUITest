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
    public static class Actions
    {
        public static void NavigateToFolder(string path)
        {
            var explorerWindow = new UIWindowsExplorer();
            explorerWindow.FilePathToolbar.WaitForControlExist();
            explorerWindow.FilePathToolbar.EnsureClickable();

            Mouse.Click(explorerWindow.FilePathToolbar);

            Keyboard.SendKeys(path);
            Keyboard.SendKeys("{Enter}");
            Playback.Wait(1000);

            Mouse.Click(explorerWindow.FilePathToolbar);
        }

        public static UITestControl OpenApplication(IConfiguration configuration)
        {
            ApplicationUnderTest applicationUnderTest = ApplicationUnderTest.Launch(configuration["AppPath"]);
            applicationUnderTest.WaitForControlExist();

            var application = UITestControlFactory.FromWindowHandle(applicationUnderTest.WindowHandle);
            application.SetFocus();
            return application;
        }

        public static UITestControl OpenNewProject(this UITestControl neoInsights, IConfiguration configuration)
        {
            GetButton button = new GetButton(neoInsights, configuration["NewProject"],configuration["ApplicationName"]);
            button.WaitForControlExist();
            button.WaitForControlEnabled();
            button.Click();

            return neoInsights;
        }
    }
}