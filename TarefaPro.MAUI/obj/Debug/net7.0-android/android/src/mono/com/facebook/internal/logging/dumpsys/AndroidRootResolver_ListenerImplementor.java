package mono.com.facebook.internal.logging.dumpsys;


public class AndroidRootResolver_ListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.facebook.internal.logging.dumpsys.AndroidRootResolver.Listener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onRootAdded:(Landroid/view/View;)V:GetOnRootAdded_Landroid_view_View_Handler:Com.Facebook.Internal.Logging.Dumpsys.AndroidRootResolver/IListenerInvoker, Xamarin.Facebook.Core.Android\n" +
			"n_onRootRemoved:(Landroid/view/View;)V:GetOnRootRemoved_Landroid_view_View_Handler:Com.Facebook.Internal.Logging.Dumpsys.AndroidRootResolver/IListenerInvoker, Xamarin.Facebook.Core.Android\n" +
			"n_onRootsChanged:(Ljava/util/List;)V:GetOnRootsChanged_Ljava_util_List_Handler:Com.Facebook.Internal.Logging.Dumpsys.AndroidRootResolver/IListenerInvoker, Xamarin.Facebook.Core.Android\n" +
			"";
		mono.android.Runtime.register ("Com.Facebook.Internal.Logging.Dumpsys.AndroidRootResolver+IListenerImplementor, Xamarin.Facebook.Core.Android", AndroidRootResolver_ListenerImplementor.class, __md_methods);
	}


	public AndroidRootResolver_ListenerImplementor ()
	{
		super ();
		if (getClass () == AndroidRootResolver_ListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Facebook.Internal.Logging.Dumpsys.AndroidRootResolver+IListenerImplementor, Xamarin.Facebook.Core.Android", "", this, new java.lang.Object[] {  });
		}
	}


	public void onRootAdded (android.view.View p0)
	{
		n_onRootAdded (p0);
	}

	private native void n_onRootAdded (android.view.View p0);


	public void onRootRemoved (android.view.View p0)
	{
		n_onRootRemoved (p0);
	}

	private native void n_onRootRemoved (android.view.View p0);


	public void onRootsChanged (java.util.List p0)
	{
		n_onRootsChanged (p0);
	}

	private native void n_onRootsChanged (java.util.List p0);

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
