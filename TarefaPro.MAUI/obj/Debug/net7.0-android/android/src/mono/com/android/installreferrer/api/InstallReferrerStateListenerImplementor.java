package mono.com.android.installreferrer.api;


public class InstallReferrerStateListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.android.installreferrer.api.InstallReferrerStateListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInstallReferrerServiceDisconnected:()V:GetOnInstallReferrerServiceDisconnectedHandler:Com.Android.Installreferrer.Api.IInstallReferrerStateListenerInvoker, Xamarin.Android.Binding.InstallReferrer\n" +
			"n_onInstallReferrerSetupFinished:(I)V:GetOnInstallReferrerSetupFinished_IHandler:Com.Android.Installreferrer.Api.IInstallReferrerStateListenerInvoker, Xamarin.Android.Binding.InstallReferrer\n" +
			"";
		mono.android.Runtime.register ("Com.Android.Installreferrer.Api.IInstallReferrerStateListenerImplementor, Xamarin.Android.Binding.InstallReferrer", InstallReferrerStateListenerImplementor.class, __md_methods);
	}


	public InstallReferrerStateListenerImplementor ()
	{
		super ();
		if (getClass () == InstallReferrerStateListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Android.Installreferrer.Api.IInstallReferrerStateListenerImplementor, Xamarin.Android.Binding.InstallReferrer", "", this, new java.lang.Object[] {  });
		}
	}


	public void onInstallReferrerServiceDisconnected ()
	{
		n_onInstallReferrerServiceDisconnected ();
	}

	private native void n_onInstallReferrerServiceDisconnected ();


	public void onInstallReferrerSetupFinished (int p0)
	{
		n_onInstallReferrerSetupFinished (p0);
	}

	private native void n_onInstallReferrerSetupFinished (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
