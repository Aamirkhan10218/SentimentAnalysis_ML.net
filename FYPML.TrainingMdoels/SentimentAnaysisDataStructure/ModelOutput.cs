using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYPML.TrainingMdoels.SentimentAnaysisDataStructure
{
    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Score { get; set; }
    }
}
