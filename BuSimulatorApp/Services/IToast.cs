using System;
using System.Collections.Generic;
using System.Text;

namespace BuSimulatorApp.Services
{
    public interface IToast
    {
        void ToastShort(string mensaje);
        void ToastLong(string mensaje);
    }
}
