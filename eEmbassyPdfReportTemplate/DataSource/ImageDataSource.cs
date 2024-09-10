// MIT License.
// Copyright (c) 2024 Caleb BENGUELET, @Bengbenz
// See more info in [LICENSE] file.

using System.Reflection;

namespace eEmbassyPdfReportTemplate.DataSource;

public static class ImageDataSource
{
  public static string GetEmbeddedResourceContent(string resourceName)
  {
    Assembly asm = Assembly.GetExecutingAssembly();
    Stream? stream = asm.GetManifestResourceStream(resourceName);
    StreamReader source = new StreamReader(stream!);
    string fileContent = source.ReadToEnd();
    source.Dispose();
    stream!.Dispose();
    return fileContent;
  }
}
