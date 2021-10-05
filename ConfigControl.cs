using System;
using System.Collections.Generic;
using System.IO;

namespace Skyrim_Background_Injector
{
    public class ConfigControl
    {
        public String CurrentPath { get; set; }

        public String ConfigFilePath { get; set; }

        public Dictionary<String, String> ConfigDictionary { get; set; }

        public Boolean IsInitialized { get; set; }

        public Boolean IsConfigChanged { get; set; }

        public void BeginInitialize()
        {
            IsInitialized = false;
        }

        public void EndInitialize()
        {
            IsInitialized = true;
        }

        public void ChangeConfig(String key, String value)
        {
            ConfigDictionary[key] = value;

            IsConfigChanged = true;
        }

        public ConfigControl()
        {
            IsInitialized = false;
            IsConfigChanged = false;

            CurrentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            ConfigFilePath = $@"{CurrentPath}\config.ini";

            ConfigDictionary = new Dictionary<String, String>
            {
                { "InputImageFolder", "" },
                { "OutputDDSFolder", $@"{CurrentPath}\output" },
                { "MaxParallelWorkers", Environment.ProcessorCount.ToString() },
                { "RandomizeInputImages", "true" },
                { "SearchOnSubfolders", "true" }
            };
        }

        public void LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                String configFileContent = File.ReadAllText(ConfigFilePath, System.Text.Encoding.UTF8);
                String[] configFileContentSpl = configFileContent.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (String line in configFileContentSpl)
                {
                    String currentLine = line.TrimEnd("\r\n".ToCharArray());

                    if (currentLine.Length >= 2 && currentLine.Contains("="))
                    {
                        int parameterSeparator = currentLine.IndexOf("=");

                        String parameterName = currentLine.Substring(0, parameterSeparator);
                        String parameterValue = currentLine.Substring(parameterSeparator + 1);

                        if (parameterValue.Length > 0 && ConfigDictionary.ContainsKey(parameterName))
                        {
                            ConfigDictionary[parameterName] = parameterValue;
                        }
                    }
                }
            }
            else
            {
                SaveConfig(true);
            }
        }

        public void SaveConfig(Boolean forceSave = false)
        {
            if (forceSave || IsConfigChanged)
            {
                String outputConfigContent = String.Empty;

                foreach (String key in ConfigDictionary.Keys)
                {
                    outputConfigContent += $"{key}={ConfigDictionary[key]}\r\n";
                }

                outputConfigContent = outputConfigContent.TrimEnd("\r\n".ToCharArray());

                File.WriteAllText(ConfigFilePath, outputConfigContent, System.Text.Encoding.UTF8);
            }
        }
    }
}
