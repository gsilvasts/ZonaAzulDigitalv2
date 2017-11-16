using System;
using System.Collections.Generic;
using Android.App;
using ZonaAzulDigital.Core.Provider.DialogProvider;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform;

public class DroidDialogProvider : IDialogProvider

{
    public void ShowMessage(string title, string message, string dismissButtonTitle, Action dismissed)
    {

        AlertDialog.Builder builder = new AlertDialog.Builder(Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
        AlertDialog alertdialog = builder.Create();
        builder.SetTitle(title);
        builder.SetMessage(message);
        builder.SetNegativeButton(dismissButtonTitle, (senderAlert, args) =>
        {
            //ToDo::Prevent from Null Reference Error beacuse somewhere Action set as null
            if (dismissed != null)
                dismissed.Invoke();
        });
        builder.Show();

        // throw new NotImplementedException();

    }

    public void Confirm(string title, string message, string okButtonTitle, string dismissButtonTitle, Action confirmed, Action dismissed)

    {

        AlertDialog.Builder builder = new AlertDialog.Builder(Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
        AlertDialog alertdialog = builder.Create();
        builder.SetTitle(title);
        builder.SetMessage(message);
        builder.SetNegativeButton(dismissButtonTitle, (senderAlert, args) =>
        {
            //ToDo::Prevent from Null Reference Error beacuse somewhere Action set as null
            if (dismissed != null)
                dismissed.Invoke();
        });
        builder.SetPositiveButton(okButtonTitle, (senderAlert, args) =>
        {
            //ToDo::Prevent from Null Reference Error beacuse somewhere Action set as null
            if (confirmed != null)
                confirmed.Invoke();
        });
        builder.Show();

    }
}