using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace MyTestProject
{
    class ArgumentParser
    {
        //Method which will parse the string input and return a hashtable
        public static CommandLineOptions Parse(String[] args)
        {
            //Hashtable argTable = new Hashtable();
            var options = new CommandLineOptions();

            var normalizedArgs = NormalizeArguments(args);
            foreach (string argument in normalizedArgs)
            {
                string option = argument.Substring(1);
                string optionValue = string.Empty;

                int optoinSeparatorIndex = option.IndexOf(':');
                if (optoinSeparatorIndex > 0)
                {
                    optionValue = option.Substring(optoinSeparatorIndex + 1);
                    option = option.Substring(0, optoinSeparatorIndex);
                }
                switch (option)
                {
                    case "ProjectDir":
                        options.ProjectDir = TrimQuotes(optionValue);
                        break;
                    case "OutputFileName":
                        options.OutputFileName = optionValue;
                        break;
                    case "FileExtensions":
                        options.FileExtensions = optionValue;
                        break;
                    case "Mode":
                        options.Mode = optionValue;
                        break;
                    case "ProjectFile":
                        options.ProjectFile = TrimQuotes(optionValue);
                        break;
					case "GeneratesGroupList":
						options.GeneratesGroupList = true;
						options.ProjectDir = TrimQuotes(optionValue);
						break;
                    case "ValidatesXmlFile":
                        options.ValidatesXmlFile = true;
                        break;
                    case "XmlFilePath":
                        options.XmlFilePath = optionValue;
                        break;
                    case "XmlSchemaFilePath":
                        options.XmlSchemaFilePath = optionValue;
                        break;
                    default:
                        break;
                }
            }

            return options;
        }

        private static IEnumerable<string> NormalizeArguments(string[] args)
        {
            string currentArgument = null;

            foreach (var arg in args)
            {
                if (arg.Trim().StartsWith("/"))
                {
                    if (currentArgument != null)
                    {
                        yield return currentArgument;
                    }
                    currentArgument = arg;
                }
                else
                {
                    currentArgument += " " + arg;
                }
            }

            if (currentArgument != null)
            {
                yield return currentArgument;
            }
        }

        private static string TrimQuotes(string value)
        {
            return value.Trim(new char[] { '"', '\'' });
        }
    }

    public class CommandLineOptions
    {
        public string ProjectDir { get; set; }
        public string OutputFileName { get; set; }
        public string FileExtensions { get; set; }
        public string Mode { get; set; }
		public string ProjectFile { get; set; }
		public bool GeneratesGroupList { get; set; }
        public bool ValidatesXmlFile { get; set; }
        public string XmlFilePath { get; set; }
        public string XmlSchemaFilePath { get; set; }
    }
}