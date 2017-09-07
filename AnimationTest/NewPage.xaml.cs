using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace AnimationTest
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class NewPage : Page
    {
        public NewPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ConnectedAnimation rectangleAni = ConnectedAnimationService.GetForCurrentView().GetAnimation("RTAni");
            ConnectedAnimation textblockAni = ConnectedAnimationService.GetForCurrentView().GetAnimation("TBAni");
            ConnectedAnimation buttonAni = ConnectedAnimationService.GetForCurrentView().GetAnimation("BTAni");
            if (rectangleAni!=null&& textblockAni!=null)
            {
                rectangleAni.TryStart(RT1);
                textblockAni.TryStart(TB1);
                buttonAni.TryStart(BackButton);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("RTBackAni", RT1);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("TBBackAni", TB1);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("BTBackAni", BackButton);
            Frame.Navigate(typeof(MainPage));
        }
    }
}
