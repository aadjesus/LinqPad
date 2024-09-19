<Query Kind="Program">
  <GACReference>Microsoft.TeamFoundation.Client, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <GACReference>Microsoft.TeamFoundation.Common, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <Namespace>Microsoft.TeamFoundation.Client</Namespace>
  <Namespace>Microsoft.TeamFoundation.Framework.Client</Namespace>
  <Namespace>Microsoft.TeamFoundation.Framework.Common</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
  <Namespace>System.Net</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	var ClientCredential =  System.Net.CredentialCache.DefaultNetworkCredentials;
	ClientCredential.Domain.Dump();
Console.WriteLine("UserName : " +  ClientCredential.UserName);

//	Uri tpcAddress= new Uri("http://172.16.4.6:8080/tfs/BGMRodotec/GlobusMais");
//	
//	NetworkCredential netCred = new NetworkCredential(
//                "alessandro.augusto",
//                "9251@ajic");
//            BasicAuthCredential basicCred = new BasicAuthCredential(netCred);
//            TfsClientCredentials tfsCred = new TfsClientCredentials(basicCred);
//            tfsCred.AllowInteractive = false;
//
//            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(
//                tpcAddress,
//                tfsCred);
//tfsCred.AllowInteractive = false;
//            tpc.Authenticate();
//
//            Console.WriteLine(tpc.InstanceId);
//	
}

// Define other methods and classes here