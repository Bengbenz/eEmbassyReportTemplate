using QRCoder;

namespace eEmbassyPdfReportTemplate.DocumentModels;

public sealed class CertificatModel
{
    public int Id { get; set; }

    public string Reference => $"{Id:D3}/AMB/RCA/SC/F";
    
    public string Title { get; set; }
    
    public string ValidatorFullName { get; set; }
    public string ValidatorOccupation { get; set; }
    public string ReferenceOfLaw { get; set; }
    
    public string ParentGender { get; set; }
    public string ParentFullName { get; set; }
    
    public string BeneficiaryFullName { get; set; }
    
    public string CountryOfSignature { get; set; }
    public DateTime DateOfSignature { get; set; }

    public byte[] GetQrCode()
    {
      QRCodeGenerator qrGenerator = new QRCodeGenerator();
      QRCodeData qrCodeData = qrGenerator.CreateQrCode(Reference, QRCodeGenerator.ECCLevel.M);
      PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

      byte[] qrCodeImage = qrCode.GetGraphic(50);
      return qrCodeImage;
      // PayloadGenerator.Url generator = new PayloadGenerator.Url("https://github.com/codebude/QRCoder/");
      // string payload = generator.ToString();
      //
      // QRCodeGenerator qrGenerator = new QRCodeGenerator();
      // QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
      // QRCode qrCode = new QRCode(qrCodeData);
      // return qrCode.GetGraphic(30);
    }
}
