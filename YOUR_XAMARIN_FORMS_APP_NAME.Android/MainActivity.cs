using System;
using System.Collections; //Hashtable
using System.Collections.Generic; //List

using Android.App; //Activity, Icon, Theme, MainLauncher, ConfigurationChange
using Android.Content.PM; //Permission
using Android.Runtime;
using Android.Support.V4.App; //ActivityCompat
using Android.Support.V4.Content; //ContextCompat
using Android.Views;
using Android.Widget;
using Android.OS; //OnCreate, Bundle


namespace YOUR_XAMARIN_FORMS_APP_NAME.Droid {
	[Activity(Label = "YOUR_XAMARIN_FORMS_APP_NAME", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
		//"Dangerous" permissions require explicit checking on runtime when target SDK >= Version 6.0 (API 23).
		string[] requiredPerms = {
			Android.Manifest.Permission.AccessCoarseLocation,
			Android.Manifest.Permission.AccessFineLocation
		};
		List<string> missingPerms = new List<string>();
		Hashtable permValues = new Hashtable();
		Hashtable requestCodes = new Hashtable();

		protected override void OnCreate(Bundle savedInstanceState) {
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			Xamarin.FormsMaps.Init(this, savedInstanceState);

			// Check for "dangerous" required permissions at Runtime.
			foreach (string key in requiredPerms) {
				var value = ContextCompat.CheckSelfPermission(this, key);
				permValues.Add(key, value);
				if (!value.Equals(Permission.Granted)) {
					missingPerms.Add(key);
				}
			}
			if (missingPerms.Count > 0) { // Permissions missing.
				//Request all required perms.
				//ActivityCompat.RequestPermissions(this, requiredPerms, 1);

				//Request missing perms.
				foreach (string missingPerm in missingPerms) {

					if (ActivityCompat.ShouldShowRequestPermissionRationale(this, missingPerm)) {// Should we show an explanation?
						// Show an explanation to the user *asynchronously* -- don't block
						// this thread waiting for the user's response! After the user
						// sees the explanation, try again to request the permission.
					}
					else {// No explanation needed. 

						//requestCode is can be any app-defined constant int for OnRequestPermissionResult().
						//Chose to use index from an array as a shorthand.
						var requestCode = Array.IndexOf(requiredPerms, missingPerm);

						//Request this missing permission.
						ActivityCompat.RequestPermissions(this, new String[] { missingPerm }, requestCode);
					}
				}
			}
			else { // Permission was previously granted.
				LoadApplication(new App());
			}
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
			if (grantResults.Length > 0 && grantResults[0] == Permission.Granted) {
				// Permission was granted.  
				// Do the tasks you need to do.
				LoadApplication(new App());
			}
			else {
				// Permission denied.
				// Disable the functionality that depends on this permission.
			}
		}
	}
}