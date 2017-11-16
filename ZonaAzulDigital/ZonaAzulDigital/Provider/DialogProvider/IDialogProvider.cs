using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaAzulDigital.Core.Provider.DialogProvider
{
    public interface IDialogProvider

    {

        void ShowMessage(string title, string message, string dismissButtonTitle, Action dismissed);

        void Confirm(string title, string message, string okButtonTitle, string dismissButtonTitle, Action confirmed, Action dismissed);

    }
}
