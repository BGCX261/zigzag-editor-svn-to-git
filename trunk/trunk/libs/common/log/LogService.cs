// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Globalization;
using System.IO;
using log4net;
using log4net.Config;

namespace Zigzag.Common
{
	public class LogService : IService<LogConfig>
	{
    #region Singleton
    static LogService s_instance = new LogService();
    public static LogService Instance { get { return s_instance; } }
    #endregion

		static ILog log = null;
    static LogConfig config = null;

    public bool InitService(string configFile)
    {
			XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
      log = LogManager.GetLogger(typeof(LogService));
      Info("LogService.InitService");

      config = new LogConfig();
      config.LoadConfig(configFile);

      return true;
    }

    public bool ReleaseService()
    {
      Info("LogService.ReleaseService");
      return true;
    }

    public LogConfig Config 
    {
      get {return config;}
    }
		
		public static void Debug(object message)
		{
			log.Debug(message);
		}
		
		public static void DebugFormatted(string format, params object[] args)
		{
			log.DebugFormat(CultureInfo.InvariantCulture, format, args);
		}
		
		public static void Info(object message)
		{
			log.Info(message);
		}
		
		public static void InfoFormatted(string format, params object[] args)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, format, args);
		}
		
		public static void Warn(object message)
		{
			log.Warn(message);
		}
		
		public static void Warn(object message, Exception exception)
		{
			log.Warn(message, exception);
		}
		
		public static void WarnFormatted(string format, params object[] args)
		{
			log.WarnFormat(CultureInfo.InvariantCulture, format, args);
		}
		
		public static void Error(object message)
		{
			log.Error(message);
		}
		
		public static void Error(object message, Exception exception)
		{
			log.Error(message, exception);
		}
		
		public static void ErrorFormatted(string format, params object[] args)
		{
			log.ErrorFormat(CultureInfo.InvariantCulture, format, args);
		}
		
		public static void Fatal(object message)
		{
			log.Fatal(message);
		}
		
		public static void Fatal(object message, Exception exception)
		{
			log.Fatal(message, exception);
		}
		
		public static void FatalFormatted(string format, params object[] args)
		{
			log.FatalFormat(CultureInfo.InvariantCulture, format, args);
		}
		
		public static bool IsDebugEnabled {
			get {
				return log.IsDebugEnabled;
			}
		}
		
		public static bool IsInfoEnabled {
			get {
				return log.IsInfoEnabled;
			}
		}
		
		public static bool IsWarnEnabled {
			get {
				return log.IsWarnEnabled;
			}
		}
		
		public static bool IsErrorEnabled {
			get {
				return log.IsErrorEnabled;
			}
		}
		
		public static bool IsFatalEnabled {
			get {
				return log.IsFatalEnabled;
			}
		}
	}
}
