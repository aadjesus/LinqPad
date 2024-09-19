<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Runtime.Serialization</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
</Query>

void Main()
{
	var dictionary = new Dictionary<int,string>();	
	
	dictionary.Add(1, @"{'DisplayName': 'nome0','SAMAccountName': 'nome2\\nome1'}");
	dictionary.Add(2, @"{'UserName': 'John Smith', 'Status' : 'Active'}");
	dictionary.Add(3, @"{""UserName"": ""domain\\username"",""Enabled"": true}");	
	
	JsonConvert.DeserializeObject<DirectoryAccount>(dictionary[1]).Dump("JsonExtensionData");	
	JsonConvert.DeserializeObject<User>(dictionary[2]).Dump("JsonConverter");	
	JsonConvert.DeserializeObject<User2>(dictionary[3]).Dump("JsonConstructor");	
}

public class DirectoryAccount
{
    public string DisplayName { get; set; }

    public string UserName { get; set; }
    public string Domain { get; set; }

    [JsonExtensionData]
    private IDictionary<string, JToken> _additionalData;

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        // SAMAccountName is not deserialized to any property
        // and so it is added to the extension data dictionary
        string samAccountName = (string)_additionalData["SAMAccountName"];

        Domain = samAccountName.Split('\\')[0];
        UserName = samAccountName.Split('\\')[1];
    }

    public DirectoryAccount()
    {
        _additionalData = new Dictionary<string, JToken>();
    }
}

public enum UserStatus
{
    NotConfirmed,
    Active,
    Deleted
}

public class User
{
    public string UserName { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public UserStatus Status { get; set; }
}

public class User2
{
    public string UserName { get; private set; }
    public bool Enabled { get; private set; }

    public User2()
    {
    }

    [JsonConstructor]
    public User2(string userName, bool enabled)
    {
        UserName = userName;
        Enabled = enabled;
    }
}