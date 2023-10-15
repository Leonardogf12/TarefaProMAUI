package crc64a97abce917d4fef8;


public class TransactionFunction_1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.firebase.firestore.Transaction.Function
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_apply:(Lcom/google/firebase/firestore/Transaction;)Ljava/lang/Object;:GetApply_Lcom_google_firebase_firestore_Transaction_Handler:Firebase.Firestore.Transaction/IFunctionInvoker, Xamarin.Firebase.Firestore\n" +
			"";
		mono.android.Runtime.register ("Plugin.Firebase.Android.Firestore.TransactionFunction`1, Plugin.Firebase", TransactionFunction_1.class, __md_methods);
	}


	public TransactionFunction_1 ()
	{
		super ();
		if (getClass () == TransactionFunction_1.class) {
			mono.android.TypeManager.Activate ("Plugin.Firebase.Android.Firestore.TransactionFunction`1, Plugin.Firebase", "", this, new java.lang.Object[] {  });
		}
	}


	public java.lang.Object apply (com.google.firebase.firestore.Transaction p0)
	{
		return n_apply (p0);
	}

	private native java.lang.Object n_apply (com.google.firebase.firestore.Transaction p0);

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
