using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYPML.TrainingMdoels.SentimentAnaysisDataStructure
{
  public  class UseSalesForecastingModel
    {
        public static ModelOutput Predict(ModelInput input)
        {

            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            string modelPath = @"C:\Users\Aamir Khan\source\repos\FYPMLTask\FYPML.TrainingMdoels\SentimentAnaysisDataStructure\Model.zip";
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // Use model to make prediction on input data
            ModelOutput result = predEngine.Predict(input);
            return result;
        }
    }
}
