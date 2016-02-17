using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using MyTestProject;
using System.Diagnostics;

namespace ProjectFilesListGenerator
{
	class Program
	{
		private const string nmspace = "http://schemas.microsoft.com/developer/msbuild/2003";

		public static List<string> ListOfFiles { get; set; }
		public static string ProjectDir { get; set; }
		public static string OutputFileName { get; set; }
		public static List<string> FileExtensions { get; set; }
		private static Dictionary<string, string> relatedFiles = new Dictionary<string, string>();

        static void Main(string[] args)
        {
			////args = new string[] { "-ProjectDir=C:\\Work\\branches\\2010.Q1\\QSF\\Examples\\DataValidation\\" };
			////args = new string[] { "-Mode=UpdateProjectGUIDs", "-ProjectFile=C:\\Projects\\WPF_SCRUM\\branches\\2010.Q1\\QSF\\Examples.Web\\Examples.Web.VB.csproj" };
			////OutputFileName = "xml.xml";

			////args = new string[] { "/GeneratesGroupList:'C://Work//Development//QSF//ProjectFilesListGenerator'" };

			ListOfFiles = new List<string>();

			var options = ArgumentParser.Parse(args);

			////WriteLog(options.GeneratesGroupList.ToString());

            if (options.GeneratesGroupList)
            {
                try
                {
                    GenerateListOfGroups(options.ProjectDir);
                }
                catch (Exception ex)
                {
                    WriteLog(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                }
            }
            else if (options.ValidatesXmlFile)
            {
                ValidateXmlFile(options.XmlFilePath, options.XmlSchemaFilePath);
            }
            else 
            {
                if (string.IsNullOrEmpty(options.Mode))
                {
                    GenerateList(options);
                }
                else if (options.Mode == "UpdateProjectGUIDs")
                {
                    UpdateProjectGUDs(options.ProjectFile);
                }
            }
        }

        private static void OutputXmlSchemaErrorToErrorList(string errorMessage, string xmlFileName = "Examples.xml", string xmlSchemaFileName = "Examples.xsd")
        {
            int lineNumber = 0;
            string errorCode = "1";
            //Console.WriteLine("{0}({1}): error {2}: {3}", fileName, lineNumber, errorCode, errorMessage);

            // HOW TO:
            // http://stackoverflow.com/questions/781168/can-i-send-error-from-console-application-that-is-called-by-post-build-event-in
            // http://blogs.msdn.com/b/msbuild/archive/2006/11/03/msbuild-visual-studio-aware-error-messages-and-message-formats.aspx

            string msg = string.Format("{0} is not valid for the {1} schema. Make sure you have correctly modified the file. ERROR: {2}", xmlFileName, xmlSchemaFileName, errorMessage);
            Console.WriteLine("Examples.xml({0}): error {1}: {2}", lineNumber, errorCode, msg);
        }

		private static void GenerateListOfGroups(string projectDir)
		{
			var examplesDir = string.Format("{0}\\examples", new DirectoryInfo(projectDir.Replace("'", string.Empty)).Parent.FullName);

			if (Directory.Exists(examplesDir))
			{
				var xbapLoaderProjectPath = string.Format("{0}\\Examples.Xbap\\GroupFileList.xml", new DirectoryInfo(projectDir.Replace("'", string.Empty)).Parent.FullName);
				using (var xmlWriter = XmlWriter.Create(xbapLoaderProjectPath))
				{
					xmlWriter.WriteStartElement("GroupNameList");

					foreach (var exampleName in Directory.GetDirectories(examplesDir))
					{
						var exampleDir = new DirectoryInfo(exampleName);
						var projFile = string.Format("{0}\\{1}.WPF.csproj", exampleName, exampleDir.Name);

						if (File.Exists(projFile))
						{
							using (var fileStream = File.OpenRead(projFile))
							{
								using (var streamReader = new StreamReader(fileStream))
								{
									var projRef = streamReader.ReadToEnd();

									var fileXml = XElement.Load(new StringReader(projRef));
									var allReferences = fileXml.DescendantNodes()
														  .Where(e => (e is XElement) && ((XElement)e).Name.LocalName == "Reference")
														  .Where(e => ((XElement)e).Attribute("Include") != null)
														  .Where(e => ((XElement)e).Attribute("Include").Value.ToLower().Contains("telerik"))
														  .Select(e=>((XElement)e).Attribute("Include").Value.Split(',')[0])
										//.Where(e => ((XElement)e).Attribute("Include").Value.Split(',')[0].ToLower() != "Telerik.Windows.Controls".ToLower())
										//.Where(e => ((XElement)e).Attribute("Include").Value.Split(',')[0].ToLower() != "Telerik.Windows.Controls.Input".ToLower())
														  .ToArray();
									var searchRef = allReferences.Count() + 1;
									CreateXmlElement(xmlWriter, exampleDir.Name, allReferences);
								}
							}
						}
					}
					xmlWriter.WriteEndElement();
				}
			}
		}

		private static void WriteLog(string value)
		{
			var logFile = File.CreateText(@"C:\Work\Development\QSF\QuickStartLoader\tuka.txt");
			logFile.WriteLine(value);
			logFile.Close();
		}

		private static void CreateXmlElement(XmlWriter xmlWriter, string exampleName, string[] assemblyReferences)
		{
			xmlWriter.WriteStartElement("Group");
			xmlWriter.WriteAttributeString("Name", exampleName);
			xmlWriter.WriteString(string.Join(",",assemblyReferences));
			xmlWriter.WriteEndElement();
		}

		private static void UpdateProjectGUDs(string projectFile)
		{
			var documentToEdit = XDocument.Load(projectFile);
			var SilverlightApplicationListElement =
				documentToEdit
					.Element(XName.Get("Project", nmspace))
					.Elements(XName.Get("PropertyGroup", nmspace))
					.Select(
						e =>
							e.Elements(XName.Get("SilverlightApplicationList", nmspace))
							.FirstOrDefault())
					.FirstOrDefault();
			var projects = SilverlightApplicationListElement
				.Value
				.ToString()
				.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
				.Select(p =>
					{
						var project = p.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
						project[0] = ExtractProjectGuid(project[1], projectFile);

						return string.Join("|", project);
					});
			SilverlightApplicationListElement.Value = string.Join(",", projects.ToArray());

			Console.WriteLine("Result: {0}", SilverlightApplicationListElement.Value);

			documentToEdit.Save(projectFile);
		}

		private static string ExtractProjectGuid(string relativePath, string baseProjectPath)
		{
			try
			{
				var projectPath = Path.Combine(Path.GetDirectoryName(baseProjectPath), relativePath);
				Console.WriteLine("Loading {0} to extract is GUID...", projectPath);
				var projectDocument = XDocument.Load(projectPath);
				var node = projectDocument.Element(XName.Get("Project", nmspace))
						.Elements(XName.Get("PropertyGroup", nmspace))
						.Select(
							e =>
								e.Elements(XName.Get("ProjectGuid", nmspace))
								.FirstOrDefault())
						.FirstOrDefault();
				if (node != null)
				{
					Console.WriteLine("Loaded! GUID: {0}.", node.Value.ToString());
					return node.Value.ToString();
				}
			}
			catch { };
			return "";
		}

		private static void GenerateList(CommandLineOptions options)
		{
			if (!string.IsNullOrEmpty(options.ProjectDir))
			{
				ProjectDir = options.ProjectDir;
			}

			if (!string.IsNullOrEmpty(options.FileExtensions))
			{
				FileExtensions = options.FileExtensions.Split(',').ToList();
			}
			else
			{
				FileExtensions = new List<string>() { "xaml", "cs", "fx", "vb" };
			}

			if (!string.IsNullOrEmpty(options.OutputFileName))
			{
				OutputFileName = options.OutputFileName;
			}

			GetFilesRecursive(ProjectDir);

			WriteFilesListToXML();
		}

		private static void WriteFilesListToXML()
		{
			using (var xmlWriter = XmlWriter.Create(string.Concat(ProjectDir, OutputFileName)))
			{
				xmlWriter.WriteStartElement("ProjectFilesPaths");

				foreach (var element in relatedFiles)
				{
					//var file = element.ToString().Replace(ProjectDir, string.Empty);

					//xmlWriter.WriteStartElement("RelativePath");
					//xmlWriter.WriteAttributeString("Key", Directory.GetParent(ProjectDir).Name + "/" + file.Split('\\').FirstOrDefault());
					//xmlWriter.WriteString(file);
					//xmlWriter.WriteEndElement();

					xmlWriter.WriteStartElement("RelativePath");
					xmlWriter.WriteAttributeString("Key", element.Value);
					xmlWriter.WriteString(element.Key);
					xmlWriter.WriteEndElement();
				}
			}
		}

		private static void GetFilesRecursive(string directory)
		{
			var rootDir = new DirectoryInfo(ProjectDir);

			try
			{
				foreach (string d in Directory.GetDirectories(directory))
				{
					if (!CheckForCorrectDir(d)) continue;

					foreach (string f in Directory.GetFiles(d))
					{
						var fileInfo = new FileInfo(f);
						var fileExtensions = fileInfo.Extension.Remove(0, 1);
						if (FileExtensions.Contains(fileExtensions) && !f.Contains(".g."))
						{
							//foreach (var extension in FileExtensions)
							//{
							//C:\Work\branches\2010.Q1\QSF\Examples\TransitionControl\Silverlight\FirstLook\Description.txt
							//if (f.EndsWith(string.Concat(".", extension)) && !f.Contains(".g."))
							//{

							if (!relatedFiles.ContainsKey(fileInfo.Name))
							{
								var dirValue = CreateDirValue(rootDir, fileInfo);

								var fileValue = fileInfo.FullName.Substring(rootDir.FullName.Length);

								relatedFiles.Add(fileValue, dirValue);
							}
							//ListOfFiles.Add(f);
						}
						//break;
						//}
						//}
					}
					GetFilesRecursive(d);
				}
			}
			catch (System.Exception excpt)
			{
				System.Diagnostics.Debug.WriteLine(excpt.Message);
				Console.WriteLine(excpt.Message);
			}
		}

		private static string CreateDirValue(DirectoryInfo rootDir, FileInfo fileInfo)
		{
			string dir = string.Empty;

			var dirInfo = fileInfo.Directory;
			do
			{
				if (string.IsNullOrEmpty(dir))
				{
					dir = dirInfo.Name;
				}
				else
				{
					dir = dirInfo.Name + "/" + dir;
				}
				dirInfo = dirInfo.Parent;
			} while (dirInfo.Name != rootDir.Name);

			return rootDir.Name + "/" + dir;
		}

		private static bool CheckForCorrectDir(string dirPath)
		{
			return !(dirPath.EndsWith("bin", StringComparison.OrdinalIgnoreCase)
						|| dirPath.EndsWith("obj", StringComparison.OrdinalIgnoreCase)
						|| dirPath.EndsWith("Properties", StringComparison.OrdinalIgnoreCase)
					);
		}

        private static void ValidateXmlFile(string xmlFileName, string xmlSchemaFileName)
        {
            XDocument document = XDocument.Load(xmlFileName);
            ExamplesXMLValidator.Validate(document, xmlSchemaFileName, (msg) =>
            {
                OutputXmlSchemaErrorToErrorList(msg, xmlFileName, xmlSchemaFileName);
            });
        }
	}
}
