using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace GoMath.Controls
{
    public sealed class CustomControl2 : Control
    {
        public CustomControl2()
        {
            this.DefaultStyleKey = typeof(CustomControl2);
        }
        RadioButton _myCheckBox1;
        RadioButton _myCheckBox2;
        RadioButton _myCheckBox3;
        RadioButton _myCheckBox4;
        public event EventHandler<RoutedEventArgs> Checked1;
        public event EventHandler<RoutedEventArgs> Checked2;
        public event EventHandler<RoutedEventArgs> Checked3;
        public event EventHandler<RoutedEventArgs> Checked4;
        protected override void OnApplyTemplate()
        {
            _myCheckBox1 = GetTemplateChild<RadioButton>("DapAnA");
            _myCheckBox1.Checked += (s, e) => Checked1?.Invoke(s, e);
            _myCheckBox2 = GetTemplateChild<RadioButton>("DapAnB");
            _myCheckBox2.Checked += (s, e) => Checked2?.Invoke(s, e);
            _myCheckBox3 = GetTemplateChild<RadioButton>("DapAnC");
            _myCheckBox3.Checked += (s, e) => Checked3?.Invoke(s, e);
            _myCheckBox4 = GetTemplateChild<RadioButton>("DapAnD");
            _myCheckBox4.Checked += (s, e) => Checked4?.Invoke(s, e);

        }
        T GetTemplateChild<T>(string name) where T : DependencyObject
        {
            var child = GetTemplateChild(name) as T;
            if (child == null)
                throw new NullReferenceException(name);
            return child;
        }
        public string SoCau
        {
            get { return (string)GetValue(SoCauProperty); }
            set { SetValue(SoCauProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SoCau.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SoCauProperty =
            DependencyProperty.Register("SoCau", typeof(string), typeof(CustomControl2), null);


        public string DeCuaCau
        {
            get { return (string)GetValue(DeCuaCauProperty); }
            set { SetValue(DeCuaCauProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeCuaCau.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeCuaCauProperty =
            DependencyProperty.Register("DeCuaCau", typeof(string), typeof(CustomControl2), null);


        public string CauTraLoiCuaDapAnA
        {
            get { return (string)GetValue(CauTraLoiCuaDapAnAProperty); }
            set { SetValue(CauTraLoiCuaDapAnAProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CauTraLoiCuaDapAnA.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CauTraLoiCuaDapAnAProperty =
            DependencyProperty.Register("CauTraLoiCuaDapAnA", typeof(string), typeof(CustomControl2), null);


        public string CauTraLoiCuaDapAnB
        {
            get { return (string)GetValue(CauTraLoiCuaDapAnBProperty); }
            set { SetValue(CauTraLoiCuaDapAnBProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CauTraLoiCuaDapAnA.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CauTraLoiCuaDapAnBProperty =
            DependencyProperty.Register("CauTraLoiCuaDapAnB", typeof(string), typeof(CustomControl2), null);

        public string CauTraLoiCuaDapAnC
        {
            get { return (string)GetValue(CauTraLoiCuaDapAnCProperty); }
            set { SetValue(CauTraLoiCuaDapAnCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CauTraLoiCuaDapAnA.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CauTraLoiCuaDapAnCProperty =
            DependencyProperty.Register("CauTraLoiCuaDapAnC", typeof(string), typeof(CustomControl2), null);

        public string CauTraLoiCuaDapAnD
        {
            get { return (string)GetValue(CauTraLoiCuaDapAnDProperty); }
            set { SetValue(CauTraLoiCuaDapAnDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CauTraLoiCuaDapAnA.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CauTraLoiCuaDapAnDProperty =
            DependencyProperty.Register("CauTraLoiCuaDapAnD", typeof(string), typeof(CustomControl2), null);






    }
}
