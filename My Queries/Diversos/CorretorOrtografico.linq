<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio 10.0\Visual Studio Tools for Office\PIA\Office12\Microsoft.Office.Interop.Word.dll</Reference>
</Query>

void Main()
{

	Microsoft.Office.Interop.Word.Application _wordApp = new Microsoft.Office.Interop.Word.Application();
	_wordApp.Documents.Add();
	Microsoft.Office.Interop.Word.Range DRange = _wordApp.ActiveDocument.Range();
	DRange.InsertAfter("julhu agostu");
	Microsoft.Office.Interop.Word.ProofreadingErrors spellCollection = DRange.SpellingErrors;
	if (spellCollection.Count > 0)
	{
		string sugestoes = spellCollection
			.OfType<Microsoft.Office.Interop.Word.Range>()
			.Select(s => _wordApp.GetSpellingSuggestions(s.Text)
							.OfType<Microsoft.Office.Interop.Word.SpellingSuggestion>()
							.Aggregate(String.Empty, (a, b) => a + (String.IsNullOrEmpty(a) ? s.Text+": " : ", ") + b.Name))
			.Aggregate(String.Empty, (a, b) => a + (String.IsNullOrEmpty(a) ? "" : Environment.NewLine ) + b);
			
		sugestoes.Dump();
	}	
	
}


