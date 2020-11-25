using Microsoft.Win32;
using MvvmBase.Classes;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace MvvmBase.ViewModels
{
    public class MvvmBaseViewModel : BaseViewModel
    {
        #region Fields


        #endregion

        #region Properties

        #endregion

        #region Constructor
        public MvvmBaseViewModel()
        {
            Command1 = new CustomDelegateCommand(SampleMethod, CanSampleMethod, nameof(Command1));
            Command2 = new CustomDelegateCommand(SampleMethod, CanSampleMethod);

        }
        #endregion

        #region Commands
        
        public CustomDelegateCommand Command1 { get; set; }
        public CustomDelegateCommand Command2 { get; set; }



        #endregion

        #region Methods

        public override void Loaded()
        {
            Telemetry.UserId = 1;
        }

        void SampleMethod()
        {

        }

        void TestMethod()
        {

        }

        bool CanSampleMethod()
        {
            return true;
        }

       

        #endregion
    }
}
