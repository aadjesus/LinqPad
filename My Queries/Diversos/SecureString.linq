<Query Kind="Program">
  <Namespace>System.Security</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

void Main()
{
	System.Security.SecureString secureString = new System.Security.SecureString();
	
	// Criptografa a string
	"password".ToCharArray()
    	.ToList()
    	.ForEach(secureString.AppendChar);

	 
	secureString.Dump();
	 
	IntPtr unmanagedString = IntPtr.Zero;
    try
    {
		// Descriptografa
        Marshal.PtrToStringUni(Marshal.SecureStringToGlobalAllocUnicode(secureString)).Dump();
    }
    finally
    {
        Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
    }
}