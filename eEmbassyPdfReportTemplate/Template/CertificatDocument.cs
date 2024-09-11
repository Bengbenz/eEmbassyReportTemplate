using eEmbassyPdfReportTemplate.DataSource;
using eEmbassyPdfReportTemplate.DocumentModels;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace eEmbassyPdfReportTemplate.Template;

public sealed class CertificatDocument(CertificatModel model) : IDocument
{
  public void Compose(IDocumentContainer container)
  {
    container
      .Page(page =>
      {
        page.Margin(25);
            
        page.Header().Element(ComposeHeader);
        page.Content().Element(ComposeContent);
        page.Footer().Element(ComposeFooter);
      });
  }
  
  private void ComposeHeader(IContainer container)
  {
    container.Row(row =>
    {
      row.Spacing(25);
      row.ConstantItem(175).Height(150)
        .AlignTop().AlignCenter()
        .Image("img/Logos_Ministeres-AMBASSADE-black_0.png")
        .FitArea();
      
      row.ConstantItem(155).Height(155)
        .AlignTop().AlignCenter()
        .Image("img/Armoiries-RCA_v2.png")
        .FitArea();
      
      row.RelativeItem()
        .Row(rd =>
        {
          rd.RelativeItem().Text("   ");
          rd.ConstantItem(100).Height(100)
            .AlignTop().AlignRight()
            .Image(model.GetQrCode())
            .FitArea();
        });
    });
  }
  
  private void ComposeContent(IContainer container)
  {
    var bodyTextStyle = TextStyle.Default.FontSize(13).FontFamily("Aria");
    container
      .AlignCenter()
      .AlignTop()
      .Layers(layers =>
      {
        layers
          .Layer()
          .AlignCenter()
          .PaddingTop(95)
          .Column(col =>
          {
            col.Spacing(60);
            col.Item().AlignCenter().Width(400)
              .Image("img/carte_vert_points_flou_2.png")
              .FitArea();
          });
          
        
        layers
          .PrimaryLayer()
          .Padding(20)
          .Column(cl =>
          {
            cl.Spacing(40);
            cl.Item()
              .AlignLeft()
              .Text($"N°  {model.Reference}").SemiBold(); // Reference
            
            cl.Spacing(30);
            cl.Item()
              .AlignMiddle()
              .AlignCenter()
              .Text("Certificat du coutume").FontSize(25).ExtraBold().Underline(); // Title
            
            cl.Spacing(40);
            cl.Item()
              .Text($"      Je soussigné, {model.ValidatorFullName}, {model.ValidatorOccupation} auprès de {CompanyInfoSettings.CompanyName} en {CompanyInfoSettings.CountryAddress},")
              .Style(bodyTextStyle); // Texte body
            
            cl.Spacing(3);
            cl.Item()
              .Text($"      Certifie que selon la coutume Centrafricain relayée par le Code de la famille, loi n° {model.ReferenceOfLaw}," +
                    $"le choix du nom est libre et un enfant peut porter un simple ou composé qui peut être celui de son père," +
                    $"de sa mère ou celui choisi par ses parents.")
              .Style(bodyTextStyle); // Texte body

            cl.Spacing(3);
            cl.Item()
              .Text($"      Ainsi donc, le nom choisi par {model.ParentGender} {model.ParentFullName}" +
                    $" pour son enfant est : {model.BeneficiaryFullName}, " +
                    $"et en application de la coutume, est bien valable.")
              .Style(bodyTextStyle);
            
            cl.Spacing(3);
            cl.Item()
              .Text($"      En foi de quoi, le présent {model.Title} est établi et délivré" +
                    $"pour servir et valoir ce que de droit. /-")
              .Style(bodyTextStyle);
              
            cl.Spacing(35);
            // Signature
            cl.Item().AlignBottom().AlignRight()
              .Column(column =>
              {
                column.Item().AlignLeft()
                  .Text($"Fait à {model.CountryOfSignature}, le {model.DateOfSignature:d}").SemiBold();
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
      });
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
