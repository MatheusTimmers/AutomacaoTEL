﻿#pragma checksum "C:\Users\10088365\source\repos\AutomaçãoTEL\AutomaçãoTEL\Views\RegistrationAccount.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "484BAF849A5D4AA843D30C2754D79379"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutomaçãoTEL.Views
{
    partial class RegistrationAccount : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\RegistrationAccount.xaml line 15
                {
                    this.TbRegistration = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // Views\RegistrationAccount.xaml line 19
                {
                    this.personPicture = (global::Windows.UI.Xaml.Controls.PersonPicture)(target);
                }
                break;
            case 4: // Views\RegistrationAccount.xaml line 30
                {
                    this.BtRegister = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 5: // Views\RegistrationAccount.xaml line 31
                {
                    this.BtPhoto = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.BtPhoto).Click += this.BtPhoto_Click;
                }
                break;
            case 6: // Views\RegistrationAccount.xaml line 26
                {
                    this.TbName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Views\RegistrationAccount.xaml line 27
                {
                    this.TboxName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

