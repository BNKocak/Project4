package md5579855c995bdb073d8182511e793544c;


public class Vraag1_Activity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("App1.Vraag1_Activity, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Vraag1_Activity.class, __md_methods);
	}


	public Vraag1_Activity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Vraag1_Activity.class)
			mono.android.TypeManager.Activate ("App1.Vraag1_Activity, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
