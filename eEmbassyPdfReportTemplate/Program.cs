// See https://aka.ms/new-console-template for more information

using eEmbassyPdfReportTemplate.DataSource;
using eEmbassyPdfReportTemplate.Template;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

QuestPDF.Settings.License = LicenseType.Community;

// code in your main method
var document = new CertificatDocument(CertificatDataSource.GetCertificatModel());
  
// instead of the standard way of generating a PDF file
document.GeneratePdf("certificat_flou_2.pdf");
    
// use the following invocation
// document.ShowInPreviewer();
