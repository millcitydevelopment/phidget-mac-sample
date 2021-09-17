// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TestPhidget
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField StatusLabel { get; set; }

		[Action ("ButtonClick:")]
		partial void ButtonClick (Foundation.NSObject sender);

		[Action ("ConnectClick:")]
		partial void ConnectClick (Foundation.NSObject sender);

		[Action ("DisconnectClick:")]
		partial void DisconnectClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (StatusLabel != null) {
				StatusLabel.Dispose ();
				StatusLabel = null;
			}
		}
	}
}
