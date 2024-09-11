// MIT License.
// Copyright (c) 2024 Caleb BENGUELET, @Bengbenz
// See more info in [LICENSE] file.

using eEmbassyPdfReportTemplate.DocumentModels;

namespace eEmbassyPdfReportTemplate.DataSource;

public static class CertificatDataSource
{
  public static CertificatModel GetCertificatModel()
  {
    return new CertificatModel
    {
      Id = 3,
      Title = "Certificat de Coutume",
      ValidatorFullName = "Caleb BENGUELET",
      ValidatorOccupation = "Chargé des affaires",
      ReferenceOfLaw = "N°97.013 en ses articles 64, 65 et 69",
      ParentGender = "Monsieur",
      ParentFullName = "KETEGUIA GBABADJA Emery Brell",
      BeneficiaryFullName = "KETEGUIA Waldren Keyden",
      CountryOfSignature = "Paris",
      DateOfSignature = DateTime.Today
    };
  }
}
