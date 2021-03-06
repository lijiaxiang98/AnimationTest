﻿using System;
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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace AnimationTest
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("RTAni", RT1);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("TBAni", TB1);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("BTAni", MyButton);
            Frame.Navigate(typeof(NewPage));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ConnectedAnimation rectangleBackAni = ConnectedAnimationService.GetForCurrentView().GetAnimation("RTBackAni");
            ConnectedAnimation textblockBackAni = ConnectedAnimationService.GetForCurrentView().GetAnimation("TBBackAni");
            ConnectedAnimation buttonBackAni = ConnectedAnimationService.GetForCurrentView().GetAnimation("BTBackAni");
            if (rectangleBackAni!=null&& textblockBackAni!=null&& buttonBackAni!=null)
            {
                rectangleBackAni.TryStart(RT1);
                textblockBackAni.TryStart(TB1);
                buttonBackAni.TryStart(MyButton);
            }
        }

    }
}
