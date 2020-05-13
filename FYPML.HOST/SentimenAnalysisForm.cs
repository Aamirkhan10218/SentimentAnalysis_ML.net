using FYPML.TrainingMdoels;
using FYPML.TrainingMdoels.SentimentAnaysisDataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYPML.HOST
{
    public partial class SentimenAnalysisForm : Form
    {
        public SentimenAnalysisForm()
        {
            InitializeComponent();
        }

        private void btnSMTrainer_Click(object sender, EventArgs e)
        {
            SentitmentAnalysisTrainer.CreateModel();
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            ModelInput modelInput = new ModelInput
            {
                Comment = txtPredText.Text
            };
            var result = UseSentimentModel.Predict(modelInput);
            lblOutput.Text = result.Prediction.ToString();
            lblScore.Text = result.Score.ToString();
        }
    }
}
