using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYPML.TrainingMdoels.SalesForecastingDataStructure
{
    public class ModelInput
    {

        [ColumnName("Lable")]
        [LoadColumn(1)]
        public double Amount { get; set; }
        [ColumnName("year")]
        [LoadColumn(0)]
        public string Year { get; set; }
        [ColumnName("month")]
        [LoadColumn(2)]
        public int Month { get; set; }

    }
}
