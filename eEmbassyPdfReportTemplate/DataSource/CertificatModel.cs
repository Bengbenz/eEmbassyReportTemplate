namespace eEmbassyPdfReportTemplate.DataSource;

public sealed class CertificatModel
{
    public int Id { get; set; }

    public string Reference => $"{Id}/AMB/RCA/SC/F";
    
    public string Title { get; set; }
    
    public string ValidatorName { get; set; }
    public string ValidatorOccupation { get; set; }
    public string ReferenceOfLaw { get; set; }
    
    public string ParentGender { get; set; }
    public string ParentFullName { get; set; }
    
    public string BeneficiaryFullName { get; set; }
    
    public string CountryOfSignature { get; set; }
    public DateOnly DateOfSignature { get; set; }
}