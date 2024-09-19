<Query Kind="Program">
  <GACReference>Microsoft.TeamFoundation.Client, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <GACReference>Microsoft.TeamFoundation.Common, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <GACReference>Microsoft.TeamFoundation.VersionControl.Client, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <Namespace>Microsoft.TeamFoundation.Client</Namespace>
  <Namespace>Microsoft.TeamFoundation.Framework.Client</Namespace>
  <Namespace>Microsoft.TeamFoundation.Framework.Common</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
  <Namespace>Microsoft.TeamFoundation.VersionControl.Client</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	Uri tfsUri = new Uri("http://172.16.4.6:8080/tfs");

//	TfsConfigurationServer configurationServer = TfsConfigurationServerFactory.GetConfigurationServer(tfsUri);
//	
//	ReadOnlyCollection<CatalogNode> collectionNodes = configurationServer.CatalogNode.QueryChildren( 
//                new[] { CatalogResourceTypes.ProjectCollection },
//                false, 
//				CatalogQueryOptions.None);
//				
//	foreach (CatalogNode collectionNode in collectionNodes)
//	{
//    	Guid collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"].Dump());
//    	TfsTeamProjectCollection teamProjectCollection = configurationServer.GetTeamProjectCollection(collectionId);
//
//        Console.WriteLine("Collection: " + teamProjectCollection.Name);
//
//        ReadOnlyCollection<CatalogNode> projectNodes = collectionNode.QueryChildren(
//            new[] { CatalogResourceTypes.TeamProject },
//            false, CatalogQueryOptions.None);
//
//        foreach (CatalogNode projectNode in projectNodes)
//            Console.WriteLine(" Team Project: " + projectNode.Resource.DisplayName);
//	}
	
	/////////////////////// 2
	//	TfsTeamProjectCollection projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(tfsUri);
	//	VersionControlServer versionControl = projectCollection.GetService<VersionControlServer>();
	//	int latestId = versionControl.GetLatestChangesetId();
	//
	//	List<Changeset> changesetList = new List<Changeset>();
	//	for (int i = 1; i < 3; i++)
	//	{
	//    	try
	//    	{
	//        	Changeset cs = versionControl.GetChangeset(i);
	//        	if (cs != null)
	//        	{
	//            	changesetList.Add(cs);
	//        	}
	//    	}
	//    	catch{}
	//	}
	//	changesetList.Dump();
	

        var tpc = new TfsTeamProjectCollection(tfsUri);

        VersionControlServer versionControlServer = tpc.GetService(typeof(VersionControlServer)) as VersionControlServer;
        TeamProject teamProject = versionControlServer.GetTeamProject(@"GlobusMais");
		
        IEnumerable listaChangeSet = versionControlServer.QueryHistory(
			String.Concat(teamProject.ServerItem,"/Fontes/WPF"), 
			VersionSpec.Latest, 
			0, 
			RecursionType.Full, 
			null, 
			null, 
			null, 
			10, 
			true, 
			true, 
			false, 
			false);
		
		listaChangeSet
			.OfType<Microsoft.TeamFoundation.VersionControl.Client.Changeset>()
			.Select(s=> new 
			{
				s.ChangesetId,
            	s.Comment,			
				s.Committer,
				s.CommitterDisplayName,
				s.CreationDate,
				s.Owner,
				s.OwnerDisplayName,
				Arquivos = s.Changes.Select(s2=> s2.Item.ServerItem),				
			})
			.Dump();
	
}