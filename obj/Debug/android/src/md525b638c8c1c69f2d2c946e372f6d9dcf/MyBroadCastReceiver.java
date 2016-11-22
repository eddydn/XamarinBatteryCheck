package md525b638c8c1c69f2d2c946e372f6d9dcf;


public class MyBroadCastReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("XamarinBatteryCheck.MyBroadCastReceiver, XamarinBatteryCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyBroadCastReceiver.class, __md_methods);
	}


	public MyBroadCastReceiver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyBroadCastReceiver.class)
			mono.android.TypeManager.Activate ("XamarinBatteryCheck.MyBroadCastReceiver, XamarinBatteryCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MyBroadCastReceiver (md525b638c8c1c69f2d2c946e372f6d9dcf.MainActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyBroadCastReceiver.class)
			mono.android.TypeManager.Activate ("XamarinBatteryCheck.MyBroadCastReceiver, XamarinBatteryCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "XamarinBatteryCheck.MainActivity, XamarinBatteryCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

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
