using System;
using AppKit;
using Foundation;
//using Phidget22;
//using Phidget22.Events;
using System.Threading;
using PhidgetMacOsBinding;

namespace TestPhidget
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void ConnectClick(NSObject sender)
        {
            ConnectPhidget();
        }

        partial void DisconnectClick(NSObject sender)
        {
            ClosePhidget();
        }

        //private TemperatureSensor _temp = null;
        private Phidget22Funcs _temp = null;
        private bool _eventSet = false;

        private void ConnectPhidget()
        {
            if (_temp == null)
            {
                //_temp = new TemperatureSensor();
                _temp = new Phidget22Funcs();
                _temp.IsLocal = true;
                //_temp.Error += Phidget_Error;
                _temp.Channel = 0;
                _temp.Open();
                DateTime start = DateTime.UtcNow;
                while (!_temp.Attached && (DateTime.UtcNow - start).TotalSeconds < 5)
                {
                    StatusLabel.StringValue = "WAITING: " + DateTime.UtcNow.ToString();
                    Thread.Sleep(100);
                }
            }
            if (_temp.Attached)
            {
                if (!_eventSet)
                {
                    //_temp.TemperatureChange += Temp_TemperatureChange;
                    StatusLabel.StringValue = "EVENT SET: " + DateTime.UtcNow.ToString();
                    _eventSet = true;
                    StatusLabel.StringValue = "TEMP: " + _temp.GetTemperature();
                }
                else
                {
                    StatusLabel.StringValue = "ALREADY SETUP: " + DateTime.UtcNow.ToString();
                }
            }
            else
            {
                StatusLabel.StringValue = "NOT ATTACHED: " + DateTime.UtcNow.ToString();
            }
        }

        private void ClosePhidget()
        {
            try
            {
                if (_temp != null)
                {
                    //_temp.Error -= Phidget_Error;
                    //_temp.TemperatureChange -= Temp_TemperatureChange;
                    _eventSet = false;
                    //_temp.Close();
                    _temp.Dispose();
                    _temp = null;
                    StatusLabel.StringValue = "CLOSED";
                }
                else
                {
                    StatusLabel.StringValue = "ALREADY CLOSED";
                }
            }
            catch (Exception exc)
            {
                StatusLabel.StringValue = "ERROR: " + exc.Message;
            }
        }

        /*
        private void Temp_TemperatureChange(object sender, TemperatureSensorTemperatureChangeEventArgs e)
        {
            NSRunLoop.Main.BeginInvokeOnMainThread(() =>
            {
                StatusLabel.StringValue = "TEMP: " + e.Temperature;
            });
        }

        private void Phidget_Error(object sender, ErrorEventArgs e)
        {
            NSRunLoop.Main.BeginInvokeOnMainThread(() =>
            {
                StatusLabel.StringValue = "ERROR: " + e.Description;
            });
        }
        */
    }
}
