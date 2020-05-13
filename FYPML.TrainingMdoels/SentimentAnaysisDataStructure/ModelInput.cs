﻿using Microsoft.ML.Data;

namespace FYPML.TrainingMdoels.SentimentAnaysisDataStructure
{
    public class ModelInput
    {
        [ColumnName("Label"), LoadColumn(0)]
        public bool Label { get; set; }


        [ColumnName("rev_id"), LoadColumn(1)]
        public float Rev_id { get; set; }


        [ColumnName("comment"), LoadColumn(2)]
        public string Comment { get; set; }


        [ColumnName("year"), LoadColumn(3)]
        public float Year { get; set; }


        [ColumnName("logged_in"), LoadColumn(4)]
        public string Logged_in { get; set; }


        [ColumnName("ns"), LoadColumn(5)]
        public string Ns { get; set; }


        [ColumnName("sample"), LoadColumn(6)]
        public string Sample { get; set; }


        [ColumnName("split"), LoadColumn(7)]
        public string Split { get; set; }
    }
}
