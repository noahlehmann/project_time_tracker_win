using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Setzt den Wert einer Property und löst PropertyChanged aus.
        /// </summary>
        /// <typeparam name="T">Typ des Wertes</typeparam>
        /// <param name="field">Klassenvariable, in der der Wert gespeichert wird</param>
        /// <param name="value">Neuer Wert</param>
        /// <param name="propertyName">Name der Property</param>
        protected virtual void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if ((object)field == (object)value)
                return;
            field = value;
            OnPropertyChanged(propertyName);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
