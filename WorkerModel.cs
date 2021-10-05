using System;

namespace Skyrim_Background_Injector
{
    public class WorkerModel
    {
        public string InputImagePath { get; set; }
        public string OutputDdsFolder { get; set; }

        public WorkerModel(String inputImagePath, String outputDdsFolder)
        {
            InputImagePath = inputImagePath;
            OutputDdsFolder = outputDdsFolder;
        }
    }
}
