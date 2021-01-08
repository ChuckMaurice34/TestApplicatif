using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicatif.Base
{
    class ModelBase : INotifyPropertyChanged
    {
        #region Implémentation de l'interface 'INotifyPropertyChanged'

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Méthodes privées

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
