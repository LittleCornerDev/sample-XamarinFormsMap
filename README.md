# sample-XamarinFormsMap
This is a very basic example of a Xamarin.Forms map for anyone completely new to Xamarin.  
No pins, no fancy displays.  Just displaying the native map for both iOS and Android.  
Because that alone could take a couple of days of digging through Google and StackOverflow from outdated tutorials or missing info.

That being said, [this](https://xamarinhelp.com/xamarin-forms-maps/) was the best tutorial I found.  It just did not have info on the additional code required for Android SDK >= 6.0 (API 23). For that, go to [this documentation](https://developer.android.com/training/permissions/requesting#java) for Java snippets you can tweak into C#.

The following are steps to replicate this work on your own in case you want to verify you have everything set-up correctly.  
I.e., making sure a blank project is deploying successfully before jumping ahead and just copying everything in the repo.


## Set-Up
### Downloads
1. [XCode](https://developer.apple.com/xcode/ "XCode")
: Even though Xamarin is edited through VisualStudio, it's cross-platform capabilities for iOS depend on XCode tools.
1. [Android Studio](https://developer.android.com/studio/ "Android Studio")
: Even though Xamarin is edited through VisualStudio, it's cross-platform capabilities for Android depend on Android Studio tools.
1. [Visual Studio IDE](https://visualstudio.microsoft.com/vs/ "Visual Studio IDE")
: VisualStudio is where we can create and edit Xamarin projects.

### Android SDK
The Android SDK Manager is available in the `Android Studio Welcome Screen > Configure` menu.

#### Platforms
Configure the Android versions you want to support in `SDK Manager > Appearance and Behavior > System Settings > Android SDK > SDK Platforms` tab.

#### Tools
Configure the Android developer tools you want to have in `SDK Manager > Appearance and Behavior > System Settings > Android SDK > SDK Tools` tab.  
This includes the emulator, HAXM installer, NDK, and whatever else Visual Studio will tell you is missing when you try to use it.


## Having a Test Project
1. Create a blank forms app in Visual Studio.  Basically, everything [here](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/get-started/hello-xamarin-forms/quickstart "Xamarin Forms Quickstart") until Step 4. ** Do not use a '-' in your project name.  It will let you, but you will get a `namespace name 'App' could not be found` error for `YOUR_XAMARIN_FORMS_APP_NAME.iOS/Main.Activity.cs`. **
1. Verify your set-up by [deploying the app](#deploy).


## Adding the Map
Once you're sure you have all your tools set up and have the blank project working, it's time to try displaying a map.

### NuGet Packages
These are how you get the Xamarin tools you want.

When you open your solution (`*.sln`) in Visual Studio, you will see three project folders: 
* `YOUR_XAMARIN_FORMS_APP_NAME` is shared
* `YOUR_XAMARIN_FORMS_APP_NAME.Android` is for Android only
* `YOUR_XAMARIN_FORMS_APP_NAME.iOS` is for iOS only

They each have their own "Dependencies" or "Packages" folder. **This is important to note if you want to make sure a package you think you have is actually there.**

#### Update
1. When you navigate to `YOUR_XAMARIN_FORMS_APP_NAME/Dependencies/NuGet`, you should only see `Xamarin.Forms`.
1. Make sure this is the latest by clicking on `Visual Studio > Project > Upgrade NuGet Packages`.

#### Get Xamarin.Forms.Map
1.  Go to`Visual Studio > Project > Add NuGet packages...` and search for `Xamarin.Forms.Maps`
1.  Add `Xamarin.Forms.Maps` to all three projects.  

### Code
Compare your code with the code in this repo to see what was added to display a basic native map on the page -- a Google map for Android and an Apple map for iOS.  

<a name="deploy"></a>
## Deploying the App
1.  Look for the run/play icon on the top bar of Visual Studio. On a Mac, this is to the left of the project dropdown.
1.  Select your desired target project in the project dropdown.  E.g., `YOUR_XAMARIN_FORMS_APP_NAME.Android`, `YOUR_XAMARIN_FORMS_APP_NAME.iOS`. 
1.  Keep the run type dropdown on `Debug`.  
1.  Pick your desired emulator in the emulator dropdown.
1.  Click on the play icon.
1.  Your emulator should open and deploy the app.
1.  The play icon should have been changed to a stop icon.  Click on the icon to stop the emulator.

