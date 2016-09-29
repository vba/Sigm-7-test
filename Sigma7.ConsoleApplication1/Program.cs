namespace Sigma7.ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IFeaturesRemover featuresRemover = new FeaturesRemover(featuresPath         : "./features.txt", 
                                                                   featuresToDeletePath : "featuresToDelete.txt", 
                                                                   outputPath           : "./");
            featuresRemover.Remove();
        }
    }
}
