<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.DataAnnotations.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <NuGetReference>FluentMigrator</NuGetReference>
  <Namespace>System.ComponentModel.DataAnnotations</Namespace>
  <Namespace>FluentMigrator.Model</Namespace>
  <Namespace>FluentMigrator.Expressions</Namespace>
</Query>

void Main()
{
	var tipo = typeof(ModelpTeste);
	var createTableExpression = new CreateTableExpression();
    createTableExpression.TableName = tipo.Name;
	
	foreach (var item in tipo.GetProperties())
	{
        var dbType = System.Data.DbType.String;
        if (!Enum.TryParse(item.PropertyType.Name, out dbType))
            continue;

        var columnDefinition = new ColumnDefinition()
        {
            Type = dbType,
            Name = item.Name,
			IsPrimaryKey = item.GetCustomAttribute(typeof(KeyAttribute)) != null
        };              
		
		var stringLength = item.GetCustomAttribute(typeof(StringLengthAttribute)) as StringLengthAttribute;
		if (stringLength != null)
			columnDefinition.Precision = stringLength.MaximumLength;
		
		var required = item.GetCustomAttribute(typeof(RequiredAttribute)) as RequiredAttribute;
		if (required != null)
			columnDefinition.IsNullable = true;
		
        createTableExpression.Columns.Add(columnDefinition);
    }
	createTableExpression.Dump();
}

class ModelpTeste
{
	[Key]
	public int Id{get;set;} 
	
	[StringLength(500)]
	public string a1{get;set;} 
	public int a2{get;set;} 
	public DateTime a3{get;set;} 
	[Required]
	public object a4{get;set;} 
}