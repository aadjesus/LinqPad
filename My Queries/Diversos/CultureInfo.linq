<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	 // Display the header.
      Console.WriteLine("{0,-53}{1}", "CULTURE", "SPECIFIC CULTURE");

      // Get each neutral culture in the .NET Framework.
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
      // Sort the returned array by name.
      Array.Sort<CultureInfo>(cultures, new NamePropertyComparer<CultureInfo>());

      // Determine the specific culture associated with each neutral culture.
      foreach (var culture in cultures) 
      {
         Console.Write("{0,-12} {1,-40}", culture.Name, culture.EnglishName);
         try 
		 {
            Console.WriteLine("{0}", CultureInfo.CreateSpecificCulture(culture.Name).Name);
         }   
         catch (ArgumentException) 
		 {
            Console.WriteLine("(no associated specific culture)");
         }
      } 
}

public class NamePropertyComparer<T> : IComparer<T>
{
   public int Compare(T x, T y) 
   {
      if (x == null)
         if (y == null)
            return 0;
         else
            return -1;

      PropertyInfo pX = x.GetType().GetProperty("Name");
      PropertyInfo pY = y.GetType().GetProperty("Name");             
      return String.Compare((string) pX.GetValue(x, null), (string) pY.GetValue(y, null));
   }
}
