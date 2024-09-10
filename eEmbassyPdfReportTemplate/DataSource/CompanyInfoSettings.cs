namespace eEmbassyPdfReportTemplate.DataSource;

public static class CompanyInfoSettings
{
  public static string CompanyName = "Ambassade de Kpetene à Paris";
  public static string StreetAddress = "55 rue de Bégoua";
  public static string ZipCodeAddress = "75056";
  public static string CityAddress = "Paris";
  public static string CountryAddress = "France";
  
  public static string PhoneNumber = "01 26 29 05 56";
  public static string Fax = "01 68 74 40 25";
  public static string Email = "contact@e-embassy.cf";

  public static string CompanyAddress => $"{StreetAddress}, {ZipCodeAddress} {CityAddress}, {CountryAddress}";
}
