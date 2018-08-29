﻿using System;
using Coderr.Client.Contracts;
using Coderr.Client.Wpf.Utils;

namespace Coderr.Client.Wpf
{
    /// <summary>
    /// Interaction logic for ReportDialog.xaml
    /// </summary>
    public partial class ReportDialog
    {
        public string ExceptionMessage { get; set; }

        public ReportDialog(ErrorReportDTO dto, string exceptionMessage)
        {
            ErrorReportDetailsProvider.DtoReport = dto ?? throw new ArgumentNullException(nameof(dto));
            ErrorReportDetailsProvider.ExceptionMessage = exceptionMessage;
            InitializeComponent();
            var height = CalculateFormHeight();
            Height = height;
        }

        private void DialogPresenterFinishedReporting(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private int CalculateFormHeight()
        {
            var height = 0;
            if (Err.Configuration.UserInteraction.AskUserForDetails)
            {
                height += 200;
            }
            if (Err.Configuration.UserInteraction.AskForEmailAddress)
            {
                height += 100;
            }
            height += 100;
            height += 100;
            return height;
        }
    }
}
