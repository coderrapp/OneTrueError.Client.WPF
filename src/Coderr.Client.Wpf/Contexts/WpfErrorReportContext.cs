﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Coderr.Client.Reporters;

namespace Coderr.Client.Wpf.Contexts
{
    /// <summary>
    ///     Customization for WPF applications
    /// </summary>
    //Created for future use (to not break binary compatibility).
    public class WpfErrorReportContext : ErrorReporterContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WpfErrorReportContext" /> class.
        /// </summary>
        /// <param name="reporter">Class that caught the exception.</param>
        /// <param name="exception">Exception that was thrown.</param>
        /// <param name="application">WPF application object.</param>
        public WpfErrorReportContext(object reporter, Exception exception, Application application) : base(reporter, exception)
        {
            MainWindow = application.MainWindow;
            Windows = application.Windows.Cast<Window>();

            ApplicationProperties = new Dictionary<string, object>();
            foreach (string key in application.Properties)
                ApplicationProperties.Add(key, application.Properties[key]);

            Dispatcher = application.Dispatcher;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WpfErrorReportContext" /> class.
        /// </summary>
        /// <param name="reporter">Class that caught the exception.</param>
        /// <param name="exception">Exception that was thrown.</param>
        protected WpfErrorReportContext(object reporter, Exception exception) : base(reporter, exception)
        {
            MainWindow = Application.Current.MainWindow;
            Windows = Application.Current.Windows.Cast<Window>();

            ApplicationProperties = new Dictionary<string, object>();
            foreach (string key in Application.Current.Properties)
                ApplicationProperties.Add(key, Application.Current.Properties[key]);

            Dispatcher = Application.Current.Dispatcher;
        }

        /// <summary>
        /// WPF dispatcher.
        /// </summary>
        public Dispatcher Dispatcher { get; set; }

        /// <summary>
        /// Properties from the WPF application context.
        /// </summary>
        public IDictionary<string, object> ApplicationProperties { get; set; }

        /// <summary>
        /// Main window in the WPF application.
        /// </summary>
        public Window MainWindow { get; set; }

        /// <summary>
        /// All open windows.
        /// </summary>
        public IEnumerable<Window> Windows { get; set; }
    }
}