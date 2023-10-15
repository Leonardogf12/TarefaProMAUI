package crc64380fb4a9f842c1be;


public class OnProgressListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.firebase.storage.OnProgressListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onProgress:(Ljava/lang/Object;)V:Getsnapshot_Ljava_lang_Object_Handler:Firebase.Storage.IOnProgressListenerInvoker, Xamarin.Firebase.Storage\n" +
			"";
		mono.android.Runtime.register ("Plugin.Firebase.Android.Storage.Listeners.OnProgressListener, Plugin.Firebase", OnProgressListener.class, __md_methods);
	}


	public OnProgressListener ()
	{
		super ();
		if (getClass () == OnProgressListener.class) {
			mono.android.TypeManager.Activate ("Plugin.Firebase.Android.Storage.Listeners.OnProgressListener, Plugin.Firebase", "", this, new java.lang.Object[] {  });
		}
	}


	public void onProgress (java.lang.Object p0)
	{
		n_onProgress (p0);
	}

	private native void n_onProgress (java.lang.Object p0);

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
