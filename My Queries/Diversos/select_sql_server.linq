<Query Kind="Program">
  <Namespace>System.Data.OleDb</Namespace>
</Query>

void Main()
{
	//string sql =  "Provider=SQLNCLI10.1;Integrated Security=\"\";Persist Security Info=False;User ID=sa;Password=manager; Initial Catalog=\"\";Data Source=172.16.0.25;Initial File Name=\"\";Server SPN=\"\"";
	string sql =  "Provider=SQLNCLI10.1;Persist Security Info=False;User ID=sa;Password=manager; Initial Catalog=\"\";Data Source=172.16.0.25;Initial File Name=\"\";Server SPN=\"\"";
	string ora = "Provider=OraOLEDB.Oracle.1;Data Source=ora10g;Per sist Security Info=True;User ID=AJOFER130522;Password=AJOFER130522;Unicode=True";
	
	OleDbConnection oleDbConnection  = new OleDbConnection(sql);
	oleDbConnection.Open();
	OleDbCommand command = oleDbConnection.CreateCommand();	
	
	//command.CommandText = String.Concat("select name, * from sysobjects");    
	command.CommandText = String.Concat("select [RoleID] from [Roles]");    
	
    command.ExecuteReader().Dump();	
	oleDbConnection.Close();
}

// Define other methods and classes here
