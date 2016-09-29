using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Sigma7.ConsoleApplication1
{
    public class FeaturesRemover : IFeaturesRemover
    {
        private const char Comma = ',';
        private readonly string _featuresPath;
        private readonly string _outputPath;
        private readonly Lazy<ISet<string>> _deleteInstructions;

        public FeaturesRemover(string featuresPath, string featuresToDeletePath, string outputPath)
        {
            if (featuresPath == null) throw new ArgumentNullException(nameof(featuresPath));
            if (featuresToDeletePath == null) throw new ArgumentNullException(nameof(featuresToDeletePath));
            if (outputPath == null) throw new ArgumentNullException(nameof(outputPath));
            
            _featuresPath = featuresPath;
            _outputPath = outputPath;
            _deleteInstructions = new Lazy<ISet<string>>(() => ReadDeleteInstruction(featuresToDeletePath), LazyThreadSafetyMode.None);
        }

        private ISet<string> ReadDeleteInstruction(string featuresToDeletePath)
        {
            var result = new HashSet<string>();
            using (var streamReader = new StreamReader(featuresToDeletePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    result.Add(line.Trim());
                }
            }
            return result;
        }

        public void Remove()
        {
            var deleteInstructions = _deleteInstructions.Value;
            var outputFile = $"{Guid.NewGuid()}.txt";

            using (var streamReader = new StreamReader(_featuresPath))
            {
                using (var streamWriter = new StreamWriter($"{_outputPath}\\{outputFile}"))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var udbNumber = (line.Split(Comma).FirstOrDefault() ?? string.Empty).Trim(); // TODO possible to write more efficient split implementation
                        if (deleteInstructions.Contains(udbNumber))
                        {
                            continue;
                        }
                        streamWriter.WriteLine(line);
                    }
                }
            }
        }
    }
}