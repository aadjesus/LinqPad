<Query Kind="Program">
  <Reference Relative="..\..\..\..\.nuget\packages\fcm.net.core\1.0.1\lib\netstandard1.6\FCM.Net.Core.dll">C:\Users\alessandro.augusto\.nuget\packages\fcm.net.core\1.0.1\lib\netstandard1.6\FCM.Net.Core.dll</Reference>
  <Reference Relative="..\..\..\..\.nuget\packages\newtonsoft.json\13.0.1\lib\netstandard2.0\Newtonsoft.Json.dll">C:\Users\alessandro.augusto\.nuget\packages\newtonsoft.json\13.0.1\lib\netstandard2.0\Newtonsoft.Json.dll</Reference>
  <Namespace>FCM.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var message = new Message()
	{
		RegistrationIds = new List<string>() 
		{ 
			"e6I6OB9HQju-WMvjeNiIQ0:APA91bHAchAS3nakJmBljMO8KwLDcAldn2GO-iGUqcy-kUl0s8jSvl6vWdZ0WTg_fxCCpxbxYGdvlJd6V6Gt8r_7-GSCpB8F2rGinIWV3_RmA067MJaINYx7FRyzCykL9o6hKF3TFqc1"
		},
        
		Notification = new Notification()
        {
        	Title = "Parabéns!",
            Body = "Feliz Aniversário!",
		}
	};

	var sender = new Sender("AAAAY1lDKJU:APA91bF5NFNN4SedMA4i2SO6nADS6kA1n-lx5Hqeq4bZ_TSjgF0p2tXBR2xEK9Pu90C0gsZL9JBm7TUuyrSAMNroJpZa6nq3LhitHY6uUTkPdJph4n9zGccxwDu6oSw8eEGvrTNEV44E");
	
    var result = await sender.SendAsync(message);
	result.Dump();

	
}
