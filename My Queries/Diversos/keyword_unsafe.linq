<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
  </Connection>
</Query>

   unsafe static void Mutiplica(int* p) 
   {
	  *p *= *p;
   }
   unsafe public static void Main() 
   {
	  int i = 5;
	  Mutiplica(&i);
	  i.Dump();
   }
