using eEmbassyPdfReportTemplate.DataSource;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace eEmbassyPdfReportTemplate.Template;

public sealed class CertificatDocument(CertificatModel model) : IDocument
{
  public void Compose(IDocumentContainer container)
  {
    container
      .Page(page =>
      {
        page.Margin(40);
            
        page.Header().Element(ComposeHeader);
        page.Content().Element(ComposeContent);
        page.Footer().Element(ComposeFooter);
      });
  }
  
  private void ComposeHeader(IContainer container)
  {
    var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
    
    container.Row(row =>
    {
      row.RelativeItem().Column(column =>
      {
        column.Item().Text($"{CompanyInfoSettings.CompanyName}").Style(titleStyle);

        column.Item().Text(text =>
        {
          text.Span("Issue date: ").SemiBold();
          text.Span($"{model.DateOfSignature:d}");
        });
                
        column.Item().Text(text =>
        {
          text.Span("Due date: ").SemiBold();
          text.Span($"{model.DateOfSignature:d}");
        });
      });

      row.ConstantItem(150).Height(150)
        .Image("img/Armoiries-RCA_v2.png")
        .FitArea();
    });
  }
  
  private void ComposeContent(IContainer container)
  {
    container
      .PaddingVertical(10)
      .Height(540)
      .AlignCenter()
      .AlignMiddle()
      // .Image("img/carte_vert_points.jpg")
      // .FitArea();
      .Grid(grid =>
      {
        grid.Item(6)
          .AlignLeft()
          .Text($"N°  {model.Reference}").SemiBold(); // Reference
        grid.Item(6);
        grid.Item(12).AlignCenter().Text(""); // spacing
        grid.Item(12).AlignCenter().Text(""); // Title
        grid.Item(12).AlignCenter().Text(""); // Texte body
        
        // Signature 
        grid.Item(6); 
        grid.Item(6)
          .Column(column =>
          {
            column.Item().AlignCenter()
              .Text($"Fait à {CompanyInfoSettings.CityAddress}, le {model.DateOfSignature:d}").SemiBold();
            column.Item().AlignCenter().Text("");
            column.Item().AlignCenter().Text("");
            column.Item().AlignCenter().Text("");
            column.Item().AlignCenter().Text("");
            column.Item().AlignCenter().Text("");
            column.Item().AlignCenter().Text("");
            column.Item().AlignCenter()
              .Text($"{model.ValidatorFullName}").Bold();
            column.Item().AlignCenter()
              .Text($"{model.ValidatorOccupation}");
          });

      });
    //.Text("Content").FontSize(16);
  }
  
  private void ComposeFooter(IContainer container)
  {
    container
      .Column(column =>
      {
        column.Item().AlignCenter()
          .Text(
            $"{CompanyInfoSettings.CompanyAddress} - TEL: {CompanyInfoSettings.PhoneNumber} - FAX: {CompanyInfoSettings.Fax}");
        
        column.Item().AlignCenter()
          .Text(
            $"{CompanyInfoSettings.Email}");
      });
  }
}
