<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Management.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.Install.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.JScript.dll</Reference>
  <Namespace>System.Management</Namespace>
</Query>

void Main()
{

	Environment.OSVersion.Dump().Version.Major.Dump();
	
	System.Management.
	
	IsServerOS(Environment.MachineName).Dump();
}

public static bool IsServerOS(string computerName)
{
    ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

    using (ManagementObjectCollection results = new ManagementObjectSearcher(query).Get())
    {
        if (results.Count != 1) 
			throw new ManagementException();		
			
		PropertyData propertyData = results.OfType<ManagementObject>()
			.First()
			.Properties["ProductType"]
			.Dump();
		
        switch (Convert.ToInt32(propertyData.Value))
        {
            case 2:
            case 3:
                return true;
            default:
                return false;
        }
    }
}