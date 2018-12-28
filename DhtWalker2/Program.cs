using CLRCLI;
using CLRCLI.Widgets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace DhtWalker2
{
    public class Options
    {
        [Option("no-log", Required = false, HelpText = "Set no logging..")]
        public bool NoLog { get; set; }
        [Option('s', "save-seed", Required = false, HelpText = "Save torrent files..")]
        public bool SaveSeed { get; set; }
        [Option("no-mongo", Required = false, HelpText = "No mongo..")]
        public bool NoMongo { get; set; }
        [Option('c', "console", Required = false, HelpText = "Use console..")]
        public bool Console { get; set; }
        [Option("localip", Required = true, HelpText = "Local IP..")]
        public string LocalIp { get; set; } = "0.0.0.0";
    }

    public class Program
    {
        //public static string LocalIp = "0.0.0.0";
        //public static bool NoLog;
        //public static bool SaveSeed;
        //public static bool NoMongo;
        //public static bool Console;
        public static Options options;
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o => options = o);

            MainUI ui;
            //ResolveArgs(args);
            if (!options.NoLog)
                Trace.Listeners.Add(new TextWriterTraceListener(string.Format("spider.{0}.log", DateTime.Now.ToBinary())));
            if (options.Console)
            {
                ui = new MainConsole();
                Trace.Listeners.Add(new ConsoleTraceListener());
            }
            else
            {
                ui = new MainWindow();
            }
            ui.Run();
        }

        //private static void ResolveArgs(string[] args)
        //{
        //    foreach (var item in args)
        //    {
        //        switch (item)
        //        {
        //            case "nl":
        //            case "no-log":
        //                NoLog = true;
        //                break;
        //            case "s":
        //            case "save-seed":
        //                SaveSeed = true;
        //                break;
        //            case "nm":
        //            case "no-mongo":
        //                NoMongo = true;
        //                break;
        //            case "c":
        //            case "console":
        //                Console = true;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}
