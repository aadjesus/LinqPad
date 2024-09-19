<Query Kind="Program">
  <GACReference>Microsoft.TeamFoundation.Client, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <GACReference>Microsoft.TeamFoundation.Common, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <GACReference>Microsoft.TeamFoundation.VersionControl.Client, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <Namespace>Microsoft.TeamFoundation.Client</Namespace>
  <Namespace>Microsoft.TeamFoundation.Framework.Client</Namespace>
  <Namespace>Microsoft.TeamFoundation.Framework.Common</Namespace>
  <Namespace>Microsoft.TeamFoundation.VersionControl.Client</Namespace>
  <Namespace>Microsoft.TeamFoundation.Server</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	Uri tfsUri = new Uri("http://172.16.4.6:8080/tfs");
//	var tpc = new TfsTeamProjectCollection(tfsUri);
//
//	var identityManagementService = tpc.GetService<IIdentityManagementService>();
//	
//	var collectionWideValidUsers = identityManagementService.ReadIdentity(
//		IdentitySearchFactor.DisplayName, 
//        "Project Collection Valid Users", 
//        MembershipQuery.Expanded, 
//        ReadIdentityOptions.None);
//
//	var validMembers = identityManagementService.ReadIdentities(
//		collectionWideValidUsers.Members, 
//        MembershipQuery.Expanded, 
//        ReadIdentityOptions.ExtendedProperties);
//		
//	var memberNames = validMembers
//		.Where(o=> !o.IsContainer)
//		.Select(s=> s.DisplayName)
//        .ToList();

	
	List <string> groupList = new List <string>();
    string projectName = "GlobusMais";
    // connect to the server
    TeamFoundationServer server = new TeamFoundationServer(tfsUri);
    // get ICommonStructureService (later to be used to list all team projects)
    ICommonStructureService iss = (ICommonStructureService)server.GetService(typeof(ICommonStructureService));
    // get IGroupSecurityService (later to be used to retrieve identity information)
    IGroupSecurityService2 gss = (IGroupSecurityService2)server.GetService(typeof(IGroupSecurityService2));
    
	ProjectInfo[] allTeamProjects = iss.ListProjects();
	allTeamProjects.Dump();
    
    foreach (ProjectInfo pi in allTeamProjects)
    {
       if (pi.Name == projectName)
        {
            Identity[] allProjectGroups = gss.ListApplicationGroups(pi.Uri);
			
            // iterate thru the project group list and get a list of direct members for each project group
            foreach (Identity projectGroup in allProjectGroups)
            {
                Identity pg = gss.ReadIdentity(SearchFactor.Sid, projectGroup.Sid, QueryMembership.Direct);
                foreach (String groupMemberSid in pg.Members)
                {
                    Identity m = gss.ReadIdentity(SearchFactor.Sid, groupMemberSid, QueryMembership.None);
                    //if (m.AccountName == account)
                    {
                        groupList.Add(pg.DisplayName);
						m.Dump();
                    }
                }
            }
        }
    }
	groupList.Dump();
	
		  
}