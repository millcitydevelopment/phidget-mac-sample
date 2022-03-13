using System;
using Microsoft.Win32.SafeHandles;

namespace PhidgetMacOsBinding
{
	public struct _PhidgetChannel { }

    public class Phidget22SafeHandle: SafeHandleMinusOneIsInvalid
    {
		public Phidget22SafeHandle() :base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            Phidget22Wrapper.Phidget_release(this);
            return true;
        }
    }
}
